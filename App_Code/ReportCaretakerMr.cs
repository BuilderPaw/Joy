using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportCaretakerMr
/// </summary>
public class ReportCaretakerMr
{
    public ReportCaretakerMr()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string Occupancy
    {
        get
        {
            if (HttpContext.Current.Session["RCMOccupancy"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMOccupancy"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMOccupancy"] = value;
        }
    }
    public static string Maintenance
    {
        get
        {
            if (HttpContext.Current.Session["RCMMaintenance"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMMaintenance"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMMaintenance"] = value;
        }
    }
    public static string GeneralComments
    {
        get
        {
            if (HttpContext.Current.Session["RCMGeneralComments"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMGeneralComments"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMGeneralComments"] = value;
        }
    }
}