﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Supervisors_Print_v2_Active_v2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserCredentials.GroupsQuery.Contains("Supervisor") || UserCredentials.GroupsQuery.Contains("Duty Manager") || UserCredentials.GroupsQuery.Contains("Senior Manager")) // if it is a member of Duty or Senior Manager display the Incident Report
        {
            supReport.Visible = true;
        }
        else
        {
            supReport.Visible = false;
        }
    }
}