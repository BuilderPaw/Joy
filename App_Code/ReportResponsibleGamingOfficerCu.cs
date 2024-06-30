using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportResponsibleGamingOfficerCu
/// </summary>
public class ReportResponsibleGamingOfficerCu
{
    public ReportResponsibleGamingOfficerCu()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string MemberSince
    {
        get
        {
            if (HttpContext.Current.Session["RGOCMemberSince"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCMemberSince"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCMemberSince"] = value;
        }
    }
    public static string ViewPlayerId
    {
        get
        {
            if (HttpContext.Current.Session["RGOCViewPlayerId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCViewPlayerId"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCViewPlayerId"] = value;
        }
    }

    public static string PlayerId
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPlayerId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPlayerId"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPlayerId"] = value;
        }
    }

    public static string Image
    {
        get
        {
            if (HttpContext.Current.Session["RGOCImage"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCImage"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCImage"] = value;
        }
    }
    public static string LastErrorMsg
    {
        get
        {
            if (HttpContext.Current.Session["RGOCLastErrorMsg"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGOCLastErrorMsg"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCLastErrorMsg"] = value;
        }
    }

    public static string TxtTimeH
    {
        get
        {
            if (HttpContext.Current.Session["RGOCTxtTimeH"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCTxtTimeH"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCTxtTimeH"] = value;
        }
    }
    public static string TxtTimeM
    {
        get
        {
            if (HttpContext.Current.Session["RGOCTxtTimeM"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCTxtTimeM"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCTxtTimeM"] = value;
        }
    }
    public static string TxtPartyType
    {
        get
        {
            if (HttpContext.Current.Session["RGOCTxtPartyType"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCTxtPartyType"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCTxtPartyType"] = value;
        }
    }
    public static string EventTypeOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOCEventTypeOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCEventTypeOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCEventTypeOther"] = value;
        }
    }
    public static string VDOB
    {
        get
        {
            if (HttpContext.Current.Session["RGOCVDOB"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCVDOB"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCVDOB"] = value;
        }
    }
    public static string MDOB
    {
        get
        {
            if (HttpContext.Current.Session["RGOCMDOB"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCMDOB"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCMDOB"] = value;
        }
    }
    public static string VAddress
    {
        get
        {
            if (HttpContext.Current.Session["RGOCVAddress"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCVAddress"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCVAddress"] = value;
        }
    }
    public static string MAddress
    {
        get
        {
            if (HttpContext.Current.Session["RGOCMAddress"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCMAddress"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCMAddress"] = value;
        }
    }
    public static string VProofID
    {
        get
        {
            if (HttpContext.Current.Session["RGOCVProofID"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCVProofID"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCVProofID"] = value;
        }
    }
    public static string First
    {
        get
        {
            if (HttpContext.Current.Session["RGOCFirst"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCFirst"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCFirst"] = value;
        }
    }
    public static string Last
    {
        get
        {
            if (HttpContext.Current.Session["RGOCLast"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCLast"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCLast"] = value;
        }
    }
    public static string Contact
    {
        get
        {
            if (HttpContext.Current.Session["RGOCContact"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCContact"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCContact"] = value;
        }
    }
    public static string PartyType
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPartyType"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPartyType"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPartyType"] = value;
        }
    }
    public static string EventType
    {
        get
        {
            if (HttpContext.Current.Session["RGOCEventType"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCEventType"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCEventType"] = value;
        }
    }
    public static string Member
    {
        get
        {
            if (HttpContext.Current.Session["RGOCMember"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCMember"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCMember"] = value;
        }
    }
    public static string SignInSlip
    {
        get
        {
            if (HttpContext.Current.Session["RGOCSignInSlip"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCSignInSlip"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCSignInSlip"] = value;
        }
    }
    public static string SignInBy
    {
        get
        {
            if (HttpContext.Current.Session["RGOCSignInBy"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCSignInBy"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCSignInBy"] = value;
        }
    }
    public static string Date
    {
        get
        {
            if (HttpContext.Current.Session["RGOCDate"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCDate"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCDate"] = value;
        }
    }
    public static string Hour
    {
        get
        {
            if (HttpContext.Current.Session["RGOCHour"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCHour"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCHour"] = value;
        }
    }
    public static string Minute
    {
        get
        {
            if (HttpContext.Current.Session["RGOCMinute"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCMinute"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCMinute"] = value;
        }
    }
    public static string LocationList
    {
        get
        {
            if (HttpContext.Current.Session["RGOCLocationList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCLocationList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCLocationList"] = value;
        }
    }
    public static string LocationOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOCLocationOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCLocationOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCLocationOther"] = value;
        }
    }
    public static string LocationMachine
    {
        get
        {
            if (HttpContext.Current.Session["RGOCLocationMachine"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCLocationMachine"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCLocationMachine"] = value;
        }
    }
    public static string RGONotifiedList
    {
        get
        {
            if (HttpContext.Current.Session["RGOCRGONotifiedList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCRGONotifiedList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCRGONotifiedList"] = value;
        }
    }
    public static string RGONotifiedOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOCRGONotifiedOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCRGONotifiedOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCRGONotifiedOther"] = value;
        }
    }
    public static string PatronSignsOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPatronSignsOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPatronSignsOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPatronSignsOther"] = value;
        }
    }
    public static string PatronsSignsList
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPatronsSignsList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPatronsSignsList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPatronsSignsList"] = value;
        }
    }
    public static string InitialActionList
    {
        get
        {
            if (HttpContext.Current.Session["RGOCInitialActionList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCInitialActionList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCInitialActionList"] = value;
        }
    }
    public static string PatronResponseList
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPatronResponseList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPatronResponseList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPatronResponseList"] = value;
        }
    }
    public static string EventOutcomeList
    {
        get
        {
            if (HttpContext.Current.Session["RGOCEventOutcomeList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCEventOutcomeList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCEventOutcomeList"] = value;
        }
    }
    public static string EventOutcomeFurtherComments
    {
        get
        {
            if (HttpContext.Current.Session["RGOCEventOutcomeFurtherComments"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCEventOutcomeFurtherComments"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCEventOutcomeFurtherComments"] = value;
        }
    }
    public static string WitnessRecorded
    {
        get
        {
            if (HttpContext.Current.Session["RGOCWitnessRecorded"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCWitnessRecorded"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCWitnessRecorded"] = value;
        }
    }
    public static string WitnessDetails
    {
        get
        {
            if (HttpContext.Current.Session["RGOCWitnessDetails"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCWitnessDetails"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCWitnessDetails"] = value;
        }
    }
    public static string PoliceNotified
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPoliceNotified"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPoliceNotified"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPoliceNotified"] = value;
        }
    }
    public static string PoliceDetails
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPoliceDetails"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPoliceDetails"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPoliceDetails"] = value;
        }
    }
    public static string IncidentReportCompleted
    {
        get
        {
            if (HttpContext.Current.Session["RGOCIncidentReportCompleted"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCIncidentReportCompleted"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCIncidentReportCompleted"] = value;
        }
    }
    public static string AssistedCompletingIncidentReport
    {
        get
        {
            if (HttpContext.Current.Session["RGOCAssistedCompletingIncidentReport"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCAssistedCompletingIncidentReport"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCAssistedCompletingIncidentReport"] = value;
        }
    }
    public static byte[] MemberPhoto
    {
        get
        {
            if (HttpContext.Current.Session["RGOCMemberPhoto"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RGOCMemberPhoto"];
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCMemberPhoto"] = value;
        }
    }
    public static string Alias
    {
        get
        {
            if (HttpContext.Current.Session["RGOCAlias"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCAlias"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCAlias"] = value;
        }
    }
    public static string PatronDetailsRecorded
    {
        get
        {
            if (HttpContext.Current.Session["RGOCPatronDetailsRecorded"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCPatronDetailsRecorded"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCPatronDetailsRecorded"] = value;
        }
    }
    public static string AlertResponseList
    {
        get
        {
            if (HttpContext.Current.Session["RGOCAlertResponseList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOCAlertResponseList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOCAlertResponseList"] = value;
        }
    }
}