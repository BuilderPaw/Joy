using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for CU Duty Manager Reports
/// </summary>
public class ReportDutyManagerCu
{
    public ReportDutyManagerCu()
    {

    }

    // CU Duty Manager Report Version 1
    public static string Sup
    {
        get
        {
            if (HttpContext.Current.Session["RDMCSupervisors"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCSupervisors"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCSupervisors"] = value;
        }
    }
    public static string Whs
    {
        get
        {
            if (HttpContext.Current.Session["RDMCWhs"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCWhs"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCWhs"] = value;
        }
    }
    public static string Cost
    {
        get
        {
            if (HttpContext.Current.Session["RDMCCost"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCCost"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCCost"] = value;
        }
    }
    public static string ClubPres
    {
        get
        {
            if (HttpContext.Current.Session["RDMCClubPres"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCClubPres"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCClubPres"] = value;
        }
    }
    public static string ClubMain
    {
        get
        {
            if (HttpContext.Current.Session["RDMCClubMain"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCClubMain"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCClubMain"] = value;
        }
    }
    public static string Absent
    {
        get
        {
            if (HttpContext.Current.Session["RDMCAbsenteeism"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCAbsenteeism"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCAbsenteeism"] = value;
        }
    }
    public static string StaffIssues
    {
        get
        {
            if (HttpContext.Current.Session["RDMCStaffIssues"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCStaffIssues"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCStaffIssues"] = value;
        }
    }
    public static string Gaming
    {
        get
        {
            if (HttpContext.Current.Session["RDMCGaming"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCGaming"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCGaming"] = value;
        }
    }
    public static string KeySec
    {
        get
        {
            if (HttpContext.Current.Session["RDMCKeySec"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCKeySec"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCKeySec"] = value;
        }
    }
    public static string Cameras
    {
        get
        {
            if (HttpContext.Current.Session["RDMCCameras"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCCameras"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCCameras"] = value;
        }
    }
    public static string GenComm
    {
        get
        {
            if (HttpContext.Current.Session["RDMCGeneralComms"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCGeneralComms"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCGeneralComms"] = value;
        }
    }
    public static string LuckyRewards
    {
        get
        {
            if (HttpContext.Current.Session["RDMCLuckyRewards"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCLuckyRewards"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCLuckyRewards"] = value;
        }
    }
    public static string Compliance
    {
        get
        {
            if (HttpContext.Current.Session["RDMCCompliance"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMCCompliance"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDMCCompliance"] = value;
        }
    }
}