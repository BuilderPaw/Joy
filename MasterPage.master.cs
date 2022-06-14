using System;
using System.Collections.Generic;
using System.Data;          // CommandType
using System.Data.SqlClient;// SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Project follows Brad Adams Naming Convention Standard Guidelines - https://blogs.msdn.microsoft.com/brada/2005/01/26/internal-coding-guidelines/
/// Program uses static property encapsulated inside a public class - https://stackoverflow.com/questions/895595/how-do-i-persist-data-without-global-variables
/// "We should however look at the reasons why Globals are bad, and they are mostly regarded as bad because you break the rules of encapsulation.
///    Static data though, is not necesarrily bad, the good thing about static data is that you can encapsulate it, my example above is a very simplistic
///    example of that,
///    probably in a real world scenario you would include your static data in the same class that does other work with the credentials." - Tim Jarvis
/// </summary>

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    AlertMessage alert = new AlertMessage();

    protected void Page_Load(object sender, EventArgs e)
    {
        // show login prompt and hide header objects
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            // display the accordion when user has logged in
            accordion.Visible = true;
            username.Visible = true;
            imgBtnLogo.Visible = true;
        }
        else
        {
            // hide accordion on login page
            accordion.Visible = false;
            username.Visible = false;
            imgBtnLogo.Visible = false;
        }

        if (!IsPostBack)
        {
            // display an alert message if user has any existing unsigned report(s)
            if (UserCredentials.StaffId != "0")
            {
                if (Report.HasDisplayedUnsignedReport <3)
                {
                    con.Open();
                    SqlCommand count = new SqlCommand("Proc_CountUserUnsignedReports", con);
                    count.CommandType = CommandType.StoredProcedure;
                    count.Parameters.Add("@StaffId", SqlDbType.VarChar).Value = UserCredentials.StaffId;
                    int numberOfReportsUnsigned = Int32.Parse(count.ExecuteScalar().ToString());
                    con.Close();

                    if (numberOfReportsUnsigned > 0)
                    {
                        alert.DisplayMessage("*Please ensure to sign all Awaiting Completion status reports. You have " + numberOfReportsUnsigned +
                            " report(s) unsigned.");
                    }
                    Report.HasDisplayedUnsignedReport++;
                }
            }

            // populate dropdownlist based on user access
            if (!string.IsNullOrWhiteSpace(UserCredentials.Groups))
            {
                // hide or display the Report Version Button depending on the users group
                if (UserCredentials.Groups.Contains("SeniorManager") || UserCredentials.Groups.Contains("DutyManager") 
                    || UserCredentials.Groups.Contains("Supervisor"))
                {
                    acpDisplayVersion.Visible = true;

                    // hide or display the Log Viewer Button depending on the users group
                    if (UserCredentials.GroupsQuery.Contains("Log Viewer"))
                    {
                        btnLogViewer.Visible = true;
                    }
                }

                UserCredentials listReports = new UserCredentials();
                // populate into an int array a list of all reports available to the user
                int[] reportList = listReports.ListReports();

                if (!UserCredentials.Groups.Contains("MRReportsSeniorManagers"))
                {
                    // sort report list in order
                    Array.Sort(reportList);
                    bool incidentAdded1 = false, incidentAdded2 = false, covidAdded1 = false, covidAdded2 = false;
                    // display the reports in proper order, All MR Reports at the top followed by CU Reports
                    for (int i = 0; i < reportList.Length; i++)
                    {
                        // if Duty Manager or Supervisor or Reception or Contractor Staff - Merrylands
                        if (reportList[i] == 1 || reportList[i] == 2 || reportList[i] == 5 || reportList[i] == 8)
                        {
                            if (!incidentAdded1)
                            {
                                ddlCreateReport.Items.Add(new ListItem("MR Incident Report", "1"));
                                ddlSearchReport.Items.Add(new ListItem("MR Incident Report", "2"));
                                incidentAdded1 = true;
                            }
                        }
                        // if Duty Manager or Reception Staff - Umina
                        if (reportList[i] == 6 || reportList[i] == 7)
                        {
                            if (!incidentAdded2)
                            {
                                ddlCreateReport.Items.Add(new ListItem("CU Incident Report", "9"));
                                ddlSearchReport.Items.Add(new ListItem("CU Incident Report", "10"));
                                incidentAdded2 = true;
                            }
                        }
                        // MR Duty Manager 
                        if (reportList[i] == 1)                                                 
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Duty Managers", "2"));
                            ddlSearchReport.Items.Add(new ListItem("MR Duty Manager", "3"));
                        }
                        // MR Supervisor
                        else if (reportList[i] == 2)
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Supervisors", "3"));
                            ddlSearchReport.Items.Add(new ListItem("MR Supervisor", "4"));
                        }
                        // if Duty Manager or Supervisor - Merrylands
                        if (reportList[i] == 1 || reportList[i] == 2)
                        {
                            if (!covidAdded1)
                            {
                                //ddlCreateReport.Items.Add(new ListItem("MR Covid Marshall", "10"));
                                //ddlSearchReport.Items.Add(new ListItem("MR Covid Marshall", "11"));
                                covidAdded1 = true;
                            }
                        }
                        // MR Function Supervisor
                        else if (reportList[i] == 3)
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Function Supervisor", "4"));
                            ddlSearchReport.Items.Add(new ListItem("MR Function Supervisor", "5"));
                        }
                        // MR Reception Supervisor
                        else if (reportList[i] == 4)
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Reception Supervisor", "5"));
                            ddlSearchReport.Items.Add(new ListItem("MR Reception Supervisor", "6"));
                        }
                        // MR Reception
                        else if (reportList[i] == 5)
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Reception", "6"));
                            ddlSearchReport.Items.Add(new ListItem("MR Reception", "7"));
                        }
                        // CU Duty Manager
                        else if (reportList[i] == 6)
                        {
                            ddlCreateReport.Items.Add(new ListItem("CU Duty Managers", "7"));
                            ddlSearchReport.Items.Add(new ListItem("CU Duty Manager", "8"));
                            //ddlCreateReport.Items.Add(new ListItem("CU Covid Marshall", "11"));
                            //ddlSearchReport.Items.Add(new ListItem("CU Covid Marshall", "12"));
                        }
                        // CU Reception
                        else if (reportList[i] == 7)
                        {
                            ddlCreateReport.Items.Add(new ListItem("CU Reception", "8"));
                            ddlSearchReport.Items.Add(new ListItem("CU Reception", "9"));
                        }
                        // MR Customer Relations Customer
                        else if (reportList[i] == 9)
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Customer Relations Officer", "12"));
                            ddlSearchReport.Items.Add(new ListItem("MR Customer Relations Officer", "13"));
                        }
                        // MR Caretaker
                        else if (reportList[i] == 10)
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Caretaker", "13"));
                            ddlSearchReport.Items.Add(new ListItem("MR Caretaker", "14"));
                        }
                    }
                }
                // if the user has Senior Managers access
                else
                {
                    // add all available reports - MR Duty Manager and MR/CU Incident Report
                    ddlCreateReport.Items.Add(new ListItem("MR Incident Report", "1"));
                    ddlSearchReport.Items.Add(new ListItem("MR Incident Report", "2"));
                    ddlCreateReport.Items.Add(new ListItem("CU Incident Report", "9"));
                    ddlSearchReport.Items.Add(new ListItem("CU Incident Report", "10"));
                    ddlCreateReport.Items.Add(new ListItem("MR Duty Managers", "2"));
                    ddlSearchReport.Items.Add(new ListItem("MR Duty Manager", "3"));
                    //ddlCreateReport.Items.Add(new ListItem("MR Covid Marshall", "10"));
                    //ddlSearchReport.Items.Add(new ListItem("MR Covid Marshall", "11"));
                    //ddlCreateReport.Items.Add(new ListItem("CU Covid Marshall", "11"));
                    //ddlSearchReport.Items.Add(new ListItem("CU Covid Marshall", "12"));
                    // MR Supervisor
                    ddlCreateReport.Items.Add(new ListItem("MR Supervisors", "3"));
                    ddlSearchReport.Items.Add(new ListItem("MR Supervisor", "4"));
                    // MR Function Supervisor
                    ddlCreateReport.Items.Add(new ListItem("MR Function Supervisor", "4"));
                    ddlSearchReport.Items.Add(new ListItem("MR Function Supervisor", "5"));
                    // MR Reception Supervisor
                    ddlCreateReport.Items.Add(new ListItem("MR Reception Supervisor", "5"));
                    ddlSearchReport.Items.Add(new ListItem("MR Reception Supervisor", "6"));
                    // MR Reception
                    ddlCreateReport.Items.Add(new ListItem("MR Reception", "6"));
                    ddlSearchReport.Items.Add(new ListItem("MR Reception", "7"));
                    // CU Duty Manager
                    ddlCreateReport.Items.Add(new ListItem("CU Duty Managers", "7"));
                    ddlSearchReport.Items.Add(new ListItem("CU Duty Manager", "8"));
                    // CU Reception
                    ddlCreateReport.Items.Add(new ListItem("CU Reception", "8"));
                    ddlSearchReport.Items.Add(new ListItem("CU Reception", "9"));
                    // MR Customer Relations Officer
                    ddlCreateReport.Items.Add(new ListItem("MR Customer Relations Officer", "12"));
                    ddlSearchReport.Items.Add(new ListItem("MR Customer Relations Officer", "13"));
                    // MR Caretaker
                    ddlCreateReport.Items.Add(new ListItem("MR Caretaker", "13"));
                    ddlSearchReport.Items.Add(new ListItem("MR Caretaker", "14"));
                }

                // populate the staff dropdownlist
                PopulateStaffList();

                // keeps the accordion set to the appropriate index (either Reports or Search Pane)
                if (!string.IsNullOrWhiteSpace(SearchReport.SetAccordion))
                {
                    acUserPanel.SelectedIndex = Int32.Parse(SearchReport.SetAccordion);
                }

                // sets the objects to filters selected by the user
                if (!string.IsNullOrWhiteSpace(Request.QueryString["ReportType"]))
                {
                    // current filters selected
                    ddlSearchReport.SelectedValue = Request.QueryString["ReportType"].ToString();
                    ddlDateGroup.SelectedValue = Request.QueryString["DateGroup"].ToString();
                    ddlReportStat.SelectedValue = Request.QueryString["ReportStatus"].ToString();

                    if (SearchReport.UnreadList)
                    {
                        cbUnreadList.Checked = true;
                    }
                    else
                    {
                        cbUnreadList.Checked = false;
                    }

                    if (SearchReport.CUOnly)
                    {
                        cbCUOnly.Checked = true;
                    }
                    else
                    {
                        cbCUOnly.Checked = false;
                    }

                    if (SearchReport.MROnly)
                    {
                        cbMROnly.Checked = true;
                    }
                    else
                    {
                        cbMROnly.Checked = false;
                    }

                    if (SearchReport.ArchivedStaff)
                    {
                        // populate the archived staff dropdownlist
                        cbArchivedStaff.Checked = true;
                        SearchReport.ArchivedStaff = true;
                        PopulateArchivedStaffList();
                    }
                    else
                    {
                        // populate the staff dropdownlist
                        cbArchivedStaff.Checked = false;
                        SearchReport.ArchivedStaff = false;
                        PopulateStaffList();
                    }

                    ddlStaffId.SelectedValue = Request.QueryString["Staff"].ToString();

                    // set keyword entered
                    if (Request.QueryString["Keyword"].ToString().Equals("0"))
                    {
                        txtKeyword.Text = "";
                    }
                    else
                    {
                        txtKeyword.Text = Request.QueryString["Keyword"].ToString();
                    }

                    if (string.IsNullOrWhiteSpace(SearchReport.ReportId))
                    {
                        txtReportId.Text = "";
                    }
                    else
                    {
                        txtReportId.Text = SearchReport.ReportId;
                    }

                    // if Custom Date is selected in Date Filter
                    if (ddlDateGroup.SelectedValue == "7")
                    {
                        txtStartDate.Text = SearchReport.StartDate;
                        txtEndDate.Text = SearchReport.EndDate;
                        txtStartDate.Visible = true;
                        refvStartDate.Visible = true;
                        regExStartDate.Visible = true;
                        txtEndDate.Visible = true;
                        refvStartDate.Visible = true;
                        regExEndDate.Visible = true;
                        cmpValue.Visible = true;
                    }

                    AdvancedFilter();
                    if (SearchReport.WhatHappened == "0")
                    {
                        ddlIncidentHappened.SelectedValue = SearchReport.WhatHappened;
                    }
                    else
                    {
                        // remove the last character (,)
                        ddlIncidentHappened.SelectedValue = SearchReport.WhatHappened.TrimEnd(',');
                    }
                    if (SearchReport.Location == "0")
                    {
                        ddlLocation.SelectedValue = SearchReport.Location;
                    }
                    else
                    {
                        ddlLocation.SelectedValue = SearchReport.Location.TrimEnd(',');
                    }
                    if (SearchReport.MemberNo.Equals("0"))
                    {
                        txtMemNo.Text = "";
                    }
                    else
                    {
                        txtMemNo.Text = SearchReport.MemberNo;
                    }
                    if (SearchReport.ActionTaken == "0")
                    {
                        ddlActionTaken.SelectedValue = SearchReport.ActionTaken;
                    }
                    else
                    {
                        ddlActionTaken.SelectedValue = SearchReport.ActionTaken.TrimEnd(',');
                    }
                    if (SearchReport.FirstName.Equals("0"))
                    {
                        txtFirstName.Text = "";
                    }
                    else
                    {
                        txtFirstName.Text = SearchReport.FirstName;
                    }
                    if (SearchReport.LastName.Equals("0"))
                    {
                        txtLastName.Text = "";
                    }
                    else
                    {
                        txtLastName.Text = SearchReport.LastName;
                    }
                    if (SearchReport.Alias.Equals("0"))
                    {
                        txtAlias.Text = "";
                    }
                    else
                    {
                        txtAlias.Text = SearchReport.Alias;
                    }
                }

                if (!string.IsNullOrEmpty(SearchReport.CreateReport))
                {
                    ddlCreateReport.SelectedValue = SearchReport.CreateReport;
                }

                if (SearchReport.RunOnStart == true)
                {
                    DefaultSearch();
                    // check if postback came from creating a report
                    if (SearchReport.FromCreateReport)
                    {
                        SearchReport.UnreadList = false;
                        SearchReport.FromCreateReport = false;
                    }
                    else
                    {
                        SearchReport.UnreadList = true;
                    }
                    SearchReport.RunOnStart = false;
                }
            }
        }

        // when key is pressed on these objects and Enter key is selected, trigger btnSearchReport_Click method
        this.cbUnreadList.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");

        this.txtStartDate.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.txtEndDate.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");

        this.ddlStaffId.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.txtReportId.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.ddlReportStat.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.txtKeyword.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");

        this.ddlIncidentHappened.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.ddlLocation.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.txtFirstName.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.txtLastName.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.txtAlias.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.txtMemNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
        this.ddlActionTaken.Attributes.Add("onkeypress", "button_click(this,'" + this.btnSearchReport.ClientID + "')");
    }

    protected void cbArchivedStaff_CheckedChanged(object sender, EventArgs e)
    {
        if (cbArchivedStaff.Checked)
        {
            // populate the archived staff dropdownlist
            SearchReport.ArchivedStaff = true;
            PopulateArchivedStaffList();
        }
        else
        {
            // populate the staff dropdownlist
            SearchReport.ArchivedStaff = false;
            PopulateStaffList();
        }
    }

    protected void PopulateStaffList()
    {
        ddlStaffId.Items.Clear();
        using (SqlCommand cmd = new SqlCommand("Proc_PopulateStaffList"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            con.Open();
            ddlStaffId.DataSource = cmd.ExecuteReader();
            ddlStaffId.DataTextField = "StaffName";
            ddlStaffId.DataValueField = "StaffId";
            ddlStaffId.DataBind();
            con.Close();
        }
        // add an "All" selection in the beginning of the list
        ddlStaffId.Items.Insert(0, new ListItem("All", ""));
    }

    protected void PopulateArchivedStaffList()
    {
        ddlStaffId.Items.Clear();
        using (SqlCommand cmd = new SqlCommand("Proc_PopulateArchivedStaffList"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            con.Open();
            ddlStaffId.DataSource = cmd.ExecuteReader();
            ddlStaffId.DataTextField = "StaffName";
            ddlStaffId.DataValueField = "StaffId";
            ddlStaffId.DataBind();
            con.Close();
        }
        // add an "All" selection in the beginning of the list
        ddlStaffId.Items.Insert(0, new ListItem("All", ""));
    }

    protected void cbMROnly_CheckedChanged(object sender, EventArgs e)
    {
        if (cbMROnly.Checked)
        {
            cbCUOnly.Checked = false;
        }
    }

    protected void cbCUOnly_CheckedChanged(object sender, EventArgs e)
    {
        if (cbCUOnly.Checked)
        {
            cbMROnly.Checked = false;
        }
    }

    protected void SetVenue() // load appropriate logo based on user IP Address
    {
        string networkAddress = string.Empty; // get user's IP Address
        string[] subnet; int i = 0; // help set the venue image logo

        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            networkAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            networkAddress = HttpContext.Current.Request.UserHostAddress;
        }
        else
        {
            alert.DisplayMessage("Local  network address not found. Please contact administrator");
        }
        subnet = networkAddress.Split('.'); // split IP Address with char '.' and set venue image logo
        foreach (string net in subnet)
        {
            i++;
            if (i == 3)
            {
                if (net == "1") // e.g. 192.168.1.271
                {
                    imgBtnLogo.ImageUrl = "~/Images/logo-MRSL.png";
                }
                else if (net == "5") // e.g. 192.168.5.44
                {
                    imgBtnLogo.ImageUrl = "~/Images/logo-CU.png";
                }
            }
        }
        if (i < 3) // if there is no appropriate IP Address found (neither 1 or 5 is present)
        {
            alert.DisplayMessage("Error Found! Please contact administrator.");
        }
    }

    protected void btnSearchReport_Click(object sender, EventArgs e) // filter list of reports listed in Default.aspx
    {
        string keyword = txtKeyword.Text;

        if (txtReportId.Equals(""))
        {
            SearchReport.ReportId = "";
        }
        else
        {
            SearchReport.ReportId = txtReportId.Text;
        }

        if (cbUnreadList.Checked)
        {
            SearchReport.UnreadList = true;
        }
        else
        {
            SearchReport.UnreadList = false;
        }

        if (cbMROnly.Checked)
        {
            SearchReport.MROnly = true;
        }
        else
        {
            SearchReport.MROnly = false;
        }

        if (cbCUOnly.Checked)
        {
            SearchReport.CUOnly = true;
        }
        else
        {
            SearchReport.CUOnly = false;
        }

        if (keyword.Equals("")) // no keyword was entered
        {
            keyword = "0";
            SearchReport.Keyword = "0";
        }
        if (ddlSearchReport.SelectedItem.Text.Contains("Incident")) // set incident report filters
        {
            if (ddlIncidentHappened.SelectedItem.Value == "")
            {
                SearchReport.WhatHappened = "0";
            }
            else
            {
                SearchReport.WhatHappened = ddlIncidentHappened.SelectedItem.Value + ","; /// the program selects only one Incident Type at the moment but eventually will have checkbox
            }

            if (ddlLocation.SelectedItem.Value == "")
            {
                SearchReport.Location = "0";
            }
            else
            {
                SearchReport.Location = ddlLocation.SelectedItem.Value + ",";
            }

            if (txtMemNo.Text == "")
            {
                SearchReport.MemberNo = "0";
            }
            else
            {
                SearchReport.MemberNo = txtMemNo.Text;
            }

            if (ddlActionTaken.SelectedItem.Value == "")
            {
                SearchReport.ActionTaken = "0";
            }
            else
            {
                SearchReport.ActionTaken = ddlActionTaken.SelectedItem.Value + ",";
            }

            if (txtFirstName.Text == "")
            {
                SearchReport.FirstName = "0";
            }
            else
            {
                SearchReport.FirstName = txtFirstName.Text;
            }

            if (txtLastName.Text == "")
            {
                SearchReport.LastName = "0";
            }
            else
            {
                SearchReport.LastName = txtLastName.Text;
            }

            if (txtAlias.Text == "")
            {
                SearchReport.Alias = "0";
            }
            else
            {
                SearchReport.Alias = txtAlias.Text;
            }
        }
        else
        {
            SearchReport.WhatHappened = "0";
            SearchReport.Location = "0";
            SearchReport.MemberNo = "0";
            SearchReport.ActionTaken = "0";
            SearchReport.FirstName = "0";
            SearchReport.LastName = "0";
            SearchReport.Alias = "0";
            SearchReport.Keyword = "0";
        }
        SearchReport.StartDate = txtStartDate.Text;
        SearchReport.EndDate = txtEndDate.Text;
        Report.PageSize = "10";

        Response.Redirect("~/Default.aspx?ReportType=" + ddlSearchReport.SelectedItem.Value + "&DateGroup=" + ddlDateGroup.SelectedItem.Value + "&Staff=" + ddlStaffId.SelectedItem.Value + "&ReportStatus=" + ddlReportStat.SelectedItem.Value + "&Keyword=" + keyword, false); // send the parameters to Default.aspx to populate the Gridview
    }

    // display the incident report filters
    protected void AdvancedFilter()
    {
        // display incident report filters
        if (ddlSearchReport.SelectedItem.Text.Contains("Incident"))
        {
            // toggle advanced filter visibility
            advancedFilter.Visible = true;
            lblIncidentHappened.Visible = true;
            lblLocation.Visible = true;
            lblMemNo.Visible = true;
            lblActionTaken.Visible = true;
            ddlIncidentHappened.Visible = true;
            ddlLocation.Visible = true;
            txtMemNo.Visible = true;
            ddlActionTaken.Visible = true;
            lblFirstName.Visible = true;
            lblLastName.Visible = true;
            lblAlias.Visible = true;
            txtFirstName.Visible = true;
            txtLastName.Visible = true;
            txtAlias.Visible = true;

            // clear any existing values for advanced filter objects
            ddlIncidentHappened.Items.Clear();
            ddlLocation.Items.Clear();
            txtMemNo.Text = "";
            ddlActionTaken.Items.Clear();

            string siteId;
            if (ddlSearchReport.SelectedItem.Text.Contains("MR"))
            {
                siteId = "1";
            }
            else
            {
                siteId = "2";
            }
            // populate the Incident Type Dropdownlist
            using (SqlCommand cmd = new SqlCommand("Proc_PopulateIncidentTypeList"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SiteId", SqlDbType.VarChar).Value = siteId;
                cmd.Connection = con;
                con.Open();
                ddlIncidentHappened.DataSource = cmd.ExecuteReader();
                ddlIncidentHappened.DataTextField = "Description";
                ddlIncidentHappened.DataValueField = "IncidentId";
                ddlIncidentHappened.DataBind();
                con.Close();
            }
            // add blank item at index 0
            ddlIncidentHappened.Items.Insert(0, new ListItem("All", ""));

            // populate the Location Dropdownlist
            using (SqlCommand cmd = new SqlCommand("Proc_PopulateLocationList"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SiteId", SqlDbType.VarChar).Value = siteId;
                cmd.Connection = con;
                con.Open();
                ddlLocation.DataSource = cmd.ExecuteReader();
                ddlLocation.DataTextField = "Description";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();
                con.Close();
            }
            // add blank item at index 0
            ddlLocation.Items.Insert(0, new ListItem("All", ""));

            // populate the Action Taken Dropdownlist
            using (SqlCommand cmd = new SqlCommand("Proc_PopulateActionTakenList"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SiteId", SqlDbType.VarChar).Value = siteId;
                cmd.Connection = con;
                con.Open();
                ddlActionTaken.DataSource = cmd.ExecuteReader();
                ddlActionTaken.DataTextField = "Description";
                ddlActionTaken.DataValueField = "ActionId";
                ddlActionTaken.DataBind();
                con.Close();
            }
            // add blank item at index 0
            ddlActionTaken.Items.Insert(0, new ListItem("All", ""));
        }
        // if report type is not an incident report, hide incident report filters
        else
        {
            advancedFilter.Visible = false;
            lblIncidentHappened.Visible = false;
            lblLocation.Visible = false;
            lblMemNo.Visible = false;
            lblActionTaken.Visible = false;
            lblFirstName.Visible = false;
            lblLastName.Visible = false;
            lblAlias.Visible = false;
            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtAlias.Visible = false;
            ddlIncidentHappened.Visible = false;
            ddlLocation.Visible = false;
            txtMemNo.Visible = false;
            ddlActionTaken.Visible = false;
        }

        // reset sort static properties
        Report.SortReset();
    }

    protected void btnCreateReport_Click(object sender, EventArgs e)
    {
        con.Open();
        // get the latest version of selected report
        SqlCommand data = new SqlCommand("Proc_LatestVersionOfSelectedReport", con);
        data.CommandType = CommandType.StoredProcedure;
        data.Parameters.Add("@RCatId", SqlDbType.VarChar).Value = ddlCreateReport.SelectedItem.Value;
        var version = data.ExecuteScalar();
        con.Close();

        // display the appropriate report to create 
        Response.Redirect("~/Reports/" + ddlCreateReport.SelectedItem.ToString() + "/Create/v" + version.ToString() + "/v" + version.ToString() + ".aspx", false);
        
        // set accordion active selected index back to Reports Panel
        SearchReport.SetAccordion = "0";
        SearchReport.CreateReport = ddlCreateReport.SelectedItem.Value.ToString();
        Report.PageSize = "10";
    }

    protected void ddlDateGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        // if selected filter is Custom Date, display Start and End Date textboxes
        if (ddlDateGroup.SelectedItem.Value == "7")
        {
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtStartDate.Visible = true;
            refvStartDate.Visible = true;
            regExStartDate.Visible = true;
            txtEndDate.Visible = true;
            refvEndDate.Visible = true;
            regExEndDate.Visible = true;
            cmpValue.Visible = true;
        }
        else
        {
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtStartDate.Visible = false;
            refvStartDate.Visible = false;
            regExStartDate.Visible = false;
            txtEndDate.Visible = false;
            refvEndDate.Visible = false;
            regExEndDate.Visible = false;
            cmpValue.Visible = false;
        }
    }

    // if report type selected is Incident Report, show incident report filters
    protected void ddlSearchReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdvancedFilter();
    }

    // display all reports available to the user logged in
    protected void imgBtnLogo_Click(object sender, ImageClickEventArgs e)
    {
        SearchReport.ArchivedStaff = false;
        SearchReport.CUOnly = false;
        SearchReport.MROnly = false;
        Report.PageSize = "10";
        DefaultSearch();
    }

    protected void DefaultSearch()
    {
        // reset the incident filters
        SearchReport.WhatHappened = "0";
        SearchReport.Location = "0";
        SearchReport.MemberNo = "0";
        SearchReport.ActionTaken = "0";
        SearchReport.ReportId = "";

        // counts the number of times ReadFiles method is called in Incident Report. It should only run one time (Run like an initial Post Back)
        Report.PopulateFields = true;
        // tells whether or not to run the editButton() in Default.aspx
        Report.RunEditMode = false;

        // set navigation tab to default list
        Report.CurrentNavigationTab = "1";

        // reset any filters selected
        SearchReport.ResetNavigation();

        // send the parameters to Default.aspx to populate the Gridview
        Response.Redirect("~/Default.aspx?ReportType=1&DateGroup=1&ReportStatus=1&Keyword=&Staff=", false);
    }

    // for Default.aspx, File Upload Object, called in the Page_Load Event to return PostBack on parameters sent
    public void RegisterTrigger(Control ct)
    {
        ScriptManager1.RegisterPostBackControl(ct);
    }
}