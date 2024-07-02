using System;
using System.Collections.Generic;
using System.Data; // Data Table
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_CU_Responsible_Gaming_Officer_Print_v1_Active_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Report.SelectedStaffId == UserCredentials.StaffId || UserCredentials.GroupsQuery.Contains("Supervisor") || UserCredentials.GroupsQuery.Contains("Duty Manager") || UserCredentials.GroupsQuery.Contains("Senior Manager") || UserCredentials.GroupsQuery.Contains("Override") || UserCredentials.GroupsQuery.Contains("Responsible Gaming")) // if it is a member of Duty or Senior Manager display the Responsible Gaming Officer Report
        {
            viewReport.Visible = true;
            readFiles(Report.ActiveReport, "getFields");
        }
        else
        {
            viewReport.Visible = false;
        }
    }

    public string ProcessMyDataItem(object myValue)
    {
        if (String.IsNullOrEmpty(myValue.ToString()))
        {
            return " ";
        }
        else
        {
            try
            {
                myValue = Convert.ToDateTime(myValue).ToString("dddd, dd MMMM yyyy");
            }
            catch
            {
                return " ";
            }
        }
        return myValue.ToString();
    }
    public string ProcessDate(object myValue)
    {
        if (String.IsNullOrEmpty(myValue.ToString()))
        {
            return "";
        }
        else
        {
            myValue = Convert.ToDateTime(myValue).ToString("dd/MM/yyyy");
        }
        return myValue.ToString();
    }

    public Boolean ProcessCheckBox(object myValue)
    {
        if (String.IsNullOrEmpty(myValue.ToString()))
        {
            return false;
        }
        return Convert.ToBoolean(myValue);
    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
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
                        // populate player id
                        if (!String.IsNullOrEmpty(rdr["PlayerId"].ToString()))
                        {
                            ReportResponsibleGamingOfficerCu.ViewPlayerId = rdr["PlayerId"].ToString();
                        }

                        // check selected items in the Event Type check box list
                        string[] arrayEventType = rdr["EventType"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_EventType.Items)
                        {
                            for (int i = 0; i < arrayEventType.Length; i++)
                            {
                                if (arrayEventType[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        // check if Other Event Type Textbox is not empty
                        if (!String.IsNullOrEmpty(rdr["EventTypeOtherDesc"].ToString()))
                        {
                            treventTypeOther.Visible = true;
                            treventTypeOther1.Visible = true;
                        }

                        List_Location.Items.Clear(); // clear any items set in the check box list
                        // get and set check box list items on how RGOs were notified of the event
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
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

                        // check items selected in Location check box list
                        string[] arrayLocation = rdr["LocationList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_Location.Items)
                        {
                            for (int i = 0; i < arrayLocation.Length; i++)
                            {
                                if (arrayLocation[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                            if (item.ToString() == "Other")
                            {
                                if (item.Selected)
                                {
                                    trlocationother.Visible = true;
                                    trlocationother1.Visible = true;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(rdr["LocationMachine"].ToString()))
                        {
                            trlocationmachine.Visible = true;
                            trlocationmachine1.Visible = true;
                        }

                        List_RGONotified.Items.Clear(); // clear any items set in the check box list
                        // get and set check box list items on how RGOs were notified of the event
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_RGONotified] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
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

                        // check items selected in RGONotified check box list
                        string[] arrayRGONotified = rdr["RGONOtifiedList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
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

                        if (!string.IsNullOrEmpty(rdr["RGONotifiedOther"].ToString()))
                        {
                            trrgonotifiedother.Visible = true;
                            trrgonotifiedother1.Visible = true;
                        }

                        // get and set check box list items for list of signs of problem gambling
                        tbllistofsignsofproblemgambling.Visible = true; // show the list of check boxes

                        // clear any items set in the check box list, and then add the check box items for Patron Signs check box list
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

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='General Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Probable Warning Signs' AND [Class2]='Social behaviours' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Length of play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Money' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Behaviour during play' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                            command.CommandText = "SELECT * FROM [dbo].[List_PatronSigns] WHERE [SiteID] = 2 AND [Active] = 1 AND [Class1]='Strong Warning Signs' AND [Class2]='Social behaviours' ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
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

                        if (!string.IsNullOrEmpty(rdr["PatronSignsOther"].ToString()))
                        {
                            patronsignsother.Visible = true;
                            patronsignsother1.Visible = true;
                        }

                        List_InitialAction.Items.Clear(); // clear any items set in the check box list
                        // get and set check box list items for initial actions taken in the event
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_InitialAction] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
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

                        List_3hrAlertResponse.Items.Clear(); // clear any items set in the check box list
                        // get and set check box list items for Alert responses in the event
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_3hrsAlertResponse] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
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

                        // check items selected in Alert Response check box list
                        string[] arrayAlertResponse = rdr["AlertResponseList"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_3hrAlertResponse.Items)
                        {
                            for (int i = 0; i < arrayAlertResponse.Length; i++)
                            {
                                if (arrayAlertResponse[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        List_PatronResponse.Items.Clear(); // clear any items set in the check box list
                        // get and set check box list items for patron responses in the event
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT * FROM [dbo].[List_PatronResponse] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
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
                            command.CommandText = "SELECT * FROM [dbo].[List_EventOutcome] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'N/A' THEN 1 ELSE 0 END, [Description]";
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

                        if (!string.IsNullOrEmpty(rdr["EventOutcomeFurtherComments"].ToString()))
                        {
                            trfurthercomments.Visible = true;
                            trfurthercomments1.Visible = true;
                        }

                        if (Convert.ToBoolean(rdr["WitnessRecorded"]) == true)
                        {
                            trwitness.Visible = true;
                            trwitness1.Visible = true;
                        }
                        if (Convert.ToBoolean(rdr["PoliceNotified"]) == true)
                        {
                            trpolice.Visible = true;
                            trpolice1.Visible = true;
                        }

                        if (Convert.ToBoolean(rdr["PatronDetailsRecorded"]) == false)
                        {
                            tblPerson1.Visible = false;
                        }
                        else
                        {
                            tblPerson1.Visible = true;

                            byte[] memberPhoto = null;

                            try // set Member Photo
                            {
                                if ((byte[])rdr["MemberPhoto"] != null)
                                {
                                    memberPhoto = (byte[])rdr["MemberPhoto"];
                                }
                            }
                            catch
                            {
                                memberPhoto = null;
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
                                member13l.Visible = true;
                                member14l.Visible = true;

                                visitor11l.Visible = false;
                                visitor12l.Visible = false;
                                visitor13l.Visible = false;
                                visitor14l.Visible = false;
                                visitor15l.Visible = false;
                            }
                            else if (rdr["PartyType"].ToString() == "2")
                            {
                                member11l.Visible = false;
                                member13l.Visible = false;
                                member14l.Visible = false;

                                visitor11l.Visible = true;
                                visitor12l.Visible = true;
                                visitor13l.Visible = true;
                                visitor14l.Visible = true;
                                visitor15l.Visible = true;
                            }
                            else
                            {
                                member11l.Visible = false;
                                member13l.Visible = false;
                                member14l.Visible = false;

                                visitor11l.Visible = false;
                                visitor12l.Visible = false;
                                visitor13l.Visible = false;
                                visitor14l.Visible = false;
                                visitor15l.Visible = false;
                            }
                        }
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