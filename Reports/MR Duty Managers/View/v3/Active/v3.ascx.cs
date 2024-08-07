﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Duty_Managers_View_v3_Active_v3 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserCredentials.GroupsQuery.Contains("Duty Manager") || UserCredentials.GroupsQuery.Contains("Senior Manager") || UserCredentials.GroupsQuery.Contains("Override")) // if it is a member of Duty or Senior Manager display the Incident Report
        {
            dmReport.Visible = true;
        }
        else
        {
            dmReport.Visible = false;
        }
    }
}