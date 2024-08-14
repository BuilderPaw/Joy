using System;
using System.Data.SqlClient; // SQL Connection
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_CU_Responsible_Gaming_Officer_Create_v1_v1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdvantageDb"].ConnectionString);
    byte[] memberPhoto = null;
    AlertMessage alert = new AlertMessage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // add the check box items for Location List
            List_Location.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["LocationID"].ToString();
                        List_Location.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for RGO Notified List
            List_RGONotified.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_RGONotified] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["RGONotifiedID"].ToString();
                        List_RGONotified.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Patron Signs List
            List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Items.Clear();
            List_PatronSigns_GeneralWarningSigns_Money.Items.Clear();
            List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.Items.Clear();
            List_PatronSigns_ProbableWarningSigns_LengthOfPlay.Items.Clear();
            List_PatronSigns_ProbableWarningSigns_Money.Items.Clear();
            List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.Items.Clear();
            List_PatronSigns_ProbableWarningSigns_SocialBehaviours.Items.Clear();
            List_PatronSigns_StrongWarningSigns_LengthOfPlay.Items.Clear();
            List_PatronSigns_StrongWarningSigns_Money.Items.Clear();
            List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.Items.Clear();
            List_PatronSigns_StrongWarningSigns_SocialBehaviours.Items.Clear();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_GeneralWarningSigns_Money.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_ProbableWarningSigns_LengthOfPlay.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_ProbableWarningSigns_Money.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Social behaviours' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_ProbableWarningSigns_SocialBehaviours.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_StrongWarningSigns_LengthOfPlay.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_StrongWarningSigns_Money.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.Items.Add(item);
                    }
                }
                con.Close();

                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Social behaviours' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronSignsId"].ToString();
                        List_PatronSigns_StrongWarningSigns_SocialBehaviours.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Initial Action List
            List_InitialAction.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_InitialAction] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["InitialActionID"].ToString();
                        List_InitialAction.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for 3hr Alert Response List
            List_3hrAlertResponse.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_3hrsAlertResponse] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["3hrAlertResponseID"].ToString();
                        List_3hrAlertResponse.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Patron Response List
            List_PatronResponse.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_PatronResponse] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["PatronResponseID"].ToString();
                        List_PatronResponse.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Event Outcome List
            List_EventOutcome.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_EventOutcome] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["EventOutcomeID"].ToString();
                        List_EventOutcome.Items.Add(item);
                    }
                }
                con.Close();
            }

            txtStaffName.Text = Session["DisplayName"].ToString();

            // check the current time then set appropriate date
            TimeSpan start = new TimeSpan(0, 0, 0);   // 12am
            TimeSpan end = new TimeSpan(8, 0, 0);     // 8am
            TimeSpan now = DateTime.Now.TimeOfDay;    // current time
            DateTime dateTime;
            if ((now > start) && (now < end))
            {
                // current time is between 12am to 8am
                dateTime = DateTime.Now.Date.AddDays(-1);
            }
            else
            {
                // current time is greater than 8am
                dateTime = DateTime.Now.Date;
            }
            // display appropriate trading date
            txtDatePicker.Text = dateTime.ToString("dddd, dd MMMM yyyy");
        }
    }

    // validates form. It also runs validatePersonForm method
    protected int validateForm()
    {
        int returnedFlag = 0, result;
        DateTime temp;
        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            returnedFlag = 1;

        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            returnedFlag = 1;

        }
        else
        {
            // compare date entered to current date
            DateTime date1a = DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString());
            // compare selected date to current date
            result = DateTime.Compare(date1a, date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                returnedFlag = 1;
            }
        }

        if (ddlShift.SelectedItem.Value == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Shift.";
            ddlShift.Focus();
            returnedFlag = 1;
        }

        // check if returnedFlag is already set 1
        if (cbPatronDetailsRecorded.Checked)
        {
            int returnedFlag1 = validatePersonForm();
            if (returnedFlag == 1 || returnedFlag1 == 1)
            {
                returnedFlag = 1;
            }
        }

        if (txtDate.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Report Date shouldn't be empty.";
            txtDate.Focus();
            returnedFlag = 1;

        }
        if (!DateTime.TryParse(txtDate.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Report Date entry is not in date format please select an appropriate date.";
            txtDate.Focus();
            returnedFlag = 1;

        }
        else
        {
            DateTime date1 = DateTime.Parse(DateTime.Parse(txtDate.Text).ToShortDateString());
            // compare selected date to current date
            result = DateTime.Compare(date1, date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDate.Focus();
                returnedFlag = 1;
            }
        }

        if (ddlHour.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour of the report.";
            ddlHour.Focus();
            returnedFlag = 1;

        }
        if (ddlMinutes.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes of the report.";
            ddlMinutes.Focus();
            returnedFlag = 1;

        }
        if (List_EventType.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select at least one event type.";
            List_EventType.Focus();
            returnedFlag = 1;
        }
        foreach (ListItem item in List_EventType.Items)
        {
            if (item.ToString() == "Other")
            {
                if (item.Selected)
                {
                    if (txtEventOthers.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please specify additional details in the event type.";
                        txtEventOthers.Focus();
                        returnedFlag = 1;
                    }
                }
            }
        }

        if (List_Location.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the location of event.";
            List_Location.Focus();
            returnedFlag = 1;
        }
        else
        {
            foreach (ListItem item in List_Location.Items)
            {
                if (item.ToString() == "Other")
                {
                    if (item.Selected)
                    {
                        if (txtLocationOther.Text == "")
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please record other location of event.";
                            txtLocationOther.Focus();
                            returnedFlag = 1;
                        }
                    }
                }
            }
        }
        if (List_RGONotified.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select how you were notified of the event.";
            List_RGONotified.Focus();
            returnedFlag = 1;
        }
        if (List_PatronSigns_GeneralWarningSigns_LengthOfPlay.SelectedValue == String.Empty && List_PatronSigns_GeneralWarningSigns_Money.SelectedValue == String.Empty && List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.SelectedValue == String.Empty &&
                List_PatronSigns_ProbableWarningSigns_LengthOfPlay.SelectedValue == String.Empty && List_PatronSigns_ProbableWarningSigns_Money.SelectedValue == String.Empty && List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.SelectedValue == String.Empty &&
                List_PatronSigns_ProbableWarningSigns_SocialBehaviours.SelectedValue == String.Empty && List_PatronSigns_StrongWarningSigns_LengthOfPlay.SelectedValue == String.Empty && List_PatronSigns_StrongWarningSigns_Money.SelectedValue == String.Empty &&
                List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.SelectedValue == String.Empty && List_PatronSigns_StrongWarningSigns_SocialBehaviours.SelectedValue == String.Empty)
        {
            if (String.IsNullOrEmpty(txtPatronSignsOther.Text))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select at least one sign of problematic gambling behaviour.";
                List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Focus();
                returnedFlag = 1;
            }
        }
        if (List_InitialAction.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select what was the initial action taken.";
            List_InitialAction.Focus();
            returnedFlag = 1;
        }
        if (List_3hrAlertResponse.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select what at least one selection from club's gaming break options.";
            List_3hrAlertResponse.Focus();
            returnedFlag = 1;
        }
        if (List_PatronResponse.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select how did the patron respond.";
            List_PatronResponse.Focus();
            returnedFlag = 1;
        }

        if (List_EventOutcome.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the final event outcome.";
            List_EventOutcome.Focus();
            returnedFlag = 1;
        }

        // make sure user selects at least a Yes or No
        if (cbPatronDetailsRecorded.Checked == false && cbPatronDetailsRecorded1.Checked == false)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select either Yes or No on whether patron details were recorded.";
            cbPatronDetailsRecorded.Focus();
            returnedFlag = 1;
        }

        if (cbWitnessRecorded.Checked == false && cbWitnessRecorded1.Checked == false)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select either Yes or No on whether witness details were recorded.";
            cbWitnessRecorded.Focus();
            returnedFlag = 1;
        }

        if (cbPoliceRecorded.Checked == false && cbPoliceRecorded1.Checked == false)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select either Yes or No on whether police details were recorded.";
            cbPoliceRecorded.Focus();
            returnedFlag = 1;
        }

        if (cbIncidentReportCompleted.Checked == false && cbIncidentReportCompleted1.Checked == false)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select either Yes or No on whether incident report was completed.";
            cbIncidentReportCompleted.Focus();
            returnedFlag = 1;
        }

        if (cbWitnessRecorded.Checked)
        {
            if (txtWitnessDetails.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please record witness details.";
                txtWitnessDetails.Focus();
                returnedFlag = 1;
            }
        }

        if (cbPoliceRecorded.Checked)
        {
            if (txtPoliceDetails.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please record police details.";
                txtPoliceDetails.Focus();
                returnedFlag = 1;
            }
        }

        if (cbIncidentReportCompleted.Checked == false)
        {
            if (List_PatronSigns_StrongWarningSigns_LengthOfPlay.SelectedValue != String.Empty || List_PatronSigns_StrongWarningSigns_Money.SelectedValue != String.Empty ||
                List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty || List_PatronSigns_StrongWarningSigns_SocialBehaviours.SelectedValue != String.Empty)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                cbIncidentReportCompleted.Focus();
                returnedFlag = 1;
            }

            int flagged = 0;
            foreach (ListItem item in List_InitialAction.Items)
            {
                if (item.ToString() == "Ask patron to leave the gaming area for private conversation")
                {
                    if (item.Selected)
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                        cbIncidentReportCompleted.Focus();
                        returnedFlag = 1;
                        flagged = 1;
                        break;
                    }
                }
            }
            if (flagged == 0)
            {
                foreach (ListItem item in List_PatronResponse.Items)
                {
                    if (item.ToString() == "Patron indicated financial issues")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = 1;
                            flagged = 1;
                            break;
                        }
                    }
                    if (item.ToString() == "Patron indicated gambling problems")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = 1;
                            flagged = 1;
                            break;
                        }
                    }
                    if (item.ToString() == "Patron showing signs of intoxication")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = 1;
                            flagged = 1;
                            break;
                        }
                    }
                }
            }
            if (flagged == 0)
            {
                foreach (ListItem item in List_EventOutcome.Items)
                {
                    if (item.ToString() == "Welfare check conducted by Duty Manager")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = 1;
                            break;
                        }
                    }
                    if (item.ToString() == "Self-exclusion completed")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = 1;
                            break;
                        }
                    }
                    if (item.ToString() == "Patron was asked to leave the premises")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = 1;
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            if (cbAssistedCompletingIncidentReport.Checked == false && cbAssistedCompletingIncidentReport1.Checked == false)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select either Yes or No on whether you have assisted in completing an incident report.";
                cbAssistedCompletingIncidentReport.Focus();
                returnedFlag = 1;
            }
        }

        if (cbAssistedCompletingIncidentReport.Checked == true)
        {
            if (cbIncidentReportCompleted.Checked == false)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                cbIncidentReportCompleted.Focus();
                returnedFlag = 1;
            }
        }
        return returnedFlag;
    }
    protected int validatePersonForm()
    {
        DateTime temp;
        int returnedFlag = 0;
        int result;

        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        // Patron
        if (ddlPartyType.SelectedItem.Value == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type.";
            ddlPartyType.Focus();
            returnedFlag = 1;

        }

        if (ddlPartyType.SelectedItem.Text == "Member")
        {
            if (txtMemberNo.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Membership number.";
                txtMemberNo.Focus();
                returnedFlag = 1;

            }
            if (txtDOB.Text != "")
            {
                if (!DateTime.TryParse(txtDOB.Text, out temp))
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Member's Date of Birth is not in date format please select an appropriate date.";
                    txtDOB.Focus();
                    returnedFlag = 1;

                }
                else
                {
                    DateTime datem1 = DateTime.Parse(DateTime.Parse(txtDOB.Text).ToShortDateString());
                    // compare selected date to current date
                    result = DateTime.Compare(datem1, date);
                    if (result > 0)
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                        txtDOB.Focus();
                        returnedFlag = 1;

                    }
                }
            }

            if (txtAddress.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter member's Address.";
                txtAddress.Focus();
                returnedFlag = 1;

            }
        }
        else if (ddlPartyType.SelectedItem.Text == "Visitor")
        {
            if (cbSignInSlip.Checked == true)
            {
                if (txtSignInBy.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who Signed in the visitor.";
                    txtSignInBy.Focus();
                    returnedFlag = 1;

                }
            }
            if (txtDOBv.Text != "")
            {
                if (!DateTime.TryParse(txtDOBv.Text, out temp))
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Visitor's Date of Birth is not in date format please select an appropriate date.";
                    txtDOBv.Focus();
                    returnedFlag = 1;

                }
                else
                {
                    DateTime datev1 = DateTime.Parse(DateTime.Parse(txtDOBv.Text).ToShortDateString());
                    // compare selected date to current date
                    result = DateTime.Compare(datev1, date);
                    if (result > 0)
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                        txtDOBv.Focus();
                        returnedFlag = 1;

                    }
                }
            }

            if (txtAddressv.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter visitor's Address.";
                txtAddress.Focus();
                returnedFlag = 1;

            }
            if (txtIDProof.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter visitor's Proof ID.";
                txtIDProof.Focus();
                returnedFlag = 1;

            }
        }
        return returnedFlag;
    }

    // reads the fields in the database
    protected void readFiles(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd;

        if (method.Contains("Member"))
        {
            cmd = new SqlCommand(sqlCommand, con1);
        }
        else
        {
            cmd = new SqlCommand(sqlCommand, con);
        }

        try
        {
            if (method.Contains("Member"))
            {
                con1.Open();
            }
            else
            {
                con.Open();
            }

            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (method.Equals("getStaff"))
                    {
                        Session["currentStaffId"] = rdr["StaffId"].ToString();
                    }
                    if (method.Equals("SearchMember"))
                    {
                        ReportResponsibleGamingOfficerCu.PlayerId = rdr["PlayerId"].ToString();
                        ReportResponsibleGamingOfficerCu.ViewPlayerId = rdr["PlayerId"].ToString();
                        txtFirstName.Text = rdr["FirstName"].ToString();
                        txtLastName.Text = rdr["LastName"].ToString();
                        txtAddress.Text = rdr["Address"].ToString();
                        txtDOB.Text = rdr["Birthday"].ToString();
                        txtMemberSince.Text = rdr["MemberSince"].ToString();
                        txtContact.Text = rdr["Contact"].ToString();

                        try
                        {
                            memberPhoto = (byte[])rdr["PlayerImage"];
                            // load image from database
                            string strBase64 = Convert.ToBase64String(memberPhoto, 0, memberPhoto.Length);
                            imgMember.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        catch
                        {
                            memberPhoto = null;
                            imgMember.ImageUrl = "~/Images/no-image.png";
                        }
                        // LinkButton.Visible = true;
                    }
                    if (method.Equals("MemberPhoto"))
                    {
                        ReportResponsibleGamingOfficerCu.PlayerId = rdr["PlayerId"].ToString();
                        ReportResponsibleGamingOfficerCu.ViewPlayerId = rdr["PlayerId"].ToString();

                        try
                        {
                            memberPhoto = (byte[])rdr["PlayerImage"];
                            // load image from database
                            string strBase64 = Convert.ToBase64String(memberPhoto, 0, memberPhoto.Length);
                            imgMember.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        catch
                        {
                            memberPhoto = null;
                            imgMember.ImageUrl = "~/Images/no-image.png";
                        }
                    }
                }
            }
            else // if Search Member doesn't have the member details
            {
                if (method.Equals("SearchMember"))
                {
                    ReportResponsibleGamingOfficerCu.PlayerId = "";
                    ReportResponsibleGamingOfficerCu.ViewPlayerId = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtDOB.Text = "";
                    txtAddress.Text = "";
                    txtMemberSince.Text = "";
                    txtContact.Text = "";
                    imgMember.ImageUrl = "~/Images/white-background.png";
                    // LinkButton.Visible = false;
                    alert.DisplayMessage("Member Not Found! Please enter another Member No.");
                }
            }
        }
        catch (Exception er)
        {
            alert.DisplayMessage(er.Message);
        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }
            if (method.Contains("Member"))
            {
                if (con1 != null)
                {
                    con1.Close();
                }
            }
            else
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }

    // show/hide Visitor and Member fields
    protected void ddlPartyType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPartyType.SelectedItem.Text == "Member")
        {
            member11l.Visible = true;
            member11.Visible = true;
            member13l.Visible = true;
            member14l.Visible = true;

            visitor11l.Visible = false;
            visitor11.Visible = false;
            visitor12l.Visible = false;
            visitor12.Visible = false;
            visitor13l.Visible = false;
            visitor13.Visible = false;
            visitor14l.Visible = false;
            visitor14.Visible = false;
            visitor15l.Visible = false;
            visitor15.Visible = false;

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtMemberSince.Text = "";
            txtContact.Text = "";
            txtMemberNo.Text = "";
            txtDOB.Text = "";
            imgMember.ImageUrl = "~/Images/white-background.png";

            txtMemberNo.Focus();
        }
        else if (ddlPartyType.SelectedItem.Text == "Visitor")
        {
            member11l.Visible = false;
            member11.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;

            visitor11l.Visible = true;
            visitor11.Visible = true;
            visitor12l.Visible = true;
            visitor12.Visible = true;
            visitor13l.Visible = true;
            visitor13.Visible = true;
            visitor14l.Visible = true;
            visitor14.Visible = true;
            visitor15l.Visible = true;
            visitor15.Visible = true;

            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddressv.Text = "";
            txtContact.Text = "";
            cbSignInSlip.Text = "";
            txtSignInBy.Text = "";
            txtDOBv.Text = "";
            txtIDProof.Text = "";

            txtFirstName.Focus();
        }
        else if (ddlPartyType.SelectedItem.Text != "Select Type")
        {
            member11l.Visible = false;
            member11.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;

            visitor11l.Visible = false;
            visitor11.Visible = false;
            visitor12l.Visible = false;
            visitor12.Visible = false;
            visitor13l.Visible = false;
            visitor13.Visible = false;
            visitor14l.Visible = false;
            visitor14.Visible = false;
            visitor15l.Visible = false;
            visitor15.Visible = false;

            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";

            txtFirstName.Focus();
        }
        else
        {
            member11l.Visible = false;
            member11.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;

            visitor11l.Visible = false;
            visitor11.Visible = false;
            visitor12l.Visible = false;
            visitor12.Visible = false;
            visitor13l.Visible = false;
            visitor13.Visible = false;
            visitor14l.Visible = false;
            visitor14.Visible = false;
            visitor15l.Visible = false;
            visitor15.Visible = false;

            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
        }
    }
    // list of all checkboxlist in the form - are AutoPostBack and toggles the visibility of other objects (such as textboxes)
    protected void List_EventType_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in List_EventType.Items)
        {
            if (item.ToString() == "Other")
            {
                if (item.Selected)
                {
                    treventTypeOther.Visible = true;
                    treventTypeOther1.Visible = true;
                }
                else
                {
                    treventTypeOther.Visible = false;
                    treventTypeOther1.Visible = false;
                    txtEventOthers.Text = "";
                }
            }
        }
    }
    // list of all checkboxlist in the form - are AutoPostBack and toggles the visibility of other objects (such as textboxes)
    protected void List_Location_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in List_Location.Items)
        {
            if (item.ToString() == "Other")
            {
                if (item.Selected)
                {
                    otherLocation.Visible = true;
                    txtLocationOther.Visible = true;
                }
                else
                {
                    otherLocation.Visible = false;
                    txtLocationOther.Visible = false;
                    txtLocationOther.Text = "";
                }
            }
        }
    }
    // view/hide form for patron details
    protected void cbPatronDetailsRecorded_CheckedChanged(object sender, EventArgs e)
    {
        if (cbPatronDetailsRecorded.Checked == true)
        {
            tblPerson1.Visible = true;
            cbPatronDetailsRecorded1.Checked = false;
        }
        else
        {
            tblPerson1.Visible = false;
        }
    }
    protected void cbPatronDetailsRecorded1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbPatronDetailsRecorded1.Checked == true)
        {
            cbPatronDetailsRecorded.Checked = false;
            tblPerson1.Visible = false;
        }
    }
    protected void cbIncidentReportCompleted_CheckedChanged(object sender, EventArgs e)
    {
        if (cbIncidentReportCompleted.Checked == true)
        {
            trassistedcompletingincidentreport.Visible = true;
            trassistedcompletingincidentreport1.Visible = true;
            cbIncidentReportCompleted1.Checked = false;
        }
        else
        {
            trassistedcompletingincidentreport.Visible = false;
            trassistedcompletingincidentreport1.Visible = false;
        }
    }
    protected void cbIncidentReportCompleted1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbIncidentReportCompleted1.Checked == true)
        {
            cbIncidentReportCompleted.Checked = false;
            trassistedcompletingincidentreport.Visible = false;
            trassistedcompletingincidentreport1.Visible = false;
        }
    }
    protected void cbAssistedCompletingIncidentReport_CheckedChanged(object sender, EventArgs e)
    {
        if (cbAssistedCompletingIncidentReport.Checked == true)
        {
            cbAssistedCompletingIncidentReport1.Checked = false;
        }
    }
    protected void cbAssistedCompletingIncidentReport1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbAssistedCompletingIncidentReport1.Checked == true)
        {
            cbAssistedCompletingIncidentReport.Checked = false;
        }
    }
    protected void cbWitnessRecorded_CheckedChanged(object sender, EventArgs e)
    {
        if (cbWitnessRecorded.Checked == true)
        {
            witness.Visible = true;
            witness1.Visible = true;
            cbWitnessRecorded1.Checked = false;
        }
        else
        {
            witness.Visible = false;
            witness1.Visible = false;
            txtWitnessDetails.Text = "";
        }

        if (cbWitnessRecorded1.Checked == true)
        {
            cbWitnessRecorded.Checked = false;
            witness.Visible = false;
            witness1.Visible = false;
            txtWitnessDetails.Text = "";
        }
    }
    protected void cbWitnessRecorded1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbWitnessRecorded1.Checked == true)
        {
            cbWitnessRecorded.Checked = false;
            witness.Visible = false;
            witness1.Visible = false;
            txtWitnessDetails.Text = "";
        }
    }
    protected void cbPoliceRecorded_CheckedChanged(object sender, EventArgs e)
    {
        if (cbPoliceRecorded.Checked == true)
        {
            police.Visible = true;
            police1.Visible = true;
            cbPoliceRecorded1.Checked = false;
        }
        else
        {
            police.Visible = false;
            police1.Visible = false;
            txtPoliceDetails.Text = "";
        }

        if (cbPoliceRecorded1.Checked == true)
        {
            cbPoliceRecorded.Checked = false;
            police.Visible = false;
            police1.Visible = false;
            txtPoliceDetails.Text = "";
        }
    }
    protected void cbPoliceRecorded1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbPoliceRecorded1.Checked == true)
        {
            cbPoliceRecorded.Checked = false;
            police.Visible = false;
            police1.Visible = false;
            txtPoliceDetails.Text = "";
        }
    }
    // clears all changes made
    protected void btnReset_Click(object sender, EventArgs e)
    {
        // get max version of the report template
        con.Open();
        SqlCommand version = new SqlCommand("SELECT MAX(VersionNo)" +
                         " FROM dbo.[Version]" +
                         " WHERE RCatId = 1", con);
        int maxVersion = (int)version.ExecuteScalar();

        //Reset the Player Id Global Variables
        ReportResponsibleGamingOfficerCu.PlayerId = "";

        // display cleared report template
        Response.Redirect("~/Reports/CU Responsible Gaming Officer/Create/v" + maxVersion.ToString() + "/v" + maxVersion.ToString() + ".aspx", false);
    }

    // stores data into database.
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SearchReport.CreateReportReset(); // takes off the selected report in ddlCreateReport

        string EventType = "", Location = "", RGONotified = "", PatronSigns = "", InitialAction = "", AlertResponse = "", PatronResponse = "", EventOutcome = "",
               query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_ClubUminaRGO";
        int lastRId;

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
            lastRId = 16000001;
        }
        con.Close();

        Report.LastReportId = lastRId.ToString();

        // store EventType as a string variable with comma delimiter
        if (List_EventType.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            List<String> tempEventTypeList = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_EventType.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempEventTypeList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            EventType = String.Join(",", tempEventTypeList.ToArray());
            if (!EventType.Equals(""))
            {
                EventType += ",";
            }
        }

        // store LocationList as a string variable with comma delimiter
        if (List_Location.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            List<String> tempLocationList = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_Location.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempLocationList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            Location = String.Join(",", tempLocationList.ToArray());
            if (!Location.Equals(""))
            {
                Location += ",";
            }
        }

        // store RGONotifiedList as a string variable with comma delimiter
        if (List_RGONotified.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            List<String> tempRGONotifiedList = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_RGONotified.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempRGONotifiedList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            RGONotified = String.Join(",", tempRGONotifiedList.ToArray());
            if (!RGONotified.Equals(""))
            {
                RGONotified += ",";
            }
        }

        // store PatronSignsList as a string variable with comma delimiter
        // Create the list to store.
        List<String> tempPatronSignsList = new List<string>();
        if (List_PatronSigns_GeneralWarningSigns_LengthOfPlay.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_GeneralWarningSigns_Money.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_Money.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_ProbableWarningSigns_LengthOfPlay.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_LengthOfPlay.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_ProbableWarningSigns_Money.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_Money.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_ProbableWarningSigns_SocialBehaviours.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_SocialBehaviours.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_StrongWarningSigns_LengthOfPlay.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_StrongWarningSigns_LengthOfPlay.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_StrongWarningSigns_Money.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_StrongWarningSigns_Money.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (List_PatronSigns_StrongWarningSigns_SocialBehaviours.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Loop through each item.
            foreach (ListItem item in List_PatronSigns_StrongWarningSigns_SocialBehaviours.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronSignsList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
        }
        if (!PatronSigns.Equals(""))
        {
            PatronSigns += ",";
        }

        // store InitialActionList as a string variable with comma delimiter
        if (List_InitialAction.SelectedValue != String.Empty)
        {
            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            List<String> tempInitialActionList = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_InitialAction.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempInitialActionList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            InitialAction = String.Join(",", tempInitialActionList.ToArray());
            if (!InitialAction.Equals(""))
            {
                InitialAction += ",";
            }
        }

        // store 3hrAlertResponseList as a string variable with comma delimiter
        if (List_3hrAlertResponse.SelectedValue != String.Empty)
        {
            // Create the list to store.
            List<String> tempAlertResponseList = new List<string>();
            foreach (ListItem item in List_3hrAlertResponse.Items)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempAlertResponseList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            AlertResponse = String.Join(",", tempAlertResponseList.ToArray());
            if (!AlertResponse.Equals(""))
            {
                AlertResponse += ",";
            }
        }

        // store PatronResponseList as a string variable with comma delimiter
        if (List_PatronResponse.SelectedValue != String.Empty)
        {
            // Create the list to store.
            List<String> tempPatronResponseList = new List<string>();
            foreach (ListItem item in List_PatronResponse.Items)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempPatronResponseList.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            PatronResponse = String.Join(",", tempPatronResponseList.ToArray());
            if (!PatronResponse.Equals(""))
            {
                PatronResponse += ",";
            }
        }

        // store EventOutcomeList as a string variable with comma delimiter
        if (List_EventOutcome.SelectedValue != String.Empty)
        {
            // Create the list to store.
            List<String> tempEventOutcome = new List<string>();
            foreach (ListItem item in List_EventOutcome.Items)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    tempEventOutcome.Add(item.Value);
                }
            }
            // Join the string together using the , delimiter.
            EventOutcome = String.Join(",", tempEventOutcome.ToArray());
            if (!EventOutcome.Equals(""))
            {
                EventOutcome += ",";
            }
        }

        // change the format of the entry date to timestamp format
        DateTime entry_date = DateTime.Now;

        // validate objects in the form
        int returnedValue = 0;
        if (ddlShift.SelectedItem.Value == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Shift.";
            ddlShift.Focus();
            returnedValue = 1;
        }

        if (returnedValue == 1)
        {
            alert.DisplayMessage(Report.ErrorMessage);
            Report.ErrorMessage = "";
            return;
        }

        // change the format of the shift date to timestamp format
        DateTime shift_date = DateTime.Parse(txtDatePicker.Text);
        string shift_tDate = shift_date.ToString("yyyyMMdd");
        // separate the shift date day of week value
        string shift_DOW = shift_date.DayOfWeek.ToString();

        // get staff's id
        string cmdText = "SELECT StaffId FROM Staff WHERE Username = '" + Session["Username"] + "'",
               variable = "getStaff";
        readFiles(cmdText, variable);

        // insert data to table
        using (DataClassesDataContext dc = new DataClassesDataContext())
        {
            Report_ClubUminaRGO dm = new Report_ClubUminaRGO();
            dm.ReportId = Int32.Parse(Report.LastReportId);
            dm.RCatId = 16;
            dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
            dm.StaffName = UserCredentials.DisplayName;
            dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
            dm.ShiftDate = shift_date.Date;
            dm.ShiftDOW = shift_DOW;
            dm.EntryDate = entry_date;
            dm.Report_Table = "Report_ClubUminaRGO";
            dm.AuditVersion = 1;
            dm.ReportStat = "Awaiting Completion";
            dm.Report_Version = 1; // current version
            dm.ReadByList = "," + UserCredentials.StaffId + ",";
            dm.PatronDetailsRecorded = cbPatronDetailsRecorded.Checked;
            dm.PartyType = ddlPartyType.SelectedItem.Value;
            dm.TxtPartyType = ddlPartyType.SelectedItem.Text;
            if (ddlPartyType.SelectedItem.Value == "1")
            {
                dm.PlayerId = ReportResponsibleGamingOfficerCu.PlayerId;
                dm.MemberNo = txtMemberNo.Text;
                string cmdQuery = SearchMember(txtMemberNo.Text);
                readFiles(cmdQuery, "MemberPhoto");
                dm.MemberPhoto = memberPhoto;
                dm.MemberDOB = txtDOB.Text;
                dm.MemberAddress = txtAddress.Text;
                dm.MemberSince = txtMemberSince.Text;
                dm.SignInSlip = false;
            }
            else if (ddlPartyType.SelectedItem.Value == "2")
            {
                dm.SignInSlip = cbSignInSlip.Checked;
                dm.SignedInBy = txtSignInBy.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.VisitorDOB = txtDOBv.Text;
                dm.VisitorAddress = txtAddressv.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.VisitorProofID = txtIDProof.Text.Replace("\n", "<br />").Replace("'", "^");
            }
            else
            {
                dm.SignInSlip = false;
            }
            dm.Date = txtDate.Text;
            dm.TimeH = ddlHour.SelectedItem.Value;
            dm.TimeM = ddlMinutes.SelectedItem.Value;
            dm.TxtTimeH = ddlHour.SelectedItem.Text;
            dm.TxtTimeM = ddlMinutes.SelectedItem.Text;
            dm.LocationList = Location;
            dm.LocationOther = txtLocationOther.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.LocationMachine = txtLocationMachine.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.EventType = EventType;
            dm.EventTypeOtherDesc = txtEventOthers.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.FirstName = txtFirstName.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.LastName = txtLastName.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.PartyType = ddlPartyType.SelectedItem.Value;
            dm.RGONotifiedList = RGONotified;
            dm.RGONotifiedOther = txtRGONotifiedOther.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.PatronsSignsList = PatronSigns;
            dm.PatronSignsOther = txtPatronSignsOther.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.InitialActionList = InitialAction;
            dm.AlertResponseList = AlertResponse;
            dm.PatronResponseList = PatronResponse;
            dm.EventOutcomeList = EventOutcome;
            dm.EventOutcomeFurtherComments = txtFurtherComments.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.WitnessRecorded = cbWitnessRecorded.Checked;
            dm.WitnessDetails = txtWitnessDetails.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.PoliceNotified = cbPoliceRecorded.Checked;
            dm.PoliceDetails = txtPoliceDetails.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.IncidentReportCompleted = cbIncidentReportCompleted.Checked;
            dm.AssistedCompletingIncidentReport = cbAssistedCompletingIncidentReport.Checked;

            dc.Report_ClubUminaRGOs.InsertOnSubmit(dm);
            dc.SubmitChanges();
        }

        //Reset the Player Id Global Variables
        ReportResponsibleGamingOfficerCu.PlayerId = "";

        SearchReport.CreateReport = ""; // reset this variable to set ddlCreateReport to default value

        //log the create activity
        RunStoredProcedure rsp = new RunStoredProcedure();
        try
        {
            rsp.Log(4, Int32.Parse(Report.LastReportId));
        }
        catch { }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        "alert('Report Saved.'); window.location='" +
        Request.ApplicationPath + "Default.aspx';", true);
        SearchReport.SetAccordion = "1";
        SearchReport.RunOnStart = true;
        SearchReport.FromCreateReport = true;
    }

    // Once Member had a Textchanged, trigger this
    protected void txtMemberNo_TextChanged(object sender, EventArgs e)
    {
        string cmdQuery = SearchMember(txtMemberNo.Text);
        readFiles(cmdQuery, "SearchMember");
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

    protected void btnUserSign_Click(object sender, EventArgs e)
    {
        if (cbUserSign.Checked == false)
        {
            alert.DisplayMessage("Please tick the checkbox to digitally sign the form.");
            cbUserSign.Focus();
            return;
        }
        else
        {
            SearchReport.CreateReportReset(); // takes off the selected report in ddlCreateReport

            string EventType = "", Location = "", RGONotified = "", PatronSigns = "", InitialAction = "", AlertResponse = "", PatronResponse = "", EventOutcome = "",
                           query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_ClubUminaRGO";
            int lastRId;

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
                lastRId = 16000001;
            }
            con.Close();

            Report.LastReportId = lastRId.ToString();

            // store EventType as a string variable with comma delimiter
            if (List_EventType.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Create the list to store.
                List<String> tempEventTypeList = new List<string>();
                // Loop through each item.
                foreach (ListItem item in List_EventType.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempEventTypeList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                EventType = String.Join(",", tempEventTypeList.ToArray());
                if (!EventType.Equals(""))
                {
                    EventType += ",";
                }
            }

            // store LocationList as a string variable with comma delimiter
            if (List_Location.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Create the list to store.
                List<String> tempLocationList = new List<string>();
                // Loop through each item.
                foreach (ListItem item in List_Location.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempLocationList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                Location = String.Join(",", tempLocationList.ToArray());
                if (!Location.Equals(""))
                {
                    Location += ",";
                }
            }

            // store RGONotifiedList as a string variable with comma delimiter
            if (List_RGONotified.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Create the list to store.
                List<String> tempRGONotifiedList = new List<string>();
                // Loop through each item.
                foreach (ListItem item in List_RGONotified.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempRGONotifiedList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                RGONotified = String.Join(",", tempRGONotifiedList.ToArray());
                if (!RGONotified.Equals(""))
                {
                    RGONotified += ",";
                }
            }

            // store PatronSignsList as a string variable with comma delimiter
            // Create the list to store.
            List<String> tempPatronSignsList = new List<string>();
            if (List_PatronSigns_GeneralWarningSigns_LengthOfPlay.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_GeneralWarningSigns_Money.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_Money.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_ProbableWarningSigns_LengthOfPlay.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_LengthOfPlay.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_ProbableWarningSigns_Money.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_Money.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_ProbableWarningSigns_SocialBehaviours.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_SocialBehaviours.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_StrongWarningSigns_LengthOfPlay.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_StrongWarningSigns_LengthOfPlay.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_StrongWarningSigns_Money.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_StrongWarningSigns_Money.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (List_PatronSigns_StrongWarningSigns_SocialBehaviours.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Loop through each item.
                foreach (ListItem item in List_PatronSigns_StrongWarningSigns_SocialBehaviours.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronSignsList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronSigns = String.Join(",", tempPatronSignsList.ToArray());
            }
            if (!PatronSigns.Equals(""))
            {
                PatronSigns += ",";
            }

            // store InitialActionList as a string variable with comma delimiter
            if (List_InitialAction.SelectedValue != String.Empty)
            {
                // store in a string all the selected item in the checkboxlist
                // Create the list to store.
                List<String> tempInitialActionList = new List<string>();
                // Loop through each item.
                foreach (ListItem item in List_InitialAction.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempInitialActionList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                InitialAction = String.Join(",", tempInitialActionList.ToArray());
                if (!InitialAction.Equals(""))
                {
                    InitialAction += ",";
                }
            }

            // store 3hrAlertResponseList as a string variable with comma delimiter
            if (List_3hrAlertResponse.SelectedValue != String.Empty)
            {
                // Create the list to store.
                List<String> tempAlertResponseList = new List<string>();
                foreach (ListItem item in List_3hrAlertResponse.Items)
                {
                    // store in a string all the selected item in the checkboxlist
                    // Loop through each item.
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempAlertResponseList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                AlertResponse = String.Join(",", tempAlertResponseList.ToArray());
                if (!AlertResponse.Equals(""))
                {
                    AlertResponse += ",";
                }
            }

            // store PatronResponseList as a string variable with comma delimiter
            if (List_PatronResponse.SelectedValue != String.Empty)
            {
                // Create the list to store.
                List<String> tempPatronResponseList = new List<string>();
                foreach (ListItem item in List_PatronResponse.Items)
                {
                    // store in a string all the selected item in the checkboxlist
                    // Loop through each item.
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempPatronResponseList.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                PatronResponse = String.Join(",", tempPatronResponseList.ToArray());
                if (!PatronResponse.Equals(""))
                {
                    PatronResponse += ",";
                }
            }

            // store EventOutcomeList as a string variable with comma delimiter
            if (List_EventOutcome.SelectedValue != String.Empty)
            {
                // Create the list to store.
                List<String> tempEventOutcome = new List<string>();
                foreach (ListItem item in List_EventOutcome.Items)
                {
                    // store in a string all the selected item in the checkboxlist
                    // Loop through each item.
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        tempEventOutcome.Add(item.Value);
                    }
                }
                // Join the string together using the , delimiter.
                EventOutcome = String.Join(",", tempEventOutcome.ToArray());
                if (!EventOutcome.Equals(""))
                {
                    EventOutcome += ",";
                }
            }

            // change the format of the entry date to timestamp format
            DateTime entry_date = DateTime.Now;

            // validate objects in the form
            int returnedValue = validateForm();

            if (returnedValue == 1)
            {
                HideUserSign();
                alert.DisplayMessage(Report.ErrorMessage);
                Report.ErrorMessage = "";
                return;
            }

            // change the format of the shift date to timestamp format
            DateTime shift_date = DateTime.Parse(txtDatePicker.Text);
            string shift_tDate = shift_date.ToString("yyyyMMdd");
            // separate the shift date day of week value
            string shift_DOW = shift_date.DayOfWeek.ToString();

            // get staff's id
            string cmdText = "SELECT StaffId FROM Staff WHERE Username = '" + Session["Username"] + "'",
                   variable = "getStaff";
            readFiles(cmdText, variable);

            // insert data to table
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                Report_ClubUminaRGO dm = new Report_ClubUminaRGO();
                dm.ReportId = Int32.Parse(Report.LastReportId);
                dm.RCatId = 16;
                dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
                dm.StaffName = UserCredentials.DisplayName;
                dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
                dm.ShiftDate = shift_date.Date;
                dm.ShiftDOW = shift_DOW;
                dm.EntryDate = entry_date;
                dm.Report_Table = "Report_ClubUminaRGO";
                dm.AuditVersion = 1;
                dm.ReportStat = "Awaiting Manager Sign-off";
                dm.Report_Version = 1; // current version
                dm.ReadByList = "," + UserCredentials.StaffId + ",";
                dm.PatronDetailsRecorded = cbPatronDetailsRecorded.Checked;
                dm.TxtPartyType = ddlPartyType.SelectedItem.Text;
                if (ddlPartyType.SelectedItem.Value == "1")
                {
                    dm.PlayerId = ReportResponsibleGamingOfficerCu.PlayerId;
                    dm.MemberNo = txtMemberNo.Text;
                    string cmdQuery = SearchMember(txtMemberNo.Text);
                    readFiles(cmdQuery, "MemberPhoto");
                    dm.MemberPhoto = memberPhoto;
                    dm.MemberDOB = txtDOB.Text;
                    dm.MemberAddress = txtAddress.Text;
                    dm.MemberSince = txtMemberSince.Text;
                    dm.SignInSlip = false;
                }
                else if (ddlPartyType.SelectedItem.Value == "2")
                {
                    dm.SignInSlip = cbSignInSlip.Checked;
                    dm.SignedInBy = txtSignInBy.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorDOB = txtDOBv.Text;
                    dm.VisitorAddress = txtAddressv.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorProofID = txtIDProof.Text.Replace("\n", "<br />").Replace("'", "^");
                }
                else
                {
                    dm.SignInSlip = false;
                }
                dm.Date = txtDate.Text;
                dm.TimeH = ddlHour.SelectedItem.Value;
                dm.TimeM = ddlMinutes.SelectedItem.Value;
                dm.TxtTimeH = ddlHour.SelectedItem.Text;
                dm.TxtTimeM = ddlMinutes.SelectedItem.Text;
                dm.LocationList = Location;
                dm.LocationOther = txtLocationOther.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.LocationMachine = txtLocationMachine.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.EventType = EventType;
                dm.EventTypeOtherDesc = txtEventOthers.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.FirstName = txtFirstName.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.LastName = txtLastName.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PartyType = ddlPartyType.SelectedItem.Value;
                dm.RGONotifiedList = RGONotified;
                dm.RGONotifiedOther = txtRGONotifiedOther.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PatronsSignsList = PatronSigns;
                dm.PatronSignsOther = txtPatronSignsOther.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.InitialActionList = InitialAction;
                dm.AlertResponseList = AlertResponse;
                dm.PatronResponseList = PatronResponse;
                dm.EventOutcomeList = EventOutcome;
                dm.EventOutcomeFurtherComments = txtFurtherComments.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.WitnessRecorded = cbWitnessRecorded.Checked;
                dm.WitnessDetails = txtWitnessDetails.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PoliceNotified = cbPoliceRecorded.Checked;
                dm.PoliceDetails = txtPoliceDetails.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.IncidentReportCompleted = cbIncidentReportCompleted.Checked;
                dm.AssistedCompletingIncidentReport = cbAssistedCompletingIncidentReport.Checked;

                dc.Report_ClubUminaRGOs.InsertOnSubmit(dm);
                dc.SubmitChanges();
            }

            //Reset the Player Id Global Variables
            ReportResponsibleGamingOfficerCu.PlayerId = "";

            SearchReport.CreateReport = ""; // reset this variable to set ddlCreateReport to default value

            // set the updated user signature string
            string updateUserSign = UserCredentials.DisplayName + " " + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:mm");

            // insert staff signature
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Report_ClubUminaRGO SET StaffSign='" + updateUserSign + "' WHERE ReportId='" + Report.LastReportId + "' AND AuditVersion='1'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Report Submitted.'); window.location='" +
            Request.ApplicationPath + "Default.aspx';", true);
            SearchReport.SetAccordion = "1";
            SearchReport.RunOnStart = true;
            SearchReport.FromCreateReport = true;

            HideUserSign();
        }
    }

    protected void btnCancelUserSign_Click(object sender, EventArgs e)
    {
        HideUserSign();
    }

    protected void HideUserSign()
    {
        body.Style.Add("opacity", "1");
        userSign.Visible = false;

        btnSubmit.Enabled = true;
        btnReset.Enabled = true;
        btnSign.Enabled = true;
    }

    protected void btnSign_Click(object sender, EventArgs e)
    {
        //body.Style.Add("opacity", "0.15");
        userSign.Visible = true;
        cbUserSign.Checked = false;

        btnSubmit.Enabled = false;
        btnReset.Enabled = false;
        btnSign.Enabled = false;
    }
}