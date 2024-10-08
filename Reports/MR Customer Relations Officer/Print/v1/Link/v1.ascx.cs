﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Customer_Relations_Officer_Print_v1_Link_v1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserCredentials.GroupsQuery.Contains("Customer Relations Officer") || UserCredentials.GroupsQuery.Contains("Senior Manager") || UserCredentials.GroupsQuery.Contains("Override")) // if it is a member of CRO or Senior Manager display the report
        {
            dmReport.Visible = true;
        }
        else
        {
            dmReport.Visible = false;
        }
    }
}