﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data; // Data Source View
using System.Data.SqlClient; // SQL Connection
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services; // Script Service
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

[ScriptService]
public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    AlertMessage alert = new AlertMessage();
    SqlQuery sqlQuery = new SqlQuery();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.RegisterTrigger(btnUpload); // call RegisterTrigger method to return PostBack sent parameters
        this.Master.RegisterTrigger(gvAttachedFiles);
        Page.Form.Attributes.Add("enctype", "multipart/form-data");

        if (Report.RunEditMode) // check whether EditMode method needs to be run
        {
            if (gvUserReports.Visible != true || gvActionReports.Visible != true)
            {
                EditMode();
            }
        }

        if (!IsPostBack)
        {   // for testing - see Web.config
            // Administrator
            /*start*/
            string test1 = "CUReportsReceptionSupervisors|MRReportsReceptionSupervisor|MRReportsFunctionSupervisor|" +
                           "MRReportsSeniorManagers|CUReportsSupervisors|CUReportsReception|CUReportsDutyManagers|MRReportsUsers|" +
                           "MRReportsSupervisors|MRReportsReception|MRReportsDutyManagers|MRReportsAllegation|",
                   test2 = "Lorenz Santiago", test3 = "paolos", test4 = "1", test5 = "MR Senior Managers";
            UserCredentials.Groups = test1;
            Session["DisplayName"] = test2;
            UserCredentials.DisplayName = test2;
            Session["Username"] = test3;
            UserCredentials.StaffId = test4;
            UserCredentials.Role = test5;
            /*end*/

            // Duty Manager
            /*start*/
            //string test1 = "CUReportsReceptionSupervisors|MRReportsReceptionSupervisor|MRReportsFunctionSupervisor|" +
            //               "CUReportsSupervisors|CUReportsReception|CUReportsDutyManagers|MRReportsUsers|" +
            //               "MRReportsSupervisors|MRReportsReception|MRReportsDutyManagers|",
            //       test2 = "Red Geronimo", test3 = "redg", test4 = "5", test5 = "MR Duty Manager";
            //UserCredentials.Groups = test1;
            //Session["DisplayName"] = test2;
            //UserCredentials.DisplayName = test2;
            //Session["Username"] = test3;
            //UserCredentials.StaffId = test4;
            //UserCredentials.Role = test5;
            /*end*/

            // Staff
            /*start*/
            //string test1 = "CUReportsReception|",
            //       test2 = "Lorenz Santiago", test3 = "paolos", test4 = "1", test5 = "CU Reception";
            //UserCredentials.Groups = test1;
            //Session["DisplayName"] = test2;
            //UserCredentials.DisplayName = test2;
            //Session["Username"] = test3;
            //UserCredentials.StaffId = test4;
            //UserCredentials.Role = test5;
            /*end*/

            //string testThis = "";
            //con.Open();
            //SqlCommand test = new SqlCommand("SELECT Password" +
            //                   " FROM [Staff] WHERE StaffId=5", con);
            //testThis = test.ExecuteScalar().ToString();
            //con.Close();
            //string testTest = ShowThis(testThis);

            // populate User Reports Gridview depending on the available unread reports the user has access to
            SearchReport searchReport = new SearchReport();
            Report.SelectQuery = searchReport.Search(1, 1, "", 1, "", "");

            sdsUserReports.SelectCommand = Report.SelectQuery;
            Report.DefaultSelectQuery = Report.SelectQuery;

            // populate the notifications in the navigation tab
            ActionsAssignedNotification();
            ReportActionsNotification();
            ManagerSignNotification();

            // populate the filter if ReportType is not null
            if (!string.IsNullOrWhiteSpace(Request.QueryString["ReportType"]))
            {
                PopulateSearch();
            }
            else
            {
                Report.SelectQuery = Report.DefaultSelectQuery; // active search query is list of reports the user has access to
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["PlayerId"]))
            {
                PopulateSearch();
            }
        }
    }

    protected void PopulateSearch() // returns a select query string from filtered inputs
    {
        SearchReport searchReport = new SearchReport();
        string selectQuery;

        if (!string.IsNullOrWhiteSpace(Request.QueryString["PlayerId"]))
        {
            SearchReport.ListPlayerIdIncidents = Request.QueryString["PlayerId"].ToString();
            selectQuery = searchReport.Search(1, 1, "", 1, "ListPlayerIdIncidents", SearchReport.ListPlayerIdIncidents);
        }
        else
        {
            selectQuery = searchReport.Search(Int32.Parse(Request.QueryString["ReportType"]),
            Int32.Parse(Request.QueryString["DateGroup"]), Request.QueryString["Staff"].ToString(),
            Int32.Parse(Request.QueryString["ReportStatus"]), Request.QueryString["Keyword"].ToString(), "");
        }

        if (string.IsNullOrEmpty(selectQuery))
        {
            sdsUserReports.SelectCommand = Report.SelectQuery;
            alert.DisplayMessage("No documents found. Please try again");
            SearchReport.SetAccordion = "1";
            return;
        }
        else
        {
            sdsUserReports.SelectCommand = selectQuery;
            SearchReport.SetAccordion = "1"; // keeps the active accordion set to Search Pane
            if (gvUserReports.Rows.Count != 0) // if has report list, display the current one
            {
                Report.SelectQuery = selectQuery;
            }
        }
    }

    protected void btnNavHome_Click(object sender, EventArgs e) // displays a list of reports the user has access to
    {
        DefaultList("NavigationTab");
    }
    protected void DefaultList(string clickedFrom) // method that displays a list of reports the user has access to
    {
        // display User Report gridview
        gvUserReports.Visible = true;
        gvActionReports.Visible = false;

        // set the highlighted navigation tab
        btnNavHome.BackColor = System.Drawing.ColorTranslator.FromHtml("#285e8e");
        btnNavActionsAssigned.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavReportActions.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavManagerSign.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");

        // populate the gridview
        if (clickedFrom.Equals("NavigationTab"))
        { // don't reset if it is coming from ShowList method
            Report.SelectQuery = Report.DefaultSelectQuery;
            SearchReport.ResetNavigation(); // reset any filters selected
        }

        sdsUserReports.SelectCommand = Report.SelectQuery;
        gvUserReports.DataBind();

        Report.CurrentNavigationTab = "1";
    }

    protected void btnNavActionsAssigned_Click(object sender, EventArgs e)
    {
        ActionsAssigned("NavigationTab");
    }
    protected void ActionsAssigned(string clickedFrom) // list of reports the user has assigned actions to
    {
        if (clickedFrom.Equals("NavigationTab"))
        { // don't reset if it is coming from ShowList method
            Report.SortReset(); // reset sort static properties
        }

        string selectQuery = "SELECT [ReportId], [Report_Table], [Version], [AuditVersion], [ReportName], [ReportStat], [StaffAuthor], [StaffSelected]," +
                " [StaffId], [StaffName], [Description], [SubmittedTo], [SubmittedBy], [SubmittedDate], [Completed], [CompletedDate], ROW_NUMBER()" +
                " OVER (ORDER BY [SubmittedDate] DESC) AS [RowNum] FROM [ActionRequired]" +
                " WHERE [StaffId] = " + UserCredentials.StaffId + " AND ([Completed] = 0 OR ([Completed] = 1 AND" +
                " [CompletedDate] BETWEEN '" + DateTime.Now.Date.AddDays(-31).ToString("yyyy-MM-dd") + "' AND '" + DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd") + "'))",
                hasActionsAssigned = "";
        try
        {
            con.Open();
            SqlCommand count = new SqlCommand(selectQuery, con);
            hasActionsAssigned = count.ExecuteScalar().ToString(); // set the number of assigned actions
            con.Close();
        }
        catch
        {
            con.Close();
        }


        ActionsAssignedNotification(); // show number of notification in the navigation tab

        // set the highlighted navigation tab
        btnNavHome.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavActionsAssigned.BackColor = System.Drawing.ColorTranslator.FromHtml("#285e8e");
        btnNavReportActions.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavManagerSign.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");

        // display Actions Report gridview
        gvUserReports.Visible = false;
        gvActionReports.Visible = true;

        // populate the gridview
        sdsActionReports.SelectCommand = selectQuery;
        Report.SelectQuery = selectQuery;
        gvActionReports.DataBind();
        Report.CurrentNavigationTab = "2";
    }
    protected void ActionsAssignedNotification() // count all pending actions assigned
    {
        con.Open();
        SqlCommand count = new SqlCommand("SELECT COUNT(*) FROM [ActionRequired] " +
                           "WHERE [StaffId] = " + UserCredentials.StaffId + " AND [Completed] = 0", con);
        lblNotifyAssigned.Text = count.ExecuteScalar().ToString(); // set the number of notifications
        con.Close();

        if (string.IsNullOrEmpty(lblNotifyAssigned.Text) || Int32.Parse(lblNotifyAssigned.Text) < 1)
        {
            lblNotifyAssigned.Style.Add("opacity", "0.01"); // hide notifications
        }
        else
        {
            lblNotifyAssigned.Style.Add("opacity", "1"); // show notifications
        }
    }

    protected void btnNavReportActions_Click(object sender, EventArgs e)
    {
        ReportActions("NavigationTab");
    }
    protected void ReportActions(string clickedFrom) // list of reports the user has actions pending
    {
        if (clickedFrom.Equals("NavigationTab"))
        { // don't reset if it is coming from ShowList method
            Report.SortReset(); // reset sort static properties
        }
        ReportActionsNotification(); // show number of notification in the navigation tab


        string selectQuery = "SELECT [ReportId], [Report_Table], [Version], [AuditVersion], [ReportName], [ReportStat], [StaffAuthor], [StaffSelected], [StaffId], [StaffName]," +
                " [Description], [SubmittedTo], [SubmittedBy], [SubmittedDate], [Completed], [CompletedDate], ROW_NUMBER() OVER (ORDER BY [SubmittedDate] DESC) AS [RowNum]" +
                " FROM [ActionRequired]" +
                " WHERE ([StaffPersonID] = " + UserCredentials.StaffId + " OR [SubmittedTo] LIKE '%" + UserCredentials.Role + "%') AND ([Completed] = 0 OR ([Completed] = 1 AND" +
                " [CompletedDate] BETWEEN '" + DateTime.Now.Date.AddDays(-31).ToString("yyyy-MM-dd") + "' AND '" + DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd") + "'))",
               hasReportActions = "";

        try
        {
            con.Open();
            SqlCommand count = new SqlCommand(selectQuery, con);
            hasReportActions = count.ExecuteScalar().ToString(); // set the number of report actions
            con.Close();
        }
        catch
        {
            con.Close();
        }

        // set the highlighted navigation tab
        btnNavHome.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavActionsAssigned.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavReportActions.BackColor = System.Drawing.ColorTranslator.FromHtml("#285e8e");
        btnNavManagerSign.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");

        // display Actions Report gridview
        gvUserReports.Visible = false;
        gvActionReports.Visible = true;

        // populate the gridview
        sdsActionReports.SelectCommand = selectQuery;
        Report.SelectQuery = sdsActionReports.SelectCommand.ToString();
        gvActionReports.DataBind();
        Report.CurrentNavigationTab = "3";
    }
    protected bool ReportActionsNotification() // count all pending report actions
    {
        bool hasNotification;

        con.Open();
        SqlCommand count = new SqlCommand("SELECT COUNT(*)" +
                           " FROM [ActionRequired] WHERE ([StaffPersonID] = " + UserCredentials.StaffId + "OR" +
                           " SubmittedTo LIKE '%" + UserCredentials.Role + "%') AND [Completed] = 0", con);
        lblNotifyActions.Text = count.ExecuteScalar().ToString(); // set the number of notifications
        con.Close();

        if (string.IsNullOrEmpty(lblNotifyActions.Text) || Int32.Parse(lblNotifyActions.Text) < 1)
        {
            lblNotifyActions.Style.Add("opacity", "0.01"); // hide notifications
            hasNotification = false;
        }
        else
        {
            lblNotifyActions.Style.Add("opacity", "1"); // show notifications
            hasNotification = true;
        }
        return hasNotification;
    }

    protected void btnNavManagerSign_Click(object sender, EventArgs e)
    {
        ManagerSign("NavigationTab");
    }
    protected void ManagerSign(string clickedFrom) // list of reports manager needs to sign
    {
        if (clickedFrom.Equals("NavigationTab"))
        { // don't reset if it is coming from ShowList method
            Report.SortReset(); // reset sort static properties
        }
        bool hasNotification = ManagerSignNotification(); // show number of notification in the navigation tab

        // set the highlighted navigation tab
        btnNavHome.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavActionsAssigned.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavReportActions.BackColor = System.Drawing.ColorTranslator.FromHtml("#3276b1");
        btnNavManagerSign.BackColor = System.Drawing.ColorTranslator.FromHtml("#285e8e");

        // display User Report gridview
        gvActionReports.Visible = false;
        gvUserReports.Visible = true;

        // populate the gridview
        sdsUserReports.SelectCommand = Report.ManagerSignQuery();
        Report.SelectQuery = sdsUserReports.SelectCommand.ToString();
        gvUserReports.DataBind();
        Report.CurrentNavigationTab = "4";
    }
    protected bool ManagerSignNotification() // count all reports that needs manager signature
    {
        bool hasNotification;

        con.Open();
        SqlCommand count = new SqlCommand("SELECT COUNT(*)" +
                           " FROM [rptView] WHERE ReportName IN('" + UserCredentials.GroupsQuery + "') AND ReportStat LIKE '%Manager%' AND" +
                           " [StaffId] != '" + UserCredentials.StaffId + "'", con);
        lblNotifyManSign.Text = count.ExecuteScalar().ToString(); // set the number of notifications
        con.Close();

        if (string.IsNullOrEmpty(lblNotifyManSign.Text) || Int32.Parse(lblNotifyManSign.Text) < 1)
        {
            lblNotifyManSign.Style.Add("opacity", "0.01"); // hide notifications
            hasNotification = false;
        }
        else
        {
            lblNotifyManSign.Style.Add("opacity", "1"); // show notifications
            hasNotification = true;
        }
        return hasNotification;
    }

    protected void SelectedReport(object sender, GridViewCommandEventArgs e) // populate select query
    {
        if (e.CommandName == "Select")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer); // get report details from selected report
            Label lblID = (Label)row.FindControl("lblReportId");
            Label lblTable = (Label)row.FindControl("lblReportTable");
            Label lblVersion = (Label)row.FindControl("lblReportVersion");
            Label lblRowNo = (Label)row.FindControl("lblRowNum");
            Label lblAuditVersion = (Label)row.FindControl("lblAuditVersion");
            Label lblReportStat = (Label)row.FindControl("lblReportStat");
            Label lblReportName = (Label)row.FindControl("lblReportType");
            Label lblStaffID = (Label)row.FindControl("lblStaffID");
            Label lblStaffSelected = (Label)row.FindControl("lblStaffName");

            Report.Id = lblID.Text;                                         // set the selected ReportId
            Report.Table = lblTable.Text;                                   // set the selected Report_Table
            Report.Version = lblVersion.Text;                               // set the selected Report_Version
            Report.RowNumber = lblRowNo.Text;                               // set the selected Row Number
            Report.AuditVersion = lblAuditVersion.Text;                     // set the selected Audit Version
            Report.Status = lblReportStat.Text;                             // set the status of the selected report
            Report.Name = lblReportName.Text;                               // set the selected ReportName
            Report.SelectedStaffId = lblStaffID.Text;                       // set the Staff ID selected in the report
            Report.SelectedStaffName = lblStaffSelected.Text;               // set the Staff selected in the report

            Report.ActiveReport = "SELECT rt.StaffId, rt.StaffName, rt.ShiftId, st.ShiftName, c.ReportName, *" + // view report
                       " FROM " + Report.Table + " rt, [Staff] s, [Shift] st, [Category] c" +
                       " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Report.Id +
                       " AND rt.AuditVersion=" + Report.AuditVersion;

            CheckMode(); // check which mode to use, is a user/manager/staff

            ViewReport(Report.ActiveReport);
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ToTheTop", "ToTopOfPage();", true); // scroll to the top of the page
        }
    }
    public string ShowThis(string encrypted)
    {
        UTF8Encoding encoder = new UTF8Encoding();
        Decoder utf8Decode = encoder.GetDecoder();
        byte[] decodeByte = Convert.FromBase64String(encrypted);
        int charCount = utf8Decode.GetCharCount(decodeByte, 0, decodeByte.Length);
        char[] decodedChar = new char[charCount];
        utf8Decode.GetChars(decodeByte, 0, decodeByte.Length, decodedChar, 0);
        string result = new String(decodedChar);
        return result;
    }

    protected void CheckMode() // check which mode to use, is a user/manager/staff
    {
        if (Report.SelectedStaffId.Equals(UserCredentials.StaffId)) // user is the owner of the report
        {
            UserMode();
        }
        else
        {
            if (UserCredentials.Groups.Contains("MRReportsSeniorManagers") || UserCredentials.Groups.Contains("DutyManagers")) // user is a manager
            {
                ManagerMode();
            }
            else // user is a staff who can view the report
            {
                StaffMode();
            }
        }
    }
    protected void UserMode()
    {
        tblComment.Visible = false;         // hide comment section (just in case opened)
        btnShowComment.Text = "Show Comment";
        btnShowComment1.Text = "Show Comment";
        tblReportObjects.Visible = true;    // show all report objects

        trUser.Visible = true;              // display user objects
        btnEdit.Visible = true;
        btnUpdate.Visible = false;
        btnPrint.Visible = true;
        btnShowReport.Visible = false;
        btnShowComment.Visible = true;

        trManager.Visible = false;          // hide manager objects

        trSign.Visible = true;              // show other objetcs
        btnShowUserSign.Visible = false;
        btnShowList.Visible = true;
        btnReadReport.Visible = false;
        btnShowActions.Visible = true;

        trLinked.Visible = true;            // show linked objects
        trAttachedFiles.Visible = true;
    }
    protected void ManagerMode()
    {
        tblComment.Visible = false;         // hide comment section (just in case opened)
        btnShowComment.Text = "Show Comment";
        btnShowComment1.Text = "Show Comment";
        tblReportObjects.Visible = true;    // show all report objects

        trUser.Visible = false;             // hide user objects

        trManager.Visible = true;           // display manager objects
        btnShowList1.Visible = false;
        btnShowManagerSign.Visible = true;
        btnPrint1.Visible = true;
        btnShowComment1.Visible = true;

        trSign.Visible = true;              // show other objects
        btnShowUserSign.Visible = false;
        btnShowList.Visible = true;
        btnReadReport.Visible = true;
        btnShowActions.Visible = true;

        trLinked.Visible = true;
        trAttachedFiles.Visible = true;

        sqlQuery.RetrieveData(Report.ActiveReport, "HasManagerSign"); // check if report has already been signed
        if (Report.HasManagerSign)
        {
            btnShowManagerSign.Visible = false;
            btnShowList.Visible = false;
            btnShowList1.Visible = true;
        }
    }
    protected void StaffMode()
    {
        tblComment.Visible = false;         // hide comment section (just in case opened)
        btnShowComment.Text = "Show Comment";
        btnShowComment1.Text = "Show Comment";
        tblReportObjects.Visible = true;    // show all report objects

        trUser.Visible = false;             // hide user objects

        trManager.Visible = true;           // display manager objects
        btnShowList1.Visible = true;
        btnShowManagerSign.Visible = false;
        btnPrint1.Visible = true;
        btnShowComment1.Visible = true;

        trSign.Visible = true;              // show other objects
        btnShowUserSign.Visible = false;
        btnShowList.Visible = false;
        btnReadReport.Visible = true;
        btnShowActions.Visible = true;

        trLinked.Visible = true;
        trAttachedFiles.Visible = true;
    }

    protected void PreviousReport(object sender, ImageClickEventArgs e) // loads up the previous available report
    {
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FadeInReport", "FadeInReport();", true);

        string viewReport = "";

        try
        {
            viewReport = Report.SelectQuery.Remove(Report.SelectQuery.LastIndexOf(" ORDER BY"));
        }
        catch
        {
            viewReport = Report.SelectQuery;
        }

        sqlQuery.RetrieveData("SELECT * FROM (" + viewReport +
            ") a WHERE RowNum = (SELECT MAX(b.RowNum) FROM (" + viewReport +
            ") b WHERE b.RowNum < " + Report.RowNumber + ")", "HasReport"); // if there is a report to view, get the details from the report

        if (Report.HasReport)
        {
            if (Report.ChangeRowNumber)
            {
                Report.ChangeRowNumber = false;
            }

            Report.ActiveReport = "SELECT rt.StaffId, rt.StaffName, rt.ShiftId, st.ShiftName, c.ReportName, *" + // view report
                       " FROM " + Report.Table + " rt, [Staff] s, [Shift] st, [Category] c" +
                       " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Report.Id +
                       " AND rt.AuditVersion=" + Report.AuditVersion;

            ViewReport(Report.ActiveReport); // update displayed report
        }
        else
        {
            ViewReport(Report.ActiveReport); // display currently shown report
        }
        CheckMode();
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ToTheTop", "ToTopOfPage();", true); // scroll to the top of the page
    }
    protected void NextReport(object sender, ImageClickEventArgs e) // loads up the next available report
    {
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FadeInReport", "FadeInReport();", true);

        string viewReport = "";

        try
        {
            viewReport = Report.SelectQuery.Remove(Report.SelectQuery.LastIndexOf(" ORDER BY"));
        }
        catch
        {
            viewReport = Report.SelectQuery;
        }

        if (Report.ChangeRowNumber)
        {
            Report.RowNumber = (Int32.Parse(Report.RowNumber) - 1).ToString();
            Report.ChangeRowNumber = false;
        }

        sqlQuery.RetrieveData("SELECT * FROM (" + viewReport +
            ") a WHERE RowNum = (SELECT MIN(b.RowNum) FROM (" + viewReport +
            ") b WHERE b.RowNum > " + Report.RowNumber + ")", "HasReport"); // if there is a report to view, get the details from the report

        if (Report.HasReport)
        {
            Report.ActiveReport = "SELECT rt.StaffId, rt.StaffName, rt.ShiftId, st.ShiftName, c.ReportName, *" + // view report
                       " FROM " + Report.Table + " rt, [Staff] s, [Shift] st, [Category] c" +
                       " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Report.Id +
                       " AND rt.AuditVersion=" + Report.AuditVersion;

            ViewReport(Report.ActiveReport); // update displayed report
        }
        else
        {
            ViewReport(Report.ActiveReport); // display currently shown report
        }
        CheckMode();
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ToTheTop", "ToTopOfPage();", true); // scroll to the top of the page
    }
    protected void ViewReport(string viewReport) // hide list and display report selected
    {
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FadeInReport", "FadeInReport();", true); // apply fade transition
        ShowReport();

        if (Report.Table.Contains("Incident"))
        {
            if(UserCredentials.Role.Equals("MR Reception"))
            {
                tblRecords.Visible = true;
                lblIncidentNo.Text = "Incident No. " + Report.Id;
                sdsRecAllegation.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [recAllegation] WHERE ReportId=" + 0;
                sdsRecDiscAction.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [recDiscAction] WHERE ReportId=" + 0;
                sdsRecJudiciary.SelectCommand = "SELECT id, StaffId, Name, Decision, Date, ReportId, StartDate, EndDate FROM [recJudiciary] WHERE ReportId=" + Report.Id;
            }
            else
            {
                tblRecords.Visible = true;
                lblIncidentNo.Text = "Incident No. " + Report.Id;
                sdsRecAllegation.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [recAllegation] WHERE ReportId=" + Report.Id;
                sdsRecDiscAction.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [recDiscAction] WHERE ReportId=" + Report.Id;
                sdsRecJudiciary.SelectCommand = "SELECT id, StaffId, Name, Decision, Date, ReportId, StartDate, EndDate FROM [recJudiciary] WHERE ReportId=" + Report.Id;
            }
        }
        else
        {
            tblRecords.Visible = false;
        }

        // exit out of edit mode
        gvPendingActions.EditIndex = -1;
        gvLinkedReports.EditIndex = -1;
        gvRecAllegation.EditIndex = -1;
        gvRecDiscAction.EditIndex = -1;
        gvRecJudiciary.EditIndex = -1;

        FeatureNavigation(); // check whether or not the report has Attached Files, Linked Reports, and Pending Actions 

        Report.ActiveReport = viewReport;         // set active report based on parameter given
        UpdateFormView();
    }
    protected void FeatureNavigation() // check whether or not the report has Attached Files, Linked Reports, and Pending Actions 
    {
        // display Attached Files if not empty
        bool hasAttachedFiles = false;

        foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Uploads")))
        {
            FileInfo fi = new FileInfo(strfile);
            if (fi.Name.Contains(Report.Id))
            {
                hasAttachedFiles = true;
                break;
            }
        }
        if (hasAttachedFiles)
        {
            btnLinkAttachedFiles.Visible = true;
            ShowAttachedFiles();
        }
        else
        {
            HideAttachedFiles();
            btnLinkAttachedFiles.Visible = false;
        }

        // display linked reports if not empty
        con.Open();
        SqlCommand checkExist1 = new SqlCommand("SELECT COUNT(*) FROM [LinkedReports] WHERE [ReportId]= '" + Report.Id + "'", con);
        int reportExist = (int)checkExist1.ExecuteScalar();
        con.Close();

        if (reportExist > 0)
        {
            ShowLinkedReports();
            btnLinkLinkedReports.Visible = true;
            sdsLinkedReports.SelectCommand = "SELECT * FROM [LinkedReports] WHERE ReportId=" + Report.Id + " ORDER BY id";
        }
        else
        {
            HideLinkedReports();
            btnLinkLinkedReports.Visible = false;
        }

        // display Action required if not empty
        con.Open();
        SqlCommand checkExist = new SqlCommand("SELECT COUNT(*) FROM [ActionRequired] WHERE [ReportId]= '" + Report.Id + "'", con);
        int actionExist = (int)checkExist.ExecuteScalar();
        con.Close();

        if (actionExist > 0)
        {
            ShowPendingActions();
            btnLinkPendingActions.Visible = true;
            sdsPendingActions.SelectCommand = "SELECT * FROM ActionRequired WHERE ReportId=" + Report.Id;
        }
        else
        {
            HidePendingActions();
            btnLinkPendingActions.Visible = false;
        }

        SpellButton1.Visible = false;
    }
    protected void FeatureNavigationReportDisplayed() // check whether or not the report has Attached Files, Linked Reports, and Pending Actions (report is currently displayed/open)
    {
        // display Attached Files if not empty
        bool hasAttachedFiles = false;

        foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Uploads")))
        {
            FileInfo fi = new FileInfo(strfile);
            if (fi.Name.Contains(Report.Id))
            {
                hasAttachedFiles = true;
                break;
            }
        }
        if (hasAttachedFiles)
        {
            btnLinkAttachedFiles.Visible = true;
        }
        else
        {
            btnLinkAttachedFiles.Visible = false;
        }

        // display linked reports if not empty
        con.Open();
        SqlCommand checkExist1 = new SqlCommand("SELECT COUNT(*) FROM [LinkedReports] WHERE [ReportId]= '" + Report.Id + "'", con);
        int reportExist = (int)checkExist1.ExecuteScalar();
        con.Close();

        if (reportExist > 0)
        {
            btnLinkLinkedReports.Visible = true;
            sdsLinkedReports.SelectCommand = "SELECT * FROM [LinkedReports] WHERE ReportId=" + Report.Id + " ORDER BY id";
        }
        else
        {
            btnLinkLinkedReports.Visible = false;
        }

        // display Action required if not empty
        con.Open();
        SqlCommand checkExist = new SqlCommand("SELECT COUNT(*) FROM [ActionRequired] WHERE [ReportId]= '" + Report.Id + "'", con);
        int actionExist = (int)checkExist.ExecuteScalar();
        con.Close();

        if (actionExist > 0)
        {
            btnLinkPendingActions.Visible = true;
            sdsPendingActions.SelectCommand = "SELECT * FROM ActionRequired WHERE ReportId=" + Report.Id;
        }
        else
        {
            btnLinkPendingActions.Visible = false;
        }

        SpellButton1.Visible = false;
    }
    protected void ShowReport() // display report objects
    {
        // hide report list and display report
        navigation.Visible = false;
        gvUserReports.Visible = false;
        gvActionReports.Visible = false;
        fvReport.Visible = true;

        phUserControl.Visible = false; // hide the Placeholder (EditItemTemplate)
        Report.PopulateFields = true;  // responsible for reading files in Edit.ascx Incident Report (If IsPostBack - Edit.ascx - Incident Report)
        Report.RunEditMode = false;    // set the variable that is used to reload on the same editing page back to zero (Default Pageload)

        // display report features
        //btnLinkedReports.Visible = true;

        // display report navigation buttons
        imgNextReport.Visible = true;
        imgPreviousReport.Visible = true;
        imgBottomScreen.Visible = true;
        imgTopScreen.Visible = true;
    }
    protected void ShowList() // display report list objects
    {
        // display report list and hide report
        navigation.Visible = true;
        gvUserReports.Visible = true;
        gvActionReports.Visible = true;
        fvReport.Visible = false;

        phUserControl.Visible = false; // hide the Placeholder (EditItemTemplate)
        Report.PopulateFields = true;
        Report.RunEditMode = false;

        tblRecords.Visible = false;

        // hide report navigation buttons
        imgNextReport.Visible = false;
        imgPreviousReport.Visible = false;
        imgBottomScreen.Visible = false;
        imgTopScreen.Visible = false;
        btnLinkAttachedFiles.Visible = false;
        btnLinkLinkedReports.Visible = false;
        btnLinkPendingActions.Visible = false;
        SpellButton1.Visible = false;

        // hide report objects
        tblReportObjects.Visible = false;

        // hide comment table
        tblComment.Visible = false;
    }

    protected void OnSelecting(object sender, SqlDataSourceSelectingEventArgs e) // loads up the form view via Data Key Name - Report Id
    { // Used for setting the Select Parameter
        e.Command.Parameters["@ReportId"].Value = Report.Id;
    }

    protected void gvUserReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        sdsUserReports.SelectCommand = Report.SelectQuery;
        gvUserReports.PageIndex = e.NewPageIndex;
        gvUserReports.DataBind();
    }

    protected void gvUserReports_Sorting(object sender, GridViewSortEventArgs e)
    {
        gvUserReports.PageIndex = 0; // displays the first page of the list

        if (Report.Sort.Equals("Set"))
        {
            e.SortDirection = SortDirection.Ascending;
            Report.Sort = "Descending";
        }
        else if (Report.Sort.Equals("Descending"))
        {
            e.SortDirection = SortDirection.Descending;
            Report.Sort = "Ascending";
        }
        else if (Report.Sort.Equals("Ascending"))
        {
            e.SortDirection = SortDirection.Ascending;
            Report.Sort = "Descending";
        }

        Report.SortExpression = e.SortExpression.ToString(); // keep the column value that's being sorted

        if (e.SortDirection.ToString().Equals("Ascending")) // keep the value of sort direction
        {
            Report.SortDirection = " ASC";
        }
        else
        {
            Report.SortDirection = " DESC";
        }

        if (!Report.SelectQuery.Contains("ROW_NUMBER() OVER(ORDER BY[" + Report.SortExpression + "]")) // if select query still has the default Order statement -  ORDER BY ShiftDate DESC, ShiftId DESC, RowNum
        { // change the order by sort expression and direction selected
            if (Report.SelectQuery.Contains(" ORDER BY ShiftDate DESC, ShiftId DESC, RowNum"))
            { // user reports sorted for the first time
                Report.SelectQuery = Report.SelectQuery.Remove(Report.SelectQuery.LastIndexOf(" ORDER BY")).Replace("[RowNum]", "ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirection + ") AS [RowNum]");
            }
            else // change column to be sorted
            {
                if (Report.SelectQuery.Contains(" ORDER BY")) // row has already been sorted before
                {
                    Report.SelectQuery = Report.SelectQuery.Remove(Report.SelectQuery.LastIndexOf(" ORDER BY")).Replace("ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpressionPrevious + "]" + Report.SortDirectionPrevious + ") AS [RowNum]", "ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirection + ") AS [RowNum]");
                }
                else // manager sign report sorted for the first time
                {
                    Report.SelectQuery = Report.SelectQuery.Replace("ROW_NUMBER() OVER (ORDER BY [ShiftDate] DESC, [ShiftId] DESC) AS [RowNum]", "ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirection + ") AS [RowNum]");
                }
            }
        }
        else // if select query has already been changed, just change the sort direction
        {
            Report.SelectQuery = Report.SelectQuery.Remove(Report.SelectQuery.LastIndexOf(" ORDER BY")).Replace("ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirectionPrevious + ") AS [RowNum]", "ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirection + ") AS [RowNum]");
        }
        Report.SortExpressionPrevious = Report.SortExpression; // keep the previous sort expression selected
        Report.SortDirectionPrevious = Report.SortDirection; // keep the previous direction selected
        Report.SelectQuery += " ORDER BY " + Report.SortExpression + Report.SortDirection;
        sdsUserReports.SelectCommand = Report.SelectQuery;
        gvUserReports.DataBind();
    }

    protected void gvActionReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        sdsActionReports.SelectCommand = Report.SelectQuery;
        gvActionReports.PageIndex = e.NewPageIndex;
        gvActionReports.DataBind();
    }

    protected void gvActionReports_Sorting(object sender, GridViewSortEventArgs e)
    {
        gvActionReports.PageIndex = 0; // displays the first page of the list

        if (Report.Sort.Equals("Set"))
        {
            e.SortDirection = SortDirection.Ascending;
            Report.Sort = "Descending";
        }
        else if (Report.Sort.Equals("Descending"))
        {
            e.SortDirection = SortDirection.Descending;
            Report.Sort = "Ascending";
        }
        else if (Report.Sort.Equals("Ascending"))
        {
            e.SortDirection = SortDirection.Ascending;
            Report.Sort = "Descending";
        }

        Report.SortExpression = e.SortExpression.ToString(); // keep the column value that's being sorted

        if (e.SortDirection.ToString().Equals("Ascending")) // keep the value of sort direction
        {
            Report.SortDirection = " ASC";
        }
        else
        {
            Report.SortDirection = " DESC";
        }

        if (!Report.SelectQuery.Contains("ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]")) // if select query still has the default Order statement -  ORDER BY ShiftDate DESC, ShiftId DESC, RowNum
        { // change the order by sort expression and direction selected
            if (Report.SelectQuery.Contains(" ORDER BY"))
            { // change column to be sorted
                Report.SelectQuery = Report.SelectQuery.Remove(Report.SelectQuery.LastIndexOf(" ORDER BY")).Replace("ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpressionPrevious + "]" + Report.SortDirectionPrevious + ") AS [RowNum]", "ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirection + ") AS [RowNum]");
            }
            else // change the sort for the first time
            {
                Report.SelectQuery = Report.SelectQuery.Replace("ROW_NUMBER() OVER (ORDER BY [SubmittedDate] DESC) AS [RowNum]", "ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirection + ") AS [RowNum]");
            }
        }
        else // if select query has already been changed, just change the sort direction
        {
            Report.SelectQuery = Report.SelectQuery.Remove(Report.SelectQuery.LastIndexOf(" ORDER BY")).Replace("ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirectionPrevious + ") AS [RowNum]", "ROW_NUMBER() OVER(ORDER BY [" + Report.SortExpression + "]" + Report.SortDirection + ") AS [RowNum]");
        }
        Report.SortExpressionPrevious = Report.SortExpression; // keep the previous sort expression selected
        Report.SortDirectionPrevious = Report.SortDirection; // keep the previous direction selected
        Report.SelectQuery += " ORDER BY " + Report.SortExpression + Report.SortDirection;
        sdsActionReports.SelectCommand = Report.SelectQuery;
        gvActionReports.DataBind();
    }

    public string ConvertDateTime(object dateTime) // converts date format to "29/09/2017 13:38"
    {
        if (String.IsNullOrEmpty(dateTime.ToString()))
        {
            return "";
        }
        else
        {
            dateTime = Convert.ToDateTime(dateTime).ToString("dd/MM/yyyy HH:mm");
        }
        return dateTime.ToString();
    }
    public string ConvertDate(object date) // converts date format to "29/09/2017"
    {
        if (String.IsNullOrEmpty(date.ToString()))
        {
            return "";
        }
        else
        {
            date = Convert.ToDateTime(date).ToString("dd/MM/yyyy HH:mm");
        }
        return date.ToString();
    }
    public string RemoveBreakLine(object textbox)
    {
        if (String.IsNullOrEmpty(textbox.ToString()))
        {
            return "";
        }
        else
        {
            textbox = textbox.ToString().Replace("<br />", "\n");
        }
        return textbox.ToString();
    }

    protected void btnShowList_Click(object sender, EventArgs e) // show list of reports depending on the navigation tab selected
    {
        ShowList();

        if (Report.CurrentNavigationTab.Equals("1"))
        {
            DefaultList("ShowList"); // the parameter prevents SortReset to be triggered
            // update the notification list from user tabs
            ManagerSignNotification();
            ActionsAssignedNotification();
            ReportActionsNotification();
        }
        else if (Report.CurrentNavigationTab.Equals("2"))
        {
            ActionsAssigned("ShowList");
            ReportActionsNotification();
            ManagerSignNotification();
        }
        else if (Report.CurrentNavigationTab.Equals("3"))
        {
            ReportActions("ShowList");
            ActionsAssignedNotification();
            ManagerSignNotification();
        }
        else if (Report.CurrentNavigationTab.Equals("4"))
        {
            ManagerSign("ShowList");
            ActionsAssignedNotification();
            ReportActionsNotification();
        }
        HideLinkedReports();
        HidePendingActions();
        HideAttachedFiles();
    }

    protected void btnShowComment_Click(object sender, EventArgs e) // shows and hides the comment section
    {
        if (tblComment.Visible == false)
        {
            tblComment.Visible = true;
            btnShowComment.Text = "Hide Comment";
            btnShowComment1.Text = "Hide Comment";
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ScrollToCommentSection", "ToCommentSection();", true); // scroll to the attachedFiles
        }
        else
        {
            tblComment.Visible = false;
            btnShowComment.Text = "Show Comment";
            btnShowComment1.Text = "Show Comment";
        }
        UpdateFormView();
    }

    protected void btnReadReport_Click(object sender, EventArgs e) // update list of users who read the report selected
    {
        UpdateReadList("ReadReport"); // update the list of users who read the report
    }

    protected void UpdateReadList(string comingFrom) // update list of users who read the report selected
    {
        string updateRead;
        DateTime dateEntered = DateTime.Now;

        // get the readby written in the selected report
        sqlQuery.RetrieveData(Report.ActiveReport, "ReadList");

        string[] arrReadListStaffId = Report.ReadListStaffId.Split(',');
        bool hasRead = false;

        for (int i = 0; i < arrReadListStaffId.Length; i++)
        {
            if (arrReadListStaffId[i].ToString().Equals(UserCredentials.StaffId))
            {
                hasRead = true;
                break;
            }
        }

        // if the method was called from btnRead_Click, and the Read By List already contains the user's signature, display a message, else do nothing and return.
        if (comingFrom.Equals("ReadReport")) // coming from ReadReport OnClick event // if 'comingFrom' variable is 0, this method was called from btnAddComm_Click, else from btnRead_Click 
        {
            if (hasRead)
            {
                alert.DisplayMessage("User have already marked the report as read.");
                UpdateFormView();
                return;
            }
        }
        else // coming from Add Comment OnClick event
        {
            if (hasRead)
            {
                UpdateFormView();
                return;
            }
        }

        // set the updated readby string
        if (string.IsNullOrEmpty(Report.ReadList))
        { // if there's no read by list posted yet
            updateRead = UserCredentials.DisplayName + " " + Convert.ToDateTime(dateEntered).ToString("dd/MM/yyyy HH:mm");
        }
        else
        { // append readby to existing one
            updateRead = Report.ReadList + ", " + UserCredentials.DisplayName + " " + Convert.ToDateTime(dateEntered).ToString("dd/MM/yyyy HH:mm");
        }

        // update readby from selected report id
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE " + Report.Table + " SET ReadBy='" + updateRead + "', ReadByList='" + Report.ReadListStaffId + UserCredentials.StaffId + "," + "' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();

        // update the form view report
        UpdateFormView();
    }

    protected void btnComment_Click(object sender, EventArgs e) // update comment written in the report selected
    {
        string updateComment;
        DateTime dateEntered = DateTime.Now;

        // validate whether the comment textbox is not empty
        if (txtComment.Text.Equals(""))
        {
            alert.DisplayMessage("Please enter a comment. Message shouldn't be empty.");
            txtComment.Focus();
            // Load proper Form version
            UpdateFormView();
            return;
        }

        // get the comment written in the selected report
        sqlQuery.RetrieveData(Report.ActiveReport, "Comment");
        // set the updated comment string
        if (Report.Comment.Equals(""))
        { // if there's no comment posted yet
            updateComment = "-" + " " + txtComment.Text + "<br/>Commented by " + UserCredentials.DisplayName + " " + Convert.ToDateTime(dateEntered).ToString("dd/MM/yyyy HH:mm");
        }
        else
        { // append comment to existing one
            updateComment = Report.Comment + "<br/><br/>-" + " " + txtComment.Text + "<br/>Commented by " + UserCredentials.DisplayName + " " + Convert.ToDateTime(dateEntered).ToString("dd/MM/yyyy HH:mm");
        }

        // take off any apostrophe's in the comment section
        updateComment = updateComment.Replace("'", "");

        // update comment from selected report id
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE " + Report.Table + " SET Comments='" + updateComment + "' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();

        // clear the add comment textbox
        txtComment.Text = "";

        // update Read By List
        UpdateReadList("Comment");
    }

    protected void btnShowManagerSign_Click(object sender, EventArgs e) // blur out the body and show the digital signature statement for managers
    {
        ShowManagerSign();
    }
    protected void ShowManagerSign()
    {
        body.Style.Add("opacity", "0.15");
        managerSign.Visible = true;
        cbManagerSign.Checked = false;

        btnEdit.Enabled = false;
        btnPrint.Enabled = false;
        btnReadReport.Enabled = false;
        btnShowList.Enabled = false;
        btnShowLinked.Enabled = false;
        btnShowAttachedFiles.Enabled = false;
        btnShowComment.Enabled = false;

        // hide report navigation buttons
        imgNextReport.Visible = false;
        imgPreviousReport.Visible = false;
        imgBottomScreen.Visible = false;
        imgTopScreen.Visible = false;

        ViewReport(Report.ActiveReport);
    }
    protected void HideManagerSign()
    {
        body.Style.Add("opacity", "1");
        managerSign.Visible = false;

        btnEdit.Enabled = true;
        btnPrint.Enabled = true;
        btnReadReport.Enabled = true;
        btnShowList.Enabled = true;
        btnShowLinked.Enabled = true;
        btnShowAttachedFiles.Enabled = true;
        btnShowComment.Enabled = true;

        // display report navigation buttons
        imgNextReport.Visible = true;
        imgPreviousReport.Visible = true;
        imgBottomScreen.Visible = true;
        imgTopScreen.Visible = true;

        ViewReport(Report.ActiveReport);
    }
    protected void btnManagerSign_Click(object sender, EventArgs e)
    {
        if (cbManagerSign.Checked == false)
        {
            alert.DisplayMessage("Please tick the checkbox to digitally sign the form.");
            cbManagerSign.Focus();
            return;
        }
        else
        {
            // check if report has already been signed
            sqlQuery.RetrieveData(Report.ActiveReport, "HasManagerSign");
            if (Report.HasManagerSign)
            {
                alert.DisplayMessage("Report has already been signed. Please select Mark as Read button instead.");
                ViewReport(Report.ActiveReport);
                return;
            }

            // set the updated manager signature string
            string updateManagerSign = UserCredentials.DisplayName + " " + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:mm");

            // insert manager signature
            con.Open();
            SqlCommand updateSign = new SqlCommand("UPDATE " + Report.Table + " SET ManagerSign='" + updateManagerSign + "', ManagerSignId='" + UserCredentials.StaffId + "," + "' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
            updateSign.ExecuteNonQuery();
            con.Close();

            UpdateStatus();

            alert.DisplayMessage("Report has been signed.");

            if (Report.CurrentNavigationTab.Equals("4"))
            {
                Report.ChangeRowNumber = true; // gets triggered in NextReport() and PreviousReport() to whether subtract or add a Row Number value
            }

            HideManagerSign();
            CheckMode();
        }
    }
    protected void UpdateStatus() // update the status of the report
    {
        sqlQuery.RetrieveData("SELECT * FROM ActionRequired WHERE ReportId=" + Report.Id + " AND Completed <> 1", "HasPendingAction"); // check if there is pending actions
        sqlQuery.RetrieveData(Report.ActiveReport, "HasManagerSign"); // check if report has already been signed by manager
        sqlQuery.RetrieveData(Report.ActiveReport, "HasUserSign");
        sqlQuery.RetrieveData("SELECT ManagerSignOffRequired FROM Category WHERE ReportName='" + Report.Name + "'", "ManagerSignOffRequired");

        // update status depending on action completed flag
        if (Report.HasPendingAction) // report has pending actions
        {
            if (Report.HasUserSign)
            {
                // update status from selected report id
                con.Open();
                SqlCommand updateReportStatus = new SqlCommand("UPDATE " + Report.Table + " SET ReportStat='Further Action Required' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
                updateReportStatus.ExecuteNonQuery();
                con.Close();

                // update all actions with this report status - Make it the updated Status
                con.Open();
                SqlCommand updateActionStatus = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='Further Action Required', AuditVersion='" + Report.AuditVersion + "'" +
                                                 " WHERE ReportId='" + Report.Id + "'", con);
                updateActionStatus.ExecuteNonQuery();
                con.Close();

                // update value of status for current report selected
                Report.Status = "Further Action Required";
            }
        }
        else // all actions are completed
        {
            if (Report.ManagerSignOffRequired)
            {
                if (Report.HasManagerSign) // report has already been signed by a manager
                {
                    // update status from selected report id
                    con.Open();
                    SqlCommand updateReportStatus = new SqlCommand("UPDATE " + Report.Table + " SET ReportStat='Report Completed' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
                    updateReportStatus.ExecuteNonQuery();
                    con.Close();

                    // update all actions with this report status - Make it the updated Status
                    con.Open();
                    SqlCommand updateActionStatus = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='Report Completed', AuditVersion='" + Report.AuditVersion + "'" +
                                                     " WHERE ReportId='" + Report.Id + "'", con);
                    updateActionStatus.ExecuteNonQuery();
                    con.Close();

                    // update value of status for current report selected
                    Report.Status = "Report Completed";
                }
                else
                {
                    if (!Report.HasUserSign)
                    {
                        // update status from selected report id
                        con.Open();
                        SqlCommand updateReportStatus = new SqlCommand("UPDATE " + Report.Table + " SET ReportStat='Awaiting Completion' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
                        updateReportStatus.ExecuteNonQuery();
                        con.Close();

                        // update all actions with this report status - Make it the updated Status
                        con.Open();
                        SqlCommand updateActionStatus = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='Awaiting Completion', AuditVersion='" + Report.AuditVersion + "'" +
                                                         " WHERE ReportId='" + Report.Id + "'", con);
                        updateActionStatus.ExecuteNonQuery();
                        con.Close();

                        // update value of status for current report selected
                        Report.Status = "Awaiting Completion";
                    }
                    else
                    {
                        // update status from selected report id
                        con.Open();
                        SqlCommand updateReportStatus = new SqlCommand("UPDATE " + Report.Table + " SET ReportStat='Awaiting Manager Sign-off' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
                        updateReportStatus.ExecuteNonQuery();
                        con.Close();

                        // update all actions with this report status - Make it the updated Status
                        con.Open();
                        SqlCommand updateActionStatus = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='Awaiting Manager Sign-off', AuditVersion='" + Report.AuditVersion + "'" +
                                                         " WHERE ReportId='" + Report.Id + "'", con);
                        updateActionStatus.ExecuteNonQuery();
                        con.Close();

                        // update value of status for current report selected
                        Report.Status = "Awaiting Manager Sign-off";
                    }
                }
            }
            else // the report doesn't need a manager sign-off
            {
                if (!Report.HasUserSign)
                {
                    // update status from selected report id
                    con.Open();
                    SqlCommand updateReportStatus = new SqlCommand("UPDATE " + Report.Table + " SET ReportStat='Awaiting Completion' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
                    updateReportStatus.ExecuteNonQuery();
                    con.Close();

                    // update all actions with this report status - Make it the updated Status
                    con.Open();
                    SqlCommand updateActionStatus = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='Awaiting Completion', AuditVersion='" + Report.AuditVersion + "'" +
                                                     " WHERE ReportId='" + Report.Id + "'", con);
                    updateActionStatus.ExecuteNonQuery();
                    con.Close();

                    // update value of status for current report selected
                    Report.Status = "Awaiting Completion";
                }
                else
                {
                    // update status from selected report id
                    con.Open();
                    SqlCommand updateReportStatus = new SqlCommand("UPDATE " + Report.Table + " SET ReportStat='Report Completed' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
                    updateReportStatus.ExecuteNonQuery();
                    con.Close();

                    // update all actions with this report status - Make it the updated Status
                    con.Open();
                    SqlCommand updateActionStatus = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='Report Completed', AuditVersion='" + Report.AuditVersion + "'" +
                                                     " WHERE ReportId='" + Report.Id + "'", con);
                    updateActionStatus.ExecuteNonQuery();
                    con.Close();

                    // update value of status for current report selected
                    Report.Status = "Report Completed";
                }
            }
            
        }
    }
    protected void btnCancelManagerSign_Click(object sender, EventArgs e)
    {
        HideManagerSign();
        CheckMode();
        ViewReport(Report.ActiveReport);
    }

    protected void btnShowUserSign_Click(object sender, EventArgs e)
    {
        ShowUserSign();
    }
    protected void ShowUserSign()
    {
        body.Style.Add("opacity", "0.15");
        userSign.Visible = true;
        cbUserSign.Checked = false;

        btnShowUserSign.Enabled = false;
        btnUpdate.Enabled = false;
        btnShowReport.Enabled = false;
    }
    protected void HideUserSign()
    {
        body.Style.Add("opacity", "1");
        userSign.Visible = false;

        btnShowUserSign.Enabled = true;
        btnUpdate.Enabled = true;
        btnShowReport.Enabled = true;
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
            // check if report has already been signed
            sqlQuery.RetrieveData(Report.ActiveReport, "HasUserSign");
            if (Report.HasUserSign)
            {
                alert.DisplayMessage("You have already signed the report.");
                ViewReport(Report.ActiveReport);
                return;
            }

            // set the updated user signature string
            string updateUserSign = UserCredentials.DisplayName + " " + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:mm");

            // insert staff signature
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE " + Report.Table + " SET StaffSign='" + updateUserSign + "' WHERE ReportId='" + Report.Id + "' AND AuditVersion='" + Report.AuditVersion + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            UpdateReport();
            UpdateStatus();

            phUserControl.Visible = false; // hide the Placeholder (EditItemTemplate)

            alert.DisplayMessage("Report has been signed.");

            HideUserSign();
        }
    }
    protected void btnCancelUserSign_Click(object sender, EventArgs e)
    {
        HideUserSign();
        CheckMode();
        ViewReport(Report.ActiveReport);
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        EditMode();
    }
    protected void EditMode()
    {
        if (Report.SelectedStaffId.Equals(UserCredentials.StaffId))
        {
            tblComment.Visible = false;         // hide comment section (just in case opened)
            tblReportObjects.Visible = true;    // show all report objects

            trUser.Visible = true;              // display user objects
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
            btnPrint.Visible = false;
            btnShowReport.Visible = true;
            btnShowComment.Visible = false;

            trManager.Visible = false;          // hide manager objects

            trSign.Visible = true;              // show other objects
            if (Report.Status == "Awaiting Completion")
            {
                btnShowUserSign.Visible = true;
            }
            else
            {
                btnShowUserSign.Visible = false;
            }
            btnShowList.Visible = false;
            btnReadReport.Visible = false;
            btnShowActions.Visible = false;

            trLinked.Visible = false;           // show linked objects
            trAttachedFiles.Visible = false;
            HideLinkedReports();
            HidePendingActions();
            HideAttachedFiles();

            fvReport.Visible = false;           // hide viewed report

            tblRecords.Visible = false;         // hide Judiciary Records

            imgNextReport.Visible = false;
            imgPreviousReport.Visible = false;
            imgBottomScreen.Visible = true;
            imgTopScreen.Visible = true;
            btnLinkAttachedFiles.Visible = false;
            btnLinkLinkedReports.Visible = false;
            btnLinkPendingActions.Visible = false;
            SpellButton1.Visible = true;

            phUserControl.Visible = true;
            string file = "~/Reports/" + Report.Name + "/Edit/v" + Report.Version + "/v" + Report.Version + ".ascx";

            try
            {
                UserControl uc; uc = (UserControl)LoadControl(file);
                phUserControl.Controls.Clear();
                phUserControl.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                alert.DisplayMessage(ex.ToString());
            }
        }
        else
        {
            ShowList();
            if (Report.CurrentNavigationTab.Equals("1"))
            {
                DefaultList("ShowList"); // the parameter prevents SortReset to be triggered
            }
            else if (Report.CurrentNavigationTab.Equals("2"))
            {
                ActionsAssigned("ShowList");
                ManagerSignNotification();
            }
            else if (Report.CurrentNavigationTab.Equals("3"))
            {
                ReportActions("ShowList");
                ManagerSignNotification();
            }
            else if (Report.CurrentNavigationTab.Equals("4"))
            {
                ManagerSign("ShowList");
            }
            HideLinkedReports();
            HidePendingActions();
            HideAttachedFiles();
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        CheckMode();
        ViewReport(Report.ActiveReport);
        sdsViewReport.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateReport();
    }

    protected void UpdateReport()
    {
        if (Report.HasErrorMessage) // don't update if error exist
        {
            // display a message box
            alert.DisplayMessage(Report.ErrorMessage);
        }
        else
        {
            if (!Report.Status.Equals("Awaiting Completion")) // do an insert statement (new audit version)
            {
                if (Report.Name.Contains("Incident"))
                {
                    if (!Report.HasChange && !Report.HasImageChange) // no changes made
                    {
                        alert.DisplayMessage("No changes made.");
                    }
                    else // changes were made
                    {
                        string changedWhere = Report.WhereChangeHappened; // for debugging - stores where the change happened
                        NewReportAuditVersion();
                    }
                }
                else
                {
                    if (!Report.HasChange) // no changes made
                    {
                        alert.DisplayMessage("No changes made.");
                    }
                    else // changes were made
                    {
                        string changedWhere = Report.WhereChangeHappened; // for debugging - stores where the change happened
                        NewReportAuditVersion();
                    }
                }
            }
            else // do an update statement
            {
                string changedWhere = Report.WhereChangeHappened; // for debugging - stores where the change happened
                UpdateReportAuditVersion();
            }

            Report.ActiveReport = "SELECT rt.StaffId, rt.StaffName, rt.ShiftId, st.ShiftName, c.ReportName, *" + // update the active report 
                           " FROM " + Report.Table + " rt, [Staff] s, [Shift] st, [Category] c" +
                           " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Report.Id +
                           " AND rt.AuditVersion=" + Report.AuditVersion;
            CheckMode();
            Report.HasChange = false; // change was notified, set this back to unchanged
            Report.WhereChangeHappened = "";
            Report.HasImageChange = false; // change was notified, set this back to unchanged
            ViewReport(Report.ActiveReport);
        }
    }

    protected void NewReportAuditVersion()
    {
        con.Open();
        SqlCommand checkExist = new SqlCommand("SELECT MAX(AuditVersion)" +
                                               " FROM [" + Report.Table + "]" +
                                               " WHERE ReportId =" + Report.Id, con);
        int newAuditVersion = (int)checkExist.ExecuteScalar();
        con.Close();

        // add plus one to the maximum audit version recorded
        newAuditVersion = newAuditVersion + 1;
        Report.AuditVersion = (newAuditVersion).ToString();

        // update all actions with this audit version - Make it the updated Audit Version
        con.Open();
        SqlCommand cmd1 = new SqlCommand("UPDATE [ActionRequired] SET AuditVersion='" + Report.AuditVersion + "'" +
                                         " WHERE ReportId='" + Report.Id + "'", con);
        cmd1.ExecuteNonQuery();
        con.Close();

        // get the comment written in the selected report
        sqlQuery.RetrieveData(Report.ActiveReport, "Comment");

        // update the selected report & sets Report Status to Awaiting Completion
        con.Open();
        SqlCommand cmd = new SqlCommand(Report.InsertQuery(), con); // insert a new row in the table with a different audit version
        cmd.ExecuteNonQuery();
        con.Close();

        if (Report.Name.Contains("MR Incident"))
        {
            if (ReportIncidentMr.MemberPhoto1 != null)
            { // update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto2 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentMr.MemberPhoto2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto3 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto4 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto5 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }

            if (ReportIncidentMr.HumanBody1 != null)
            { // update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody2 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentMr.HumanBody2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody3 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody4 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody5 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        if (Report.Name.Contains("CU Incident"))
        {
            if (ReportIncidentCu.MemberPhoto1 != null)
            { // update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto2 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentCu.MemberPhoto2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto3 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto4 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto5 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }

            if (ReportIncidentCu.HumanBody1 != null)
            { // update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody2 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentCu.HumanBody2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody3 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody4 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody5 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        // update all actions with this report status - Make it the updated Status
        con.Open();
        SqlCommand cmd2 = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='Awaiting Completion'" +
                                         " WHERE ReportId='" + Report.Id + "'", con);
        cmd2.ExecuteNonQuery();
        con.Close();

        Report.Status = "Awaiting Completion"; // just in case the user edits the report again after it has just been updated (Stops the program from incrementing the audti version again)
        alert.DisplayMessage("Report was Modified");
    }

    protected void UpdateReportAuditVersion()
    {
        // update the selected report
        con.Open();
        SqlCommand cmd = new SqlCommand(Report.UpdateQuery(), con);
        cmd.ExecuteNonQuery();
        con.Close();

        // update all actions with this report status - Make it the updated Status
        con.Open();
        SqlCommand cmd2 = new SqlCommand("UPDATE [ActionRequired] SET ReportStat='" + Report.Status + "'" +
                                         " WHERE ReportId='" + Report.Id + "'", con);
        cmd2.ExecuteNonQuery();
        con.Close();

        if (Report.Name.Contains("MR Incident"))
        {
            if (ReportIncidentMr.MemberPhoto1 != null)
            { // update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto2 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentMr.MemberPhoto2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto3 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto4 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.MemberPhoto5 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.MemberPhoto5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET MemberPhoto5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }

            if (ReportIncidentMr.HumanBody1 != null)
            { // update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody2 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentMr.HumanBody2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody3 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody4 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentMr.HumanBody5 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentMr.HumanBody5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptMRIncident SET Image5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        if (Report.Name.Contains("CU Incident"))
        {
            if (ReportIncidentCu.MemberPhoto1 != null)
            { // update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto2 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentCu.MemberPhoto2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto3 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto4 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.MemberPhoto5 != null)
            {// update the Member Image Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.MemberPhoto5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET MemberPhoto5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }

            if (ReportIncidentCu.HumanBody1 != null)
            { // update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image1=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody1;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image1=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody2 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image2=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.DbType = DbType.Binary;
                par.ParameterName = "image";
                par.Value = ReportIncidentCu.HumanBody2;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image2=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody3 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image3=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody3;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image3=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody4 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image4=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody4;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image4=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            if (ReportIncidentCu.HumanBody5 != null)
            {// update the Human Body Photo
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image5=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                IDataParameter par = command.CreateParameter();
                par.ParameterName = "image";
                par.DbType = DbType.Binary;
                par.Value = ReportIncidentCu.HumanBody5;
                command.Parameters.Add(par);
                command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE rptUMIncident SET Image5=NULL WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    protected void OnRowDataBound_JudiciaryRecord(object sender, GridViewRowEventArgs e) // Judiciary Record - Allegation
    {
        Button btnEdit = (Button)e.Row.FindControl("btnEdit");
        Button btnDelete = (Button)e.Row.FindControl("btnDelete");
        Button btnInsert = (Button)e.Row.FindControl("btnInsert");
        Button btnInsert1 = (Button)e.Row.FindControl("btnInsert1");
        TextBox txtStatement = (TextBox)e.Row.FindControl("txtStatement");
        TextBox txtStatement1 = (TextBox)e.Row.FindControl("txtStatement1");
        Label lblStaffId = (Label)e.Row.FindControl("lblStaffId");
        Label lblStatement = (Label)e.Row.FindControl("lblStatement");
        Label lblStatement1 = (Label)e.Row.FindControl("lblStatement1");

        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (!UserCredentials.GroupsQuery.Contains("Allegation") || Report.Status.Equals("Awaiting Completion"))
                {
                    e.Row.Cells[0].Visible = false;
                }
                else
                {

                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!UserCredentials.GroupsQuery.Contains("Allegation") || Report.Status.Equals("Awaiting Completion"))
                {
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    e.Row.Cells[0].Visible = false;
                }
                else
                {
                    // check whether the action was created from this patron - if yes, show delete else hide delete button.
                    if (lblStaffId.Text.Equals(UserCredentials.StaffId))
                    {
                        btnEdit.Visible = true;
                        btnDelete.Visible = true;
                    }
                    else
                    {
                        btnEdit.Visible = false;
                        btnDelete.Visible = false;
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (!UserCredentials.GroupsQuery.Contains("Allegation") || Report.Status.Equals("Awaiting Completion"))
                {
                    btnInsert.Visible = false;
                    lblStatement.Visible = false;
                    txtStatement.Visible = false;
                    e.Row.Cells[0].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                }
                else
                {

                }
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                if (!UserCredentials.GroupsQuery.Contains("Allegation") || Report.Status.Equals("Awaiting Completion"))
                {
                    btnInsert1.Visible = false;
                    lblStatement1.Text = "";
                    txtStatement1.Visible = false;
                }

                else
                {

                }
            }
        }
        catch
        {

        }
    }
    protected void gvRecAllegation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Retrieve controls
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        Label lblId = (Label)row.FindControl("lblId");
        TextBox txtStatement = (TextBox)row.FindControl("txtStatement");
        TextBox txtStatement1 = (TextBox)row.FindControl("txtStatement1");
        Label lblDateEntered = (Label)row.FindControl("lblDateEntered");
        string activeDescription = "";

        if (e.CommandName.Equals("EmptyDataTemplateInsert"))
        {
            // check if control has ' and if it is null
            txtStatement1.Text = txtStatement1.Text.Replace("'", "");
            if (txtStatement1.Text == "")
            {
                alert.DisplayMessage("Action required description can't be empty.");
                ViewReport(Report.ActiveReport); return;
            }

            // Set parameters
            sdsRecAllegation.InsertParameters["ReportId"].DefaultValue = Report.Id;
            sdsRecAllegation.InsertParameters["StaffId"].DefaultValue = UserCredentials.StaffId;
            sdsRecAllegation.InsertParameters["Statement"].DefaultValue = txtStatement1.Text;
            sdsRecAllegation.InsertParameters["Name"].DefaultValue = UserCredentials.DisplayName;
            sdsRecAllegation.InsertParameters["DateEntered"].DefaultValue = DateTime.Now.ToString();

            // Perform insert
            sdsRecAllegation.Insert();
            UpdateFormView();
        }
        else if (e.CommandName.Equals("FooterInsert"))
        {
            // Retrieve controls
            TextBox txtStatement2 = (TextBox)row.FindControl("txtStatement");

            // check if control has ' and if it is null
            txtStatement2.Text = txtStatement2.Text.Replace("'", "");
            if (txtStatement2.Text == "")
            {
                alert.DisplayMessage("Action required Statement can't be empty.");
                ViewReport(Report.ActiveReport);
                return;
            }


            // Set parameters
            sdsRecAllegation.InsertParameters["ReportId"].DefaultValue = Report.Id;
            sdsRecAllegation.InsertParameters["StaffId"].DefaultValue = UserCredentials.StaffId;
            sdsRecAllegation.InsertParameters["Statement"].DefaultValue = txtStatement.Text;
            sdsRecAllegation.InsertParameters["Name"].DefaultValue = UserCredentials.DisplayName;
            sdsRecAllegation.InsertParameters["DateEntered"].DefaultValue = DateTime.Now.ToString();

            // Perform insert
            sdsRecAllegation.Insert();
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Edit"))
        {
            try
            {
                activeDescription = txtStatement.Text;
            }
            catch
            {

            }
            ViewReport(Report.ActiveReport);
        }
        else if (e.CommandName.Equals("Cancel"))
        {
            ViewReport(Report.ActiveReport);
        }
        else if (e.CommandName.Equals("Delete"))
        {
            sdsRecAllegation.DeleteCommand = "DELETE FROM [recAllegation] WHERE [id] = " + lblId.Text;
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Update"))
        {
            // check if control has ' and if it is null
            txtStatement.Text = txtStatement.Text.Replace("'", "");
            if (txtStatement.Text.Equals(""))
            {
                alert.DisplayMessage("Action wasn't updated, please don't leave the Statement textbox empty.");
                sdsRecAllegation.UpdateCommand = "UPDATE [recAllegation] SET [Statement] = '" + activeDescription + "' WHERE [id] = " + lblId.Text;
                return;
            }

            sdsRecAllegation.UpdateCommand = "UPDATE [recAllegation] SET [Statement] = '" + txtStatement.Text + "' WHERE [id] = " + lblId.Text;

            UpdateFormView();
        }
    }
    protected void OnInserted_JudiciaryRecord(object sender, SqlDataSourceStatusEventArgs e)
    {
        if ((e.Exception == null) && e.AffectedRows.Equals(1))
        {
            alert.DisplayMessage("Action successfully entered.");
        }
        else
        {
            alert.DisplayMessage("Unable to successfully enter action.");
            e.ExceptionHandled = true;
        }
    }
    protected void OnRowUpdated_JudiciaryRecord(object sender, GridViewUpdatedEventArgs e)
    {
        if ((e.Exception == null) && e.AffectedRows.Equals(1))
        {
            alert.DisplayMessage("Successfully updated.");
        }
        else
        {
            alert.DisplayMessage("Unable to successfully update.");
            e.ExceptionHandled = true;
        }
    }
    protected void OnRowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if ((e.Exception == null) && e.AffectedRows.Equals(1) || e.AffectedRows.Equals(2))
        {
            alert.DisplayMessage("Successfully deleted.");
        }
        else
        {
            alert.DisplayMessage("Unable to successfully delete.");
            e.ExceptionHandled = true;
        }
    }
    protected void gvRecDiscAction_RowCommand(object sender, GridViewCommandEventArgs e) // Disciplinary Action
    {
        // Retrieve controls
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        Label lblId = (Label)row.FindControl("lblId");
        TextBox txtStatement = (TextBox)row.FindControl("txtStatement");
        TextBox txtStatement1 = (TextBox)row.FindControl("txtStatement1");
        Label lblDateEntered = (Label)row.FindControl("lblDateEntered");

        if (e.CommandName.Equals("EmptyDataTemplateInsert"))
        {
            // check if control has ' and if it is null
            txtStatement1.Text = txtStatement1.Text.Replace("'", "");
            if (txtStatement1.Text == "")
            {
                alert.DisplayMessage("Action required description can't be empty.");

                ViewReport(Report.ActiveReport);
                return;
            }

            // Set parameters
            sdsRecDiscAction.InsertParameters["ReportId"].DefaultValue = Report.Id;
            sdsRecDiscAction.InsertParameters["StaffId"].DefaultValue = UserCredentials.StaffId;
            sdsRecDiscAction.InsertParameters["Statement"].DefaultValue = txtStatement1.Text;
            sdsRecDiscAction.InsertParameters["Name"].DefaultValue = UserCredentials.DisplayName;
            sdsRecDiscAction.InsertParameters["DateEntered"].DefaultValue = DateTime.Now.ToString();

            // Perform insert
            sdsRecDiscAction.Insert();
            UpdateFormView();
        }
        else if (e.CommandName.Equals("FooterInsert"))
        {
            // Retrieve controls
            TextBox txtStatement2 = (TextBox)row.FindControl("txtStatement");

            // check if control has ' and if it is null
            txtStatement2.Text = txtStatement2.Text.Replace("'", "");
            if (txtStatement2.Text == "")
            {
                alert.DisplayMessage("Action required Statement can't be empty.");
                ViewReport(Report.ActiveReport);
                return;
            }


            // Set parameters
            sdsRecDiscAction.InsertParameters["ReportId"].DefaultValue = Report.Id;
            sdsRecDiscAction.InsertParameters["StaffId"].DefaultValue = UserCredentials.StaffId;
            sdsRecDiscAction.InsertParameters["Statement"].DefaultValue = txtStatement.Text;
            sdsRecDiscAction.InsertParameters["Name"].DefaultValue = UserCredentials.DisplayName;
            sdsRecDiscAction.InsertParameters["DateEntered"].DefaultValue = DateTime.Now.ToString();

            // Perform insert
            sdsRecDiscAction.Insert();
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Edit"))
        {
            ViewReport(Report.ActiveReport);
        }
        else if (e.CommandName.Equals("Cancel"))
        {
            ViewReport(Report.ActiveReport);
        }
        else if (e.CommandName.Equals("Delete"))
        {
            sdsRecDiscAction.DeleteCommand = "DELETE FROM [recDiscAction] WHERE [id] = " + lblId.Text;
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Update"))
        {
            // store current fields (Just in case it triggers an error message)
            // Statement
            string currentStatement;
            con.Open();
            SqlCommand checkExist = new SqlCommand("SELECT Statement FROM [recDiscAction] WHERE [id] = " + lblId.Text, con);
            try
            {
                currentStatement = (string)checkExist.ExecuteScalar();
            }
            catch
            {
                currentStatement = "";
            }
            con.Close();

            // check if control has ' and if it is null
            txtStatement.Text = txtStatement.Text.Replace("'", "");
            if (txtStatement.Text.Equals(""))
            {
                alert.DisplayMessage("Action wasn't updated, please don't leave the Statement textbox empty.");
                sdsRecDiscAction.UpdateCommand = "UPDATE [recDiscAction] SET [Statement] = '" + currentStatement + "' WHERE [id] = " + lblId.Text;
                return;
            }

            sdsRecDiscAction.UpdateCommand = "UPDATE [recDiscAction] SET [Statement] = '" + txtStatement.Text + "' WHERE [id] = " + lblId.Text;
            UpdateFormView();
        }
    }
    protected void gvRecJudiciary_RowDataBound(object sender, GridViewRowEventArgs e) // Judiciary Committee/Board Decision
    {
        Button btnEdit = (Button)e.Row.FindControl("btnEdit");
        Button btnInsert1 = (Button)e.Row.FindControl("btnInsert1");
        TextBox txtDecision = (TextBox)e.Row.FindControl("txtDecision");
        TextBox txtDecision1 = (TextBox)e.Row.FindControl("txtDecision1");
        TextBox txtDate = (TextBox)e.Row.FindControl("txtDate");
        TextBox txtDate1 = (TextBox)e.Row.FindControl("txtDate1");
        TextBox txtStartDate = (TextBox)e.Row.FindControl("txtStartDate");
        TextBox txtStartDate1 = (TextBox)e.Row.FindControl("txtStartDate1");
        TextBox txtEndDate = (TextBox)e.Row.FindControl("txtEndDate");
        TextBox txtEndDate1 = (TextBox)e.Row.FindControl("txtEndDate1");
        Label lblStaffId = (Label)e.Row.FindControl("lblStaffId");
        Label lblDecision1 = (Label)e.Row.FindControl("lblDecision1");
        Label lblDate1 = (Label)e.Row.FindControl("lblDate1");
        Label lblStartDate1 = (Label)e.Row.FindControl("lblStartDate1");
        Label lblEndDate1 = (Label)e.Row.FindControl("lblEndDate1");

        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (!UserCredentials.GroupsQuery.Contains("Allegation") || Report.Status.Equals("Awaiting Completion"))
                {
                    e.Row.Cells[0].Visible = false;
                }
                else
                {

                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!UserCredentials.GroupsQuery.Contains("Allegation") || Report.Status.Equals("Awaiting Completion"))
                {
                    btnEdit.Visible = false;
                    e.Row.Cells[0].Visible = false;
                }
                else
                {
                    // check whether the action was created from this patron - if yes, show delete else hide delete button.
                    if (lblStaffId.Text.Equals(UserCredentials.StaffId))
                    {
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        btnEdit.Visible = false;
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                if (!UserCredentials.GroupsQuery.Contains("Allegation") || Report.Status.Equals("Awaiting Completion"))
                {
                    btnInsert1.Visible = false;
                    lblDecision1.Text = "";
                    txtDecision1.Visible = false;
                    lblDate1.Text = "";
                    txtDate1.Visible = false;
                    lblEndDate1.Text = "";
                    txtEndDate1.Visible = false;
                    lblStartDate1.Text = "";
                    txtStartDate1.Visible = false;
                }
                else
                {

                }
            }
        }
        catch
        {

        }
    }
    protected void gvRecJudiciary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Retrieve controls
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        Label lblId = (Label)row.FindControl("lblId");
        TextBox txtDecision = (TextBox)row.FindControl("txtDecision");
        TextBox txtDate = (TextBox)row.FindControl("txtDate");
        TextBox txtStartDate = (TextBox)row.FindControl("txtStartDate");
        TextBox txtEndDate = (TextBox)row.FindControl("txtEndDate");
        Label lblDecision1 = (Label)row.FindControl("lblDecision1");
        Label lblDate1 = (Label)row.FindControl("lblDate1");
        Label lblStartDate1 = (Label)row.FindControl("lblStartDate");
        Label lblEndDate1 = (Label)row.FindControl("lblEndDate1");
        TextBox txtDecision1 = (TextBox)row.FindControl("txtDecision1");
        TextBox txtDate1 = (TextBox)row.FindControl("txtDate1");
        TextBox txtStartDate1 = (TextBox)row.FindControl("txtStartDate1");
        TextBox txtEndDate1 = (TextBox)row.FindControl("txtEndDate1");
        DateTime temp;

        if (e.CommandName.Equals("EmptyDataTemplateInsert"))
        {
            // check if control has ' and if it is null
            txtDecision1.Text = txtDecision1.Text.Replace("'", "");
            txtDate1.Text = txtDate1.Text.Replace("'", "");
            txtStartDate1.Text = txtStartDate1.Text.Replace("'", "");
            txtEndDate1.Text = txtEndDate1.Text.Replace("'", "");
            if (txtDecision1.Text == "")
            {
                alert.DisplayMessage("Description can't be empty.");
                UpdateFormView();
                return;
            }
            if (txtDate1.Text == "")
            {
                alert.DisplayMessage("Date can't be empty.");
                UpdateFormView();
                return;
            }
            else if (!DateTime.TryParse(txtDate1.Text, out temp))
            {
                alert.DisplayMessage("Entered Date is not of type Date. Please check your input.");
                UpdateFormView();
                return;
            }
            if (txtStartDate1.Text == "")
            {
                alert.DisplayMessage("Start Date can't be empty.");
                UpdateFormView();
                return;
            }
            else if (!DateTime.TryParse(txtStartDate1.Text, out temp))
            {
                alert.DisplayMessage("Entered Start Date is not of type Date. Please check your input.");
                UpdateFormView();
                return;
            }
            if (txtEndDate1.Text != "")
            {
                if (!DateTime.TryParse(txtEndDate1.Text, out temp))
                {
                    alert.DisplayMessage("Entered End Date is not of type Date. Please check your input.");
                    UpdateFormView();
                    return;
                }
            }

            // Set parameters
            sdsRecJudiciary.InsertParameters["ReportId"].DefaultValue = Report.Id;
            sdsRecJudiciary.InsertParameters["StaffId"].DefaultValue = UserCredentials.StaffId;
            sdsRecJudiciary.InsertParameters["Name"].DefaultValue = UserCredentials.DisplayName;
            sdsRecJudiciary.InsertParameters["Decision"].DefaultValue = txtDecision1.Text;
            sdsRecJudiciary.InsertParameters["Date"].DefaultValue = txtDate1.Text;
            sdsRecJudiciary.InsertParameters["StartDate"].DefaultValue = txtStartDate1.Text;
            if (txtEndDate1.Text != "")
            {
                sdsRecJudiciary.InsertParameters["EndDate"].DefaultValue = txtEndDate1.Text;
            }
            else
            {
                sdsRecJudiciary.InsertParameters["EndDate"].DefaultValue = null;
            }

            // Perform insert
            sdsRecJudiciary.Insert();
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Edit"))
        {
            ViewReport(Report.ActiveReport);
        }
        else if (e.CommandName.Equals("Cancel"))
        {
            ViewReport(Report.ActiveReport);
        }
        else if (e.CommandName.Equals("Update"))
        {
            // store current fields (Just in case it triggers an error message)
            // StaffId
            con.Open();
            SqlCommand checkExist = new SqlCommand("SELECT StaffId FROM [recJudiciary] WHERE [id] = " + lblId.Text, con);
            int currentStaffId = (int)checkExist.ExecuteScalar();
            con.Close();
            // Name
            con.Open();
            SqlCommand checkExist1 = new SqlCommand("SELECT Name FROM [recJudiciary] WHERE [id] = " + lblId.Text, con);
            string currentName = (string)checkExist1.ExecuteScalar();
            con.Close();
            // Decision
            con.Open();
            SqlCommand checkExist2 = new SqlCommand("SELECT Decision FROM [recJudiciary] WHERE [id] = " + lblId.Text, con);
            string currentDecision = (string)checkExist2.ExecuteScalar();
            con.Close();
            // Date
            con.Open();
            SqlCommand checkExist3 = new SqlCommand("SELECT Date FROM [recJudiciary] WHERE [id] = " + lblId.Text, con);
            DateTime currentDate = (DateTime)checkExist3.ExecuteScalar();
            con.Close();
            // Start Date
            con.Open();
            SqlCommand checkExist4 = new SqlCommand("SELECT StartDate FROM [recJudiciary] WHERE [id] = " + lblId.Text, con);
            DateTime currentStartDate = (DateTime)checkExist4.ExecuteScalar();
            con.Close();
            // End Date
            // flag if the End Date variable is empty
            DateTime currentEndDate = DateTime.Now;
            int flag = 0;
            con.Open();
            SqlCommand checkExist5 = new SqlCommand("SELECT EndDate FROM [recJudiciary] WHERE [id] = " + lblId.Text, con);
            try
            {
                currentDate = (DateTime)checkExist5.ExecuteScalar();
            }
            catch
            {
                flag = 1;
            }
            con.Close();

            // check if control has ' and if it is null
            txtDecision.Text = txtDecision.Text.Replace("'", "");
            txtDate.Text = txtDate.Text.Replace("'", "");
            txtStartDate.Text = txtStartDate.Text.Replace("'", "");
            txtEndDate.Text = txtEndDate.Text.Replace("'", "");
            if (txtDecision.Text == "")
            {
                alert.DisplayMessage("Decision can't be empty.");
                if (flag == 0)
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = (CONVERT(DateTime,'" + currentEndDate + "',103)) WHERE [id] = " + lblId.Text;
                }
                else
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = NULL WHERE [id] = " + lblId.Text;
                }
                return;
            }
            if (txtDate.Text == "")
            {
                alert.DisplayMessage("Date can't be empty.");
                if (flag == 0)
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = (CONVERT(DateTime,'" + currentEndDate + "',103)) WHERE [id] = " + lblId.Text;
                }
                else
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = NULL WHERE [id] = " + lblId.Text;
                }
                return;
            }
            else if (!DateTime.TryParse(txtDate.Text, out temp))
            {
                alert.DisplayMessage("Entered Date is not of type Date. Please check your input.");
                if (flag == 0)
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = (CONVERT(DateTime,'" + currentEndDate + "',103)) WHERE [id] = " + lblId.Text;
                }
                else
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = NULL WHERE [id] = " + lblId.Text;
                }
                return;
            }
            if (txtStartDate.Text == "")
            {
                alert.DisplayMessage("Start Date can't be empty.");
                if (flag == 0)
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = (CONVERT(DateTime,'" + currentEndDate + "',103)) WHERE [id] = " + lblId.Text;
                }
                else
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = NULL WHERE [id] = " + lblId.Text;
                }
                return;
            }
            else if (!DateTime.TryParse(txtStartDate.Text, out temp))
            {
                alert.DisplayMessage("Entered Start Date is not of type Date. Please check your input.");
                if (flag == 0)
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = (CONVERT(DateTime,'" + currentEndDate + "',103)) WHERE [id] = " + lblId.Text;
                }
                else
                {
                    sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = NULL WHERE [id] = " + lblId.Text;
                }
                return;
            }
            if (txtEndDate.Text != "")
            {
                if (!DateTime.TryParse(txtEndDate.Text, out temp))
                {
                    alert.DisplayMessage("Entered End Date is not of type Date. Please check your input.");
                    if (flag == 0)
                    {
                        sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = (CONVERT(DateTime,'" + currentEndDate + "',103)) WHERE [id] = " + lblId.Text;
                    }
                    else
                    {
                        sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + currentStaffId + ", [Name] = '" + currentName + "', [Decision] = '" + currentDecision + "', [Date] = (CONVERT(DateTime,'" + currentDate + "',103)), [StartDate] = (CONVERT(DateTime,'" + currentStartDate + "',103)), [EndDate] = NULL WHERE [id] = " + lblId.Text;
                    }
                    return;
                }
            }

            if (txtEndDate.Text.Equals(""))
            {
                sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + UserCredentials.StaffId + ", [Name] = '" + UserCredentials.DisplayName + "', [Decision] = '" + txtDecision.Text + "', [Date] = (CONVERT(DateTime,'" + txtDate.Text + "',103)), [StartDate] = (CONVERT(DateTime,'" + txtStartDate.Text + "',103)), [EndDate] = NULL WHERE [id] = " + lblId.Text;
            }
            else
            {
                sdsRecJudiciary.UpdateCommand = "UPDATE [recJudiciary] SET [StaffId] = " + UserCredentials.StaffId + ", [Name] = '" + UserCredentials.DisplayName + "', [Decision] = '" + txtDecision.Text + "', [Date] = (CONVERT(DateTime,'" + txtDate.Text + "',103)), [StartDate] = (CONVERT(DateTime,'" + txtStartDate.Text + "',103)), [EndDate] = (CONVERT(DateTime,'" + txtEndDate.Text + "',103)) WHERE [id] = " + lblId.Text;
            }
            UpdateFormView();
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ViewReport(Report.ActiveReport);

        // open a pop up window at the center of the page.
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
            "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '/Web_Forms/PrintReport.aspx', null, 'height=2,width=2,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    } // print report

    protected void UpdateFormView() // Update the SQL Data Source linked to the Form View, then load it
    {
        sdsViewReport.SelectCommand = Report.ActiveReport;
        fvReport.ItemTemplate = Page.LoadTemplate("Reports/" + Report.Name + "/View/v" + Report.Version + "/Active/v" + Report.Version + ".ascx"); // display report in the formview
    }

    // Linked Reports
    protected void btnShowLinked_Click(object sender, EventArgs e)
    {
        if (gvLinkedReports.Visible == false) // if report is hidden, show linked reports
        {
            ShowLinkedReports();
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ScrollToLinkedReports", "ToLinkedReports();", true); // scroll to the attachedFiles
        }
        else // if shown, hide linked reports
        {
            HideLinkedReports();
        }
        UpdateFormView();
        Report.LinkedReport = "SELECT rt.StaffId, rt.StaffName, rt.ShiftId, st.ShiftName, c.ReportName, *" + " FROM " + Report.Table + " rt, [Staff] s, [Shift] st, [Category] c" +
                           " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Report.Id + " AND rt.AuditVersion=" + Report.AuditVersion;
        sdsLinkedReports.SelectCommand = "SELECT * FROM LinkedReports WHERE ReportId=" + Report.Id + " ORDER BY id";
    }
    protected void ShowLinkedReports()
    {
        lblLinkedReports.Visible = true;
        btnShowLinked.Text = "Hide Linked Reports";
        gvLinkedReports.Visible = true;
        ddlReportType.Items.Clear();
        PopulateLinkReportType();
    }
    protected void HideLinkedReports()
    {
        lblLinkedReports.Visible = false;
        gvLinkedReports.Visible = false;
        btnShowLinked.Text = "Show Linked Reports";
        divLinkReports.Visible = false;
    }
    protected void PopulateLinkReportType() // populate linked report's report type dropdown list
    {
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
                }

                // use Array.Sort to display the Report Types accordingly
                Array.Sort(int_groups);
                for (int i = 0; i < int_groups.Length; i++)
                {
                    // display the reports in proper order, All MR Reports at the top followed by CU Reports
                    if (int_groups[i] == 1 || int_groups[i] == 2)
                    {
                        ddlReportType.Items.Add(new ListItem("MR Incident Report", "2"));
                    }

                    if (int_groups[i] == 1)
                    {
                        ddlReportType.Items.Add(new ListItem("MR Duty Manager", "3"));
                    }
                    else if (int_groups[i] == 2)
                    {
                        ddlReportType.Items.Add(new ListItem("MR Supervisor", "4"));
                    }
                    else if (int_groups[i] == 3)
                    {
                        ddlReportType.Items.Add(new ListItem("MR Function Supervisor", "5"));
                    }
                    else if (int_groups[i] == 4)
                    {
                        ddlReportType.Items.Add(new ListItem("MR Reception Supervisor", "6"));
                    }
                    else if (int_groups[i] == 5)
                    {
                        ddlReportType.Items.Add(new ListItem("MR Reception", "7"));
                    }
                    else if (int_groups[i] == 6)
                    {
                        ddlReportType.Items.Add(new ListItem("CU Incident Report", "10"));
                        ddlReportType.Items.Add(new ListItem("CU Duty Manager", "8"));
                    }
                    else if (int_groups[i] == 7)
                    {
                        ddlReportType.Items.Add(new ListItem("CU Reception", "9"));
                    }
                }
            }
            else // if the user is a member of Senior Managers
            {
                // add all reports
                // MR Duty Manager & Incident Report
                ddlReportType.Items.Add(new ListItem("MR Incident Report", "2"));
                ddlReportType.Items.Add(new ListItem("MR Duty Manager", "3"));
                // MR Supervisor
                ddlReportType.Items.Add(new ListItem("MR Supervisor", "4"));
                // MR Function Supervisor
                ddlReportType.Items.Add(new ListItem("MR Function Supervisor", "5"));
                // MR Reception Supervisor
                ddlReportType.Items.Add(new ListItem("MR Reception Supervisor", "6"));
                // MR Reception
                ddlReportType.Items.Add(new ListItem("MR Reception", "7"));
                // CU Duty Manager
                ddlReportType.Items.Add(new ListItem("CU Duty Manager", "8"));
                ddlReportType.Items.Add(new ListItem("CU Incident Report", "10"));
                // CU Reception
                ddlReportType.Items.Add(new ListItem("CU Reception", "9"));
            }
        }
    }
    protected void gvLinkedReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btnDelete = (Button)e.Row.FindControl("btnDelete1");
        Label lblStaffId = (Label)e.Row.FindControl("lblStaffId");

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // check whether the action was created from this patron - if yes, show delete else hide delete button.
                if (lblStaffId.Text.Equals(UserCredentials.StaffId))
                {
                    btnDelete.Visible = true;
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
        }
        catch
        {

        }
    }
    protected void gvLinkedReports_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Retrieve controls
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        Label lblId = (Label)row.FindControl("lblId");
        Button btnInsert1 = (Button)row.FindControl("btnInsert1");
        Button btnInsert = (Button)row.FindControl("btnInsert");
        Label lblRId = (Label)row.FindControl("lblReportId");
        Label lblReportName = (Label)row.FindControl("lblReportType");
        Label lblTable = (Label)row.FindControl("lblReportTable");
        Label lblVersion = (Label)row.FindControl("lblReportVersion");
        Report.LinkSort = "0";

        if (e.CommandName.Equals("EmptyDataTemplateInsert"))
        {
            if (divLinkReports.Visible == false)
            {
                divLinkReports.Visible = true;
                btnInsert1.Text = "Cancel";
            }
            else
            {
                divLinkReports.Visible = false;
                btnInsert1.Text = "Link a Report";
            }
            sdsLinkReports.SelectCommand = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat]," +
                                           " [AuditVersion], [RowNum] FROM [rptView] WHERE ReportName IN ('" + UserCredentials.GroupsQuery + "') AND ([ReportStat] = " +
                                           "'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off') ORDER BY ShiftDate DESC, ShiftId DESC";
            UpdateFormView();
        }
        else if (e.CommandName.Equals("FooterInsert"))
        {
            if (divLinkReports.Visible == false)
            {
                divLinkReports.Visible = true;
                btnInsert.Text = "Cancel";
            }
            else
            {
                divLinkReports.Visible = false;
                btnInsert.Text = "Link a Report";
            }
            sdsLinkReports.SelectCommand = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                             " FROM [rptView]" +
                             " WHERE ReportName IN ('" + UserCredentials.GroupsQuery + "') AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off') ORDER BY ShiftDate DESC, ShiftId DESC";
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Select"))
        {
            Report.LinkedTable = lblTable.Text; // set the linked table name selected & check whether user logged in has access viewing an Incident Report
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open('/Web_Forms/LinkedReport.aspx?RId=" + lblRId.Text + "&ReportName=" + lblReportName.Text + "&ReportTable=" + lblTable.Text + "&Version=" + lblVersion.Text + "', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );", true);
            ViewReport(Report.ActiveReport);
        }
        else if (e.CommandName.Equals("View"))
        {
            Report.LinkedTable = lblTable.Text; // set the linked table name selected & check whether user logged in has access viewing an Incident Report

            // update selected report details
            Report.Table = lblTable.Text;
            Report.Id = lblRId.Text;
            Report.Version = lblVersion.Text;
            Report.Name = lblReportName.Text;

            // get report's staff author
            con.Open();
            SqlCommand getStaffId = new SqlCommand("SELECT StaffId FROM " + lblTable.Text + " WHERE ReportId= " + lblRId.Text + " AND AuditVersion=(SELECT MAX(AuditVersion) FROM " + lblTable.Text + " WHERE ReportId = " + lblRId.Text + " AND ReportStat != 'Awaiting Completion')", con);
            string selectedStaffId = getStaffId.ExecuteScalar().ToString();
            con.Close();
            Report.SelectedStaffId = selectedStaffId;

            con.Open();
            SqlCommand getStaffName = new SqlCommand("SELECT StaffName FROM " + lblTable.Text + " WHERE ReportId= " + lblRId.Text + " AND AuditVersion=(SELECT MAX(AuditVersion) FROM " + lblTable.Text + " WHERE ReportId = " + lblRId.Text + " AND ReportStat != 'Awaiting Completion')", con);
            string selectedStaffName = getStaffName.ExecuteScalar().ToString();
            con.Close();
            Report.SelectedStaffName = selectedStaffName;

            string auditVersionQuery = "";
            if (UserCredentials.StaffId.Equals(Report.SelectedStaffId))
            {
                auditVersionQuery = "SELECT AuditVersion FROM " + lblTable.Text + " WHERE AuditVersion=(SELECT MAX(AuditVersion) FROM " + lblTable.Text + " WHERE ReportId = " + lblRId.Text + ")";
            }
            else
            {
                auditVersionQuery = "SELECT AuditVersion FROM " + lblTable.Text + " WHERE AuditVersion=(SELECT MAX(AuditVersion) FROM " + lblTable.Text + " WHERE ReportId = " + lblRId.Text + " AND ReportStat != 'Awaiting Completion')";
            }
            // get report's audit version
            con.Open();
            SqlCommand getAuditVersion = new SqlCommand(auditVersionQuery, con);
            string auditVersion = getAuditVersion.ExecuteScalar().ToString();
            con.Close();
            Report.AuditVersion = auditVersion;


            CheckMode();
            string report = "SELECT rt.StaffId, rt.ShiftId, st.ShiftName, c.ReportName, *" + " FROM " + lblTable.Text + " rt, [Staff] s, [Shift] st, [Category] c" +
                            " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + lblRId.Text +
                            " AND rt.AuditVersion=" + Report.AuditVersion;
            ViewReport(report);
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ToTheTop", "ToTopOfPage();", true); // scroll to the top of the page
        }
        else if (e.CommandName.Equals("Delete"))
        {
            sdsLinkedReports.DeleteCommand = "DELETE FROM [LinkedReports] WHERE (([ReportId] = " + Report.Id + " AND [RId] = " + lblRId.Text + ") OR ([ReportId] = " + lblRId.Text + " AND [RId] = " + Report.Id + "))";
            ViewReport(Report.ActiveReport);
        }
    }
    protected void btnFilter_Click(object sender, EventArgs e) // filter for searching the link report
    {
        string groups1 = UserCredentials.GroupsQuery,
                   search1 = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                                 " FROM [rptView]" +
                                 " WHERE ReportName IN ('" + groups1 + "') AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' " +
                                 "OR [ReportStat] = 'Awaiting Manager Sign-off') " +
                                 " ORDER BY ShiftDate DESC, ShiftId DESC";
        Session["defaultSearch1"] = search1;
        int ReportType = Int32.Parse(ddlReportType.SelectedItem.Value);
        int DateGroup = Int32.Parse(ddlDateGroup.SelectedItem.Value);
        DateTime date1 = DateTime.Now.Date;
        DateTime date2 = DateTime.Now.Date;
        string _reportType = "Duty Manager", search;

        // set the date being filtered
        if (DateGroup == 2)
        {
            date2 = DateTime.Now.Date.AddDays(-1);  // reports from yesterday
        }
        else if (DateGroup == 3)
        {
            date2 = DateTime.Now.Date.AddDays(-7);  // reports from last seven days
        }
        else if (DateGroup == 4)
        {
            date2 = DateTime.Now.Date.AddDays(-14);  // reports from last 14 days
        }
        else if (DateGroup == 5)
        {
            date2 = DateTime.Now.Date.AddDays(-30);  // reports from last month
        }
        else if (DateGroup == 6)
        {
            date2 = DateTime.Now.Date.AddDays(-365);  // reports from last year
        }

        // set the report type being filtered (take note that any changes from the Active Directory group will create a system error - MRReportsDutyManager)
        if (ReportType == 2)
        {
            _reportType = "MR Incident Report";
        }
        else if (ReportType == 3)
        {
            _reportType = "MR Duty Managers";
        }
        else if (ReportType == 4)
        {
            _reportType = "MR Supervisors";
        }
        else if (ReportType == 5)
        {
            _reportType = "MR Function Supervisor";
        }
        else if (ReportType == 6)
        {
            _reportType = "MR Reception Supervisor";
        }
        else if (ReportType == 7)
        {
            _reportType = "MR Reception";
        }
        else if (ReportType == 8)
        {
            _reportType = "CU Duty Managers";
        }
        else if (ReportType == 9)
        {
            _reportType = "CU Reception";
        }
        else if (ReportType == 10)
        {
            _reportType = "CU Incident Report";
        }

        // find appropriate search query
        if (ReportType == 1 && DateGroup == 1) // search all reports the user is allowed to view
        {
            search = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                     " FROM [rptView]" +
                     " WHERE ReportName IN('" + groups1 + "') AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off') ORDER BY ShiftDate DESC, ShiftId DESC";
        }
        else if (ReportType == 1) // search all the reports the user is allowed to view plus the filtered date entered
        {
            search = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                     " FROM [rptView]" +
                     " WHERE ReportName IN('" + groups1 + "') AND ShiftDate BETWEEN '" + date2.ToString("yyyy-MM-dd") + "' AND '" + date1.ToString("yyyy-MM-dd") + "' AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off')" +
                     " ORDER BY ShiftDate DESC, ShiftId DESC";
        }
        else if (DateGroup == 1) // search by filtered report type through all dates
        {
            search = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                     " FROM [rptView]" +
                     " WHERE ReportName ='" + _reportType + "' AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off') ORDER BY ShiftDate DESC, ShiftId DESC";
        }
        else // search by user's filter
        {
            search = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                     " FROM [rptView]" +
                     " WHERE ReportName ='" + _reportType + "' AND ShiftDate BETWEEN '" + date2.ToString("yyyy-MM-dd") + "' AND '" + date1.ToString("yyyy-MM-dd") + "' AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off')" +
                     " ORDER BY ShiftDate DESC, ShiftId DESC";
        }
        Report.LinkSelectQuery = search; // keeping the filtered fields (active Select Command) for sorting and paging
        sdsLinkReports.SelectCommand = search;
        gvLinkReports.DataBind();
        Report.LinkSort = "1";
        if (gvLinkReports.Rows.Count == 0) // if no report was found display a message
        {
            sdsLinkReports.SelectCommand = search1;
            Report.LinkSort = "0";
            Report.LinkSelectQuery = search; // keeping the filtered fields (active Select Command) for sorting and paging
            alert.DisplayMessage("No documents found. Please try again");
        }
        UpdateFormView();
    }
    protected void gvLinkReports_SelectedIndexChanged(object sender, EventArgs e)
    {
        // hide the Search List for adding a Link Report
        gvLinkedReports.Visible = false;
        lblLinkedReports.Visible = false;
        divLinkReports.Visible = false;

        // show a message that the insert was successful and bind gvLinkedReports
        alert.DisplayMessage("Linked Report successful");
        sdsLinkedReports.SelectCommand = "SELECT * FROM LinkedReports WHERE ReportId=" + Report.Id + " ORDER BY id";
        gvLinkedReports.DataBind();

        // show list of linked reports and current report selected
        gvLinkedReports.Visible = true;
        lblLinkedReports.Visible = true;

        ViewReport(Report.ActiveReport);
    }
    protected void gvLinkReports_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            Label lblID = (Label)row.FindControl("lblReportId");
            Label lblTable = (Label)row.FindControl("lblReportTable");
            Label lblVersion = (Label)row.FindControl("lblReportVersion");
            Label lblReportName = (Label)row.FindControl("lblReportType");

            con.Open();
            SqlCommand checkExist = new SqlCommand("SELECT COUNT(*) FROM [LinkedReports] WHERE [ReportId]= '" + Report.Id + "' AND [RId] = '" + lblID.Text + "'", con);
            int ReportExist = (int)checkExist.ExecuteScalar();
            con.Close();
            if (ReportExist > 0)
            {
                //Report already exist
                alert.DisplayMessage("Report selected is already linked");
                ViewReport(Report.ActiveReport);
                return;
            }
            if (Report.Id.Equals(lblID.Text))
            {
                // linking the same report to itself
                alert.DisplayMessage("Cannot link the same report to itself.");
                ViewReport(Report.ActiveReport);
                return;
            }


            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO LinkedReports (ReportId, RId, ReportName, ReportTable, Version, StaffId, StaffName) VALUES ('" + Report.Id + "', '" + lblID.Text + "', '" + lblReportName.Text + "', '" + lblTable.Text + "', '" + lblVersion.Text + "', '" + UserCredentials.StaffId + "', '" + UserCredentials.DisplayName + "'), ('" + lblID.Text + "', '" + Report.Id + "', '" + Report.Name + "', '" + Report.Table + "', '" + Report.Version + "', '" + UserCredentials.StaffId + "', '" + UserCredentials.DisplayName + "');", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ViewReport(Report.ActiveReport);
        }
    }
    protected void gvLinkReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Report.LinkSort.Equals("1"))
        {
            sdsLinkReports.SelectCommand = Report.LinkSelectQuery;
        }
        else
        {
            sdsLinkReports.SelectCommand = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                         " FROM [rptView]" +
                         " WHERE ReportName IN ('" + UserCredentials.GroupsQuery + "') AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' " +
                         "OR [ReportStat] = 'Awaiting Manager Sign-off') ORDER BY ShiftDate DESC, ShiftId DESC";
        }
        gvLinkReports.PageIndex = e.NewPageIndex;
        gvLinkReports.DataBind();
        UpdateFormView();
    }
    protected void gvLinkReports_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (Report.LinkSort.Equals("1"))
        {
            sdsLinkReports.SelectCommand = Report.LinkSelectQuery;
        }
        else
        {
            sdsLinkReports.SelectCommand = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                         " FROM [rptView]" +
                         " WHERE ReportName IN ('" + UserCredentials.GroupsQuery + "') AND ([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' " +
                         "OR [ReportStat] = 'Awaiting Manager Sign-off') ORDER BY ShiftDate DESC, ShiftId DESC";
        }

        if (Report.LinkSortDirection.Equals("Set"))
        {
            e.SortDirection = SortDirection.Ascending;
            Report.LinkSortDirection = "Descending";
        }
        else if (Report.LinkSortDirection.Equals("Descending"))
        {
            e.SortDirection = SortDirection.Descending;
            Report.LinkSortDirection = "Ascending";
        }
        else if (Report.LinkSortDirection.Equals("Ascending"))
        {
            e.SortDirection = SortDirection.Ascending;
            Report.LinkSortDirection = "Descending";
        }
        UpdateFormView();
    }

    // Attached Files
    protected void btnShowAttachedFiles_Click(object sender, EventArgs e)
    {
        if (gvAttachedFiles.Visible == false) // if there is any attached files to show, show gridview
        {
            ShowAttachedFiles();
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ScrollToAttachedFiles", "ToAttachedFiles();", true); // scroll to the attachedFiles
        }
        else // if shown, hide attached files
        {
            HideAttachedFiles();
        }
        UpdateFormView();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuUpload.HasFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(fuUpload.FileName) + "_" + Report.Id + "-sid" + UserCredentials.StaffId + "-" + Path.GetExtension(fuUpload.FileName);

            if (File.Exists(Server.MapPath("~/Uploads/") + fileName))
            {
                alert.DisplayMessage("File already exist. Upload failed.");
            }
            else
            {
                fuUpload.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                alert.DisplayMessage("File uploaded successfully.");
            }
        }
        PopulateAttachedFiles();
    }
    protected void ShowAttachedFiles()
    {
        if (Report.Name.Contains("Incident"))
        {
            if (UserCredentials.Role.Equals("MR Reception") || UserCredentials.Role.Equals("CU Reception"))
            {
                HideAttachedFiles();
                btnLinkAttachedFiles.Visible = false;
            }
            else
            {
                lblAttachedFiles.Visible = true;
                fuUpload.Visible = true;
                btnUpload.Visible = true;
                btnShowAttachedFiles.Text = "Hide Attached Files";
                gvAttachedFiles.Visible = true;
                PopulateAttachedFiles();
            }
        }
        else
        {
            lblAttachedFiles.Visible = true;
            fuUpload.Visible = true;
            btnUpload.Visible = true;
            btnShowAttachedFiles.Text = "Hide Attached Files";
            gvAttachedFiles.Visible = true;
            PopulateAttachedFiles();
        }
    }
    protected void HideAttachedFiles()
    {
        lblAttachedFiles.Visible = false;
        fuUpload.Visible = false;
        btnUpload.Visible = false;
        btnShowAttachedFiles.Text = "Show Attached Files";
        gvAttachedFiles.Visible = false;
    }
    protected void PopulateAttachedFiles()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("File");
        dt.Columns.Add("Type");

        foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Uploads")))
        {
            FileInfo fi = new FileInfo(strfile);
            if (fi.Name.Contains(Report.Id))
            {
                dt.Rows.Add(fi.Name, GetFileTypeByExtension(fi.Extension));
            }
        }

        gvAttachedFiles.DataSource = dt;
        gvAttachedFiles.DataBind();

        FeatureNavigationReportDisplayed(); // check whether or not the report has Attached Files, Linked Reports, and Pending Actions (report is currently displayed/open)

        UpdateFormView();
    }
    private string GetFileTypeByExtension(string fileExtension)
    {
        switch (fileExtension.ToLower())
        {
            case ".docx":
            case ".doc":
                return "Microsoft Word Document";
            case ".xlsx":
            case ".xls":
                return "Microsoft Excel Document";
            case ".txt":
                return "Text Document";
            case ".jpg":
            case ".png":
                return "Image";
            case ".pdf":
                return "Portable Document Format";
            case ".csv":
                return "Comma-Separated Values";
            default:
                return "Unknown";
        }
    }
    protected void gvAttachedFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("DownloadFile"))
        {
            HttpResponse response = HttpContext.Current.Response;
            Response.ClearContent();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition",
                               "attachment; filename=" + e.CommandArgument + ";");
            Response.TransmitFile(Server.MapPath("~/Uploads/") + e.CommandArgument);
            Response.Flush();
            Response.End();
        }

        if (e.CommandName.Equals("Delete"))
        {
            try
            {
                File.Delete(Server.MapPath("~/Uploads/") + e.CommandArgument.ToString());
            }
            catch (Exception exc)
            {
                alert.DisplayMessage(exc.ToString());
            }

            alert.DisplayMessage("Successfully deleted attached file.");
        }
    }
    protected void gvAttachedFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btnDelete = (Button)e.Row.FindControl("btnDelete");
        LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // check whether the action was created from this patron - if yes, show delete else hide delete button.
                if (!string.IsNullOrEmpty(LinkButton1.Text))
                {
                    if (!LinkButton1.Text.Contains("-sid" + UserCredentials.StaffId + "-"))
                    {
                        btnDelete.Visible = false;
                    }
                    else
                    {
                        btnDelete.Visible = true;
                    }
                }
            }
        }
        catch
        {

        }
    }
    protected void gvAttachedFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PopulateAttachedFiles();
    }

    // Pending Actions
    protected void btnShowActions_Click(object sender, EventArgs e)
    {
        if (gvPendingActions.Visible == false)
        {
            ShowPendingActions();
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "ScrollToPendingActions", "ToPendingActions();", true); // scroll to the attachedFiles
        }
        else
        {
            HidePendingActions();
        }
        Report.ActiveReport = "SELECT rt.StaffId, rt.ShiftId, st.ShiftName, c.ReportName, *" + " FROM " + Report.Table + " rt, [Staff] s, [Shift] st, [Category] c" +
                           " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Report.Id + " AND rt.AuditVersion=" + Report.AuditVersion;
        UpdateFormView();
        sdsPendingActions.SelectCommand = "SELECT * FROM ActionRequired WHERE ReportId='" + Report.Id + "'";
    }
    protected void ShowPendingActions()
    {
        gvPendingActions.Visible = true;
        lblAddAction.Visible = true;
        btnShowActions.Text = "Hide Pending Actions";
    }
    protected void HidePendingActions()
    {
        gvPendingActions.Visible = false;
        lblAddAction.Visible = false;
        btnShowActions.Text = "Show Pending Actions";
        ActionsAssignedNotification();
        ReportActionsNotification();
    }
    protected void sdsPendingActions_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        if ((e.Exception == null) && e.AffectedRows.Equals(1))
        {
            alert.DisplayMessage("Action successfully inserted.");
        }
        else
        {
            alert.DisplayMessage("Unable to successfully insert Action.");
            e.ExceptionHandled = true;
        }

        UpdateStatus();
        sdsPendingActions.SelectCommand = "SELECT * FROM ActionRequired WHERE ReportId=" + Report.Id;
    }
    protected void gvPendingActions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Retrieve controls
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        Label lblId = (Label)row.FindControl("lblId");
        TextBox txtDescription = (TextBox)row.FindControl("txtDescription");
        CheckBox cbCompleted = (CheckBox)row.FindControl("cbCompleted");
        TextBox txtDescription1 = (TextBox)row.FindControl("txtDescription1");
        Label lblCompletedDate = (Label)row.FindControl("lblCompletedDate");
        TextBox txtComments = (TextBox)row.FindControl("txtComments");
        CheckBox cbToPerson = (CheckBox)row.FindControl("cbToPerson");
        DropDownList ddlPerson = (DropDownList)row.FindControl("ddlPerson");
        DropDownList ddlGroup = (DropDownList)row.FindControl("ddlGroup");
        CheckBoxList cblGroup = (CheckBoxList)row.FindControl("cblGroup");
        string activeDescription = "";


        // Keep the selected report's staff id value
        con.Open();
        SqlCommand checkExist = new SqlCommand("SELECT StaffId FROM [Staff] WHERE [StaffId]= '" + UserCredentials.StaffId + "'", con);
        int StaffExist = (int)checkExist.ExecuteScalar();
        con.Close();
        if (StaffExist > 0)
        {
            //Staff already exist
            UserCredentials.StaffId = StaffExist.ToString();
        }

        if (e.CommandName.Equals("EmptyDataTemplateInsert"))
        {
            // check if control has ' and if it is null
            txtDescription1.Text = txtDescription1.Text.Replace("'", "");
            if (txtDescription1.Text == "")
            {
                alert.DisplayMessage("Action required description can't be empty.");
                UpdateFormView();
                return;
            }

            if (ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
            {
                bool isAnySelected = cblGroup.SelectedIndex != -1;

                if (!isAnySelected)
                {
                    alert.DisplayMessage("Please select a group to assign the action.");
                    UpdateFormView();
                    return;
                }
            }

            // set to whom the action is submitted to
            string staffPersonId = "", staffPerson = "", submittedTo = "";
            if (cbToPerson.Checked == true)
            {
                staffPersonId = ddlPerson.SelectedItem.Value;
                staffPerson = ddlPerson.SelectedItem.Text;
                submittedTo = ddlPerson.SelectedItem.Text;
            }
            else
            {
                staffPersonId = "";
                staffPerson = "";
                submittedTo = ddlGroup.SelectedItem.Text;
            }

            string selectedRole = "";
            if (ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
            {
                selectedRole = String.Join(",", cblGroup.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Text));
                submittedTo = selectedRole;
            }
            else
            {
                selectedRole = ddlGroup.SelectedItem.Text;
            }

            // Set parameters
            sdsPendingActions.InsertParameters["ReportId"].DefaultValue = Report.Id;
            sdsPendingActions.InsertParameters["Report_Table"].DefaultValue = Report.Table;
            sdsPendingActions.InsertParameters["Version"].DefaultValue = Report.Version;
            sdsPendingActions.InsertParameters["AuditVersion"].DefaultValue = Report.AuditVersion;
            sdsPendingActions.InsertParameters["ReportName"].DefaultValue = Report.Name;
            sdsPendingActions.InsertParameters["ReportStat"].DefaultValue = Report.Status;
            sdsPendingActions.InsertParameters["StaffAuthor"].DefaultValue = Report.SelectedStaffId;
            sdsPendingActions.InsertParameters["StaffName"].DefaultValue = Report.SelectedStaffName;
            sdsPendingActions.InsertParameters["StaffId"].DefaultValue = UserCredentials.StaffId;
            sdsPendingActions.InsertParameters["StaffSelected"].DefaultValue = UserCredentials.DisplayName;
            sdsPendingActions.InsertParameters["StaffPersonId"].DefaultValue = staffPersonId;
            sdsPendingActions.InsertParameters["StaffPerson"].DefaultValue = staffPerson;
            sdsPendingActions.InsertParameters["StaffGroup"].DefaultValue = selectedRole;
            sdsPendingActions.InsertParameters["Description"].DefaultValue = txtDescription1.Text.Replace("\n", "<br />").Replace("'", "");
            sdsPendingActions.InsertParameters["SubmittedBy"].DefaultValue = UserCredentials.DisplayName;
            sdsPendingActions.InsertParameters["SubmittedTo"].DefaultValue = submittedTo;
            sdsPendingActions.InsertParameters["SubmittedDate"].DefaultValue = DateTime.Now.ToString();
            sdsPendingActions.InsertParameters["Completed"].DefaultValue = Convert.ToString(false);
            sdsPendingActions.InsertParameters["CompletedDate"].DefaultValue = "";
            sdsPendingActions.InsertParameters["Comments"].DefaultValue = "";
            sdsPendingActions.InsertParameters["ToPerson"].DefaultValue = Convert.ToString(cbToPerson.Checked);

            // Perform insert
            sdsPendingActions.Insert();
            UpdateFormView();
        }
        else if (e.CommandName.Equals("FooterInsert"))
        {
            // Retrieve controls
            TextBox txtDescription2 = (TextBox)row.FindControl("txtDescription");

            // check if control has ' and if it is null
            txtDescription2.Text = txtDescription2.Text.Replace("'", "");
            if (txtDescription2.Text == "")
            {
                alert.DisplayMessage("Action required description can't be empty.");
                UpdateFormView();
                return;
            }

            if (ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
            {
                bool isAnySelected = cblGroup.SelectedIndex != -1;

                if (!isAnySelected)
                {
                    alert.DisplayMessage("Please select a group to assign the action.");
                    UpdateFormView();
                    return;
                }
            }

            // set to whom the action is submitted to
            string staffPersonId = "", staffPerson = "", submittedTo = "";
            if (cbToPerson.Checked == true)
            {
                staffPersonId = ddlPerson.SelectedItem.Value;
                staffPerson = ddlPerson.SelectedItem.Text;
                submittedTo = ddlPerson.SelectedItem.Text;
            }
            else
            {
                staffPersonId = "";
                staffPerson = "";
                submittedTo = ddlGroup.SelectedItem.Text;
            }

            string selectedRole = "";
            if (ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
            {
                selectedRole = String.Join(",", cblGroup.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Text));
                submittedTo = selectedRole;
            }
            else
            {
                selectedRole = ddlGroup.SelectedItem.Text;
            }

            // Set parameters
            sdsPendingActions.InsertParameters["ReportId"].DefaultValue = Report.Id;
            sdsPendingActions.InsertParameters["Report_Table"].DefaultValue = Report.Table;
            sdsPendingActions.InsertParameters["Version"].DefaultValue = Report.Version;
            sdsPendingActions.InsertParameters["AuditVersion"].DefaultValue = Report.AuditVersion;
            sdsPendingActions.InsertParameters["ReportName"].DefaultValue = Report.Name;
            sdsPendingActions.InsertParameters["ReportStat"].DefaultValue = Report.Status;
            sdsPendingActions.InsertParameters["StaffAuthor"].DefaultValue = Report.SelectedStaffId;
            sdsPendingActions.InsertParameters["StaffName"].DefaultValue = Report.SelectedStaffName;
            sdsPendingActions.InsertParameters["StaffId"].DefaultValue = UserCredentials.StaffId;
            sdsPendingActions.InsertParameters["StaffSelected"].DefaultValue = UserCredentials.DisplayName;
            sdsPendingActions.InsertParameters["StaffPersonId"].DefaultValue = staffPersonId;
            sdsPendingActions.InsertParameters["StaffPerson"].DefaultValue = staffPerson;
            sdsPendingActions.InsertParameters["StaffGroup"].DefaultValue = selectedRole;
            sdsPendingActions.InsertParameters["Description"].DefaultValue = txtDescription2.Text.Replace("\n", "<br />").Replace("'", "");
            sdsPendingActions.InsertParameters["SubmittedBy"].DefaultValue = UserCredentials.DisplayName;
            sdsPendingActions.InsertParameters["SubmittedTo"].DefaultValue = submittedTo;
            sdsPendingActions.InsertParameters["SubmittedDate"].DefaultValue = DateTime.Now.ToString();
            sdsPendingActions.InsertParameters["Completed"].DefaultValue = Convert.ToString(false);
            sdsPendingActions.InsertParameters["CompletedDate"].DefaultValue = "";
            sdsPendingActions.InsertParameters["Comments"].DefaultValue = "";
            sdsPendingActions.InsertParameters["ToPerson"].DefaultValue = Convert.ToString(cbToPerson.Checked);

            // Perform insert
            sdsPendingActions.Insert();
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Edit"))
        {
            try
            {
                activeDescription = txtDescription.Text;
            }
            catch
            {

            }
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Cancel"))
        {
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Delete"))
        {
            sdsPendingActions.DeleteCommand = "DELETE FROM [ActionRequired] WHERE [id] = " + lblId.Text;
            UpdateFormView();
        }
        else if (e.CommandName.Equals("Update"))
        {
            string completedDate = lblCompletedDate.Text;
            int completed = 0;

            // check if control has ' and if it is null
            txtDescription.Text = txtDescription.Text.Replace("'", "");
            if (txtDescription.Equals(""))
            {
                alert.DisplayMessage("Action wasn't updated, please don't leave the description textbox empty.");
                return;
            }

            if (cbCompleted.Checked == true)
            {
                completedDate = DateTime.Now.ToString();
                completed = 1;
            }

            if (completedDate.Equals("")) // Update the description
            {
                sdsPendingActions.UpdateCommand = "UPDATE [ActionRequired] SET [ReportId] = " + Report.Id + ", [Description] = '" + txtDescription.Text.Replace("\n", "<br />").Replace("'", "") + "', [Completed] = " + completed + ", [Comments] = '" + txtComments.Text.Replace("\n", "<br />").Replace("'", "") + "' WHERE [id] = " + lblId.Text;
            }
            else // update the completed bit, completed date, and who completed the action
            {
                sdsPendingActions.UpdateCommand = "UPDATE [ActionRequired] SET [ReportId] = " + Report.Id + ", [Description] = '" + txtDescription.Text.Replace("\n", "<br />").Replace("'", "") + "', [Completed] = " + completed + ", [CompletedDate] = (CONVERT(DateTime, '" + completedDate + "', 103)), [CompletedBy] = '" + UserCredentials.DisplayName + "', [Comments] = '" + txtComments.Text.Replace("\n", "<br />").Replace("'", "") + "' WHERE [id] = " + lblId.Text;
            }
            UpdateFormView();
        }
    }
    protected void gvPendingActions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btnEdit = (Button)e.Row.FindControl("btnEdit");
        Button btnDelete = (Button)e.Row.FindControl("btnDelete");
        Button btnInsert = (Button)e.Row.FindControl("btnInsert");
        Button btnInsert1 = (Button)e.Row.FindControl("btnInsert1");
        TextBox txtDescription = (TextBox)e.Row.FindControl("txtDescription");
        TextBox txtDescription1 = (TextBox)e.Row.FindControl("txtDescription1");
        Label lblDescriptionHead = (Label)e.Row.FindControl("lblDescriptionHead");
        CheckBox cbCompleted = (CheckBox)e.Row.FindControl("cbCompleted");
        Label lblStaffId = (Label)e.Row.FindControl("lblStaffId");
        Label lblDescription = (Label)e.Row.FindControl("lblDescription");
        Label lblPerson = (Label)e.Row.FindControl("lblPerson");
        Label lblToPerson = (Label)e.Row.FindControl("lblToPerson");
        Label lblGroup = (Label)e.Row.FindControl("lblGroup");
        CheckBox cbToPerson = (CheckBox)e.Row.FindControl("cbToPerson");
        DropDownList ddlPerson = (DropDownList)e.Row.FindControl("ddlPerson");
        DropDownList ddlGroup = (DropDownList)e.Row.FindControl("ddlGroup");
        Label lblStaffPersonId = (Label)e.Row.FindControl("lblStaffPersonId");
        Label lblSubmittedTo = (Label)e.Row.FindControl("lblSubmittedTo");
        Label lblStaffGroup = (Label)e.Row.FindControl("lblStaffGroup");

        // populate Group dropdown list
        try
        {
            PopulateDdlGroup(ddlGroup);
        }
        catch
        {

        }

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!UserCredentials.Role.Equals("MR Senior Managers"))
                {
                    if (!string.IsNullOrEmpty(lblStaffPersonId.Text)) // check if user is assigned to pending action
                    {
                        if (!lblStaffPersonId.Text.Equals(UserCredentials.StaffId))
                        {
                            e.Row.Visible = false;
                        }
                        else
                        {
                            e.Row.Visible = true;
                        }
                    }
                    else if (!string.IsNullOrEmpty(lblStaffGroup.Text)) // check if user's role is assigned to pending action
                    {
                        if (!lblStaffGroup.Text.Contains(UserCredentials.Role))
                        {
                            e.Row.Visible = false;
                        }
                        else
                        {
                            e.Row.Visible = true;
                        }
                    }

                    if (lblStaffId.Text.Equals(UserCredentials.StaffId))
                    {
                        e.Row.Visible = true;
                    }
                }

                if (((CheckBox)e.Row.FindControl("cbCompleted")).Checked == true)
                {
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
                else
                {
                    // check whether the action was created from this patron - if yes, show delete else hide delete button.
                    if (lblStaffId.Text.Equals(UserCredentials.StaffId))
                    {
                        btnDelete.Visible = true;
                    }
                    else
                    {
                        btnDelete.Visible = false;
                    }
                    // check whether the person is the one who assigned or owns the action required
                    if (lblStaffId.Text.Equals(UserCredentials.StaffId) || lblStaffPersonId.Text.Equals(UserCredentials.StaffId) || lblSubmittedTo.Text.Contains(UserCredentials.Role))
                    {
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        btnEdit.Visible = false;
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (Report.Status.Equals("Awaiting Completion"))
                {
                    if (!UserCredentials.Groups.Contains("DutyManagers"))
                    {
                        btnInsert.Visible = false;
                        txtDescription.Visible = false;
                        lblDescription.Visible = false;
                        lblPerson.Visible = false;
                        lblToPerson.Visible = false;
                        lblGroup.Visible = false;

                        try
                        {
                            cbToPerson.Visible = false;
                            ddlPerson.Visible = false;
                            ddlGroup.Visible = false;
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        btnInsert.Visible = true;
                        txtDescription.Visible = true;
                        lblDescription.Visible = true;
                        lblPerson.Visible = true;
                        lblToPerson.Visible = true;
                        lblGroup.Visible = true;

                        try
                        {
                            cbToPerson.Visible = true;
                            ddlPerson.Visible = true;
                            ddlGroup.Visible = true;
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    try
                    {
                        cbCompleted.Visible = false;
                    }
                    catch
                    {

                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                if (Report.Status.Equals("Awaiting Completion"))
                {
                    if (!UserCredentials.Groups.Contains("DutyManagers"))
                    {
                        lblDescriptionHead.Text = "No Action Required";
                        btnInsert1.Visible = false;
                        txtDescription1.Visible = false;

                        try
                        {
                            cbToPerson.Visible = false;
                            ddlPerson.Visible = false;
                            ddlGroup.Visible = false;
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        lblDescriptionHead.Text = "Action";
                        btnInsert1.Visible = true;
                        txtDescription1.Visible = true;

                        try
                        {
                            cbToPerson.Visible = true;
                            ddlPerson.Visible = true;
                            ddlGroup.Visible = true;
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
        catch
        {

        }
    }
    protected void gvPendingActions_PreRender(object sender, EventArgs e)
    {
        if (this.gvPendingActions.EditIndex != -1) // if gridview is in edit mode
        {
            Label lblStaffId = (Label)gvPendingActions.Rows[gvPendingActions.EditIndex].FindControl("lblStaffId");
            TextBox txtDescription = (TextBox)gvPendingActions.Rows[gvPendingActions.EditIndex].FindControl("txtDescription");

            // check whether the action selected was from the person who assigned it
            if (lblStaffId.Text.Equals(UserCredentials.StaffId))
            {
                txtDescription.Enabled = true;
            }
            else
            {
                txtDescription.Enabled = false;
            }
        }
    }
    protected void gvPendingActions_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if ((e.Exception == null) && e.AffectedRows.Equals(1))
        {
            alert.DisplayMessage("Action successfully deleted.");
        }
        else
        {
            alert.DisplayMessage("Unable to successfully delete Action.");
            e.ExceptionHandled = true;
        }

        UpdateStatus();
    }
    protected void gvPendingActions_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if ((e.Exception == null) && e.AffectedRows.Equals(1))
        {
            alert.DisplayMessage("Action successfully updated.");
        }
        else
        {
            alert.DisplayMessage("Unable to successfully update action.");
            e.ExceptionHandled = true;
        }

        UpdateStatus();
    }
    protected void PopulateDdlGroup(DropDownList ddlGroup)
    {
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
                }

                // use Array.Sort to display the Report Types accordingly
                Array.Sort(int_groups);
                for (int i = 0; i < int_groups.Length; i++)
                {
                    // display the reports in proper order, All MR Reports at the top followed by CU Reports
                    if (int_groups[i] == 1)
                    {
                        ddlGroup.Items.Add(new ListItem("MR Duty Managers", "1"));
                    }
                    else if (int_groups[i] == 2)
                    {
                        ddlGroup.Items.Add(new ListItem("MR Supervisors", "2"));
                    }
                    else if (int_groups[i] == 3)
                    {
                        ddlGroup.Items.Add(new ListItem("MR Function Supervisor", "3"));
                    }
                    else if (int_groups[i] == 4)
                    {
                        ddlGroup.Items.Add(new ListItem("MR Reception Supervisor", "4"));
                    }
                    else if (int_groups[i] == 5)
                    {
                        ddlGroup.Items.Add(new ListItem("MR Reception", "5"));
                    }
                    else if (int_groups[i] == 6)
                    {
                        ddlGroup.Items.Add(new ListItem("CU Duty Managers", "6"));
                    }
                    else if (int_groups[i] == 7)
                    {
                        ddlGroup.Items.Add(new ListItem("CU Reception", "7"));
                    }
                }
            }
            else // if the user is a member of Senior Managers
            {
                // add all reports
                // MR Duty Manager & Senior Managers
                ddlGroup.Items.Add(new ListItem("MR Senior Managers", "0"));
                ddlGroup.Items.Add(new ListItem("MR Duty Managers", "1"));
                // MR Supervisor
                ddlGroup.Items.Add(new ListItem("MR Supervisors", "2"));
                // MR Function Supervisor
                ddlGroup.Items.Add(new ListItem("MR Function Supervisor", "3"));
                // MR Reception Supervisor
                ddlGroup.Items.Add(new ListItem("MR Reception Supervisor", "4"));
                // MR Reception
                ddlGroup.Items.Add(new ListItem("MR Reception", "5"));
                // CU Duty Manager
                ddlGroup.Items.Add(new ListItem("CU Duty Managers", "6"));
                // CU Reception
                ddlGroup.Items.Add(new ListItem("CU Reception", "7"));
            }
            ddlGroup.Items.Add(new ListItem("Select Multiple Groups", "-1"));
        }
    }
    protected void PopulateCblGroup(CheckBoxList cblGroup)
    {
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
                }

                // use Array.Sort to display the Report Types accordingly
                Array.Sort(int_groups);
                for (int i = 0; i < int_groups.Length; i++)
                {
                    // display the reports in proper order, All MR Reports at the top followed by CU Reports
                    if (int_groups[i] == 1)
                    {
                        cblGroup.Items.Add(new ListItem("MR Duty Managers", "1"));
                    }
                    else if (int_groups[i] == 2)
                    {
                        cblGroup.Items.Add(new ListItem("MR Supervisors", "2"));
                    }
                    else if (int_groups[i] == 3)
                    {
                        cblGroup.Items.Add(new ListItem("MR Function Supervisor", "3"));
                    }
                    else if (int_groups[i] == 4)
                    {
                        cblGroup.Items.Add(new ListItem("MR Reception Supervisor", "4"));
                    }
                    else if (int_groups[i] == 5)
                    {
                        cblGroup.Items.Add(new ListItem("MR Reception", "5"));
                    }
                    else if (int_groups[i] == 6)
                    {
                        cblGroup.Items.Add(new ListItem("CU Duty Managers", "6"));
                    }
                    else if (int_groups[i] == 7)
                    {
                        cblGroup.Items.Add(new ListItem("CU Reception", "7"));
                    }
                }
            }
            else // if the user is a member of Senior Managers
            {
                // add all reports
                // MR Duty Manager & Senior Managers
                cblGroup.Items.Add(new ListItem("MR Senior Managers", "0"));
                cblGroup.Items.Add(new ListItem("MR Duty Managers", "1"));
                // MR Supervisor
                cblGroup.Items.Add(new ListItem("MR Supervisors", "2"));
                // MR Function Supervisor
                cblGroup.Items.Add(new ListItem("MR Function Supervisor", "3"));
                // MR Reception Supervisor
                cblGroup.Items.Add(new ListItem("MR Reception Supervisor", "4"));
                // MR Reception
                cblGroup.Items.Add(new ListItem("MR Reception", "5"));
                // CU Duty Manager
                cblGroup.Items.Add(new ListItem("CU Duty Managers", "6"));
                // CU Reception
                cblGroup.Items.Add(new ListItem("CU Reception", "7"));
            }
        }
    }
    protected void cbPersonPendingActions_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbToPerson = (CheckBox)gvPendingActions.Controls[0].Controls[0].FindControl("cbToPerson"); // coming from an Empty Data Row
        DropDownList ddlPerson = (DropDownList)gvPendingActions.Controls[0].Controls[0].FindControl("ddlPerson");
        DropDownList ddlGroup = (DropDownList)gvPendingActions.Controls[0].Controls[0].FindControl("ddlGroup");
        CheckBoxList cblGroup = (CheckBoxList)gvPendingActions.Controls[0].Controls[0].FindControl("cblGroup");

        if (gvPendingActions.Rows.Count > 0) // not coming from an Empty Data Row
        {
            cbToPerson = (CheckBox)gvPendingActions.FooterRow.FindControl("cbToPerson");
            ddlPerson = (DropDownList)gvPendingActions.FooterRow.FindControl("ddlPerson");
            ddlGroup = (DropDownList)gvPendingActions.FooterRow.FindControl("ddlGroup");
            cblGroup = (CheckBoxList)gvPendingActions.FooterRow.FindControl("cblGroup");
        }

        // toggle whether ddlPerson will be enabled or disabled and populate the Person Dropdown List
        PopulatePerson(cbToPerson, ddlPerson, ddlGroup, cblGroup);
    }
    protected void ddlGroupPendingActions_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox cbToPerson = (CheckBox)gvPendingActions.Controls[0].Controls[0].FindControl("cbToPerson"); // coming from an Empty Data Row
        DropDownList ddlPerson = (DropDownList)gvPendingActions.Controls[0].Controls[0].FindControl("ddlPerson");
        DropDownList ddlGroup = (DropDownList)gvPendingActions.Controls[0].Controls[0].FindControl("ddlGroup");
        CheckBoxList cblGroup = (CheckBoxList)gvPendingActions.Controls[0].Controls[0].FindControl("cblGroup");

        if (gvPendingActions.Rows.Count > 0) // not coming from Empty Data Row
        {
            cbToPerson = (CheckBox)gvPendingActions.FooterRow.FindControl("cbToPerson");
            ddlPerson = (DropDownList)gvPendingActions.FooterRow.FindControl("ddlPerson");
            ddlGroup = (DropDownList)gvPendingActions.FooterRow.FindControl("ddlGroup");
            cblGroup = (CheckBoxList)gvPendingActions.FooterRow.FindControl("cblGroup");
        }

        // populate Person Drop Down List
        SelectedGroup(cbToPerson, ddlPerson, ddlGroup, cblGroup);
    }
    protected void PopulatePerson(CheckBox cbToPerson, DropDownList ddlPerson, DropDownList ddlGroup, CheckBoxList cblGroup)
    {
        if (cbToPerson.Checked)
        {
            ddlPerson.Enabled = true;
            ddlPerson.Style.Add("background-color", "#ffffff");
            // populate Person Drop Down List
            SelectedGroup(cbToPerson, ddlPerson, ddlGroup, cblGroup);
        }
        else
        {
            ddlPerson.Enabled = false;
            ddlPerson.Style.Add("background-color", "#eeeeee");
        }
        UpdateFormView();
    }
    protected void SelectedGroup(CheckBox cbToPerson, DropDownList ddlPerson, DropDownList ddlGroup, CheckBoxList cblGroup)
    {
        if (ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            ddlPerson.Enabled = false;
            cbToPerson.Checked = false;
            cbToPerson.Enabled = false;
            cblGroup.Visible = true;
            PopulateCblGroup(cblGroup);
        }
        else
        {
            cblGroup.Items.Clear();
            ddlPerson.Enabled = true;
            cbToPerson.Enabled = true;
        }

        ddlPerson.Items.Clear();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [staffView] WHERE [StaffGroup] = '" + ddlGroup.SelectedItem.Text + "' ORDER BY [StaffName]"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            ddlPerson.DataSource = cmd.ExecuteReader();
            ddlPerson.DataTextField = "StaffName";
            ddlPerson.DataValueField = "StaffId";
            ddlPerson.DataBind();
            con.Close();
        }
        UpdateFormView();
    }

    [WebMethod()] // method responsible for saving the Human Body Image to server directory - MR-WEB01
    public static void SaveHumanBodyImage(string imageData)
    {
        byte[] data = Convert.FromBase64String(imageData);

        string ImageNo = "";  // var w/c stores the current selected accordion pane
        if (Report.SelectedAcp == "0")
        {
            ImageNo = "Image1";
            if (Report.Name.Contains("MR Incident"))
            {
                ReportIncidentMr.HumanBody1 = data;
            }
            else
            {
                ReportIncidentCu.HumanBody1 = data;
            }
        }
        else if (Report.SelectedAcp == "1")
        {
            ImageNo = "Image2";
            if (Report.Name.Contains("MR Incident"))
            {
                ReportIncidentMr.HumanBody2 = data;
            }
            else
            {
                ReportIncidentCu.HumanBody2 = data;
            }
        }
        else if (Report.SelectedAcp == "2")
        {
            ImageNo = "Image3";
            if (Report.Name.Contains("MR Incident"))
            {
                ReportIncidentMr.HumanBody3 = data;
            }
            else
            {
                ReportIncidentCu.HumanBody3 = data;
            }
        }
        else if (Report.SelectedAcp == "3")
        {
            ImageNo = "Image4";
            if (Report.Name.Contains("MR Incident"))
            {
                ReportIncidentMr.HumanBody4 = data;
            }
            else
            {
                ReportIncidentCu.HumanBody4 = data;
            }
        }
        else if (Report.SelectedAcp == "4")
        {
            ImageNo = "Image5";
            if (Report.Name.Contains("MR Incident"))
            {
                ReportIncidentMr.HumanBody5 = data;
            }
            else
            {
                ReportIncidentCu.HumanBody5 = data;
            }
        }

        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

        con2.Open();
        SqlCommand command = new SqlCommand("UPDATE " + Report.Table + " SET " + ImageNo + "=@image WHERE ReportId=" + Report.Id + " AND AuditVersion=" + Report.AuditVersion, con2);
        IDataParameter par = command.CreateParameter();
        par.ParameterName = "image";
        par.DbType = DbType.Binary;
        par.Value = data;
        command.Parameters.Add(par);
        command.ExecuteNonQuery();
        con2.Close();

        // if report status is anything other than 'Awaiting Completion'. Flag that there were changes made
        if (Report.Status != "Awaiting Completion")
        {
            Report.HasImageChange = true;
        }
    }
}