using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportCustomerRelationsOfficerMr
/// </summary>
public class ReportCustomerRelationsOfficerMr
{
    public ReportCustomerRelationsOfficerMr()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string Gaming
    {
        get
        {
            if (HttpContext.Current.Session["RCROMGaming"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMGaming"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMGaming"] = value;
        }
    }
    public static string Promotions
    {
        get
        {
            if (HttpContext.Current.Session["RCROMPromotions"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMPromotions"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMPromotions"] = value;
        }
    }
    public static string NewCustomers
    {
        get
        {
            if (HttpContext.Current.Session["RCROMNewCustomers"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMNewCustomers"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMNewCustomers"] = value;
        }
    }
    public static string MemberContacts
    {
        get
        {
            if (HttpContext.Current.Session["RCROMMemberContacts"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMMemberContacts"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMMemberContacts"] = value;
        }
    }
    public static string CustomerFeedback
    {
        get
        {
            if (HttpContext.Current.Session["RCROMCustomerFeedback"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMCustomerFeedback"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMCustomerFeedback"] = value;
        }
    }
    public static string CustomerFollow
    {
        get
        {
            if (HttpContext.Current.Session["RCROMCustomerFollow"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMCustomerFollow"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMCustomerFollow"] = value;
        }
    }
    public static string Maintenance
    {
        get
        {
            if (HttpContext.Current.Session["RCROMMaintenance"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMMaintenance"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMMaintenance"] = value;
        }
    }
    public static string GeneralComments
    {
        get
        {
            if (HttpContext.Current.Session["RCROMGeneralComments"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCROMGeneralComments"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCROMGeneralComments"] = value;
        }
    }
}