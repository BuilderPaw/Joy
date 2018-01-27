using System;
using System.Collections.Generic;
using System.Data; // CommandType
using System.Data.SqlClient; /// SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Project follows Brad Adams Naming Convention Standard Guidelines - https://blogs.msdn.microsoft.com/brada/2005/01/26/internal-coding-guidelines/
/// Program uses static property encapsulated inside a public class - https://stackoverflow.com/questions/895595/how-do-i-persist-data-without-global-variables
/// "We should however look at the reasons why Globals are bad, and they are mostly regarded as bad because you break the rules of encapsulation.
///    Static data though, is not necesarrily bad, the good thing about static data is that you can encapsulate it, my example above is a very simplistic example of that,
///    probably in a real world scenario you would include your static data in the same class that does other work with the credentials." - Tim Jarvis
/// </summary>

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    AlertMessage alert = new AlertMessage();

    protected void Page_Load(object sender, EventArgs e)
    {
        accordion.Visible = true; // directly display homepage
        imgBtnLogo.Visible = true;
        username.Visible = true;

        //if (HttpContext.Current.User.Identity.IsAuthenticated) // show login prompt and hide header objects
        //{
        //    // display the accordion when user has logged in
        //    accordion.Visible = true;
        //    username.Visible = true;
        //    imgBtnLogo.Visible = true;
        //}
        //else
        //{
        //    // hide accordion on login page
        //    accordion.Visible = false;
        //    username.Visible = false;
        //    imgBtnLogo.Visible = false;
        //}

        if (!IsPostBack)
        {
            //SetVenue();

            // populate dropdownlist based on user priviledges
            if (!string.IsNullOrWhiteSpace(UserCredentials.Groups)) // check if user group is not empty
            {
                // hide or display the Report Version Button depending on the users group
                if (UserCredentials.Groups.Contains("SeniorManager") || UserCredentials.Groups.Contains("DutyManager") || UserCredentials.Groups.Contains("Supervisor"))
                {
                    acpDisplayVersion.Visible = true;
                }

                UserCredentials listReports = new UserCredentials();
                int[] reportList = listReports.ListReports(); // populate into an int array a list of all reports available to the user

                if (!UserCredentials.Groups.Contains("MRReportsSeniorManagers")) // if user is not a member of Senior Managers
                {
                    Array.Sort(reportList); // sort report list in order
                    bool incidentAdded1 = false, incidentAdded2 = false;
                    for (int i = 0; i < reportList.Length; i++) // display the reports in proper order, All MR Reports at the top followed by CU Reports
                    {
                        if (reportList[i] == 1 || reportList[i] == 2 || reportList[i] == 5)     // if Duty Manager or Supervisor or Reception Staff - Merrylands
                        {
                            if (!incidentAdded1)
                            {
                                ddlCreateReport.Items.Add(new ListItem("MR Incident Report", "1"));
                                ddlSearchReport.Items.Add(new ListItem("MR Incident Report", "2"));
                                incidentAdded1 = true;
                            }
                        }

                        if (reportList[i] == 6 || reportList[i] == 7)                           // if Duty Manager or Reception Staff - Umina
                        {
                            if (!incidentAdded2)
                            {
                                ddlCreateReport.Items.Add(new ListItem("CU Incident Report", "9"));
                                ddlSearchReport.Items.Add(new ListItem("CU Incident Report", "10"));
                                incidentAdded2 = true;
                            }
                        }

                        if (reportList[i] == 1)                                                 // MR Duty Manager 
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Duty Managers", "2"));
                            ddlSearchReport.Items.Add(new ListItem("MR Duty Manager", "3"));
                        }
                        else if (reportList[i] == 2)                                            // MR Supervisor
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Supervisors", "3"));
                            ddlSearchReport.Items.Add(new ListItem("MR Supervisor", "4"));
                        }
                        else if (reportList[i] == 3)                                            // MR Function Supervisor
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Function Supervisor", "4"));
                            ddlSearchReport.Items.Add(new ListItem("MR Function Supervisor", "5"));
                        }
                        else if (reportList[i] == 4)                                            // MR Reception Supervisor
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Reception Supervisor", "5"));
                            ddlSearchReport.Items.Add(new ListItem("MR Reception Supervisor", "6"));
                        }
                        else if (reportList[i] == 5)                                            // MR Reception
                        {
                            ddlCreateReport.Items.Add(new ListItem("MR Reception", "6"));
                            ddlSearchReport.Items.Add(new ListItem("MR Reception", "7"));
                        }
                        else if (reportList[i] == 6)                                            // CU Duty Manager
                        {
                            ddlCreateReport.Items.Add(new ListItem("CU Duty Managers", "7"));
                            ddlSearchReport.Items.Add(new ListItem("CU Duty Manager", "8"));
                        }
                        else if (reportList[i] == 7)                                            // CU Reception
                        {
                            ddlCreateReport.Items.Add(new ListItem("CU Reception", "8"));
                            ddlSearchReport.Items.Add(new ListItem("CU Reception", "9"));
                        }
                    }
                }
                else // if the user is a member of Senior Managers
                {
                    ddlCreateReport.Items.Add(new ListItem("MR Incident Report", "1"));           // add all available reports - MR Duty Manager and MR/CU Incident Report
                    ddlSearchReport.Items.Add(new ListItem("MR Incident Report", "2"));
                    ddlCreateReport.Items.Add(new ListItem("CU Incident Report", "9"));
                    ddlSearchReport.Items.Add(new ListItem("CU Incident Report", "10"));
                    ddlCreateReport.Items.Add(new ListItem("MR Duty Managers", "2"));
                    ddlSearchReport.Items.Add(new ListItem("MR Duty Manager", "3"));
                    ddlCreateReport.Items.Add(new ListItem("MR Supervisors", "3"));               // MR Supervisor
                    ddlSearchReport.Items.Add(new ListItem("MR Supervisor", "4"));
                    ddlCreateReport.Items.Add(new ListItem("MR Function Supervisor", "4"));       // MR Function Supervisor
                    ddlSearchReport.Items.Add(new ListItem("MR Function Supervisor", "5"));
                    ddlCreateReport.Items.Add(new ListItem("MR Reception Supervisor", "5"));      // MR Reception Supervisor
                    ddlSearchReport.Items.Add(new ListItem("MR Reception Supervisor", "6"));
                    ddlCreateReport.Items.Add(new ListItem("MR Reception", "6"));                 // MR Reception
                    ddlSearchReport.Items.Add(new ListItem("MR Reception", "7"));
                    ddlCreateReport.Items.Add(new ListItem("CU Duty Managers", "7"));             // CU Duty Manager
                    ddlSearchReport.Items.Add(new ListItem("CU Duty Manager", "8"));
                    ddlCreateReport.Items.Add(new ListItem("CU Reception", "8"));                 // CU Reception
                    ddlSearchReport.Items.Add(new ListItem("CU Reception", "9"));
                }

                ddlStaffId.Items.Clear();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [View_Staff] WHERE [StaffGroup] IN ('" + UserCredentials.GroupsQuery + "') ORDER BY StaffName")) // populate the staff dropdownlist
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlStaffId.DataSource = cmd.ExecuteReader();
                    ddlStaffId.DataTextField = "StaffName";
                    ddlStaffId.DataValueField = "StaffId";
                    ddlStaffId.DataBind();
                    con.Close();
                }
                ddlStaffId.Items.Insert(0, new ListItem("All", "")); // add "All" selection in the beginning of the list

                if (!string.IsNullOrWhiteSpace(SearchReport.SetAccordion)) // keeps the accordion set to the appropriate index (either Reports or Search Pane)
                {
                    acUserPanel.SelectedIndex = Int32.Parse(SearchReport.SetAccordion);
                }

                if (!string.IsNullOrWhiteSpace(Request.QueryString["ReportType"])) // sets the objects to filters selected by the user
                {
                    ddlSearchReport.SelectedValue = Request.QueryString["ReportType"].ToString(); // current filters selected
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
                        cbArchivedStaff.Checked = true;
                        SearchReport.ArchivedStaff = true;

                        ddlStaffId.Items.Clear();
                        using (SqlCommand cmd = new SqlCommand("SELECT s.StaffId, sn.Name AS StaffName, s.Username, s.StaffGroup FROM dbo.Staff AS s INNER JOIN dbo.StaffName AS sn ON s.StaffId = sn.StaffId WHERE (sn.Active = 1) AND (s.Active = 0) AND [StaffGroup] IN ('" + UserCredentials.GroupsQuery + "') ORDER BY StaffName")) // populate the staff dropdownlist
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            ddlStaffId.DataSource = cmd.ExecuteReader();
                            ddlStaffId.DataTextField = "StaffName";
                            ddlStaffId.DataValueField = "StaffId";
                            ddlStaffId.DataBind();
                            con.Close();
                        }
                        ddlStaffId.Items.Insert(0, new ListItem("All", "")); // add "All" selection in the beginning of the list
                    }
                    else
                    {
                        cbArchivedStaff.Checked = false;
                        SearchReport.ArchivedStaff = false;
                        ddlStaffId.Items.Clear();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [View_Staff] WHERE [StaffGroup] IN ('" + UserCredentials.GroupsQuery + "') ORDER BY StaffName")) // populate the staff dropdownlist
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            ddlStaffId.DataSource = cmd.ExecuteReader();
                            ddlStaffId.DataTextField = "StaffName";
                            ddlStaffId.DataValueField = "StaffId";
                            ddlStaffId.DataBind();
                            con.Close();
                        }
                        ddlStaffId.Items.Insert(0, new ListItem("All", "")); // add "All" selection in the beginning of the list
                    }

                    ddlStaffId.SelectedValue = Request.QueryString["Staff"].ToString();

                    if (Request.QueryString["Keyword"].ToString().Equals("0")) // set keyword entered
                    {
                        txtKeyword.Text = "";
                    }
                    else
                    {
                        txtKeyword.Text = Request.QueryString["Keyword"].ToString();
                    }

                    if (ddlDateGroup.SelectedValue == "7") // if Custom Date is selected in Date Filter
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
                        ddlIncidentHappened.SelectedValue = SearchReport.WhatHappened.Remove(SearchReport.WhatHappened.Length - 1); // remove the last character (,)
                    }
                    if (SearchReport.Location == "0")
                    {
                        ddlLocation.SelectedValue = SearchReport.Location;
                    }
                    else
                    {
                        ddlLocation.SelectedValue = SearchReport.Location.Remove(SearchReport.Location.Length - 1);
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
                        ddlActionTaken.SelectedValue = SearchReport.ActionTaken.Remove(SearchReport.ActionTaken.Length - 1);
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
                    SearchReport.RunOnStart = false;
                }
            }
        }
    }

    protected void cbArchivedStaff_CheckedChanged(object sender, EventArgs e)
    {
        if (cbArchivedStaff.Checked)
        {
            SearchReport.ArchivedStaff = true;
            ddlStaffId.Items.Clear();
            using (SqlCommand cmd = new SqlCommand("SELECT s.StaffId, sn.Name AS StaffName, s.Username, s.StaffGroup FROM dbo.Staff AS s INNER JOIN dbo.StaffName AS sn ON s.StaffId = sn.StaffId WHERE (sn.Active = 1) AND (s.Active = 0) AND [StaffGroup] IN ('" + UserCredentials.GroupsQuery + "') ORDER BY StaffName")) // populate the staff dropdownlist
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                ddlStaffId.DataSource = cmd.ExecuteReader();
                ddlStaffId.DataTextField = "StaffName";
                ddlStaffId.DataValueField = "StaffId";
                ddlStaffId.DataBind();
                con.Close();
            }
            ddlStaffId.Items.Insert(0, new ListItem("All", "")); // add "All" selection in the beginning of the list
        }
        else
        {
            SearchReport.ArchivedStaff = false;
            ddlStaffId.Items.Clear();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [View_Staff] WHERE [StaffGroup] IN ('" + UserCredentials.GroupsQuery + "') ORDER BY StaffName")) // populate the staff dropdownlist
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                ddlStaffId.DataSource = cmd.ExecuteReader();
                ddlStaffId.DataTextField = "StaffName";
                ddlStaffId.DataValueField = "StaffId";
                ddlStaffId.DataBind();
                con.Close();
            }
            ddlStaffId.Items.Insert(0, new ListItem("All", "")); // add "All" selection in the beginning of the list
        }
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

        if (cbUnreadList.Checked)
        {
            SearchReport.UnreadList = true;
        }else
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

        Response.Redirect("~/Default.aspx?ReportType=" + ddlSearchReport.SelectedItem.Value + "&DateGroup=" + ddlDateGroup.SelectedItem.Value + "&Staff=" + ddlStaffId.SelectedItem.Value + "&ReportStatus=" + ddlReportStat.SelectedItem.Value + "&Keyword=" + keyword, false); // send the parameters to Default.aspx to populate the Gridview
    }

    protected void AdvancedFilter() // display the incident report filters
    {
        if (ddlSearchReport.SelectedItem.Text.Contains("Incident")) // display incident report filters
        {
            advancedFilter.Visible = true; // toggle advanced filter visibility
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
            ddlIncidentHappened.Items.Clear(); // clear any existing values for advanced filter objects
            ddlLocation.Items.Clear();
            txtMemNo.Text = "";
            ddlActionTaken.Items.Clear();

            string siteId;
            if (ddlSearchReport.SelectedItem.Text.Contains("MR"))
            {
                siteId = "1";
            }else
            {
                siteId = "2";
            }
            using (SqlCommand cmd = new SqlCommand("SELECT IncidentId, Description FROM [List_IncidentType] WHERE [SiteId]=" + siteId + " AND [Active]=1 ORDER BY Description")) // populate the Incident Happened Dropdownlist
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                ddlIncidentHappened.DataSource = cmd.ExecuteReader();
                ddlIncidentHappened.DataTextField = "Description";
                ddlIncidentHappened.DataValueField = "IncidentId";
                ddlIncidentHappened.DataBind();
                con.Close();
            }
            ddlIncidentHappened.Items.Insert(0, new ListItem("All", "")); // add blank item at index 0

            using (SqlCommand cmd = new SqlCommand("SELECT LocationId, Description FROM [List_Location] WHERE [SiteId]=" + siteId + " AND [Active]=1 ORDER BY Description")) // populate the Location Dropdownlist
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                ddlLocation.DataSource = cmd.ExecuteReader();
                ddlLocation.DataTextField = "Description";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();
                con.Close();
            }
            ddlLocation.Items.Insert(0, new ListItem("All", "")); // add blank item at index 0

            using (SqlCommand cmd = new SqlCommand("SELECT ActionId, Description FROM [List_ActionTaken] WHERE [SiteId]=" + siteId + " AND [Active]=1 ORDER BY Description")) // populate the Action Taken Dropdownlist
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                ddlActionTaken.DataSource = cmd.ExecuteReader();
                ddlActionTaken.DataTextField = "Description";
                ddlActionTaken.DataValueField = "ActionId";
                ddlActionTaken.DataBind();
                con.Close();
            }
            ddlActionTaken.Items.Insert(0, new ListItem("All", "")); // add blank item at index 0
        }
        else // if report type is not an incident report, hide incident report filters
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
        Report.SortReset(); // reset sort static properties
    }

    protected void btnCreateReport_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand data = new SqlCommand("SELECT MAX(VersionNo) AS 'latestVersion'" + // get the latest version of selected report
                                               " FROM dbo.[Version]" +
                                               " WHERE RCatId = " + ddlCreateReport.SelectedItem.Value, con);
        int version = (int)data.ExecuteScalar();
        con.Close();

        Response.Redirect("~/Reports/" + ddlCreateReport.SelectedItem.ToString() + "/Create/v" + version.ToString() + "/v" + version.ToString() + ".aspx", false); // display the appropriate Report to create 
        SearchReport.SetAccordion = "0"; // set accordion active selected index back to Reports Pane
        SearchReport.CreateReport = ddlCreateReport.SelectedItem.Value.ToString();
    }

    protected void ddlDateGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateGroup.SelectedItem.Value == "7") // if selected filter is Custom Date, display Start and End Date textboxes
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

    protected void ddlSearchReport_SelectedIndexChanged(object sender, EventArgs e) // if report type selected is Incident Report, show incident report filters
    {
        AdvancedFilter();
    }

    protected void imgBtnLogo_Click(object sender, ImageClickEventArgs e) // display all reports available to the user logged in
    {
        SearchReport.ArchivedStaff = false;
        SearchReport.CUOnly = false;
        SearchReport.MROnly = false;
        DefaultSearch();
    }

    protected void DefaultSearch()
    {
        SearchReport.WhatHappened = "0"; // reset the incident filters
        SearchReport.Location = "0";
        SearchReport.MemberNo = "0";
        SearchReport.ActionTaken = "0";

        Report.PopulateFields = true;  // counts the number of times ReadFiles method is called in Incident Report. It should only run one time (Run like an initial Post Back)
        Report.RunEditMode = false;    // tells whether or not to run the editButton() in Default.aspx

        Report.CurrentNavigationTab = "1"; // set navigation tab to default list

        SearchReport.ResetNavigation(); // reset any filters selected

        Response.Redirect("~/Default.aspx?ReportType=1&DateGroup=1&ReportStatus=1&Keyword=&Staff=", false); // send the parameters to Default.aspx to populate the Gridview
    }

    public void RegisterTrigger(Control ct) // for Default.aspx, File Upload Object, called in the Page_Load Event to return PostBack on parameters sent
    {
        ScriptManager1.RegisterPostBackControl(ct);
    }
}