using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportCovidMarshallCu
/// </summary>
public class ReportCovidMarshallCu
{
    public ReportCovidMarshallCu()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string GeneralComments
    {
        get
        {
            if (HttpContext.Current.Session["RCMCGeneralComments"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCGeneralComments"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCGeneralComments"] = value;
        }
    }
    public static string TextBox1
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox1"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox1"] = value;
        }
    }
    public static string TextBox2
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox2"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox2"] = value;
        }
    }
    public static string TextBox3
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox3"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox3"] = value;
        }
    }
    public static string TextBox4
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox4"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox4"] = value;
        }
    }
    public static string TextBox5
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox5"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox5"] = value;
        }
    }
    public static string TextBox6
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox6"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox6"] = value;
        }
    }
    public static string TextBox7
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox7"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox7"] = value;
        }
    }
    public static string TextBox8
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox8"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox8"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox8"] = value;
        }
    }
    public static string TextBox9
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox9"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox9"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox9"] = value;
        }
    }
    public static string TextBox10
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox10"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox10"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox10"] = value;
        }
    }
    public static string TextBox11
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox11"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox11"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox11"] = value;
        }
    }
    public static string TextBox12
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox12"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox12"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox12"] = value;
        }
    }
    public static string TextBox13
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox13"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox13"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox13"] = value;
        }
    }
    public static string TextBox14
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox14"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox14"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox14"] = value;
        }
    }
    public static string TextBox15
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox15"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox15"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox15"] = value;
        }
    }
    public static string TextBox16
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox16"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox16"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox16"] = value;
        }
    }
    public static string TextBox17
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox17"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox17"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox17"] = value;
        }
    }
    public static string TextBox18
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox18"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox18"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox18"] = value;
        }
    }
    public static string TextBox19
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox19"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox19"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox19"] = value;
        }
    }
    public static string TextBox20
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox20"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox20"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox20"] = value;
        }
    }
    public static string TextBox21
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox21"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox21"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox21"] = value;
        }
    }
    public static string TextBox22
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox22"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox22"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox22"] = value;
        }
    }
    public static string TextBox23
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox23"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox23"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox23"] = value;
        }
    }
    public static string TextBox24
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox24"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox24"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox24"] = value;
        }
    }
    public static string TextBox25
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox25"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox25"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox25"] = value;
        }
    }
    public static string TextBox26
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox26"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox26"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox26"] = value;
        }
    }
    public static string TextBox27
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox27"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox27"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox27"] = value;
        }
    }
    public static string TextBox28
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox28"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox28"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox28"] = value;
        }
    }
    public static string TextBox29
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox29"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox29"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox29"] = value;
        }
    }
    public static string TextBox30
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox30"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox30"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox30"] = value;
        }
    }
    public static string TextBox31
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox31"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox31"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox31"] = value;
        }
    }
    public static string TextBox32
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox32"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox32"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox32"] = value;
        }
    }
    public static string TextBox33
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox33"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox33"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox33"] = value;
        }
    }
    public static string TextBox34
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox34"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox34"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox34"] = value;
        }
    }
    public static string TextBox35
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox35"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox35"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox35"] = value;
        }
    }
    public static string TextBox36
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox36"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox36"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox36"] = value;
        }
    }
    public static string TextBox37
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox37"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox37"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox37"] = value;
        }
    }
    public static string TextBox38
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox38"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox38"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox38"] = value;
        }
    }
    public static string TextBox39
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox39"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox39"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox39"] = value;
        }
    }
    public static string TextBox40
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox40"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox40"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox40"] = value;
        }
    }
    public static string TextBox41
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox41"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox41"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox41"] = value;
        }
    }
    public static string TextBox42
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox42"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox42"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox42"] = value;
        }
    }
    public static string TextBox43
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox43"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox43"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox43"] = value;
        }
    }
    public static string TextBox44
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox44"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox44"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox44"] = value;
        }
    }
    public static string TextBox45
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox45"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox45"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox45"] = value;
        }
    }
    public static string TextBox46
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox46"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox46"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox46"] = value;
        }
    }
    public static string TextBox47
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox47"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox47"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox47"] = value;
        }
    }
    public static string TextBox48
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox48"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox48"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox48"] = value;
        }
    }
    public static string TextBox49
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox49"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox49"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox49"] = value;
        }
    }
    public static string TextBox50
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox50"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox50"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox50"] = value;
        }
    }
    public static string TextBox51
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox51"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox51"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox51"] = value;
        }
    }
    public static string TextBox52
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox52"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox52"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox52"] = value;
        }
    }
    public static string TextBox53
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox53"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox53"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox53"] = value;
        }
    }
    public static string TextBox54
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox54"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox54"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox54"] = value;
        }
    }
    public static string TextBox55
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox55"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox55"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox55"] = value;
        }
    }
    public static string TextBox56
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox56"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox56"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox56"] = value;
        }
    }
    public static string TextBox57
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox57"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox57"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox57"] = value;
        }
    }
    public static string TextBox58
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox58"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox58"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox58"] = value;
        }
    }
    public static string TextBox59
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox59"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox59"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox59"] = value;
        }
    }
    public static string TextBox60
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox60"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox60"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox60"] = value;
        }
    }
    public static string TextBox61
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox61"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox61"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox61"] = value;
        }
    }
    public static string TextBox62
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox62"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox62"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox62"] = value;
        }
    }
    public static string TextBox63
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox63"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox63"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox63"] = value;
        }
    }
    public static string TextBox64
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox64"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox64"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox64"] = value;
        }
    }
    public static string CheckBox65
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox65"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox65"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox65"] = value;
        }
    }
    public static string CheckBox66
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox66"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox66"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox66"] = value;
        }
    }
    public static string CheckBox67
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox67"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox67"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox67"] = value;
        }
    }
    public static string CheckBox68
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox68"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox68"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox68"] = value;
        }
    }
    public static string CheckBox69
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox69"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox69"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox69"] = value;
        }
    }
    public static string CheckBox70
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox70"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox70"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox70"] = value;
        }
    }
    public static string CheckBox71
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox71"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox71"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox71"] = value;
        }
    }
    public static string CheckBox72
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox72"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox72"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox72"] = value;
        }
    }
    public static string CheckBox73
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox73"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox73"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox73"] = value;
        }
    }
    public static string CheckBox74
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox74"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox74"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox74"] = value;
        }
    }
    public static string CheckBox75
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox75"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox75"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox75"] = value;
        }
    }
    public static string CheckBox76
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox76"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox76"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox76"] = value;
        }
    }
    public static string CheckBox77
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox77"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox77"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox77"] = value;
        }
    }
    public static string CheckBox78
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox78"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox78"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox78"] = value;
        }
    }
    public static string CheckBox79
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox79"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox79"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox79"] = value;
        }
    }
    public static string CheckBox80
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox80"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox80"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox80"] = value;
        }
    }
    public static string TextBox81
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox81"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox81"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox81"] = value;
        }
    }
    public static string TextBox82
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox82"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox82"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox82"] = value;
        }
    }
    public static string TextBox83
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox83"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox83"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox83"] = value;
        }
    }
    public static string TextBox84
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox84"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox84"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox84"] = value;
        }
    }
    public static string TextBox85
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox85"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox85"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox85"] = value;
        }
    }
    public static string TextBox86
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox86"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox86"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox86"] = value;
        }
    }
    public static string TextBox87
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox87"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox87"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox87"] = value;
        }
    }
    public static string TextBox88
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox88"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox88"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox88"] = value;
        }
    }
    public static string TextBox89
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox89"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox89"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox89"] = value;
        }
    }
    public static string TextBox90
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox90"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox90"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox90"] = value;
        }
    }
    public static string TextBox91
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox91"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox91"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox91"] = value;
        }
    }
    public static string TextBox92
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox92"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox92"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox92"] = value;
        }
    }
    public static string TextBox93
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox93"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox93"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox93"] = value;
        }
    }
    public static string TextBox94
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox94"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox94"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox94"] = value;
        }
    }
    public static string TextBox95
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox95"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox95"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox95"] = value;
        }
    }
    public static string TextBox96
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox96"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox96"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox96"] = value;
        }
    }
    public static string TextBox97
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox97"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox97"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox97"] = value;
        }
    }
    public static string TextBox98
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox98"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox98"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox98"] = value;
        }
    }
    public static string TextBox99
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox99"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox99"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox99"] = value;
        }
    }
    public static string TextBox100
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox100"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox100"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox100"] = value;
        }
    }
    public static string TextBox101
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox101"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox101"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox101"] = value;
        }
    }
    public static string TextBox102
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox102"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox102"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox102"] = value;
        }
    }
    public static string TextBox103
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox103"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox103"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox103"] = value;
        }
    }
    public static string TextBox104
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox104"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox104"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox104"] = value;
        }
    }
    public static string TextBox105
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox105"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox105"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox105"] = value;
        }
    }
    public static string TextBox106
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox106"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox106"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox106"] = value;
        }
    }
    public static string TextBox107
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox107"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox107"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox107"] = value;
        }
    }
    public static string TextBox108
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox108"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox108"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox108"] = value;
        }
    }
    public static string TextBox109
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox109"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox109"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox109"] = value;
        }
    }
    public static string TextBox110
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox110"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox110"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox110"] = value;
        }
    }
    public static string TextBox111
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox111"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox111"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox111"] = value;
        }
    }
    public static string TextBox112
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox112"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox112"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox112"] = value;
        }
    }
    public static string TextBox113
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox113"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox113"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox113"] = value;
        }
    }
    public static string TextBox114
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox114"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox114"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox114"] = value;
        }
    }
    public static string TextBox115
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox115"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox115"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox115"] = value;
        }
    }
    public static string TextBox116
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox116"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox116"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox116"] = value;
        }
    }
    public static string TextBox117
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox117"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox117"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox117"] = value;
        }
    }
    public static string TextBox118
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox118"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox118"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox118"] = value;
        }
    }
    public static string TextBox119
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox119"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox119"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox119"] = value;
        }
    }
    public static string TextBox120
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox120"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox120"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox120"] = value;
        }
    }
    public static string TextBox121
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox121"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox121"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox121"] = value;
        }
    }
    public static string TextBox122
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox122"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox122"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox122"] = value;
        }
    }
    public static string TextBox123
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox123"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox123"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox123"] = value;
        }
    }
    public static string TextBox124
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox124"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox124"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox124"] = value;
        }
    }
    public static string TextBox125
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox125"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox125"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox125"] = value;
        }
    }
    public static string TextBox126
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox126"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox126"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox126"] = value;
        }
    }
    public static string TextBox127
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox127"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox127"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox127"] = value;
        }
    }
    public static string TextBox128
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox128"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox128"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox128"] = value;
        }
    }
    public static string TextBox129
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox129"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox129"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox129"] = value;
        }
    }
    public static string TextBox130
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox130"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox130"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox130"] = value;
        }
    }
    public static string TextBox131
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox131"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox131"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox131"] = value;
        }
    }
    public static string TextBox132
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox132"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox132"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox132"] = value;
        }
    }
    public static string TextBox133
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox133"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox133"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox133"] = value;
        }
    }
    public static string TextBox134
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox134"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox134"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox134"] = value;
        }
    }
    public static string TextBox135
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox135"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox135"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox135"] = value;
        }
    }
    public static string TextBox136
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox136"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox136"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox136"] = value;
        }
    }
    public static string TextBox137
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox137"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox137"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox137"] = value;
        }
    }
    public static string TextBox138
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox138"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox138"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox138"] = value;
        }
    }
    public static string TextBox139
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox139"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox139"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox139"] = value;
        }
    }
    public static string TextBox140
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox140"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox140"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox140"] = value;
        }
    }
    public static string TextBox141
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox141"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox141"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox141"] = value;
        }
    }
    public static string TextBox142
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox142"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox142"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox142"] = value;
        }
    }
    public static string TextBox143
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox143"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox143"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox143"] = value;
        }
    }
    public static string TextBox144
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox144"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox144"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox144"] = value;
        }
    }
    public static string CheckBox145
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox145"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox145"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox145"] = value;
        }
    }
    public static string CheckBox146
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox146"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox146"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox146"] = value;
        }
    }
    public static string CheckBox147
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox147"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox147"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox147"] = value;
        }
    }
    public static string CheckBox148
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox148"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox148"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox148"] = value;
        }
    }
    public static string CheckBox149
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox149"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox149"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox149"] = value;
        }
    }
    public static string CheckBox150
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox150"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox150"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox150"] = value;
        }
    }
    public static string CheckBox151
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox151"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox151"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox151"] = value;
        }
    }
    public static string CheckBox152
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox152"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox152"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox152"] = value;
        }
    }
    public static string CheckBox153
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox153"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox153"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox153"] = value;
        }
    }
    public static string CheckBox154
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox154"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox154"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox154"] = value;
        }
    }
    public static string CheckBox155
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox155"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox155"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox155"] = value;
        }
    }
    public static string CheckBox156
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox156"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox156"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox156"] = value;
        }
    }
    public static string CheckBox157
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox157"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox157"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox157"] = value;
        }
    }
    public static string CheckBox158
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox158"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox158"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox158"] = value;
        }
    }
    public static string CheckBox159
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox159"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox159"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox159"] = value;
        }
    }
    public static string CheckBox160
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox160"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox160"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox160"] = value;
        }
    }
    public static string CheckBox161
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox161"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox161"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox161"] = value;
        }
    }
    public static string CheckBox162
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox162"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox162"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox162"] = value;
        }
    }
    public static string CheckBox163
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox163"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox163"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox163"] = value;
        }
    }
    public static string CheckBox164
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox164"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox164"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox164"] = value;
        }
    }
    public static string CheckBox165
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox165"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox165"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox165"] = value;
        }
    }
    public static string CheckBox166
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox166"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox166"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox166"] = value;
        }
    }
    public static string CheckBox167
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox167"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox167"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox167"] = value;
        }
    }
    public static string CheckBox168
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox168"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox168"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox168"] = value;
        }
    }
    public static string CheckBox169
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox169"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox169"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox169"] = value;
        }
    }
    public static string CheckBox170
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox170"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox170"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox170"] = value;
        }
    }
    public static string CheckBox171
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox171"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox171"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox171"] = value;
        }
    }
    public static string CheckBox172
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox172"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox172"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox172"] = value;
        }
    }
    public static string CheckBox173
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox173"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox173"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox173"] = value;
        }
    }
    public static string CheckBox174
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox174"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox174"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox174"] = value;
        }
    }
    public static string CheckBox175
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox175"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox175"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox175"] = value;
        }
    }
    public static string CheckBox176
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox176"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox176"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox176"] = value;
        }
    }
    public static string CheckBox177
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox177"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox177"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox177"] = value;
        }
    }
    public static string CheckBox178
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox178"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox178"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox178"] = value;
        }
    }
    public static string TextBox179
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox179"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox179"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox179"] = value;
        }
    }
    public static string CheckBox180
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox180"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox180"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox180"] = value;
        }
    }
    public static string CheckBox181
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox181"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox181"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox181"] = value;
        }
    }
    public static string CheckBox182
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox182"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox182"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox182"] = value;
        }
    }
    public static string CheckBox183
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox183"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox183"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox183"] = value;
        }
    }
    public static string TextBox184
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox184"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox184"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox184"] = value;
        }
    }
    public static string CheckBox185
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox185"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox185"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox185"] = value;
        }
    }
    public static string CheckBox186
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox186"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox186"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox186"] = value;
        }
    }
    public static string CheckBox187
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox187"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox187"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox187"] = value;
        }
    }
    public static string CheckBox188
    {
        get
        {
            if (HttpContext.Current.Session["RCMCCheckBox188"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCCheckBox188"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCCheckBox188"] = value;
        }
    }
    public static string TextBox189
    {
        get
        {
            if (HttpContext.Current.Session["RCMCTextBox189"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RCMCTextBox189"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RCMCTextBox189"] = value;
        }
    }
}