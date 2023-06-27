using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Gaming_Services_Create_v1_v1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStaffName.Text = Session["DisplayName"].ToString();

            // check the current time then set appropriate date
            TimeSpan start = new TimeSpan(0, 0, 0); // 12am
            TimeSpan end = new TimeSpan(6, 0, 0);     // 6am
            TimeSpan now = DateTime.Now.TimeOfDay;  // current time
            DateTime dateTime;
            if ((now > start) && (now < end))
            {
                // current time is between 12am to 6am
                dateTime = DateTime.Now.Date.AddDays(-1);
            }
            else
            {
                // current time is greater than 6am
                dateTime = DateTime.Now.Date;
            }
            // display appropriate trading date
            txtDatePicker.Text = dateTime.ToString("dddd, dd MMMM yyyy");

            string hm = "Total patron check Ins completed: <br /><br />3 hour checks: <br />Potential Gambling Harm: <br />Other: <br />Patrons referred to Duty Manager: <br />Comments: ";
            txtHarmMinimisation.Text = hm.ToString().Replace("<br />", "\n");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SearchReport.CreateReportReset(); // takes off the selected report in ddlCreateReport

        // get the last Report ID
        string query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_MerrylandsRSLGamingServices";
        int lastRId, result, returnFlag = 2;
        DateTime temp, date = DateTime.Parse(DateTime.Now.ToShortDateString());
        Report.ErrorMessage = "";

        con.Open();
        SqlCommand getRId = new SqlCommand(query, con);
        try
        {
            lastRId = (int)getRId.ExecuteScalar();
            // add plus one to the current report id to be used in this report
            lastRId += 1;
        }
        catch
        {
            lastRId = 14000001;
        }
        con.Close();

        Report.LastReportId = lastRId.ToString();

        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            returnFlag = 1;
        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            returnFlag = 1;
        }
        else if (DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                returnFlag = 1;
            }
        }

        if (returnFlag == 1)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"" + Report.ErrorMessage + "\");", true);
            return;
        }

        // change the format of the shift date to timestamp format
        DateTime shift_date = DateTime.Parse(txtDatePicker.Text);
        string shift_tDate = shift_date.ToString("yyyyMMdd");

        // separate the shift date day of week value
        string shift_DOW = shift_date.DayOfWeek.ToString();

        // change the format of the entry date to timestamp format
        DateTime entry_date = DateTime.Now;

        // pop a message if shift is unchanged
        if (ddlShift.SelectedItem.Value == "-1")
        {
            showAlert("Please select Shift.");
            ddlShift.Focus();
            return;
        }

        // get staff's id
        string cmdText = "SELECT StaffId FROM Staff WHERE Username = '" + Session["Username"] + "'",
               variable = "getStaff";
        readFiles(cmdText, variable);

        // insert data to table
        using (DataClassesDataContext dc = new DataClassesDataContext())
        {
            Report_MerrylandsRSLGamingService dm = new Report_MerrylandsRSLGamingService();
            dm.ReportId = Int32.Parse(Report.LastReportId);
            dm.RCatId = 14; // Gaming Services Category
            dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
            dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
            dm.StaffName = UserCredentials.DisplayName;
            dm.ShiftDate = shift_date.Date;
            dm.ShiftDOW = shift_DOW;
            dm.EntryDate = entry_date;
            dm.Report_Table = "Report_MerrylandsRSLGamingServices";
            dm.AuditVersion = 1;
            dm.ReportStat = "Awaiting Completion";
            dm.Report_Version = 1; // current version
            dm.ReadByList = "," + UserCredentials.StaffId + ",";
            dm.HarmMinimisation = txtHarmMinimisation.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.PromotionalAwareness = txtPromotionalAwareness.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.SipAndChill = txtSipAndChill.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.CustomerFeedback = txtCustomerFeedback.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.CustomerComplaints = txtCustomerComplaints.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.Maintenance = txtMaintenance.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.Incidents = txtIncidents.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.GeneralComments = txtGeneralComments.Text.Replace("\n", "<br />").Replace("'", "^");
            dc.Report_MerrylandsRSLGamingServices.InsertOnSubmit(dm);
            dc.SubmitChanges();
        }

        //log the create activity
        RunStoredProcedure rsp = new RunStoredProcedure();
        try
        {
            rsp.Log(4, Int32.Parse(Report.LastReportId));
        }
        catch { }

        //showAlert("Report Submitted.");
        //Response.Redirect("Default.aspx", false);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        "alert('Report Submitted.'); window.location='" +
        Request.ApplicationPath + "Default.aspx';", true);
        SearchReport.SetAccordion = "1";
        SearchReport.RunOnStart = true;
        SearchReport.FromCreateReport = true;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtHarmMinimisation.Text = "";
        txtPromotionalAwareness.Text = "";
        txtSipAndChill.Text = "";
        txtCustomerFeedback.Text = "";
        txtCustomerComplaints.Text = "";
        txtMaintenance.Text = "";
        txtIncidents.Text = "";
        txtGeneralComments.Text = "";
    }

    protected void readFiles(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand(sqlCommand, con);

        try
        {
            con.Open();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (method.Equals("getStaff"))
                    {
                        Session["currentStaffId"] = rdr["StaffId"].ToString();
                    }
                }
            }
        }
        catch (Exception er)
        {
            showAlert(er.Message);
        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }
            if (con != null)
            {
                con.Close();
            }
        }
    }

    protected void showAlert(string message)
    {
        // display a message box
        message = "alert(\"" + message + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", message, true);
    }
}