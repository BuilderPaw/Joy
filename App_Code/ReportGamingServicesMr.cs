using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportGamingServicesMr
/// </summary>
public class ReportGamingServicesMr
{
    public ReportGamingServicesMr()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string HarmMinimisation
    {
        get
        {
            if (HttpContext.Current.Session["RGSMHarmMinimisation"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMHarmMinimisation"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMHarmMinimisation"] = value;
        }
    }
    public static string PromotionalAwareness
    {
        get
        {
            if (HttpContext.Current.Session["RGSMPromotionalAwareness"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMPromotionalAwareness"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMPromotionalAwareness"] = value;
        }
    }
    public static string SipAndChill
    {
        get
        {
            if (HttpContext.Current.Session["RGSMSipAndChill"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMSipAndChill"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMSipAndChill"] = value;
        }
    }
    public static string CustomerFeedback
    {
        get
        {
            if (HttpContext.Current.Session["RGSMCustomerFeedback"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMCustomerFeedback"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMCustomerFeedback"] = value;
        }
    }
    public static string CustomerComplaints
    {
        get
        {
            if (HttpContext.Current.Session["RGSMCustomerComplaints"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMCustomerComplaints"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMCustomerComplaints"] = value;
        }
    }
    public static string Maintenance
    {
        get
        {
            if (HttpContext.Current.Session["RGSMMaintenance"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMMaintenance"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMMaintenance"] = value;
        }
    }
    public static string Incidents
    {
        get
        {
            if (HttpContext.Current.Session["RGSMIncidents"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMIncidents"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMIncidents"] = value;
        }
    }
    public static string GeneralComments
    {
        get
        {
            if (HttpContext.Current.Session["RGSMGeneralComments"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGSMGeneralComments"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGSMGeneralComments"] = value;
        }
    }
}