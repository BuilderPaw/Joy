using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Configuration;

public partial class Web_Forms_LogViewer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    //string ipAddress;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(SqlQuery.LogViewerLoad == 0)
            {

                string strConnString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString,
                    defaultquery = "SELECT TOP (25) * FROM [View_Log] order by datestamp desc";

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand(defaultquery))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandTimeout = 300;

                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                gvLogViewer.DataSource = dt;
                                gvLogViewer.DataBind();
                            }
                        }
                    }
                }

                SqlQuery.LogViewerLoad = 1;
            }

            // load appropriate image
            // get IP Address
            //ipAddress = GetUser_IP();
            // set Venue
            //setVenue(ipAddress);

            // REPORTS AND SEARCH PANES - Drop Down List - set the list of values shown in the dropdown list
            // use a global variable to check whether groups array is not empty
            if (!string.IsNullOrWhiteSpace(UserCredentials.Groups))
            {
                string groups = UserCredentials.Groups;
                bool contains = groups.Contains("MRReportsSeniorManagers"); // MRReportsAdmin should be part of group MRReportsSeniorManagers
                string[] array_groups = groups.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                int j = 0;
                int[] int_groups = new int[12];

                if (!contains)
                {
                    for (int i = 0; i < array_groups.Length; i++)
                    {
                        if (array_groups[i].ToString().Equals("MRReportsDutyManagers"))
                        {
                            int_groups[j] = 1; // assign this number in the array and increment variable 'j' to add the next value
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsSupervisors"))
                        {
                            int_groups[j] = 2;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsFunctionSupervisor"))
                        {
                            int_groups[j] = 3;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsReceptionSupervisor"))
                        {
                            int_groups[j] = 4;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsReception"))
                        {
                            int_groups[j] = 5;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("CUReportsDutyManagers"))
                        {
                            int_groups[j] = 6;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("CUReportsReception"))
                        {
                            int_groups[j] = 7;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsCustomerRelationsOfficer"))
                        {
                            int_groups[j] = 8;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsCaretaker"))
                        {
                            int_groups[j] = 9;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsGamingServices"))
                        {
                            int_groups[j] = 10;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsResponsibleGamingOfficer"))
                        {
                            int_groups[j] = 11;
                            j++;
                        }
                    }

                    // use Array.Sort to display the Report Types accordingly
                    Array.Sort(int_groups);
                    for (int i = 0; i < int_groups.Length; i++)
                    {
                        // display the reports in proper order, All MR Reports at the top followed by CU Reports
                        if (int_groups[i] == 1)
                        {
                            ddlReport.Items.Add(new ListItem("MR Incident Report", "Report_MerrylandsRSLIncident"));
                            ddlReport.Items.Add(new ListItem("MR Duty Managers", "Report_MerrylandsRSLDutyManager"));
                            //ddlReport.Items.Add(new ListItem("MR Covid Marshall", "Report_MerrylandsRSLCovidMarshall"));
                        }
                        else if (int_groups[i] == 2)
                        {
                            ddlReport.Items.Add(new ListItem("MR Supervisors", "Report_MerrylandsRSLSupervisor"));
                        }
                        else if (int_groups[i] == 3)
                        {
                            ddlReport.Items.Add(new ListItem("MR Function Supervisor", "Report_MerrylandsRSLFunctionSupervisor"));
                        }
                        else if (int_groups[i] == 4)
                        {
                            ddlReport.Items.Add(new ListItem("MR Reception Supervisor", "Report_MerrylandsRSLReceptionSupervisor"));
                        }
                        else if (int_groups[i] == 5)
                        {
                            ddlReport.Items.Add(new ListItem("MR Reception", "Report_MerrylandsRSLReception"));
                        }
                        else if (int_groups[i] == 6)
                        {
                            ddlReport.Items.Add(new ListItem("CU Incident Report", "Report_ClubUminaIncident"));
                            ddlReport.Items.Add(new ListItem("CU Duty Managers", "Report_ClubUminaDutyManager"));
                            //ddlReport.Items.Add(new ListItem("CU Covid Marshall", "Report_ClubUminaCovidMarshall"));
                        }
                        else if (int_groups[i] == 7)
                        {
                            ddlReport.Items.Add(new ListItem("CU Reception", "Report_ClubUminaReception"));
                        }
                        else if (int_groups[i] == 8)
                        {
                            ddlReport.Items.Add(new ListItem("MR Customer Relations Officer", "Report_MerrylandsRSLCustomerRelationsOfficer"));
                        }
                        else if (int_groups[i] == 9)
                        {
                            ddlReport.Items.Add(new ListItem("MR Caretaker", "Report_MerrylandsRSLCaretaker"));
                        }
                        else if (int_groups[i] == 10)
                        {
                            ddlReport.Items.Add(new ListItem("MR Gaming Services", "Report_MerrylandsRSLGamingServices"));
                        }
                        else if (int_groups[i] == 11)
                        {
                            ddlReport.Items.Add(new ListItem("MR Responsible Gaming Officer", "Report_MerrylandsRSLResponsibleGamingOfficer"));
                        }
                    }
                }
                else // if the user is a member of Senior Managers
                {
                    // add all reports
                    // MR Duty Manager & Incident Report
                    ddlReport.Items.Add(new ListItem("MR Incident Report", "Report_MerrylandsRSLIncident"));
                    // CU Incident Report
                    ddlReport.Items.Add(new ListItem("CU Incident Report", "Report_ClubUminaIncident"));
                    ddlReport.Items.Add(new ListItem("MR Duty Managers", "Report_MerrylandsRSLDutyManager"));
                    //ddlReport.Items.Add(new ListItem("MR Covid Marshall", "Report_MerrylandsRSLCovidMarshall"));
                    // MR Supervisor
                    ddlReport.Items.Add(new ListItem("MR Supervisors", "Report_MerrylandsRSLSupervisor"));
                    // MR Function Supervisor
                    ddlReport.Items.Add(new ListItem("MR Function Supervisor", "Report_MerrylandsRSLFunctionSupervisor"));
                    // MR Reception Supervisor
                    ddlReport.Items.Add(new ListItem("MR Reception Supervisor", "Report_MerrylandsRSLReceptionSupervisor"));
                    // MR Reception
                    ddlReport.Items.Add(new ListItem("MR Reception", "Report_MerrylandsRSLReception"));
                    // CU Duty Manager
                    ddlReport.Items.Add(new ListItem("CU Duty Managers", "Report_ClubUminaDutyManager"));
                    //ddlReport.Items.Add(new ListItem("CU Covid Marshall", "Report_ClubUminaCovidMarshall"));
                    // CU Reception
                    ddlReport.Items.Add(new ListItem("CU Reception", "Report_ClubUminaReception"));
                    // MR Customer Relations Officer
                    ddlReport.Items.Add(new ListItem("MR Customer Relations Officer", "Report_MerrylandsRSLCustomerRelationsOfficer"));
                    // MR Caretaker
                    ddlReport.Items.Add(new ListItem("MR Caretaker", "Report_MerrylandsRSLCaretaker"));
                    // MR Gaming Services
                    ddlReport.Items.Add(new ListItem("MR Gaming Services", "Report_MerrylandsRSLGamingServices"));
                    // MR Responsible Gaming Officer
                    ddlReport.Items.Add(new ListItem("MR Responsible Gaming Officer", "Report_MerrylandsRSLResponsibleGamingOfficer"));
                }

                // populate the all staff dropdownlist
                PopulateAllStaffList();

                // populate the log type dropdownlist
                PopulateLogType();

                // set datetime to today's date
                txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtEndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
    }

    protected string GetUser_IP()
    {
        // get User's Network IP Address
        string VisitorsIPAddr = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
        }
        return VisitorsIPAddr;
        throw new Exception("Local IP Address Not Found!");
    }

    protected void setVenue(string ipAddress)
    {
        int i = 0;

        // Split IP Address string with '.' and set the Venue /*GODisGood*/
        string[] subnet = ipAddress.Split('.');
        foreach (string net in subnet)
        {
            i++;
            if (i == 3)
            {
                if (net == "1")
                {
                    ImageButton1.Src = "~/Images/logo-MRSL.png";
                }
                else if (net == "5")
                {
                    ImageButton1.Src = "~/Images/logo-CU.png";
                }
            }
        }
        if (i < 3) // if there is no proper IP Address found, close the program
        {
            showAlert("Error Found! Please contact administrator.");
        }
    }
    protected void gvLogViewer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLogViewer.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ValidateHour();

        string selectquery = LogQuery();
    }

    protected void ValidateHour()
    {
        if (ddlStartTimeHour.SelectedItem.Value.ToString() == "-1")
        {
            ddlStartTimeHour.Focus();
            showAlert("Please select start time (Hour)");
            return;
        }
        if (ddlStartTimeMinute.SelectedItem.Value.ToString() == "-1")
        {
            ddlStartTimeMinute.Focus();
            showAlert("Please select end time (Minute)");
            return;
        }
        if (ddlEndTimeHour.SelectedItem.Value.ToString() == "-1")
        {
            ddlEndTimeHour.Focus();
            showAlert("Please select end time (Hour)");
            return;
        }
        if (ddlEndTimeMinute.SelectedItem.Value.ToString() == "-1")
        {
            ddlEndTimeMinute.Focus();
            showAlert("Please select end time (Minute)");
            return;
        }
    }

    protected string LogQuery()
    {
        string startquery = "SELECT * FROM [View_Log] WHERE ", endquery = " ORDER BY DateStamp Desc",
               name = "", logtype = "", reportid = "", report = "", reportauthor = "", selectquery = "",
               datestamp = "DateStamp BETWEEN '" + DateTime.Parse(txtStartDate.Text).ToString("yyyy-MM-dd") + " " + ddlStartTimeHour.SelectedItem.Text + ":" + ddlStartTimeMinute.SelectedItem.Text +
               "' AND '" + DateTime.Parse(txtEndDate.Text).ToString("yyyy-MM-dd") + " " + ddlEndTimeHour.SelectedItem.Text + ":" + ddlEndTimeMinute.SelectedItem.Text + "'";

        if (ddlStaffName.SelectedItem.Text != "All")
        {
            name = " AND Name = '" + ddlStaffName.SelectedItem.Text + "'";
        }

        if (ddlLogType.SelectedItem.Text != "All")
        {
            logtype = " AND LogType = '" + ddlLogType.SelectedItem.Text + "'";
        }

        if (!string.IsNullOrEmpty(txtReportId.Text))
        {
            reportid = " AND ReportID = '" + txtReportId.Text + "'";
        }

        if (ddlReport.SelectedItem.Text != "All")
        {
            report = " AND Report = '" + ddlReport.SelectedItem.Text + "'";
        }

        if (ddlLogType.SelectedItem.Text == "Login")
        {
            report = "";
        }

        if (ddlReportAuthor.SelectedItem.Text != "All")
        {
            reportauthor = " AND ReportAuthor = '" + ddlReportAuthor.SelectedItem.Text + "'";
        }

        selectquery = startquery + datestamp + name + logtype + reportid + report + reportauthor + endquery;

        // display Action required if not empty
        con.Open();
        SqlCommand checkExist = new SqlCommand(selectquery, con);
        try
        {
            int ReportExist = (int)checkExist.ExecuteScalar();
            if (ReportExist > 0)
            {
                gvLogViewer.Visible = true;
            }
            else
            {
                //showAlert("No Reports to Display. Please Check the Report ID.");
            }
        }
        catch
        {
            //showAlert("No Reports to Display. Please Check the Report ID.");
        }
        con.Close();

        string strConnString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand(selectquery))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 300;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvLogViewer.DataSource = dt;
                        gvLogViewer.DataBind();
                    }
                }
            }
        }

        // for paging and sorting
        Session["displaySearch"] = selectquery;

        return selectquery;
    }

    protected void BindGrid()
    {
        string startquery = "SELECT * FROM [View_Log] WHERE ", endquery = " ORDER BY DateStamp Desc",
               name = "", logtype = "", reportid = "", report = "", reportauthor = "", selectquery = "",
               datestamp = "DateStamp BETWEEN '" + DateTime.Parse(txtStartDate.Text).ToString("yyyy-MM-dd") + " " + ddlStartTimeHour.SelectedItem.Text + ":" + ddlStartTimeMinute.SelectedItem.Text +
               "' AND '" + DateTime.Parse(txtEndDate.Text).ToString("yyyy-MM-dd") + " " + ddlEndTimeHour.SelectedItem.Text + ":" + ddlEndTimeMinute.SelectedItem.Text + "'";

        if (ddlStaffName.SelectedItem.Text != "All")
        {
            name = " AND Name = '" + ddlStaffName.SelectedItem.Text + "'";
        }

        if (ddlLogType.SelectedItem.Text != "All")
        {
            logtype = " AND LogType = '" + ddlLogType.SelectedItem.Text + "'";
        }

        if (!string.IsNullOrEmpty(txtReportId.Text))
        {
            reportid = " AND ReportID = '" + txtReportId.Text + "'";
        }

        if (ddlReport.SelectedItem.Text != "All")
        {
            report = " AND Report = '" + ddlReport.SelectedItem.Text + "'";
        }

        if (ddlLogType.SelectedItem.Text == "Login")
        {
            report = "";
        }

        if (ddlReportAuthor.SelectedItem.Text != "All")
        {
            reportauthor = " AND ReportAuthor = '" + ddlReportAuthor.SelectedItem.Text + "'";
        }

        selectquery = startquery + datestamp + name + logtype + reportid + report + reportauthor + endquery;

        string strConnString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand(selectquery))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 300;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvLogViewer.DataSource = dt;
                        gvLogViewer.DataBind();
                    }
                }
            }
        }
    }

    protected void PopulateLogType()
    {
        ddlLogType.Items.Clear();
        using (SqlCommand cmd = new SqlCommand("Proc_LogType"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            con.Open();
            ddlLogType.DataSource = cmd.ExecuteReader();
            ddlLogType.DataTextField = "Description";
            ddlLogType.DataValueField = "LogTypeID";
            ddlLogType.DataBind();
            con.Close();
        }
        // add an "All" selection in the beginning of the list
        ddlLogType.Items.Insert(0, new ListItem("All", ""));
    }

    protected void PopulateAllStaffList()
    {
        ddlStaffName.Items.Clear();
        using (SqlCommand cmd = new SqlCommand("Proc_PopulateAllStaffList"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            con.Open();
            ddlStaffName.DataSource = cmd.ExecuteReader();
            ddlStaffName.DataTextField = "StaffName";
            ddlStaffName.DataValueField = "StaffId";
            ddlStaffName.DataBind();
            con.Close();
        }
        // add an "All" selection in the beginning of the list
        ddlStaffName.Items.Insert(0, new ListItem("All", ""));

        ddlReportAuthor.Items.Clear();
        using (SqlCommand cmd = new SqlCommand("Proc_PopulateAllStaffList"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            con.Open();
            ddlReportAuthor.DataSource = cmd.ExecuteReader();
            ddlReportAuthor.DataTextField = "StaffName";
            ddlReportAuthor.DataValueField = "StaffId";
            ddlReportAuthor.DataBind();
            con.Close();
        }
        // add an "All" selection in the beginning of the list
        ddlReportAuthor.Items.Insert(0, new ListItem("All", ""));
    }

    // display a message box
    protected void showAlert(string message)
    {
        message = "alert(\"" + message + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", message, true);
    }

    protected void ddlLogType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlLogType.SelectedItem.Text == "Login")
        {
            ddlReport.SelectedIndex = -1;
            ddlReport.Enabled = false;
        }
        else
        {
            ddlReport.Enabled = true;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ValidateHour();

        LogQuery();

        if (gvLogViewer.Rows.Count != 0) // if has list has records
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
                gvLogViewer.AllowPaging = false;
                this.BindGrid();

                gvLogViewer.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvLogViewer.HeaderRow.Cells)
                {
                    cell.BackColor = gvLogViewer.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvLogViewer.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvLogViewer.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvLogViewer.RowStyle.BackColor;
                        }

                        cell.CssClass = "textmode";
                    }
                }

                gvLogViewer.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { }</style>";

                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        else
        {
            showAlert("Please change the date range filter");
        }
        gvLogViewer.AllowPaging = true;
        this.BindGrid();
    }
}