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
    public static string MemberSince
    {
        get
        {
            if (HttpContext.Current.Session["RGOMMemberSince"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMMemberSince"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMMemberSince"] = value;
        }
    }
    public static string ViewPlayerId
    {
        get
        {
            if (HttpContext.Current.Session["RGOMViewPlayerId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMViewPlayerId"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMViewPlayerId"] = value;
        }
    }

    public static string PlayerId
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPlayerId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPlayerId"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPlayerId"] = value;
        }
    }

    public static string Image
    {
        get
        {
            if (HttpContext.Current.Session["RGOMImage"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMImage"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMImage"] = value;
        }
    }
    public static string LastErrorMsg
    {
        get
        {
            if (HttpContext.Current.Session["RGOMLastErrorMsg"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RGOMLastErrorMsg"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMLastErrorMsg"] = value;
        }
    }

    public static string TxtTimeH
    {
        get
        {
            if (HttpContext.Current.Session["RGOMTxtTimeH"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMTxtTimeH"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMTxtTimeH"] = value;
        }
    }
    public static string TxtTimeM
    {
        get
        {
            if (HttpContext.Current.Session["RGOMTxtTimeM"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMTxtTimeM"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMTxtTimeM"] = value;
        }
    }
    public static string TxtPartyType
    {
        get
        {
            if (HttpContext.Current.Session["RGOMTxtPartyType"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMTxtPartyType"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMTxtPartyType"] = value;
        }
    }
    public static string EventTypeOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOMEventTypeOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMEventTypeOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMEventTypeOther"] = value;
        }
    }
    public static string VDOB
    {
        get
        {
            if (HttpContext.Current.Session["RGOMVDOB"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMVDOB"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMVDOB"] = value;
        }
    }
    public static string MDOB
    {
        get
        {
            if (HttpContext.Current.Session["RGOMMDOB"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMMDOB"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMMDOB"] = value;
        }
    }
    public static string VAddress
    {
        get
        {
            if (HttpContext.Current.Session["RGOMVAddress"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMVAddress"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMVAddress"] = value;
        }
    }
    public static string MAddress
    {
        get
        {
            if (HttpContext.Current.Session["RGOMMAddress"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMMAddress"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMMAddress"] = value;
        }
    }
    public static string VProofID
    {
        get
        {
            if (HttpContext.Current.Session["RGOMVProofID"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMVProofID"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMVProofID"] = value;
        }
    }
    public static string First
    {
        get
        {
            if (HttpContext.Current.Session["RGOMFirst"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMFirst"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMFirst"] = value;
        }
    }
    public static string Last
    {
        get
        {
            if (HttpContext.Current.Session["RGOMLast"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMLast"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMLast"] = value;
        }
    }
    public static string Contact
    {
        get
        {
            if (HttpContext.Current.Session["RGOMContact"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMContact"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMContact"] = value;
        }
    }
    public static string PartyType
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPartyType"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPartyType"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPartyType"] = value;
        }
    }
    public static string EventType
    {
        get
        {
            if (HttpContext.Current.Session["RGOMEventType"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMEventType"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMEventType"] = value;
        }
    }
    public static string Member
    {
        get
        {
            if (HttpContext.Current.Session["RGOMMember"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMMember"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMMember"] = value;
        }
    }
    public static string SignInSlip
    {
        get
        {
            if (HttpContext.Current.Session["RGOMSignInSlip"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMSignInSlip"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMSignInSlip"] = value;
        }
    }
    public static string SignInBy
    {
        get
        {
            if (HttpContext.Current.Session["RGOMSignInBy"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMSignInBy"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMSignInBy"] = value;
        }
    }
    public static string Date
    {
        get
        {
            if (HttpContext.Current.Session["RGOMDate"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMDate"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMDate"] = value;
        }
    }
    public static string Hour
    {
        get
        {
            if (HttpContext.Current.Session["RGOMHour"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMHour"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMHour"] = value;
        }
    }
    public static string Minute
    {
        get
        {
            if (HttpContext.Current.Session["RGOMMinute"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMMinute"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMMinute"] = value;
        }
    }
    public static string LocationList
    {
        get
        {
            if (HttpContext.Current.Session["RGOMLocationList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMLocationList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMLocationList"] = value;
        }
    }
    public static string LocationOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOMLocationOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMLocationOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMLocationOther"] = value;
        }
    }
    public static string LocationMachine
    {
        get
        {
            if (HttpContext.Current.Session["RGOMLocationMachine"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMLocationMachine"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMLocationMachine"] = value;
        }
    }
    public static string RGONotifiedList
    {
        get
        {
            if (HttpContext.Current.Session["RGOMRGONotifiedList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMRGONotifiedList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMRGONotifiedList"] = value;
        }
    }
    public static string RGONotifiedOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOMRGONotifiedOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMRGONotifiedOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMRGONotifiedOther"] = value;
        }
    }
    public static string PatronSignsOther
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPatronSignsOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPatronSignsOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPatronSignsOther"] = value;
        }
    }
    public static string PatronsSignsList
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPatronsSignsList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPatronsSignsList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPatronsSignsList"] = value;
        }
    }
    public static string InitialActionList
    {
        get
        {
            if (HttpContext.Current.Session["RGOMInitialActionList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMInitialActionList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMInitialActionList"] = value;
        }
    }
    public static string PatronResponseList
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPatronResponseList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPatronResponseList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPatronResponseList"] = value;
        }
    }
    public static string EventOutcomeList
    {
        get
        {
            if (HttpContext.Current.Session["RGOMEventOutcomeList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMEventOutcomeList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMEventOutcomeList"] = value;
        }
    }
    public static string EventOutcomeFurtherComments
    {
        get
        {
            if (HttpContext.Current.Session["RGOMEventOutcomeFurtherComments"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMEventOutcomeFurtherComments"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMEventOutcomeFurtherComments"] = value;
        }
    }
    public static string WitnessRecorded
    {
        get
        {
            if (HttpContext.Current.Session["RGOMWitnessRecorded"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMWitnessRecorded"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMWitnessRecorded"] = value;
        }
    }
    public static string WitnessDetails
    {
        get
        {
            if (HttpContext.Current.Session["RGOMWitnessDetails"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMWitnessDetails"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMWitnessDetails"] = value;
        }
    }
    public static string PoliceNotified
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPoliceNotified"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPoliceNotified"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPoliceNotified"] = value;
        }
    }
    public static string PoliceDetails
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPoliceDetails"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPoliceDetails"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPoliceDetails"] = value;
        }
    }
    public static string IncidentReportCompleted
    {
        get
        {
            if (HttpContext.Current.Session["RGOMIncidentReportCompleted"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMIncidentReportCompleted"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMIncidentReportCompleted"] = value;
        }
    }
    public static string AssistedCompletingIncidentReport
    {
        get
        {
            if (HttpContext.Current.Session["RGOMAssistedCompletingIncidentReport"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMAssistedCompletingIncidentReport"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMAssistedCompletingIncidentReport"] = value;
        }
    }
    public static byte[] MemberPhoto
    {
        get
        {
            if (HttpContext.Current.Session["RGOMMemberPhoto"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RGOMMemberPhoto"];
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMMemberPhoto"] = value;
        }
    }
    public static string Alias
    {
        get
        {
            if (HttpContext.Current.Session["RGOMAlias"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMAlias"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMAlias"] = value;
        }
    }
    public static string PatronDetailsRecorded
    {
        get
        {
            if (HttpContext.Current.Session["RGOMPatronDetailsRecorded"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMPatronDetailsRecorded"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMPatronDetailsRecorded"] = value;
        }
    }
    public static string AlertResponseList
    {
        get
        {
            if (HttpContext.Current.Session["RGOMAlertResponseList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RGOMAlertResponseList"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RGOMAlertResponseList"] = value;
        }
    }
}