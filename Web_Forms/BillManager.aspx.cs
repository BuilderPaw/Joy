using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Forms_BillManager : System.Web.UI.Page
{
    decimal cash, eftpos, cheques, points, misc1, misc2, totalAmount;
    decimal sum = 0;
    AlertMessage alert = new AlertMessage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserCredentials.BillManager == 0)
        {
            this.BindGrid();
            UserCredentials.BillManager = 1;
        }
    }

    public void BillTotal()
    {
        // cash
        if (string.IsNullOrWhiteSpace(txtCash.Text))
            cash = 0;
        else
            cash = Decimal.Parse(txtCash.Text);

        // eftpos
        if (string.IsNullOrWhiteSpace(txtEFTPOS.Text))
            eftpos = 0;
        else
            eftpos = Decimal.Parse(txtEFTPOS.Text);

        // cheques
        if (string.IsNullOrWhiteSpace(txtCheques.Text))
            cheques = 0;
        else
            cheques = Decimal.Parse(txtCheques.Text);

        // points
        if (string.IsNullOrWhiteSpace(txtPoints.Text))
            points = 0;
        else
            points = Decimal.Parse(txtPoints.Text);

        // misc1
        if (string.IsNullOrWhiteSpace(txtMiscellaneous1.Text))
            misc1 = 0;
        else
            misc1 = Decimal.Parse(txtMiscellaneous1.Text);

        // misc2
        if (string.IsNullOrWhiteSpace(txtMiscellaneous2.Text))
            misc2 = 0;
        else
            misc2 = Decimal.Parse(txtMiscellaneous2.Text);

        totalAmount = cash + eftpos + cheques + points + misc1 + misc2;
        lblTotalAmount.Text = totalAmount.ToString();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ResetFields();
    }

    protected void ResetFields()
    {
        txtMemberNo.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtBiller.Text = "";
        txtConfirmationId.Text = "";
        txtCash.Text = "";
        txtEFTPOS.Text = "";
        txtCheques.Text = "";
        txtPoints.Text = "";
        txtMiscellaneous1.Text = "";
        txtMiscellaneous2.Text = "";
        BillTotal();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        BillTotal();

        using (DataClassesDataContext dc = new DataClassesDataContext())
        {
            BillPayment bp = new BillPayment();
            // check which site it is coming from
            // get IP Address
            string ipAddress = GetIPAddress();
            //string ipAddress = GetLocalIPAddress();

            // set site venue
            string site = SetVenue(ipAddress);

            if (site.Equals("Check IP Address"))
            {
                alert.DisplayMessage("Check IP Address. Please contact administrator.");
                return;
            }

            bp.Site = site;
            bp.MemberNo = Int32.Parse(txtMemberNo.Text);
            bp.FirstName = txtFirstName.Text;
            bp.LastName = txtLastName.Text;
            bp.Biller = txtBiller.Text;
            bp.ConfirmationId = txtConfirmationId.Text;
            bp.Cash = cash;
            bp.EFTPOS = eftpos;
            bp.Cheques = cheques;
            bp.Points = points;
            bp.Miscellaneous1 = misc1;
            bp.Miscellaneous2 = misc2;
            bp.TotalAmount = totalAmount;
            bp.StaffId = Int32.Parse(UserCredentials.StaffId);
            bp.Username = UserCredentials.Username;
            bp.StaffName = UserCredentials.DisplayName;
            DateTime currentDate = DateTime.Now, tradingDate = DateTime.Now;
            bp.EnteredDate = currentDate;

            if (currentDate.Hour == 0 || currentDate.Hour == 1 || currentDate.Hour == 2 || currentDate.Hour == 3 ||
                currentDate.Hour == 4 || currentDate.Hour == 5 || currentDate.Hour == 6 ||
                currentDate.Hour == 7 || currentDate.Hour == 8)
            {
                tradingDate = DateTime.Now.AddDays(-1);
            }
            bp.TradingDate = tradingDate;
            dc.BillPayments.InsertOnSubmit(bp);
            dc.SubmitChanges();
        }

        this.BindGrid();
        ResetFields();
    }

    public static string GetLocalIPAddress()
    {
        // get Local IP Address
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("IP Address Not Found!");
    }

    protected string GetIPAddress()
    {
        // get User's Network IP Address
        string UserIPAddr = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            UserIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            UserIPAddr = HttpContext.Current.Request.UserHostAddress;
        }
        return UserIPAddr;
        throw new Exception("Local IP Address Not Found!");
    }

    protected string SetVenue(string ipAddress)
    {
        string site = "Check IP Address";
        int i = 0;

        // Split IP Address string with '.' and set the Venue /*GODisGood*/
        string[] subnet = ipAddress.Split('.');
        foreach (string net in subnet)
        {
            i++;
            // get the 3rd octet of the ip address
            if (i == 3)
            {
                if (net == "1")
                {
                    site = "Merrylands RSL";
                }
                else if (net == "5")
                {
                    site = "Club Umina";
                }
            }
        }
        return site;
    }

    protected void txtMemberNo_TextChanged(object sender, EventArgs e)
    {
        string cmdQuery = SearchMember(txtMemberNo.Text);
        ReadFields(cmdQuery, "SearchMember");
    }

    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdvantageDb"].ConnectionString);
    protected void ReadFields(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand(sqlCommand, conn);

        cmd = new SqlCommand(sqlCommand, conn);

        try
        {
            conn.Open();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    txtFirstName.Text = rdr["FirstName"].ToString();
                    txtLastName.Text = rdr["LastName"].ToString();
                }
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error: ReadFields method under BillManager class: " + ex.Message);
        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }
    }

    protected string SearchMember(string MemberNo)
    {
        string query = "SELECT p.PlayerId, CONVERT(INT, pmn.MembershipNumber) MemberNo, p.FirstName, p.MiddleName, p.LastName, " +
                       "CASE WHEN EXISTS(SELECT pp.Phone FROM PlayerPhone pp, PlayerMembershipNumber pmn WHERE pp.PlayerId = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pp.Phone IS NOT NULL) " +
                            "THEN(SELECT pp.Phone FROM PlayerPhone pp, PlayerMembershipNumber pmn WHERE pp.PlayerId = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pp.Preferred = 'Y') " +
                            "ELSE '' END AS Contact, CONVERT(VARCHAR, pm.DateNominated, 103) AS MemberSince, CONVERT(VARCHAR, p.Birthday, 103) as Birthday, pa.Line1 + ', ' + " +
                       "CASE WHEN EXISTS(SELECT pa.Line2 FROM PlayerAddress pa, PlayerMembershipNumber pmn WHERE pa.PlayerId = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pa.Line2 IS NOT NULL) " +
                            "THEN(SELECT pa.Line2 + ', ' FROM PlayerAddress pa, PlayerMembershipNumber pmn WHERE pa.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "') " +
                            "ELSE '' END + pa.City + ' ' + pa.ZipCode + ' ' + pa.State AS Address, p.Gender, " +
                       "CASE WHEN EXISTS(SELECT pim.PlayerImage FROM PlayerImage pim, PlayerMembershipNumber pmn WHERE pim.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "') " +
                            "THEN(SELECT pim.PlayerImage FROM PlayerImage pim, PlayerMembershipNumber pmn WHERE pim.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pim.Date = (SELECT MAX(pim.Date) FROM PlayerImage pim, PlayerMembershipNumber pmn WHERE pim.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "')) " +
                            "ELSE NULL " +
                       "END AS PlayerImage " +
                       "FROM Player p, PlayerMembershipNumber pmn, PlayerAddress pa, PlayerMembership pm " +
                       "WHERE p.PlayerId = pmn.PlayerID AND p.PlayerId = pa.PlayerId AND p.PlayerId = pm.PlayerID AND pmn.MembershipNumber NOT LIKE '%V%' AND pmn.MembershipNumber NOT LIKE '%P%' " +
                       "AND pmn.MembershipNumber NOT LIKE '%A%' AND pmn.MembershipNumber NOT LIKE '%M%' AND pmn.MembershipNumber NOT LIKE '%S%' AND pmn.MembershipNumber = '" + MemberNo + "' " +
                       "AND pa.TypeID = 1 " +
                       "ORDER BY CONVERT(INT, pmn.MembershipNumber)";
        return query;
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        UserCredentials.BillManagerFiltered = true;

        this.BindGrid();
        btnPrint.Visible = true;
    }

    private void BindGrid()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
        string queryDefault = "SELECT * FROM [BillPayment] ORDER BY [BillPaymentId] DESC", query = "", queryFiltered = "";

        try
        {
            queryFiltered = "SELECT * FROM [BillPayment] WHERE TradingDate BETWEEN '" + DateTime.Parse(txtStartDate.Text).ToString("yyyy-MM-dd") + "' AND '" + DateTime.Parse(txtEndDate.Text).ToString("yyyy-MM-dd") + "' AND Site='" + ddlSite.SelectedValue + "' ORDER BY [BillPaymentId] DESC";
        }
        catch
        {
            queryFiltered = "";
        }

        if (UserCredentials.BillManagerFiltered)
        {
            query = queryFiltered;
        }
        else
        {
            query = queryDefault;
        }

        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvBillPayment.DataSource = dt;
                        gvBillPayment.DataBind();
                    }
                }
            }
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvBillPayment.AllowPaging = false;
            this.BindGrid();

            gvBillPayment.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvBillPayment.HeaderRow.Cells)
            {
                cell.BackColor = gvBillPayment.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvBillPayment.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvBillPayment.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvBillPayment.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvBillPayment.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        btnPrint.Visible = false;
        UserCredentials.BillManagerFiltered = false;
        this.BindGrid();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void gvBillPayment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string amount = ((Label)e.Row.FindControl("lblTotalAmount")).Text;
            decimal totalvalue;
            bool convt = decimal.TryParse(amount, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out totalvalue);
            if (convt)
            {
                sum += totalvalue;
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotal");
            lbl.Text = String.Format("{0:C}", sum);
        }
    }

    protected void gvBillPayment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (!UserCredentials.Groups.Contains("ReceptionSupervisor"))
        {
            // hide delete column
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }
        }
    }

    protected void gvBillPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBillPayment.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void gvBillPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int billPaymentId = int.Parse(gvBillPayment.DataKeys[e.RowIndex].Value.ToString());
        string query = "DELETE FROM [BillPayment] WHERE [BillPaymentId] = " + billPaymentId;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            con.Open();
            SqlCommand sqlcom = new SqlCommand(query, con);
            try
            {
                sqlcom.ExecuteNonQuery();
            }
            catch
            {

            }
            con.Close();
        }
        this.BindGrid();
    }
}