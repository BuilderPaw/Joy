using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Gaming_Services_Edit_v1_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        readFiles(Report.ActiveReport, "getFields");
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
                    if (method.Equals("getFields"))
                    {
                        lblReportName.Text = rdr["ReportName"].ToString();
                        lblReportId.Text = rdr["ReportId"].ToString();
                        lblStaffName.Text = rdr["StaffName"].ToString();
                        Report.SelectedStaffId = rdr["StaffId"].ToString();
                        ddlShift.SelectedIndex = Int32.Parse(rdr["ShiftId"].ToString());
                        Report.ShiftId = ddlShift.SelectedIndex.ToString();
                        txtDatePicker.Text = Convert.ToDateTime(rdr["ShiftDate"]).ToString("dddd, dd MMMM yyyy");
                        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
                        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
                        lblEntryDetails.Text = Convert.ToDateTime(rdr["EntryDate"]).ToString("dd/MM/yyyy HH:mm");
                        Report.EntryDate = Convert.ToDateTime(rdr["EntryDate"]).ToString();
                        txtHarmMinimisation.Text = rdr["HarmMinimisation"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtPromotionalAwareness.Text = rdr["PromotionalAwareness"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtSipAndChill.Text = rdr["SipAndChill"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCustomerFeedback.Text = rdr["CustomerFeedback"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCustomerComplaints.Text = rdr["CustomerComplaints"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtMaintenance.Text = rdr["Maintenance"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtIncidents.Text = rdr["Incidents"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtGeneralComments.Text = rdr["GeneralComments"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        // set the Global variables to the current fields
                        SetStaticVariable();
                        Report.RunEditMode = true;
                    }
                    if (method.Equals("checkChanges"))
                    {
                        int flag = 0;
                        if (Report.ShiftId != rdr["ShiftId"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ShiftId";
                        }
                        if (Report.ShiftDate.ToString() != rdr["ShiftDate"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ShiftDate";
                        }
                        if (ReportGamingServicesMr.HarmMinimisation != rdr["HarmMinimisation"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "HarmMinimisation";
                        }
                        if (ReportGamingServicesMr.PromotionalAwareness != rdr["PromotionalAwareness"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PromotionalAwareness";
                        }
                        if (ReportGamingServicesMr.SipAndChill != rdr["SipAndChill"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SipAndChill";
                        }
                        if (ReportGamingServicesMr.CustomerFeedback != rdr["CustomerFeedback"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CustomerFeedback";
                        }
                        if (ReportGamingServicesMr.CustomerComplaints != rdr["CustomerComplaints"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CustomerComplaints";
                        }
                        if (ReportGamingServicesMr.Maintenance != rdr["Maintenance"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Maintenance";
                        }
                        if (ReportGamingServicesMr.Incidents != rdr["Incidents"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Incidents";
                        }
                        if (ReportGamingServicesMr.GeneralComments != rdr["GeneralComments"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "GeneralComments";
                        }
                        if (flag == 0)
                        {
                            Report.HasChange = false;
                            Report.WhereChangeHappened = "";
                        }
                        return;
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

    protected void TextChanged_TextChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void getChanges()
    {
        int result;
        DateTime temp;
        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        Report.ErrorMessage = "";
        Report.HasErrorMessage = false;
        Report.HasErrorMessage1 = false;

        // General Incident Report Form
        if (ddlShift.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";
            ddlShift.Focus();
            Report.HasErrorMessage1 = true;
        }

        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            Report.HasErrorMessage1 = true;
        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            Report.HasErrorMessage1 = true;
        }
        else
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                Report.HasErrorMessage1 = true;
            }
        }

        Report.RunEditMode = true;
        Report.ShiftId = ddlShift.SelectedItem.Value;
        if (Report.HasErrorMessage1.Equals(false))
        {
            Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
            Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
        }
        SetStaticVariable();
        readFiles(Report.ActiveReport, "checkChanges");
    }

    protected void SetStaticVariable()
    {
        ReportGamingServicesMr.HarmMinimisation = txtHarmMinimisation.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportGamingServicesMr.PromotionalAwareness = txtPromotionalAwareness.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportGamingServicesMr.SipAndChill = txtSipAndChill.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportGamingServicesMr.CustomerFeedback = txtCustomerFeedback.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportGamingServicesMr.CustomerComplaints = txtCustomerComplaints.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportGamingServicesMr.Maintenance = txtMaintenance.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportGamingServicesMr.Incidents = txtIncidents.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportGamingServicesMr.GeneralComments = txtGeneralComments.Text.Replace("\n", "<br />").Replace("'", "^");
    }
}