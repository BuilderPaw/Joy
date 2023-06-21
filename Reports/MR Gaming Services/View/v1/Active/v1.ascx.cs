using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Gaming_Services_View_v1_Active_v1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserCredentials.GroupsQuery.Contains("Gaming Services") || UserCredentials.GroupsQuery.Contains("Senior Manager") || UserCredentials.GroupsQuery.Contains("Override"))  // if it is a member of GS or Senior Manager display the report
        {
            dmReport.Visible = true;
        }
        else
        {
            dmReport.Visible = false;
        }
    }
}