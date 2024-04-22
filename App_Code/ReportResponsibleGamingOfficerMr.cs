using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportResponsibleGamingOfficerMr
/// </summary>
public class ReportResponsibleGamingOfficerMr
{
    public ReportResponsibleGamingOfficerMr()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string MemberSince1
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberSince1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMemberSince1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberSince1"] = value;
        }
    }
}