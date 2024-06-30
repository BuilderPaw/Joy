using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Responsible_Gaming_Officer_Edit_v1_v1 : System.Web.UI.UserControl
{
    SqlConnection connRptPrg = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection connAdv = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdvantageDb"].ConnectionString);
    byte[] memberPhoto = null;
    AlertMessage alert = new AlertMessage();

    // on initial postback, reads the stored fields in the database
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Report.PopulateFields) // checks whether or not the method reads the fields from the database
        {
            // add the check box items for Location List
            List_Location.Items.Clear();

            // add the check box items for RGO Notified List
            List_RGONotified.Items.Clear();

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

            // add the check box items for Initial Action List
            List_InitialAction.Items.Clear();

            // add the check box items for 3hr Alert Response List
            List_3hrAlertResponse.Items.Clear();

            // add the check box items for Patron Response List
            List_PatronResponse.Items.Clear();

            // add the check box items for Event Outcome List
            List_EventOutcome.Items.Clear();

            ReadFields(Report.ActiveReport, "GetFields");
            Report.PopulateFields = false;

            // validate objects in the form
            bool returnedValue = checkFields();
            if (returnedValue == true)
            {
                return;
            }
        }
    }

    // validates form, calls validatePersonForm method, error message gets displayed once update button is selected
    protected bool validateForm()
    {
        bool returnedFlag = false;
        int result;
        DateTime temp;
        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        /* General Report Form */
        if (ddlShift.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";

            returnedFlag = true;
        }
        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";

            returnedFlag = true;
        }
        if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";

            returnedFlag = true;
        }
        else
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                returnedFlag = true;
            }
        }

        if (cbPatronDetailsRecorded.Checked)
        {
            bool returnedFlag1 = validatePersonForm();
            if (returnedFlag == true || returnedFlag1 == true)
            {
                returnedFlag = true;
            }
        }

        // General Report Form
        if (txtDate.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incident Date shouldn't be empty.";

            returnedFlag = true;
        }
        if (!DateTime.TryParse(txtDate.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incidents Date entry is not in date format please select an appropriate date.";

            returnedFlag = true;
        }
        else
        {
            DateTime date1 = DateTime.Parse(DateTime.Parse(txtDate.Text).ToShortDateString());
            // compare selected date to current date
            result = DateTime.Compare(date1, date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                returnedFlag = true;
            }
        }

        if (ddlHour.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour of the report.";

            returnedFlag = true;
        }
        if (ddlMinutes.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes of the report.";

            returnedFlag = true;
        }
        if (List_EventType.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select at least one event type.";
            List_EventType.Focus();
            returnedFlag = true;
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
                        returnedFlag = true;
                    }
                }
            }
        }

        if (List_Location.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the location of event.";
            List_Location.Focus();
            returnedFlag = true;
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
                            returnedFlag = true;
                        }
                    }
                }
            }
        }

        if (List_RGONotified.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select how you were notified of the event.";
            List_RGONotified.Focus();
            returnedFlag = true;
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
                returnedFlag = true;
            }
        }
        if (List_InitialAction.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select what was the initial action taken.";
            List_InitialAction.Focus();
            returnedFlag = true;
        }
        if (List_3hrAlertResponse.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select what at least one selection from club's gaming break options.";
            List_3hrAlertResponse.Focus();
            returnedFlag = true;
        }
        if (List_PatronResponse.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select how did the patron respond.";
            List_PatronResponse.Focus();
            returnedFlag = true;
        }

        if (List_EventOutcome.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the final event outcome.";
            List_EventOutcome.Focus();
            returnedFlag = true;
        }

        if (cbIncidentReportCompleted.Checked == false)
        {
            if (List_PatronSigns_StrongWarningSigns_LengthOfPlay.SelectedValue != String.Empty || List_PatronSigns_StrongWarningSigns_Money.SelectedValue != String.Empty || 
                List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.SelectedValue != String.Empty || List_PatronSigns_StrongWarningSigns_SocialBehaviours.SelectedValue != String.Empty)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                cbIncidentReportCompleted.Focus();
                returnedFlag = true;
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
                        returnedFlag = true;
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
                            returnedFlag = true;
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
                            returnedFlag = true;
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
                            returnedFlag = true;
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
                            returnedFlag = true;
                            break;
                        }
                    }
                    if (item.ToString() == "Self-exclusion completed")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = true;
                            break;
                        }
                    }
                    if (item.ToString() == "Patron was asked to leave the premises")
                    {
                        if (item.Selected)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                            cbIncidentReportCompleted.Focus();
                            returnedFlag = true;
                            break;
                        }
                    }
                }
            }
        }

        if (cbAssistedCompletingIncidentReport.Checked == true)
        {
            if (cbIncidentReportCompleted.Checked == false)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Event indicated requires DM escalation.";
                cbIncidentReportCompleted.Focus();
                returnedFlag = true;
            }
        }
        return returnedFlag;
    }
    protected bool validatePersonForm()
    {
        DateTime temp;
        bool returnedFlag = false;
        int result;

        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        if (!Report.HasMember)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Member Not Found! Please enter another Member Number.";
            returnedFlag = true;
        }

        // Person 1
        if (ddlPartyType.SelectedItem.Value == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for patron.";
            returnedFlag = true;
        }

        if (ddlPartyType.SelectedItem.Value == "1")
        {
            if (txtMemberNo.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Member Number.";
                returnedFlag = true;
            }
            if (txtAddress.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for member.";
                returnedFlag = true;
            }
            if (txtDOB.Text != "")
            {
                if (!DateTime.TryParse(txtDOB.Text, out temp))
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's DOB is not in date format please select an appropriate date.";
                    returnedFlag = true;
                }
                else
                {
                    // compare selected date to current date
                    result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOB.Text).ToShortDateString()), date);
                    if (result > 0)
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                        returnedFlag = true;
                    }
                }
            }
        }
        if (ddlPartyType.SelectedItem.Value == "2")
        {
            if (cbSignInSlip.Checked == true)
            {
                if (txtSignInBy.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who signed in visitor.";
                    returnedFlag = true;
                }
            }
            if (txtIDProof.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Proof of Identity for visitor.";
                returnedFlag = true;
            }
            if (txtAddressv.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for visitor.";
                returnedFlag = true;
            }
            if (txtDOBv.Text != "")
            {
                if (!DateTime.TryParse(txtDOBv.Text, out temp))
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Visitor's DOB is not in date format please select an appropriate date.";
                    returnedFlag = true;
                }
                else
                {
                    // compare selected date to current date
                    result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOBv.Text).ToShortDateString()), date);
                    if (result > 0)
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                        returnedFlag = true;
                    }
                }
            }
        }

        return returnedFlag;
    }

    // reads the fields in the database
    protected void ReadFields(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand(sqlCommand, connRptPrg);

        if (method.Equals("SearchMember")) // if method is to search a member use the advantage connection
        {
            cmd = new SqlCommand(sqlCommand, connAdv);
        }
        else // use the local database connection
        {
            cmd = new SqlCommand(sqlCommand, connRptPrg);
        }

        try
        {
            if (method.Equals("SearchMember")) // if method is to search a member open the advantage connection
            {
                connAdv.Open();
            }
            else // open the local database connection
            {
                connRptPrg.Open();
            }

            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (method.Equals("GetFields"))
                    {
                        //lblReportName.Text = rdr["ReportName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        lblReportId.Text = rdr["ReportId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        lblStaffName.Text = rdr["StaffName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        Report.SelectedStaffId = rdr["StaffId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlShift.SelectedIndex = Int32.Parse(rdr["ShiftId"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        Report.ShiftId = ddlShift.SelectedIndex.ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtDatePicker.Text = Convert.ToDateTime(rdr["ShiftDate"]).ToString("dddd, dd MMMM yyyy");
                        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString().Replace("<br />", "\n").Replace("^", "'");
                        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString().Replace("<br />", "\n").Replace("^", "'")).DayOfWeek.ToString().Replace("<br />", "\n").Replace("^", "'");
                        lblEntryDetails.Text = Convert.ToDateTime(rdr["EntryDate"]).ToString("dd/MM/yyyy HH:mm");
                        Report.EntryDate = Convert.ToDateTime(rdr["EntryDate"]).ToString().Replace("<br />", "\n").Replace("^", "'");

                        cbPatronDetailsRecorded.Checked = Convert.ToBoolean(rdr["PatronDetailsRecorded"]);
                        if (cbPatronDetailsRecorded.Checked == true)
                        {
                            tblPerson1.Visible = true;
                            /* Patron Details */
                            txtFirstName.Text = rdr["FirstName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtLastName.Text = rdr["LastName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtContact.Text = rdr["Contact"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAlias.Text = rdr["Alias"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            ddlPartyType.SelectedIndex = Int32.Parse(rdr["PartyType"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                            if (ddlPartyType.SelectedItem.Value == "1") // if person is a member, don't allow user to edit the following objects
                            {
                                txtFirstName.Enabled = false;
                                txtLastName.Enabled = false;
                                txtDOB.Enabled = false;

                                // member's fields
                                ReportResponsibleGamingOfficerMr.PlayerId = rdr["PlayerId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                txtMemberNo.Text = rdr["MemberNo"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                txtDOB.Text = rdr["MemberDOB"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                txtAddress.Text = rdr["MemberAddress"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                txtMemberSince.Text = rdr["MemberSince"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            }
                            if (ddlPartyType.SelectedItem.Value == "2") // if person is a visitor read following objects
                            {
                                // visitor's fields
                                cbSignInSlip.Checked = Convert.ToBoolean(rdr["SignInSlip"]);
                                txtSignInBy.Text = rdr["SignedInBy"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                txtDOBv.Text = rdr["VisitorDOB"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                txtIDProof.Text = rdr["VisitorProofID"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                txtAddressv.Text = rdr["VisitorAddress"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            }

                            try // set Member Photo
                            {
                                if ((byte[])rdr["MemberPhoto"] != null)
                                {
                                    memberPhoto = (byte[])rdr["MemberPhoto"];
                                    ReportResponsibleGamingOfficerMr.MemberPhoto = memberPhoto; // set global variable to current member photo
                                }
                            }
                            catch
                            {
                                memberPhoto = null;
                                ReportResponsibleGamingOfficerMr.MemberPhoto = memberPhoto; // set global variable to current member photo
                            }
                            if (memberPhoto != null && memberPhoto.Length > 0)
                            {
                                string strBase64 = Convert.ToBase64String(memberPhoto, 0, memberPhoto.Length);
                                imgMember.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            else
                            {
                                imgMember.ImageUrl = "~/Images/no-image.png";
                            }

                            if (rdr["PartyType"].ToString() == "1")
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
                            }
                            else if (rdr["PartyType"].ToString() == "2")
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
                            }
                        }
                        else
                        {
                            tblPerson1.Visible = false;
                        }

                        txtDate.Text = rdr["Date"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlHour.SelectedIndex = Int32.Parse(rdr["TimeH"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlMinutes.SelectedIndex = Int32.Parse(rdr["TimeM"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        // tick the checkbox selected for event type
                        string[] arrayEventType = rdr["EventType"].ToString().Replace("<br />", "\n").Replace("^", "'").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_EventType.Items)
                        {
                            for (int i = 0; i < arrayEventType.Length; i++)
                            {
                                if (arrayEventType[i].ToString().Replace("<br />", "\n").Replace("^", "'").Equals(item.Value))
                                {
                                    item.Selected = true;

                                    // show hidden fields if selected
                                    if (item.ToString().Replace("<br />", "\n").Replace("^", "'") == "Other")
                                    {
                                        if (item.Selected)
                                        {
                                            // check if event type:other textbox is not empty
                                            if (!String.IsNullOrEmpty(rdr["EventTypeOtherDesc"].ToString().Replace("<br />", "\n").Replace("^", "'")))
                                            {
                                                treventTypeOther.Visible = true;
                                                treventTypeOther1.Visible = true;
                                                txtEventOthers.Text = rdr["EventTypeOtherDesc"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // add the check box items for Location List
                        List_Location.Items.Clear();
                        using (SqlCommand command = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            cmd.Connection = connection;
                            connection.Open();
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
                            connection.Close();
                        }

                        // check items selected in Location List check box list
                        string[] arrayLocation = rdr["LocationList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_Location.Items)
                        {
                            for (int i = 0; i < arrayLocation.Length; i++)
                            {
                                if (arrayLocation[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                    if (item.ToString() == "Other")
                                    {
                                        if (item.Selected)
                                        {
                                            otherLocation.Visible = true;
                                            txtLocationOther.Visible = true;
                                            txtLocationOther.Text = rdr["LocationOther"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                        }
                                    }
                                }
                            }
                        }

                        txtLocationMachine.Text = rdr["LocationMachine"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        // add the check box items for RGO Notified List
                        using (SqlCommand command = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM [dbo].[List_RGONotified] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            cmd.Connection = connection;
                            connection.Open();
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
                            connection.Close();
                        }

                        // check items selected in RGO Notified List check box list
                        string[] arrayRGONotified = rdr["RGONotifiedList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_RGONotified.Items)
                        {
                            for (int i = 0; i < arrayRGONotified.Length; i++)
                            {
                                if (arrayRGONotified[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        txtRGONotifiedOther.Text = rdr["RGONotifiedOther"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_GeneralWarningSigns_Money.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_ProbableWarningSigns_LengthOfPlay.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_ProbableWarningSigns_Money.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Social behaviours' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_ProbableWarningSigns_SocialBehaviours.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_StrongWarningSigns_LengthOfPlay.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_StrongWarningSigns_Money.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.Items.Add(item);
                                }
                            }
                            connection.Close();

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 1 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Social behaviours' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronSignsID"].ToString();
                                    List_PatronSigns_StrongWarningSigns_SocialBehaviours.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        // check items selected in the check box list
                        string[] arrayPatronSignsGeneralWarningSignsLengthOfPlay = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsGeneralWarningSignsLengthOfPlay.Length; i++)
                            {
                                if (arrayPatronSignsGeneralWarningSignsLengthOfPlay[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsGeneralWarningSignsMoney = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_Money.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsGeneralWarningSignsMoney.Length; i++)
                            {
                                if (arrayPatronSignsGeneralWarningSignsMoney[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsGeneralWarningSignsBehaviourDuringPlay = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsGeneralWarningSignsBehaviourDuringPlay.Length; i++)
                            {
                                if (arrayPatronSignsGeneralWarningSignsBehaviourDuringPlay[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsProbableWarningSignsLengthOfPlay = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_LengthOfPlay.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsProbableWarningSignsLengthOfPlay.Length; i++)
                            {
                                if (arrayPatronSignsProbableWarningSignsLengthOfPlay[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsProbableWarningSignsMoney = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_Money.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsProbableWarningSignsMoney.Length; i++)
                            {
                                if (arrayPatronSignsProbableWarningSignsMoney[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsProbableWarningSignsBehaviourDuringPlay = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsProbableWarningSignsBehaviourDuringPlay.Length; i++)
                            {
                                if (arrayPatronSignsProbableWarningSignsBehaviourDuringPlay[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsProbableWarningSignsSocialBehaviours = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_SocialBehaviours.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsProbableWarningSignsSocialBehaviours.Length; i++)
                            {
                                if (arrayPatronSignsProbableWarningSignsSocialBehaviours[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsStrongWarningSignsLengthOfPlay = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_LengthOfPlay.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsStrongWarningSignsLengthOfPlay.Length; i++)
                            {
                                if (arrayPatronSignsStrongWarningSignsLengthOfPlay[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsStrongWarningSignsMoney = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_Money.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsStrongWarningSignsMoney.Length; i++)
                            {
                                if (arrayPatronSignsStrongWarningSignsMoney[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsStrongWarningSignsBehaviourDuringPlay = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsStrongWarningSignsBehaviourDuringPlay.Length; i++)
                            {
                                if (arrayPatronSignsStrongWarningSignsBehaviourDuringPlay[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        string[] arrayPatronSignsStrongWarningSignsSocialBehaviours = rdr["PatronsSignsList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_SocialBehaviours.Items)
                        {
                            for (int i = 0; i < arrayPatronSignsStrongWarningSignsSocialBehaviours.Length; i++)
                            {
                                if (arrayPatronSignsStrongWarningSignsSocialBehaviours[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        txtPatronSignsOther.Text = rdr["PatronSignsOther"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        // get and set check box list items for initial actions taken in the event
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_InitialAction] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["InitialActionID"].ToString();
                                    List_InitialAction.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        // check items selected in Initial Action check box list
                        string[] arrayInitialAction = rdr["InitialActionList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_InitialAction.Items)
                        {
                            for (int i = 0; i < arrayInitialAction.Length; i++)
                            {
                                if (arrayInitialAction[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        // add the check box items for 3hr Alert Response List
                        using (SqlCommand command = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM [dbo].[List_3hrsAlertResponse] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                            cmd.Connection = connection;
                            connection.Open();
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
                            connection.Close();
                        }

                        // check items selected in 3hr Alert Response List check box list
                        string[] arrayAlertResponseList = rdr["AlertResponseList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_3hrAlertResponse.Items)
                        {
                            for (int i = 0; i < arrayAlertResponseList.Length; i++)
                            {
                                if (arrayAlertResponseList[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        List_PatronResponse.Items.Clear(); // clear any items set in the check box list
                        // get and set check box list items for patron responses in the event
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_PatronResponse] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["PatronResponseID"].ToString();
                                    List_PatronResponse.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        // check items selected in Patron Response check box list
                        string[] arrayPatronResponse = rdr["PatronResponseList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_PatronResponse.Items)
                        {
                            for (int i = 0; i < arrayPatronResponse.Length; i++)
                            {
                                if (arrayPatronResponse[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        List_EventOutcome.Items.Clear(); // clear any items set in the check box list
                        // get and set check box list items for the event outcome
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_EventOutcome] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["EventOutcomeID"].ToString();
                                    List_EventOutcome.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        // check items selected in Event Outcome check box list
                        string[] arrayEventOutcome = rdr["EventOutcomeList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_EventOutcome.Items)
                        {
                            for (int i = 0; i < arrayEventOutcome.Length; i++)
                            {
                                if (arrayEventOutcome[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        txtFurtherComments.Text = rdr["EventOutcomeFurtherComments"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        cbWitnessRecorded.Checked = Convert.ToBoolean(rdr["WitnessRecorded"]);
                        txtWitnessDetails.Text = rdr["WitnessDetails"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        cbPoliceRecorded.Checked = Convert.ToBoolean(rdr["PoliceNotified"]);
                        txtPoliceDetails.Text = rdr["PoliceDetails"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        if (Convert.ToBoolean(rdr["WitnessRecorded"]) == true)
                        {
                            witness.Visible = true;
                            witness1.Visible = true;
                        }
                        if (Convert.ToBoolean(rdr["PoliceNotified"]) == true)
                        {
                            police.Visible = true;
                            police1.Visible = true;
                        }

                        cbIncidentReportCompleted.Checked = Convert.ToBoolean(rdr["IncidentReportCompleted"]);
                        cbAssistedCompletingIncidentReport.Checked = Convert.ToBoolean(rdr["AssitedCompletingIncidentReport"]);

                    }
                    if (method.Equals("SearchMember")) // Get the Member Details from IGT Advantage Database
                    {
                        Report.HasMember = true;
                        ReportResponsibleGamingOfficerMr.PlayerId = rdr["PlayerId"].ToString();
                        ReportResponsibleGamingOfficerMr.ViewPlayerId = rdr["PlayerId"].ToString();
                        txtFirstName.Text = rdr["FirstName"].ToString();
                        txtLastName.Text = rdr["LastName"].ToString();
                        txtAddress.Text = rdr["Address"].ToString();
                        txtDOB.Text = rdr["Birthday"].ToString();
                        txtMemberSince.Text = rdr["MemberSince"].ToString();
                        txtContact.Text = rdr["Contact"].ToString();
                        try
                        {
                            memberPhoto = (byte[])rdr["PlayerImage"];
                            string strBase64 = Convert.ToBase64String(memberPhoto, 0, memberPhoto.Length); // load image from database
                            imgMember.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        catch
                        {
                            memberPhoto = null;
                            imgMember.ImageUrl = "~/Images/no-image.png";
                        }

                        ReportResponsibleGamingOfficerMr.MemberPhoto = memberPhoto; // set global variable to current member photo
                    }
                    if (method.Equals("CheckChanges")) // check if there are any changes made in the report
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
                        if (ReportResponsibleGamingOfficerMr.EventType.ToString() != rdr["EventType"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "EventType";
                        }
                        if (ReportResponsibleGamingOfficerMr.EventTypeOther.ToString() != rdr["EventTypeOtherDesc"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "EventTypeOther";
                        }
                        if (ReportResponsibleGamingOfficerMr.EventTypeOther.ToString() != rdr["EventTypeOtherDesc"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "EventTypeOther";
                        }
                        if (ReportResponsibleGamingOfficerMr.RGONotifiedOther.ToString() != rdr["RGONotifiedOther"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "RGONotifiedOther";
                        }
                        if (ReportResponsibleGamingOfficerMr.PatronDetailsRecorded.ToString().ToLower() != Convert.ToBoolean(rdr["PatronDetailsRecorded"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PatronDetailsRecorded";
                        }
                        if (ReportResponsibleGamingOfficerMr.PartyType.ToString() != rdr["PartyType"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PartyType";
                        }
                        if (ReportResponsibleGamingOfficerMr.TxtPartyType.ToString() != rdr["TxtPartyType"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TxtPartyType";
                        }
                        if (ReportResponsibleGamingOfficerMr.PlayerId.ToString() != rdr["PlayerId"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PlayerId";
                        }
                        //if (ReportResponsibleGamingOfficerMr.MemberPhoto != (byte[])rdr["MemberPhoto"])
                        //{
                        //    Report.HasChange = true; flag = 1;
                        //    Report.WhereChangeHappened = "MemberPhoto";
                        //}
                        if (ReportResponsibleGamingOfficerMr.Member.ToString() != rdr["MemberNo"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MemberNumber";
                        }
                        if (ReportResponsibleGamingOfficerMr.First.ToString() != rdr["FirstName"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "FirstName";
                        }
                        if (ReportResponsibleGamingOfficerMr.Last.ToString() != rdr["LastName"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "LastName";
                        }
                        if (ReportResponsibleGamingOfficerMr.Alias.ToString() != rdr["Alias"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Alias";
                        }
                        if (ReportResponsibleGamingOfficerMr.Contact.ToString() != rdr["Contact"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Contact";
                        }
                        if (ReportResponsibleGamingOfficerMr.MemberSince.ToString() != rdr["MemberSince"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MemberSince";
                        }
                        if (ReportResponsibleGamingOfficerMr.MDOB.ToString() != rdr["MemberDOB"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MemberDOB";
                        }
                        if (ReportResponsibleGamingOfficerMr.MAddress.ToString() != rdr["MemberAddress"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MAddress";
                        }
                        if (ReportResponsibleGamingOfficerMr.SignInSlip.ToString().ToLower() != Convert.ToBoolean(rdr["SignInSlip"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInSlip";
                        }
                        if (ReportResponsibleGamingOfficerMr.SignInBy.ToString() != rdr["SignedInBy"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInBy";
                        }
                        if (ReportResponsibleGamingOfficerMr.VDOB.ToString() != rdr["VisitorDOB"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VisitorDOB";
                        }
                        if (ReportResponsibleGamingOfficerMr.VProofID.ToString() != rdr["VisitorProofID"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VProofID";
                        }
                        if (ReportResponsibleGamingOfficerMr.VAddress.ToString() != rdr["VisitorAddress"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VAddress";
                        }
                        if (ReportResponsibleGamingOfficerMr.Date.ToString() != rdr["Date"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Date";
                        }
                        if (ReportResponsibleGamingOfficerMr.Hour.ToString() != rdr["TimeH"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TimeH";
                        }
                        if (ReportResponsibleGamingOfficerMr.Minute.ToString() != rdr["TimeM"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TimeM";
                        }
                        if (ReportResponsibleGamingOfficerMr.LocationList.ToString() != rdr["LocationList"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "LocationList";
                        }
                        if (ReportResponsibleGamingOfficerMr.LocationOther.ToString() != rdr["LocationOther"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "LocationOther";
                        }
                        if (ReportResponsibleGamingOfficerMr.LocationMachine.ToString() != rdr["LocationMachine"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "LocationMachine";
                        }
                        if (ReportResponsibleGamingOfficerMr.RGONotifiedList.ToString() != rdr["RGONotifiedList"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "RGONotifiedList";
                        }
                        if (ReportResponsibleGamingOfficerMr.PatronSignsOther.ToString() != rdr["PatronSignsOther"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PatronSignsOther";
                        }
                        if (ReportResponsibleGamingOfficerMr.PatronsSignsList.ToString() != rdr["PatronsSignsList"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PatronsSignsList";
                        }
                        if (ReportResponsibleGamingOfficerMr.InitialActionList.ToString() != rdr["InitialActionList"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "InitialActionList";
                        }
                        if (ReportResponsibleGamingOfficerMr.AlertResponseList.ToString() != rdr["AlertResponseList"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AlertResponseList";
                        }
                        if (ReportResponsibleGamingOfficerMr.PatronResponseList.ToString() != rdr["PatronResponseList"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PatronResponseList";
                        }
                        if (ReportResponsibleGamingOfficerMr.EventOutcomeList.ToString() != rdr["EventOutcomeList"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "EventOutcomeList";
                        }
                        if (ReportResponsibleGamingOfficerMr.EventOutcomeFurtherComments.ToString() != rdr["EventOutcomeFurtherComments"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "EventOutcomeFurtherComments";
                        }
                        if (ReportResponsibleGamingOfficerMr.WitnessRecorded.ToString().ToLower() != Convert.ToBoolean(rdr["WitnessRecorded"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "WitnessRecorded";
                        }
                        if (ReportResponsibleGamingOfficerMr.WitnessDetails.ToString() != rdr["WitnessDetails"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "WitnessDetails";
                        }
                        if (ReportResponsibleGamingOfficerMr.PoliceNotified.ToString().ToLower() != Convert.ToBoolean(rdr["PoliceNotified"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PoliceNotified";
                        }
                        if (ReportResponsibleGamingOfficerMr.PoliceDetails.ToString() != rdr["PoliceDetails"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PoliceDetails";
                        }
                        if (ReportResponsibleGamingOfficerMr.IncidentReportCompleted.ToString().ToLower() != Convert.ToBoolean(rdr["IncidentReportCompleted"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "IncidentReportCompleted";
                        }
                        if (ReportResponsibleGamingOfficerMr.AssistedCompletingIncidentReport.ToString().ToLower() != Convert.ToBoolean(rdr["AssistedCompletingIncidentReport"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AssistedCompletingIncidentReport";
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
            else // there's nothing to read, the entered membership number is not found / doesn't exist
            {
                if (method.Equals("SearchMember")) // reset member fields
                {
                    Report.HasMember = false;
                    ReportResponsibleGamingOfficerMr.PlayerId = "";
                    ReportResponsibleGamingOfficerMr.ViewPlayerId = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtAddress.Text = "";
                    txtDOB.Text = "";
                    txtMemberSince.Text = "";
                    txtContact.Text = "";
                    imgMember.ImageUrl = "~/Images/white-background.png";
                    ReportResponsibleGamingOfficerMr.MemberPhoto = null; // set global variable to current member photo                       
                    alert.DisplayMessage("Member Not Found!");
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
            if (method.Equals("SearchMember"))
            {
                if (connAdv != null)
                {
                    connAdv.Close();
                }
            }
            else
            {
                if (connRptPrg != null)
                {
                    connRptPrg.Close();
                }
            }
        }
        // set the Global variables to the current fields
        setGlobalVar();
        Report.RunEditMode = true;
    }

    // stores field data in global variables
    protected void setGlobalVar()
    {
        Report.ShiftId = ddlShift.SelectedItem.Value;
        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string eventType;
        List<String> eventTypeList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_EventType.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                eventTypeList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        eventType = String.Join(",", eventTypeList.ToArray());
        List<string> uniqueEventType = eventType.Split(',').Distinct().ToList(); // to remove duplicate values
        eventType = string.Join(",", uniqueEventType);
        if (!eventType.Equals(""))
        {
            eventType += ",";
        }

        ReportResponsibleGamingOfficerMr.EventType = eventType;
        ReportResponsibleGamingOfficerMr.EventTypeOther = txtEventOthers.Text.Replace("'", "^");
        ReportResponsibleGamingOfficerMr.RGONotifiedOther = txtRGONotifiedOther.Text.Replace("'", "^");

        ReportResponsibleGamingOfficerMr.PatronDetailsRecorded = cbPatronDetailsRecorded.Checked.ToString();

        ReportResponsibleGamingOfficerMr.First = txtFirstName.Text.Replace("'", "^");
        ReportResponsibleGamingOfficerMr.Last = txtLastName.Text.Replace("'", "^");
        ReportResponsibleGamingOfficerMr.Alias = txtAlias.Text.Replace("'", "^");
        ReportResponsibleGamingOfficerMr.Contact = txtContact.Text.Replace("'", "^");
        ReportResponsibleGamingOfficerMr.PartyType = ddlPartyType.SelectedItem.Value;
        ReportResponsibleGamingOfficerMr.TxtPartyType = ddlPartyType.SelectedItem.Text;
        if (ddlPartyType.SelectedItem.Value == "1")
        {
            ReportResponsibleGamingOfficerMr.Member = txtMemberNo.Text.Replace("'", "^");
            ReportResponsibleGamingOfficerMr.MDOB = txtDOB.Text;
            ReportResponsibleGamingOfficerMr.MemberSince = txtMemberSince.Text;
            ReportResponsibleGamingOfficerMr.MAddress = txtAddress.Text.Replace("'", "^");
            ReportResponsibleGamingOfficerMr.SignInSlip = "false";

            // clear Visitor selection
            ReportResponsibleGamingOfficerMr.SignInBy = "";
            ReportResponsibleGamingOfficerMr.VDOB = "";
            ReportResponsibleGamingOfficerMr.VAddress = "";
            ReportResponsibleGamingOfficerMr.VProofID = "";
        }
        else if (ddlPartyType.SelectedItem.Value == "2")
        {
            ReportResponsibleGamingOfficerMr.SignInSlip = cbSignInSlip.Checked.ToString();
            ReportResponsibleGamingOfficerMr.SignInBy = txtSignInBy.Text.Replace("'", "^");
            ReportResponsibleGamingOfficerMr.VDOB = txtDOBv.Text;
            ReportResponsibleGamingOfficerMr.VAddress = txtAddressv.Text.Replace("'", "^");
            ReportResponsibleGamingOfficerMr.VProofID = txtIDProof.Text.Replace("'", "^");

            // clear Member selection
            ReportResponsibleGamingOfficerMr.Member = "";
            ReportResponsibleGamingOfficerMr.MDOB = "";
            ReportResponsibleGamingOfficerMr.MAddress = "";
            ReportResponsibleGamingOfficerMr.MemberSince = "";
        }
        else
        {
            // clear Member and Visitor selections
            ReportResponsibleGamingOfficerMr.Member = "";
            ReportResponsibleGamingOfficerMr.MDOB = "";
            ReportResponsibleGamingOfficerMr.MAddress = "";
            ReportResponsibleGamingOfficerMr.MemberSince = "";

            ReportResponsibleGamingOfficerMr.SignInBy = "";
            ReportResponsibleGamingOfficerMr.SignInSlip = "false";
            ReportResponsibleGamingOfficerMr.VDOB = "";
            ReportResponsibleGamingOfficerMr.VAddress = "";
            ReportResponsibleGamingOfficerMr.VProofID = "";
        }

        ReportResponsibleGamingOfficerMr.Date = txtDate.Text;
        ReportResponsibleGamingOfficerMr.TxtTimeH = ddlHour.SelectedItem.Text;
        ReportResponsibleGamingOfficerMr.Hour = ddlHour.SelectedItem.Value;
        ReportResponsibleGamingOfficerMr.TxtTimeM = ddlMinutes.SelectedItem.Text;
        ReportResponsibleGamingOfficerMr.Minute = ddlMinutes.SelectedItem.Value;

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string location;
        List<String> locationList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_Location.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                locationList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        location = String.Join(",", locationList.ToArray());
        List<string> uniquelocation = location.Split(',').Distinct().ToList(); // to remove duplicate values
        location = string.Join(",", uniquelocation);
        if (!location.Equals(""))
        {
            location += ",";
        }

        ReportResponsibleGamingOfficerMr.LocationList = location;
        ReportResponsibleGamingOfficerMr.LocationOther = txtLocationOther.Text.Replace("'", "^");
        ReportResponsibleGamingOfficerMr.LocationMachine = txtLocationMachine.Text.Replace("'", "^");

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string rgoNotified;
        List<String> rgoNotifiedList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_RGONotified.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                rgoNotifiedList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        rgoNotified = String.Join(",", rgoNotifiedList.ToArray());
        List<string> uniqueRGONotified = rgoNotified.Split(',').Distinct().ToList(); // to remove duplicate values
        rgoNotified = string.Join(",", uniqueRGONotified);
        if (!rgoNotified.Equals(""))
        {
            rgoNotified += ",";
        }

        ReportResponsibleGamingOfficerMr.RGONotifiedList = rgoNotified;
        ReportResponsibleGamingOfficerMr.RGONotifiedOther = txtRGONotifiedOther.Text.Replace("'", "^");

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string patronSigns;
        List<String> patronSignsList = new List<string>();
        // Loop through each item for each of the check box list.
        foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_LengthOfPlay.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_Money.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_LengthOfPlay.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_Money.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_ProbableWarningSigns_SocialBehaviours.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_LengthOfPlay.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_Money.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }
        foreach (ListItem item in List_PatronSigns_StrongWarningSigns_SocialBehaviours.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronSignsList.Add(item.Value);
            }
        }

        // Join the string together using the ; delimiter.
        patronSigns = String.Join(",", patronSignsList.ToArray());
        List<string> uniquePatronSigns = patronSigns.Split(',').Distinct().ToList(); // to remove duplicate values
        patronSigns = string.Join(",", uniquePatronSigns);
        if (!patronSigns.Equals(""))
        {
            patronSigns += ",";
        }

        ReportResponsibleGamingOfficerMr.PatronsSignsList = patronSigns;
        ReportResponsibleGamingOfficerMr.PatronSignsOther = txtPatronSignsOther.Text.Replace("'", "^");

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string initialAction;
        List<String> initialActionList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_InitialAction.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                initialActionList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        initialAction = String.Join(",", initialActionList.ToArray());
        List<string> uniqueInitialAction = initialAction.Split(',').Distinct().ToList(); // to remove duplicate values
        initialAction = string.Join(",", uniqueInitialAction);
        if (!initialAction.Equals(""))
        {
            initialAction += ",";
        }

        ReportResponsibleGamingOfficerMr.InitialActionList = initialAction;

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string alertResponse;
        List<String> alertResponseList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_3hrAlertResponse.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                alertResponseList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        alertResponse = String.Join(",", alertResponseList.ToArray());
        List<string> uniqueAlertResponse = alertResponse.Split(',').Distinct().ToList(); // to remove duplicate values
        alertResponse = string.Join(",", uniqueAlertResponse);
        if (!alertResponse.Equals(""))
        {
            alertResponse += ",";
        }

        ReportResponsibleGamingOfficerMr.AlertResponseList = alertResponse;

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string patronResponse;
        List<String> patronResponseList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_PatronResponse.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                patronResponseList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        patronResponse = String.Join(",", patronResponseList.ToArray());
        List<string> uniquePatronResponse = patronResponse.Split(',').Distinct().ToList(); // to remove duplicate values
        patronResponse = string.Join(",", uniquePatronResponse);
        if (!patronResponse.Equals(""))
        {
            patronResponse += ",";
        }

        ReportResponsibleGamingOfficerMr.PatronResponseList = patronResponse;

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string eventOutcome;
        List<String> eventOutcomeList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_EventOutcome.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                eventOutcomeList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        eventOutcome = String.Join(",", eventOutcomeList.ToArray());
        List<string> uniqueEventOutcome = eventOutcome.Split(',').Distinct().ToList(); // to remove duplicate values
        eventOutcome = string.Join(",", uniqueEventOutcome);
        if (!eventOutcome.Equals(""))
        {
            eventOutcome += ",";
        }

        ReportResponsibleGamingOfficerMr.EventOutcomeList = eventOutcome;
        ReportResponsibleGamingOfficerMr.EventOutcomeFurtherComments = txtFurtherComments.Text.Replace("\n", "<br />");

        ReportResponsibleGamingOfficerMr.WitnessRecorded = cbWitnessRecorded.Checked.ToString();
        ReportResponsibleGamingOfficerMr.WitnessDetails = txtWitnessDetails.Text.Replace("\n", "<br />");
        ReportResponsibleGamingOfficerMr.PoliceNotified = cbPoliceRecorded.Checked.ToString();
        ReportResponsibleGamingOfficerMr.PoliceDetails = txtPoliceDetails.Text.Replace("\n", "<br />");

        ReportResponsibleGamingOfficerMr.IncidentReportCompleted = cbIncidentReportCompleted.Checked.ToString();
        ReportResponsibleGamingOfficerMr.AssistedCompletingIncidentReport = cbAssistedCompletingIncidentReport.Checked.ToString();

        if (Report.Status != "Awaiting Completion")
        {
            ReadFields(Report.ActiveReport, "CheckChanges");
        }
    }

    // stores the error message on a global variable
    protected void showAlert(string message)
    {
        message = "alert(\"" + message + "\");";
        //ReportIncidentMr.LastErrorMsg = message;
    }

    // show/hide Visitor, Member, and Staff's fields for Person forms
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
            ReportResponsibleGamingOfficerMr.SignInSlip = "false";
            ReportResponsibleGamingOfficerMr.SignInBy = "";
            ReportResponsibleGamingOfficerMr.VDOB = "";
            ReportResponsibleGamingOfficerMr.VProofID = "";
            ReportResponsibleGamingOfficerMr.VAddress = "";
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

            ReportResponsibleGamingOfficerMr.Member = "";
            ReportResponsibleGamingOfficerMr.MDOB = "";
            ReportResponsibleGamingOfficerMr.MemberSince = "";
            ReportResponsibleGamingOfficerMr.MAddress = "";
            ReportResponsibleGamingOfficerMr.MemberPhoto = null;
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

            ReportResponsibleGamingOfficerMr.Member = "";
            ReportResponsibleGamingOfficerMr.MDOB = "";
            ReportResponsibleGamingOfficerMr.MemberSince = "";
            ReportResponsibleGamingOfficerMr.MAddress = "";
            ReportResponsibleGamingOfficerMr.MemberPhoto = null;

            ReportResponsibleGamingOfficerMr.SignInSlip = "false";
            ReportResponsibleGamingOfficerMr.SignInBy = "";
            ReportResponsibleGamingOfficerMr.VDOB = "";
            ReportResponsibleGamingOfficerMr.VProofID = "";
            ReportResponsibleGamingOfficerMr.VAddress = "";

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

        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
 
    // generic text, selectedindex, check changed events
    protected void TextChanged_TextChanged(object sender, EventArgs e)
    {
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    // view/hide list of signs of problem gambling
    protected void cbPatronDetailsRecorded_CheckedChanged(object sender, EventArgs e)
    {
        if (cbPatronDetailsRecorded.Checked == true)
        {
            tblPerson1.Visible = true;
        }
        else
        {
            tblPerson1.Visible = false;
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }    
    protected void cbIncidentReportCompleted_CheckedChanged(object sender, EventArgs e)
    {
        if (cbIncidentReportCompleted.Checked == true)
        {
            trassistedcompletingincidentreport.Visible = true;
            trassistedcompletingincidentreport1.Visible = true;
        }
        else
        {
            trassistedcompletingincidentreport.Visible = false;
            trassistedcompletingincidentreport1.Visible = false;
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void cbWitnessRecorded_CheckedChanged(object sender, EventArgs e)
    {
        if (cbWitnessRecorded.Checked == true)
        {
            witness.Visible = true;
            witness1.Visible = true;
        }
        else
        {
            witness.Visible = false;
            witness1.Visible = false;
            txtWitnessDetails.Text = "";
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void cbPoliceRecorded_CheckedChanged(object sender, EventArgs e)
    {
        if (cbPoliceRecorded.Checked == true)
        {
            police.Visible = true;
            police1.Visible = true;
        }
        else
        {
            police.Visible = false;
            police1.Visible = false;
            txtPoliceDetails.Text = "";
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    // generic text, selectedindex, check changed events
    protected void MemberNo_TextChanged(object sender, EventArgs e)
    {
        string cmdQuery = SearchMember(txtMemberNo.Text);
        ReadFields(cmdQuery, "SearchMember");

        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
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

    protected void SelectedIndexChanged_SelectedIndexChanged(object sender, EventArgs e)
    {
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }

    protected void CheckChanged_CheckedChanged(object sender, EventArgs e)
    {
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }

    // runs validateForm method and sets global variables
    protected bool checkFields()
    {
        Report.ErrorMessage = ""; // stores the last known error message
        bool returnedValue = false;

        if (ddlShift.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";
            ddlShift.Focus();
            returnedValue = true;
        }

        // sets Returned Flag to either 1 or 2 (with / without error) and reloads editButton from Default.aspx
        if (returnedValue == true)
        {
            Report.HasErrorMessage = true; // does not trigger update query in Default because of the error
            return returnedValue;
        }
        else
        {
            Report.HasErrorMessage = false; // allows the update query to run (no errors)
            Report.ErrorMessage = ""; // stores the last known error message
        }

        bool returnedValue1 = validateForm();
        // sets Returned Flag to either 1 or 2 (with / without error) and reloads editButton from Default.aspx
        if (returnedValue1 == true)
        {
            Report.HasErrorMessage1 = true; // does not trigger update query in Default because of the error
        }
        else
        {
            Report.HasErrorMessage1 = false; // allows the update query to run (no errors)
            Report.ErrorMessage = ""; // stores the last known error message
        }
        Report.RunEditMode = true; // reloads editButton method from Default.aspx
        setGlobalVar(); // stores the objects data in a global variable

        return returnedValue;
    }
}