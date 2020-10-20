using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Covid_Marshall_Edit_v1_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        readFiles(Report.ActiveReport, "getFields");
    }

    protected void readFiles(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand(sqlCommand, con);

        try
        {
            con.Open();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (method.Equals("getFields"))
                    {
                        lblReportName.Text = rdr["ReportName"].ToString();
                        lblReportId.Text = rdr["ReportId"].ToString();
                        lblStaffName.Text = rdr["StaffName"].ToString();
                        Report.SelectedStaffId = rdr["StaffId"].ToString();
                        ddlShift.SelectedIndex = Int32.Parse(rdr["ShiftId"].ToString());
                        Report.ShiftId = ddlShift.SelectedIndex.ToString();
                        txtDatePicker.Text = Convert.ToDateTime(rdr["ShiftDate"]).ToString("dddd, dd MMMM yyyy");
                        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
                        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
                        lblEntryDetails.Text = Convert.ToDateTime(rdr["EntryDate"]).ToString("dd/MM/yyyy HH:mm");
                        Report.EntryDate = Convert.ToDateTime(rdr["EntryDate"]).ToString();
                        txtGeneralComments.Text = rdr["GeneralComments"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        TextBox1.Text = rdr["1"].ToString();
                        TextBox2.Text = rdr["2"].ToString();
                        TextBox3.Text = rdr["3"].ToString();
                        TextBox4.Text = rdr["4"].ToString();
                        TextBox5.Text = rdr["5"].ToString();
                        TextBox6.Text = rdr["6"].ToString();
                        TextBox7.Text = rdr["7"].ToString();
                        TextBox8.Text = rdr["8"].ToString();
                        TextBox9.Text = rdr["9"].ToString();
                        TextBox10.Text = rdr["10"].ToString();
                        TextBox11.Text = rdr["11"].ToString();
                        TextBox12.Text = rdr["12"].ToString();
                        TextBox13.Text = rdr["13"].ToString();
                        TextBox14.Text = rdr["14"].ToString();
                        TextBox15.Text = rdr["15"].ToString();
                        TextBox16.Text = rdr["16"].ToString();
                        TextBox17.Text = rdr["17"].ToString();
                        TextBox18.Text = rdr["18"].ToString();
                        TextBox19.Text = rdr["19"].ToString();
                        TextBox20.Text = rdr["20"].ToString();
                        TextBox21.Text = rdr["21"].ToString();
                        TextBox22.Text = rdr["22"].ToString();
                        TextBox23.Text = rdr["23"].ToString();
                        TextBox24.Text = rdr["24"].ToString();
                        TextBox25.Text = rdr["25"].ToString();
                        TextBox26.Text = rdr["26"].ToString();
                        TextBox27.Text = rdr["27"].ToString();
                        TextBox28.Text = rdr["28"].ToString();
                        TextBox29.Text = rdr["29"].ToString();
                        TextBox30.Text = rdr["30"].ToString();
                        TextBox31.Text = rdr["31"].ToString();
                        TextBox32.Text = rdr["32"].ToString();
                        TextBox33.Text = rdr["33"].ToString();
                        TextBox34.Text = rdr["34"].ToString();
                        TextBox35.Text = rdr["35"].ToString();
                        TextBox36.Text = rdr["36"].ToString();
                        TextBox37.Text = rdr["37"].ToString();
                        TextBox38.Text = rdr["38"].ToString();
                        TextBox39.Text = rdr["39"].ToString();
                        TextBox40.Text = rdr["40"].ToString();
                        TextBox41.Text = rdr["41"].ToString();
                        TextBox42.Text = rdr["42"].ToString();
                        TextBox43.Text = rdr["43"].ToString();
                        TextBox44.Text = rdr["44"].ToString();
                        TextBox45.Text = rdr["45"].ToString();
                        TextBox46.Text = rdr["46"].ToString();
                        TextBox47.Text = rdr["47"].ToString();
                        TextBox48.Text = rdr["48"].ToString();
                        TextBox49.Text = rdr["49"].ToString();
                        TextBox50.Text = rdr["50"].ToString();
                        TextBox51.Text = rdr["51"].ToString();
                        TextBox52.Text = rdr["52"].ToString();
                        TextBox53.Text = rdr["53"].ToString();
                        TextBox54.Text = rdr["54"].ToString();
                        TextBox55.Text = rdr["55"].ToString();
                        TextBox56.Text = rdr["56"].ToString();
                        TextBox57.Text = rdr["57"].ToString();
                        TextBox58.Text = rdr["58"].ToString();
                        TextBox59.Text = rdr["59"].ToString();
                        TextBox60.Text = rdr["60"].ToString();
                        TextBox61.Text = rdr["61"].ToString();
                        TextBox62.Text = rdr["62"].ToString();
                        TextBox63.Text = rdr["63"].ToString();
                        TextBox64.Text = rdr["64"].ToString();
                        TextBox65.Text = rdr["65"].ToString();
                        TextBox66.Text = rdr["66"].ToString();
                        TextBox67.Text = rdr["67"].ToString();
                        TextBox68.Text = rdr["68"].ToString();
                        TextBox69.Text = rdr["69"].ToString();
                        TextBox70.Text = rdr["70"].ToString();
                        TextBox71.Text = rdr["71"].ToString();
                        TextBox72.Text = rdr["72"].ToString();
                        TextBox73.Text = rdr["73"].ToString();
                        TextBox74.Text = rdr["74"].ToString();
                        TextBox75.Text = rdr["75"].ToString();
                        TextBox76.Text = rdr["76"].ToString();
                        TextBox77.Text = rdr["77"].ToString();
                        TextBox78.Text = rdr["78"].ToString();
                        TextBox79.Text = rdr["79"].ToString();
                        TextBox80.Text = rdr["80"].ToString();
                        TextBox81.Text = rdr["81"].ToString();
                        TextBox82.Text = rdr["82"].ToString();
                        TextBox83.Text = rdr["83"].ToString();
                        TextBox84.Text = rdr["84"].ToString();
                        TextBox85.Text = rdr["85"].ToString();
                        TextBox86.Text = rdr["86"].ToString();
                        TextBox87.Text = rdr["87"].ToString();
                        TextBox88.Text = rdr["88"].ToString();
                        TextBox89.Text = rdr["89"].ToString();
                        TextBox90.Text = rdr["90"].ToString();
                        TextBox91.Text = rdr["91"].ToString();
                        TextBox92.Text = rdr["92"].ToString();
                        TextBox93.Text = rdr["93"].ToString();
                        TextBox94.Text = rdr["94"].ToString();
                        TextBox95.Text = rdr["95"].ToString();
                        TextBox96.Text = rdr["96"].ToString();
                        TextBox97.Text = rdr["97"].ToString();
                        TextBox98.Text = rdr["98"].ToString();
                        TextBox99.Text = rdr["99"].ToString();
                        TextBox100.Text = rdr["100"].ToString();
                        TextBox101.Text = rdr["101"].ToString();
                        TextBox102.Text = rdr["102"].ToString();
                        TextBox103.Text = rdr["103"].ToString();
                        TextBox104.Text = rdr["104"].ToString();
                        TextBox105.Text = rdr["105"].ToString();
                        TextBox106.Text = rdr["106"].ToString();
                        TextBox107.Text = rdr["107"].ToString();
                        TextBox108.Text = rdr["108"].ToString();
                        TextBox109.Text = rdr["109"].ToString();
                        TextBox110.Text = rdr["110"].ToString();
                        TextBox111.Text = rdr["111"].ToString();
                        TextBox112.Text = rdr["112"].ToString();
                        TextBox113.Text = rdr["113"].ToString();
                        TextBox114.Text = rdr["114"].ToString();
                        TextBox115.Text = rdr["115"].ToString();
                        TextBox116.Text = rdr["116"].ToString();
                        TextBox117.Text = rdr["117"].ToString();
                        TextBox118.Text = rdr["118"].ToString();
                        TextBox119.Text = rdr["119"].ToString();
                        TextBox120.Text = rdr["120"].ToString();
                        TextBox121.Text = rdr["121"].ToString();
                        TextBox122.Text = rdr["122"].ToString();
                        TextBox123.Text = rdr["123"].ToString();
                        TextBox124.Text = rdr["124"].ToString();
                        TextBox125.Text = rdr["125"].ToString();
                        TextBox126.Text = rdr["126"].ToString();
                        TextBox127.Text = rdr["127"].ToString();
                        TextBox128.Text = rdr["128"].ToString();
                        TextBox129.Text = rdr["129"].ToString();
                        TextBox130.Text = rdr["130"].ToString();
                        TextBox131.Text = rdr["131"].ToString();
                        TextBox132.Text = rdr["132"].ToString();
                        TextBox133.Text = rdr["133"].ToString();
                        TextBox134.Text = rdr["134"].ToString();
                        TextBox135.Text = rdr["135"].ToString();
                        TextBox136.Text = rdr["136"].ToString();
                        TextBox137.Text = rdr["137"].ToString();
                        TextBox138.Text = rdr["138"].ToString();
                        TextBox139.Text = rdr["139"].ToString();
                        TextBox140.Text = rdr["140"].ToString();
                        TextBox141.Text = rdr["141"].ToString();
                        TextBox142.Text = rdr["142"].ToString();
                        TextBox143.Text = rdr["143"].ToString();
                        TextBox144.Text = rdr["144"].ToString();
                        TextBox145.Text = rdr["145"].ToString();
                        TextBox146.Text = rdr["146"].ToString();
                        TextBox147.Text = rdr["147"].ToString();
                        TextBox148.Text = rdr["148"].ToString();
                        TextBox149.Text = rdr["149"].ToString();
                        TextBox150.Text = rdr["150"].ToString();
                        TextBox151.Text = rdr["151"].ToString();
                        TextBox152.Text = rdr["152"].ToString();
                        TextBox153.Text = rdr["153"].ToString();
                        TextBox154.Text = rdr["154"].ToString();
                        TextBox155.Text = rdr["155"].ToString();
                        TextBox156.Text = rdr["156"].ToString();
                        TextBox157.Text = rdr["157"].ToString();
                        TextBox158.Text = rdr["158"].ToString();
                        TextBox159.Text = rdr["159"].ToString();
                        TextBox160.Text = rdr["160"].ToString();
                        TextBox161.Text = rdr["161"].ToString();
                        TextBox162.Text = rdr["162"].ToString();
                        TextBox163.Text = rdr["163"].ToString();
                        TextBox164.Text = rdr["164"].ToString();
                        TextBox165.Text = rdr["165"].ToString();
                        TextBox166.Text = rdr["166"].ToString();
                        TextBox167.Text = rdr["167"].ToString();
                        TextBox168.Text = rdr["168"].ToString();
                        TextBox169.Text = rdr["169"].ToString();
                        TextBox170.Text = rdr["170"].ToString();
                        TextBox171.Text = rdr["171"].ToString();
                        TextBox172.Text = rdr["172"].ToString();
                        TextBox173.Text = rdr["173"].ToString();
                        TextBox174.Text = rdr["174"].ToString();
                        TextBox175.Text = rdr["175"].ToString();
                        TextBox176.Text = rdr["176"].ToString();
                        TextBox177.Text = rdr["177"].ToString();
                        TextBox178.Text = rdr["178"].ToString();
                        TextBox179.Text = rdr["179"].ToString();
                        TextBox180.Text = rdr["180"].ToString();
                        TextBox181.Text = rdr["181"].ToString();
                        TextBox182.Text = rdr["182"].ToString();
                        TextBox183.Text = rdr["183"].ToString();
                        TextBox184.Text = rdr["184"].ToString();
                        TextBox185.Text = rdr["185"].ToString();
                        TextBox186.Text = rdr["186"].ToString();
                        TextBox187.Text = rdr["187"].ToString();
                        TextBox188.Text = rdr["188"].ToString();
                        TextBox189.Text = rdr["189"].ToString();
                        TextBox190.Text = rdr["190"].ToString();
                        TextBox191.Text = rdr["191"].ToString();
                        TextBox192.Text = rdr["192"].ToString();
                        TextBox193.Text = rdr["193"].ToString();
                        TextBox194.Text = rdr["194"].ToString();
                        TextBox195.Text = rdr["195"].ToString();
                        TextBox196.Text = rdr["196"].ToString();
                        TextBox197.Text = rdr["197"].ToString();
                        TextBox198.Text = rdr["198"].ToString();
                        TextBox199.Text = rdr["199"].ToString();
                        TextBox200.Text = rdr["200"].ToString();
                        TextBox201.Text = rdr["201"].ToString();
                        TextBox202.Text = rdr["202"].ToString();
                        TextBox203.Text = rdr["203"].ToString();
                        TextBox204.Text = rdr["204"].ToString();
                        TextBox205.Text = rdr["205"].ToString();
                        TextBox206.Text = rdr["206"].ToString();
                        TextBox207.Text = rdr["207"].ToString();
                        TextBox208.Text = rdr["208"].ToString();
                        TextBox209.Text = rdr["209"].ToString();
                        TextBox210.Text = rdr["210"].ToString();
                        TextBox211.Text = rdr["211"].ToString();
                        TextBox212.Text = rdr["212"].ToString();
                        TextBox213.Text = rdr["213"].ToString();
                        TextBox214.Text = rdr["214"].ToString();
                        TextBox215.Text = rdr["215"].ToString();
                        TextBox216.Text = rdr["216"].ToString();
                        TextBox217.Text = rdr["217"].ToString();
                        TextBox218.Text = rdr["218"].ToString();
                        TextBox219.Text = rdr["219"].ToString();
                        TextBox220.Text = rdr["220"].ToString();
                        TextBox221.Text = rdr["221"].ToString();
                        TextBox222.Text = rdr["222"].ToString();
                        TextBox223.Text = rdr["223"].ToString();
                        TextBox224.Text = rdr["224"].ToString();
                        TextBox225.Text = rdr["225"].ToString();
                        TextBox226.Text = rdr["226"].ToString();
                        TextBox227.Text = rdr["227"].ToString();
                        TextBox228.Text = rdr["228"].ToString();
                        TextBox229.Text = rdr["229"].ToString();
                        TextBox230.Text = rdr["230"].ToString();
                        TextBox231.Text = rdr["231"].ToString();
                        TextBox232.Text = rdr["232"].ToString();
                        TextBox233.Text = rdr["233"].ToString();
                        TextBox234.Text = rdr["234"].ToString();
                        TextBox235.Text = rdr["235"].ToString();
                        TextBox236.Text = rdr["236"].ToString();
                        TextBox237.Text = rdr["237"].ToString();
                        TextBox238.Text = rdr["238"].ToString();
                        TextBox239.Text = rdr["239"].ToString();
                        TextBox240.Text = rdr["240"].ToString();
                        TextBox241.Text = rdr["241"].ToString();
                        TextBox242.Text = rdr["242"].ToString();
                        TextBox243.Text = rdr["243"].ToString();
                        TextBox244.Text = rdr["244"].ToString();
                        TextBox245.Text = rdr["245"].ToString();
                        TextBox246.Text = rdr["246"].ToString();
                        TextBox247.Text = rdr["247"].ToString();
                        TextBox248.Text = rdr["248"].ToString();
                        TextBox249.Text = rdr["249"].ToString();
                        TextBox250.Text = rdr["250"].ToString();
                        TextBox251.Text = rdr["251"].ToString();
                        TextBox252.Text = rdr["252"].ToString();
                        TextBox253.Text = rdr["253"].ToString();
                        TextBox254.Text = rdr["254"].ToString();
                        TextBox255.Text = rdr["255"].ToString();
                        TextBox256.Text = rdr["256"].ToString();
                        TextBox257.Text = rdr["257"].ToString();
                        TextBox258.Text = rdr["258"].ToString();
                        TextBox259.Text = rdr["259"].ToString();
                        TextBox260.Text = rdr["260"].ToString();
                        TextBox261.Text = rdr["261"].ToString();
                        TextBox262.Text = rdr["262"].ToString();
                        TextBox263.Text = rdr["263"].ToString();
                        TextBox264.Text = rdr["264"].ToString();
                        TextBox265.Text = rdr["265"].ToString();
                        TextBox266.Text = rdr["266"].ToString();
                        TextBox267.Text = rdr["267"].ToString();
                        TextBox268.Text = rdr["268"].ToString();
                        TextBox269.Text = rdr["269"].ToString();
                        TextBox270.Text = rdr["270"].ToString();
                        TextBox271.Text = rdr["271"].ToString();
                        TextBox272.Text = rdr["272"].ToString();
                        TextBox273.Text = rdr["273"].ToString();
                        TextBox274.Text = rdr["274"].ToString();
                        TextBox275.Text = rdr["275"].ToString();
                        TextBox276.Text = rdr["276"].ToString();
                        TextBox277.Text = rdr["277"].ToString();
                        TextBox278.Text = rdr["278"].ToString();
                        TextBox279.Text = rdr["279"].ToString();
                        TextBox280.Text = rdr["280"].ToString();
                        TextBox281.Text = rdr["281"].ToString();
                        TextBox282.Text = rdr["282"].ToString();
                        TextBox283.Text = rdr["283"].ToString();
                        TextBox284.Text = rdr["284"].ToString();
                        TextBox285.Text = rdr["285"].ToString();
                        TextBox286.Text = rdr["286"].ToString();
                        TextBox287.Text = rdr["287"].ToString();
                        TextBox288.Text = rdr["288"].ToString();
                        TextBox289.Text = rdr["289"].ToString();
                        TextBox290.Text = rdr["290"].ToString();
                        TextBox291.Text = rdr["291"].ToString();
                        TextBox292.Text = rdr["292"].ToString();
                        TextBox293.Text = rdr["293"].ToString();
                        TextBox294.Text = rdr["294"].ToString();
                        TextBox295.Text = rdr["295"].ToString();
                        TextBox296.Text = rdr["296"].ToString();
                        TextBox297.Text = rdr["297"].ToString();
                        TextBox298.Text = rdr["298"].ToString();
                        TextBox299.Text = rdr["299"].ToString();
                        TextBox300.Text = rdr["300"].ToString();
                        TextBox301.Text = rdr["301"].ToString();
                        TextBox302.Text = rdr["302"].ToString();
                        TextBox303.Text = rdr["303"].ToString();
                        TextBox304.Text = rdr["304"].ToString();
                        TextBox305.Text = rdr["305"].ToString();
                        TextBox306.Text = rdr["306"].ToString();
                        CheckBox307.Checked = Convert.ToBoolean(rdr["307"]);
                        CheckBox308.Checked = Convert.ToBoolean(rdr["308"]);
                        CheckBox309.Checked = Convert.ToBoolean(rdr["309"]);
                        CheckBox310.Checked = Convert.ToBoolean(rdr["310"]);
                        CheckBox311.Checked = Convert.ToBoolean(rdr["311"]);
                        CheckBox312.Checked = Convert.ToBoolean(rdr["312"]);
                        CheckBox313.Checked = Convert.ToBoolean(rdr["313"]);
                        CheckBox314.Checked = Convert.ToBoolean(rdr["314"]);
                        CheckBox315.Checked = Convert.ToBoolean(rdr["315"]);
                        CheckBox316.Checked = Convert.ToBoolean(rdr["316"]);
                        CheckBox317.Checked = Convert.ToBoolean(rdr["317"]);
                        CheckBox318.Checked = Convert.ToBoolean(rdr["318"]);
                        CheckBox319.Checked = Convert.ToBoolean(rdr["319"]);
                        CheckBox320.Checked = Convert.ToBoolean(rdr["320"]);
                        CheckBox321.Checked = Convert.ToBoolean(rdr["321"]);
                        CheckBox322.Checked = Convert.ToBoolean(rdr["322"]);
                        CheckBox323.Checked = Convert.ToBoolean(rdr["323"]);
                        CheckBox324.Checked = Convert.ToBoolean(rdr["324"]);
                        TextBox325.Text = rdr["325"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox326.Checked = Convert.ToBoolean(rdr["326"]);
                        CheckBox327.Checked = Convert.ToBoolean(rdr["327"]);
                        CheckBox328.Checked = Convert.ToBoolean(rdr["328"]);
                        CheckBox329.Checked = Convert.ToBoolean(rdr["329"]);
                        TextBox330.Text = rdr["330"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox331.Checked = Convert.ToBoolean(rdr["331"]);
                        CheckBox332.Checked = Convert.ToBoolean(rdr["332"]);
                        CheckBox333.Checked = Convert.ToBoolean(rdr["333"]);
                        CheckBox334.Checked = Convert.ToBoolean(rdr["334"]);
                        TextBox335.Text = rdr["335"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox336.Checked = Convert.ToBoolean(rdr["336"]);
                        CheckBox337.Checked = Convert.ToBoolean(rdr["337"]);
                        CheckBox338.Checked = Convert.ToBoolean(rdr["338"]);
                        CheckBox339.Checked = Convert.ToBoolean(rdr["339"]);
                        TextBox340.Text = rdr["340"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox341.Checked = Convert.ToBoolean(rdr["341"]);
                        CheckBox342.Checked = Convert.ToBoolean(rdr["342"]);
                        CheckBox343.Checked = Convert.ToBoolean(rdr["343"]);
                        CheckBox344.Checked = Convert.ToBoolean(rdr["344"]);
                        TextBox345.Text = rdr["345"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox346.Checked = Convert.ToBoolean(rdr["346"]);
                        CheckBox347.Checked = Convert.ToBoolean(rdr["347"]);
                        CheckBox348.Checked = Convert.ToBoolean(rdr["348"]);
                        CheckBox349.Checked = Convert.ToBoolean(rdr["349"]);
                        TextBox350.Text = rdr["350"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox351.Checked = Convert.ToBoolean(rdr["351"]);
                        CheckBox352.Checked = Convert.ToBoolean(rdr["352"]);
                        CheckBox353.Checked = Convert.ToBoolean(rdr["353"]);
                        CheckBox354.Checked = Convert.ToBoolean(rdr["354"]);
                        TextBox355.Text = rdr["355"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        // set the Global variable to the current fields
                        SetStaticVariable();
                        Report.RunEditMode = true;
                    }
                    if (method.Equals("checkChanges"))
                    {
                        int flag = 0;
                        if (Report.ShiftId != rdr["ShiftId"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ShiftId";
                        }
                        if (Report.ShiftDate.ToString() != rdr["ShiftDate"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ShiftDate";
                        }
                        if (ReportCovidMarshallMr.GeneralComments != rdr["GeneralComments"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "GeneralComments";
                        }
                        if (ReportCovidMarshallMr.TextBox1 != rdr["1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox1";
                        }
                        if (ReportCovidMarshallMr.TextBox2 != rdr["2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox2";
                        }
                        if (ReportCovidMarshallMr.TextBox3 != rdr["3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox3";
                        }
                        if (ReportCovidMarshallMr.TextBox4 != rdr["4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox4";
                        }
                        if (ReportCovidMarshallMr.TextBox5 != rdr["5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox5";
                        }
                        if (ReportCovidMarshallMr.TextBox6 != rdr["6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox6";
                        }
                        if (ReportCovidMarshallMr.TextBox7 != rdr["7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox7";
                        }
                        if (ReportCovidMarshallMr.TextBox8 != rdr["8"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox8";
                        }
                        if (ReportCovidMarshallMr.TextBox9 != rdr["9"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox9";
                        }
                        if (ReportCovidMarshallMr.TextBox10 != rdr["10"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox10";
                        }
                        if (ReportCovidMarshallMr.TextBox11 != rdr["11"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox11";
                        }
                        if (ReportCovidMarshallMr.TextBox12 != rdr["12"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox12";
                        }
                        if (ReportCovidMarshallMr.TextBox13 != rdr["13"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox13";
                        }
                        if (ReportCovidMarshallMr.TextBox14 != rdr["14"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox14";
                        }
                        if (ReportCovidMarshallMr.TextBox15 != rdr["15"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox15";
                        }
                        if (ReportCovidMarshallMr.TextBox16 != rdr["16"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox16";
                        }
                        if (ReportCovidMarshallMr.TextBox17 != rdr["17"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox17";
                        }
                        if (ReportCovidMarshallMr.TextBox18 != rdr["18"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox18";
                        }
                        if (ReportCovidMarshallMr.TextBox19 != rdr["19"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox19";
                        }
                        if (ReportCovidMarshallMr.TextBox20 != rdr["20"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox20";
                        }
                        if (ReportCovidMarshallMr.TextBox21 != rdr["21"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox21";
                        }
                        if (ReportCovidMarshallMr.TextBox22 != rdr["22"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox22";
                        }
                        if (ReportCovidMarshallMr.TextBox23 != rdr["23"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox23";
                        }
                        if (ReportCovidMarshallMr.TextBox24 != rdr["24"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox24";
                        }
                        if (ReportCovidMarshallMr.TextBox25 != rdr["25"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox25";
                        }
                        if (ReportCovidMarshallMr.TextBox26 != rdr["26"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox26";
                        }
                        if (ReportCovidMarshallMr.TextBox27 != rdr["27"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox27";
                        }
                        if (ReportCovidMarshallMr.TextBox28 != rdr["28"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox28";
                        }
                        if (ReportCovidMarshallMr.TextBox29 != rdr["29"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox29";
                        }
                        if (ReportCovidMarshallMr.TextBox30 != rdr["30"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox30";
                        }
                        if (ReportCovidMarshallMr.TextBox31 != rdr["31"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox31";
                        }
                        if (ReportCovidMarshallMr.TextBox32 != rdr["32"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox32";
                        }
                        if (ReportCovidMarshallMr.TextBox33 != rdr["33"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox33";
                        }
                        if (ReportCovidMarshallMr.TextBox34 != rdr["34"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox34";
                        }
                        if (ReportCovidMarshallMr.TextBox35 != rdr["35"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox35";
                        }
                        if (ReportCovidMarshallMr.TextBox36 != rdr["36"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox36";
                        }
                        if (ReportCovidMarshallMr.TextBox37 != rdr["37"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox37";
                        }
                        if (ReportCovidMarshallMr.TextBox38 != rdr["38"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox38";
                        }
                        if (ReportCovidMarshallMr.TextBox39 != rdr["39"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox39";
                        }
                        if (ReportCovidMarshallMr.TextBox40 != rdr["40"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox40";
                        }
                        if (ReportCovidMarshallMr.TextBox41 != rdr["41"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox41";
                        }
                        if (ReportCovidMarshallMr.TextBox42 != rdr["42"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox42";
                        }
                        if (ReportCovidMarshallMr.TextBox43 != rdr["43"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox43";
                        }
                        if (ReportCovidMarshallMr.TextBox44 != rdr["44"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox44";
                        }
                        if (ReportCovidMarshallMr.TextBox45 != rdr["45"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox45";
                        }
                        if (ReportCovidMarshallMr.TextBox46 != rdr["46"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox46";
                        }
                        if (ReportCovidMarshallMr.TextBox47 != rdr["47"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox47";
                        }
                        if (ReportCovidMarshallMr.TextBox48 != rdr["48"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox48";
                        }
                        if (ReportCovidMarshallMr.TextBox49 != rdr["49"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox49";
                        }
                        if (ReportCovidMarshallMr.TextBox50 != rdr["50"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox50";
                        }
                        if (ReportCovidMarshallMr.TextBox51 != rdr["51"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox51";
                        }
                        if (ReportCovidMarshallMr.TextBox52 != rdr["52"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox52";
                        }
                        if (ReportCovidMarshallMr.TextBox53 != rdr["53"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox53";
                        }
                        if (ReportCovidMarshallMr.TextBox54 != rdr["54"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox54";
                        }
                        if (ReportCovidMarshallMr.TextBox55 != rdr["55"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox55";
                        }
                        if (ReportCovidMarshallMr.TextBox56 != rdr["56"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox56";
                        }
                        if (ReportCovidMarshallMr.TextBox57 != rdr["57"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox57";
                        }
                        if (ReportCovidMarshallMr.TextBox58 != rdr["58"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox58";
                        }
                        if (ReportCovidMarshallMr.TextBox59 != rdr["59"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox59";
                        }
                        if (ReportCovidMarshallMr.TextBox60 != rdr["60"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox60";
                        }
                        if (ReportCovidMarshallMr.TextBox61 != rdr["61"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox61";
                        }
                        if (ReportCovidMarshallMr.TextBox62 != rdr["62"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox62";
                        }
                        if (ReportCovidMarshallMr.TextBox63 != rdr["63"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox63";
                        }
                        if (ReportCovidMarshallMr.TextBox64 != rdr["64"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox64";
                        }
                        if (ReportCovidMarshallMr.TextBox65 != rdr["65"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox65";
                        }
                        if (ReportCovidMarshallMr.TextBox66 != rdr["66"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox66";
                        }
                        if (ReportCovidMarshallMr.TextBox67 != rdr["67"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox67";
                        }
                        if (ReportCovidMarshallMr.TextBox68 != rdr["68"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox68";
                        }
                        if (ReportCovidMarshallMr.TextBox69 != rdr["69"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox69";
                        }
                        if (ReportCovidMarshallMr.TextBox70 != rdr["70"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox70";
                        }
                        if (ReportCovidMarshallMr.TextBox71 != rdr["71"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox71";
                        }
                        if (ReportCovidMarshallMr.TextBox72 != rdr["72"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox72";
                        }
                        if (ReportCovidMarshallMr.TextBox73 != rdr["73"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox73";
                        }
                        if (ReportCovidMarshallMr.TextBox74 != rdr["74"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox74";
                        }
                        if (ReportCovidMarshallMr.TextBox75 != rdr["75"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox75";
                        }
                        if (ReportCovidMarshallMr.TextBox76 != rdr["76"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox76";
                        }
                        if (ReportCovidMarshallMr.TextBox77 != rdr["77"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox77";
                        }
                        if (ReportCovidMarshallMr.TextBox78 != rdr["78"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox78";
                        }
                        if (ReportCovidMarshallMr.TextBox79 != rdr["79"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox79";
                        }
                        if (ReportCovidMarshallMr.TextBox80 != rdr["80"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox80";
                        }
                        if (ReportCovidMarshallMr.TextBox81 != rdr["81"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox81";
                        }
                        if (ReportCovidMarshallMr.TextBox82 != rdr["82"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox82";
                        }
                        if (ReportCovidMarshallMr.TextBox83 != rdr["83"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox83";
                        }
                        if (ReportCovidMarshallMr.TextBox84 != rdr["84"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox84";
                        }
                        if (ReportCovidMarshallMr.TextBox85 != rdr["85"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox85";
                        }
                        if (ReportCovidMarshallMr.TextBox86 != rdr["86"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox86";
                        }
                        if (ReportCovidMarshallMr.TextBox87 != rdr["87"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox87";
                        }
                        if (ReportCovidMarshallMr.TextBox88 != rdr["88"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox88";
                        }
                        if (ReportCovidMarshallMr.TextBox89 != rdr["89"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox89";
                        }
                        if (ReportCovidMarshallMr.TextBox90 != rdr["90"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox90";
                        }
                        if (ReportCovidMarshallMr.TextBox91 != rdr["91"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox91";
                        }
                        if (ReportCovidMarshallMr.TextBox92 != rdr["92"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox92";
                        }
                        if (ReportCovidMarshallMr.TextBox93 != rdr["93"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox93";
                        }
                        if (ReportCovidMarshallMr.TextBox94 != rdr["94"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox94";
                        }
                        if (ReportCovidMarshallMr.TextBox95 != rdr["95"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox95";
                        }
                        if (ReportCovidMarshallMr.TextBox96 != rdr["96"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox96";
                        }
                        if (ReportCovidMarshallMr.TextBox97 != rdr["97"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox97";
                        }
                        if (ReportCovidMarshallMr.TextBox98 != rdr["98"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox98";
                        }
                        if (ReportCovidMarshallMr.TextBox99 != rdr["99"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox99";
                        }
                        if (ReportCovidMarshallMr.TextBox100 != rdr["100"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox100";
                        }
                        if (ReportCovidMarshallMr.TextBox101 != rdr["101"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox101";
                        }
                        if (ReportCovidMarshallMr.TextBox102 != rdr["102"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox102";
                        }
                        if (ReportCovidMarshallMr.TextBox103 != rdr["103"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox103";
                        }
                        if (ReportCovidMarshallMr.TextBox104 != rdr["104"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox104";
                        }
                        if (ReportCovidMarshallMr.TextBox105 != rdr["105"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox105";
                        }
                        if (ReportCovidMarshallMr.TextBox106 != rdr["106"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox106";
                        }
                        if (ReportCovidMarshallMr.TextBox107 != rdr["107"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox107";
                        }
                        if (ReportCovidMarshallMr.TextBox108 != rdr["108"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox108";
                        }
                        if (ReportCovidMarshallMr.TextBox109 != rdr["109"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox109";
                        }
                        if (ReportCovidMarshallMr.TextBox110 != rdr["110"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox110";
                        }
                        if (ReportCovidMarshallMr.TextBox111 != rdr["111"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox111";
                        }
                        if (ReportCovidMarshallMr.TextBox112 != rdr["112"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox112";
                        }
                        if (ReportCovidMarshallMr.TextBox113 != rdr["113"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox113";
                        }
                        if (ReportCovidMarshallMr.TextBox114 != rdr["114"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox114";
                        }
                        if (ReportCovidMarshallMr.TextBox115 != rdr["115"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox115";
                        }
                        if (ReportCovidMarshallMr.TextBox116 != rdr["116"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox116";
                        }
                        if (ReportCovidMarshallMr.TextBox117 != rdr["117"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox117";
                        }
                        if (ReportCovidMarshallMr.TextBox118 != rdr["118"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox118";
                        }
                        if (ReportCovidMarshallMr.TextBox119 != rdr["119"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox119";
                        }
                        if (ReportCovidMarshallMr.TextBox120 != rdr["120"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox120";
                        }
                        if (ReportCovidMarshallMr.TextBox121 != rdr["121"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox121";
                        }
                        if (ReportCovidMarshallMr.TextBox122 != rdr["122"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox122";
                        }
                        if (ReportCovidMarshallMr.TextBox123 != rdr["123"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox123";
                        }
                        if (ReportCovidMarshallMr.TextBox124 != rdr["124"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox124";
                        }
                        if (ReportCovidMarshallMr.TextBox125 != rdr["125"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox125";
                        }
                        if (ReportCovidMarshallMr.TextBox126 != rdr["126"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox126";
                        }
                        if (ReportCovidMarshallMr.TextBox127 != rdr["127"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox127";
                        }
                        if (ReportCovidMarshallMr.TextBox128 != rdr["128"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox128";
                        }
                        if (ReportCovidMarshallMr.TextBox129 != rdr["129"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox129";
                        }
                        if (ReportCovidMarshallMr.TextBox130 != rdr["130"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox130";
                        }
                        if (ReportCovidMarshallMr.TextBox131 != rdr["131"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox131";
                        }
                        if (ReportCovidMarshallMr.TextBox132 != rdr["132"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox132";
                        }
                        if (ReportCovidMarshallMr.TextBox133 != rdr["133"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox133";
                        }
                        if (ReportCovidMarshallMr.TextBox134 != rdr["134"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox134";
                        }
                        if (ReportCovidMarshallMr.TextBox135 != rdr["135"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox135";
                        }
                        if (ReportCovidMarshallMr.TextBox136 != rdr["136"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox136";
                        }
                        if (ReportCovidMarshallMr.TextBox137 != rdr["137"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox137";
                        }
                        if (ReportCovidMarshallMr.TextBox138 != rdr["138"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox138";
                        }
                        if (ReportCovidMarshallMr.TextBox139 != rdr["139"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox139";
                        }
                        if (ReportCovidMarshallMr.TextBox140 != rdr["140"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox140";
                        }
                        if (ReportCovidMarshallMr.TextBox141 != rdr["141"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox141";
                        }
                        if (ReportCovidMarshallMr.TextBox142 != rdr["142"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox142";
                        }
                        if (ReportCovidMarshallMr.TextBox143 != rdr["143"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox143";
                        }
                        if (ReportCovidMarshallMr.TextBox144 != rdr["144"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox144";
                        }
                        if (ReportCovidMarshallMr.TextBox145 != rdr["145"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox145";
                        }
                        if (ReportCovidMarshallMr.TextBox146 != rdr["146"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox146";
                        }
                        if (ReportCovidMarshallMr.TextBox147 != rdr["147"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox147";
                        }
                        if (ReportCovidMarshallMr.TextBox148 != rdr["148"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox148";
                        }
                        if (ReportCovidMarshallMr.TextBox149 != rdr["149"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox149";
                        }
                        if (ReportCovidMarshallMr.TextBox150 != rdr["150"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox150";
                        }
                        if (ReportCovidMarshallMr.TextBox151 != rdr["151"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox151";
                        }
                        if (ReportCovidMarshallMr.TextBox152 != rdr["152"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox152";
                        }
                        if (ReportCovidMarshallMr.TextBox153 != rdr["153"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox153";
                        }
                        if (ReportCovidMarshallMr.TextBox154 != rdr["154"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox154";
                        }
                        if (ReportCovidMarshallMr.TextBox155 != rdr["155"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox155";
                        }
                        if (ReportCovidMarshallMr.TextBox156 != rdr["156"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox156";
                        }
                        if (ReportCovidMarshallMr.TextBox157 != rdr["157"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox157";
                        }
                        if (ReportCovidMarshallMr.TextBox158 != rdr["158"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox158";
                        }
                        if (ReportCovidMarshallMr.TextBox159 != rdr["159"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox159";
                        }
                        if (ReportCovidMarshallMr.TextBox160 != rdr["160"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox160";
                        }
                        if (ReportCovidMarshallMr.TextBox161 != rdr["161"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox161";
                        }
                        if (ReportCovidMarshallMr.TextBox162 != rdr["162"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox162";
                        }
                        if (ReportCovidMarshallMr.TextBox163 != rdr["163"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox163";
                        }
                        if (ReportCovidMarshallMr.TextBox164 != rdr["164"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox164";
                        }
                        if (ReportCovidMarshallMr.TextBox165 != rdr["165"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox165";
                        }
                        if (ReportCovidMarshallMr.TextBox166 != rdr["166"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox166";
                        }
                        if (ReportCovidMarshallMr.TextBox167 != rdr["167"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox167";
                        }
                        if (ReportCovidMarshallMr.TextBox168 != rdr["168"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox168";
                        }
                        if (ReportCovidMarshallMr.TextBox169 != rdr["169"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox169";
                        }
                        if (ReportCovidMarshallMr.TextBox170 != rdr["170"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox170";
                        }
                        if (ReportCovidMarshallMr.TextBox171 != rdr["171"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox171";
                        }
                        if (ReportCovidMarshallMr.TextBox172 != rdr["172"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox172";
                        }
                        if (ReportCovidMarshallMr.TextBox173 != rdr["173"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox173";
                        }
                        if (ReportCovidMarshallMr.TextBox174 != rdr["174"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox174";
                        }
                        if (ReportCovidMarshallMr.TextBox175 != rdr["175"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox175";
                        }
                        if (ReportCovidMarshallMr.TextBox176 != rdr["176"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox176";
                        }
                        if (ReportCovidMarshallMr.TextBox177 != rdr["177"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox177";
                        }
                        if (ReportCovidMarshallMr.TextBox178 != rdr["178"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox178";
                        }
                        if (ReportCovidMarshallMr.TextBox179 != rdr["179"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox179";
                        }
                        if (ReportCovidMarshallMr.TextBox180 != rdr["180"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox180";
                        }
                        if (ReportCovidMarshallMr.TextBox181 != rdr["181"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox181";
                        }
                        if (ReportCovidMarshallMr.TextBox182 != rdr["182"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox182";
                        }
                        if (ReportCovidMarshallMr.TextBox183 != rdr["183"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox183";
                        }
                        if (ReportCovidMarshallMr.TextBox184 != rdr["184"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox184";
                        }
                        if (ReportCovidMarshallMr.TextBox185 != rdr["185"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox185";
                        }
                        if (ReportCovidMarshallMr.TextBox186 != rdr["186"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox186";
                        }
                        if (ReportCovidMarshallMr.TextBox187 != rdr["187"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox187";
                        }
                        if (ReportCovidMarshallMr.TextBox188 != rdr["188"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox188";
                        }
                        if (ReportCovidMarshallMr.TextBox189 != rdr["189"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox189";
                        }
                        if (ReportCovidMarshallMr.TextBox190 != rdr["190"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox190";
                        }
                        if (ReportCovidMarshallMr.TextBox191 != rdr["191"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox191";
                        }
                        if (ReportCovidMarshallMr.TextBox192 != rdr["192"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox192";
                        }
                        if (ReportCovidMarshallMr.TextBox193 != rdr["193"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox193";
                        }
                        if (ReportCovidMarshallMr.TextBox194 != rdr["194"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox194";
                        }
                        if (ReportCovidMarshallMr.TextBox195 != rdr["195"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox195";
                        }
                        if (ReportCovidMarshallMr.TextBox196 != rdr["196"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox196";
                        }
                        if (ReportCovidMarshallMr.TextBox197 != rdr["197"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox197";
                        }
                        if (ReportCovidMarshallMr.TextBox198 != rdr["198"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox198";
                        }
                        if (ReportCovidMarshallMr.TextBox199 != rdr["199"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox199";
                        }
                        if (ReportCovidMarshallMr.TextBox200 != rdr["200"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox200";
                        }
                        if (ReportCovidMarshallMr.TextBox201 != rdr["201"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox201";
                        }
                        if (ReportCovidMarshallMr.TextBox202 != rdr["202"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox202";
                        }
                        if (ReportCovidMarshallMr.TextBox203 != rdr["203"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox203";
                        }
                        if (ReportCovidMarshallMr.TextBox204 != rdr["204"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox204";
                        }
                        if (ReportCovidMarshallMr.TextBox205 != rdr["205"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox205";
                        }
                        if (ReportCovidMarshallMr.TextBox206 != rdr["206"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox206";
                        }
                        if (ReportCovidMarshallMr.TextBox207 != rdr["207"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox207";
                        }
                        if (ReportCovidMarshallMr.TextBox208 != rdr["208"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox208";
                        }
                        if (ReportCovidMarshallMr.TextBox209 != rdr["209"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox209";
                        }
                        if (ReportCovidMarshallMr.TextBox210 != rdr["210"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox210";
                        }
                        if (ReportCovidMarshallMr.TextBox211 != rdr["211"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox211";
                        }
                        if (ReportCovidMarshallMr.TextBox212 != rdr["212"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox212";
                        }
                        if (ReportCovidMarshallMr.TextBox213 != rdr["213"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox213";
                        }
                        if (ReportCovidMarshallMr.TextBox214 != rdr["214"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox214";
                        }
                        if (ReportCovidMarshallMr.TextBox215 != rdr["215"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox215";
                        }
                        if (ReportCovidMarshallMr.TextBox216 != rdr["216"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox216";
                        }
                        if (ReportCovidMarshallMr.TextBox217 != rdr["217"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox217";
                        }
                        if (ReportCovidMarshallMr.TextBox218 != rdr["218"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox218";
                        }
                        if (ReportCovidMarshallMr.TextBox219 != rdr["219"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox219";
                        }
                        if (ReportCovidMarshallMr.TextBox220 != rdr["220"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox220";
                        }
                        if (ReportCovidMarshallMr.TextBox221 != rdr["221"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox221";
                        }
                        if (ReportCovidMarshallMr.TextBox222 != rdr["222"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox222";
                        }
                        if (ReportCovidMarshallMr.TextBox223 != rdr["223"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox223";
                        }
                        if (ReportCovidMarshallMr.TextBox224 != rdr["224"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox224";
                        }
                        if (ReportCovidMarshallMr.TextBox225 != rdr["225"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox225";
                        }
                        if (ReportCovidMarshallMr.TextBox226 != rdr["226"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox226";
                        }
                        if (ReportCovidMarshallMr.TextBox227 != rdr["227"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox227";
                        }
                        if (ReportCovidMarshallMr.TextBox228 != rdr["228"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox228";
                        }
                        if (ReportCovidMarshallMr.TextBox229 != rdr["229"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox229";
                        }
                        if (ReportCovidMarshallMr.TextBox230 != rdr["230"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox230";
                        }
                        if (ReportCovidMarshallMr.TextBox231 != rdr["231"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox231";
                        }
                        if (ReportCovidMarshallMr.TextBox232 != rdr["232"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox232";
                        }
                        if (ReportCovidMarshallMr.TextBox233 != rdr["233"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox233";
                        }
                        if (ReportCovidMarshallMr.TextBox234 != rdr["234"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox234";
                        }
                        if (ReportCovidMarshallMr.TextBox235 != rdr["235"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox235";
                        }
                        if (ReportCovidMarshallMr.TextBox236 != rdr["236"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox236";
                        }
                        if (ReportCovidMarshallMr.TextBox237 != rdr["237"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox237";
                        }
                        if (ReportCovidMarshallMr.TextBox238 != rdr["238"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox238";
                        }
                        if (ReportCovidMarshallMr.TextBox239 != rdr["239"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox239";
                        }
                        if (ReportCovidMarshallMr.TextBox240 != rdr["240"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox240";
                        }
                        if (ReportCovidMarshallMr.TextBox241 != rdr["241"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox241";
                        }
                        if (ReportCovidMarshallMr.TextBox242 != rdr["242"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox242";
                        }
                        if (ReportCovidMarshallMr.TextBox243 != rdr["243"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox243";
                        }
                        if (ReportCovidMarshallMr.TextBox244 != rdr["244"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox244";
                        }
                        if (ReportCovidMarshallMr.TextBox245 != rdr["245"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox245";
                        }
                        if (ReportCovidMarshallMr.TextBox246 != rdr["246"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox246";
                        }
                        if (ReportCovidMarshallMr.TextBox247 != rdr["247"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox247";
                        }
                        if (ReportCovidMarshallMr.TextBox248 != rdr["248"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox248";
                        }
                        if (ReportCovidMarshallMr.TextBox249 != rdr["249"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox249";
                        }
                        if (ReportCovidMarshallMr.TextBox250 != rdr["250"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox250";
                        }
                        if (ReportCovidMarshallMr.TextBox251 != rdr["251"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox251";
                        }
                        if (ReportCovidMarshallMr.TextBox252 != rdr["252"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox252";
                        }
                        if (ReportCovidMarshallMr.TextBox253 != rdr["253"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox253";
                        }
                        if (ReportCovidMarshallMr.TextBox254 != rdr["254"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox254";
                        }
                        if (ReportCovidMarshallMr.TextBox255 != rdr["255"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox255";
                        }
                        if (ReportCovidMarshallMr.TextBox256 != rdr["256"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox256";
                        }
                        if (ReportCovidMarshallMr.TextBox257 != rdr["257"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox257";
                        }
                        if (ReportCovidMarshallMr.TextBox258 != rdr["258"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox258";
                        }
                        if (ReportCovidMarshallMr.TextBox259 != rdr["259"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox259";
                        }
                        if (ReportCovidMarshallMr.TextBox260 != rdr["260"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox260";
                        }
                        if (ReportCovidMarshallMr.TextBox261 != rdr["261"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox261";
                        }
                        if (ReportCovidMarshallMr.TextBox262 != rdr["262"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox262";
                        }
                        if (ReportCovidMarshallMr.TextBox263 != rdr["263"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox263";
                        }
                        if (ReportCovidMarshallMr.TextBox264 != rdr["264"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox264";
                        }
                        if (ReportCovidMarshallMr.TextBox265 != rdr["265"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox265";
                        }
                        if (ReportCovidMarshallMr.TextBox266 != rdr["266"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox266";
                        }
                        if (ReportCovidMarshallMr.TextBox267 != rdr["267"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox267";
                        }
                        if (ReportCovidMarshallMr.TextBox268 != rdr["268"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox268";
                        }
                        if (ReportCovidMarshallMr.TextBox269 != rdr["269"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox269";
                        }
                        if (ReportCovidMarshallMr.TextBox270 != rdr["270"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox270";
                        }
                        if (ReportCovidMarshallMr.TextBox271 != rdr["271"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox271";
                        }
                        if (ReportCovidMarshallMr.TextBox272 != rdr["272"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox272";
                        }
                        if (ReportCovidMarshallMr.TextBox273 != rdr["273"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox273";
                        }
                        if (ReportCovidMarshallMr.TextBox274 != rdr["274"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox274";
                        }
                        if (ReportCovidMarshallMr.TextBox275 != rdr["275"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox275";
                        }
                        if (ReportCovidMarshallMr.TextBox276 != rdr["276"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox276";
                        }
                        if (ReportCovidMarshallMr.TextBox277 != rdr["277"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox277";
                        }
                        if (ReportCovidMarshallMr.TextBox278 != rdr["278"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox278";
                        }
                        if (ReportCovidMarshallMr.TextBox279 != rdr["279"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox279";
                        }
                        if (ReportCovidMarshallMr.TextBox280 != rdr["280"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox280";
                        }
                        if (ReportCovidMarshallMr.TextBox281 != rdr["281"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox281";
                        }
                        if (ReportCovidMarshallMr.TextBox282 != rdr["282"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox282";
                        }
                        if (ReportCovidMarshallMr.TextBox283 != rdr["283"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox283";
                        }
                        if (ReportCovidMarshallMr.TextBox284 != rdr["284"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox284";
                        }
                        if (ReportCovidMarshallMr.TextBox285 != rdr["285"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox285";
                        }
                        if (ReportCovidMarshallMr.TextBox286 != rdr["286"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox286";
                        }
                        if (ReportCovidMarshallMr.TextBox287 != rdr["287"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox287";
                        }
                        if (ReportCovidMarshallMr.TextBox288 != rdr["288"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox288";
                        }
                        if (ReportCovidMarshallMr.TextBox289 != rdr["289"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox289";
                        }
                        if (ReportCovidMarshallMr.TextBox290 != rdr["290"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox290";
                        }
                        if (ReportCovidMarshallMr.TextBox291 != rdr["291"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox291";
                        }
                        if (ReportCovidMarshallMr.TextBox292 != rdr["292"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox292";
                        }
                        if (ReportCovidMarshallMr.TextBox293 != rdr["293"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox293";
                        }
                        if (ReportCovidMarshallMr.TextBox294 != rdr["294"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox294";
                        }
                        if (ReportCovidMarshallMr.TextBox295 != rdr["295"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox295";
                        }
                        if (ReportCovidMarshallMr.TextBox296 != rdr["296"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox296";
                        }
                        if (ReportCovidMarshallMr.TextBox297 != rdr["297"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox297";
                        }
                        if (ReportCovidMarshallMr.TextBox298 != rdr["298"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox298";
                        }
                        if (ReportCovidMarshallMr.TextBox299 != rdr["299"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox299";
                        }
                        if (ReportCovidMarshallMr.TextBox300 != rdr["300"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox300";
                        }
                        if (ReportCovidMarshallMr.TextBox301 != rdr["301"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox301";
                        }
                        if (ReportCovidMarshallMr.TextBox302 != rdr["302"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox302";
                        }
                        if (ReportCovidMarshallMr.TextBox303 != rdr["303"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox303";
                        }
                        if (ReportCovidMarshallMr.TextBox304 != rdr["304"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox304";
                        }
                        if (ReportCovidMarshallMr.TextBox305 != rdr["305"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox305";
                        }
                        if (ReportCovidMarshallMr.TextBox306 != rdr["306"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox306";
                        }
                        if (ReportCovidMarshallMr.CheckBox307.ToString() != Convert.ToBoolean(rdr["307"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox307";
                        }
                        if (ReportCovidMarshallMr.CheckBox308.ToString() != Convert.ToBoolean(rdr["308"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox308";
                        }
                        if (ReportCovidMarshallMr.CheckBox309.ToString() != Convert.ToBoolean(rdr["309"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox309";
                        }
                        if (ReportCovidMarshallMr.CheckBox310.ToString() != Convert.ToBoolean(rdr["310"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox310";
                        }
                        if (ReportCovidMarshallMr.CheckBox311.ToString() != Convert.ToBoolean(rdr["311"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox311";
                        }
                        if (ReportCovidMarshallMr.CheckBox312.ToString() != Convert.ToBoolean(rdr["312"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox312";
                        }
                        if (ReportCovidMarshallMr.CheckBox313.ToString() != Convert.ToBoolean(rdr["313"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox313";
                        }
                        if (ReportCovidMarshallMr.CheckBox314.ToString() != Convert.ToBoolean(rdr["314"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox314";
                        }
                        if (ReportCovidMarshallMr.CheckBox315.ToString() != Convert.ToBoolean(rdr["315"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox315";
                        }
                        if (ReportCovidMarshallMr.CheckBox316.ToString() != Convert.ToBoolean(rdr["316"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox316";
                        }
                        if (ReportCovidMarshallMr.CheckBox317.ToString() != Convert.ToBoolean(rdr["317"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox317";
                        }
                        if (ReportCovidMarshallMr.CheckBox318.ToString() != Convert.ToBoolean(rdr["318"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox318";
                        }
                        if (ReportCovidMarshallMr.CheckBox319.ToString() != Convert.ToBoolean(rdr["319"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox319";
                        }
                        if (ReportCovidMarshallMr.CheckBox320.ToString() != Convert.ToBoolean(rdr["320"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox320";
                        }
                        if (ReportCovidMarshallMr.CheckBox321.ToString() != Convert.ToBoolean(rdr["321"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox321";
                        }
                        if (ReportCovidMarshallMr.CheckBox322.ToString() != Convert.ToBoolean(rdr["322"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox322";
                        }
                        if (ReportCovidMarshallMr.CheckBox323.ToString() != Convert.ToBoolean(rdr["323"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox323";
                        }
                        if (ReportCovidMarshallMr.CheckBox324.ToString() != Convert.ToBoolean(rdr["324"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox324";
                        }
                        if (ReportCovidMarshallMr.TextBox325 != rdr["325"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox325";
                        }
                        if (ReportCovidMarshallMr.CheckBox326.ToString() != Convert.ToBoolean(rdr["326"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox326";
                        }
                        if (ReportCovidMarshallMr.CheckBox327.ToString() != Convert.ToBoolean(rdr["327"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox327";
                        }
                        if (ReportCovidMarshallMr.CheckBox328.ToString() != Convert.ToBoolean(rdr["328"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox328";
                        }
                        if (ReportCovidMarshallMr.CheckBox329.ToString() != Convert.ToBoolean(rdr["329"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox329";
                        }
                        if (ReportCovidMarshallMr.TextBox330 != rdr["330"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox330";
                        }
                        if (ReportCovidMarshallMr.CheckBox331.ToString() != Convert.ToBoolean(rdr["331"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox331";
                        }
                        if (ReportCovidMarshallMr.CheckBox332.ToString() != Convert.ToBoolean(rdr["332"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox332";
                        }
                        if (ReportCovidMarshallMr.CheckBox333.ToString() != Convert.ToBoolean(rdr["333"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox333";
                        }
                        if (ReportCovidMarshallMr.CheckBox334.ToString() != Convert.ToBoolean(rdr["334"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox334";
                        }
                        if (ReportCovidMarshallMr.TextBox335 != rdr["335"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox335";
                        }
                        if (ReportCovidMarshallMr.CheckBox336.ToString() != Convert.ToBoolean(rdr["336"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox336";
                        }
                        if (ReportCovidMarshallMr.CheckBox337.ToString() != Convert.ToBoolean(rdr["337"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox337";
                        }
                        if (ReportCovidMarshallMr.CheckBox338.ToString() != Convert.ToBoolean(rdr["338"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox338";
                        }
                        if (ReportCovidMarshallMr.CheckBox339.ToString() != Convert.ToBoolean(rdr["339"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox339";
                        }
                        if (ReportCovidMarshallMr.TextBox340 != rdr["340"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox340";
                        }
                        if (ReportCovidMarshallMr.CheckBox341.ToString() != Convert.ToBoolean(rdr["341"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox341";
                        }
                        if (ReportCovidMarshallMr.CheckBox342.ToString() != Convert.ToBoolean(rdr["342"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox342";
                        }
                        if (ReportCovidMarshallMr.CheckBox343.ToString() != Convert.ToBoolean(rdr["343"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox343";
                        }
                        if (ReportCovidMarshallMr.CheckBox344.ToString() != Convert.ToBoolean(rdr["344"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox344";
                        }
                        if (ReportCovidMarshallMr.TextBox345 != rdr["345"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox345";
                        }
                        if (ReportCovidMarshallMr.CheckBox346.ToString() != Convert.ToBoolean(rdr["346"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox346";
                        }
                        if (ReportCovidMarshallMr.CheckBox347.ToString() != Convert.ToBoolean(rdr["347"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox347";
                        }
                        if (ReportCovidMarshallMr.CheckBox348.ToString() != Convert.ToBoolean(rdr["348"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox348";
                        }
                        if (ReportCovidMarshallMr.CheckBox349.ToString() != Convert.ToBoolean(rdr["349"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox349";
                        }
                        if (ReportCovidMarshallMr.TextBox350 != rdr["350"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox350";
                        }
                        if (ReportCovidMarshallMr.CheckBox351.ToString() != Convert.ToBoolean(rdr["351"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox351";
                        }
                        if (ReportCovidMarshallMr.CheckBox352.ToString() != Convert.ToBoolean(rdr["352"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox352";
                        }
                        if (ReportCovidMarshallMr.CheckBox353.ToString() != Convert.ToBoolean(rdr["353"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox353";
                        }
                        if (ReportCovidMarshallMr.CheckBox354.ToString() != Convert.ToBoolean(rdr["354"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox354";
                        }
                        if (ReportCovidMarshallMr.TextBox355 != rdr["355"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox355";
                        }

                        if (flag == 0)
                        {
                            Report.HasChange = false;
                            Report.WhereChangeHappened = "";
                        }
                        return;
                    }
                }
            }
        }
        catch (Exception er)
        {
            showAlert(er.Message);
        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }
            if (con != null)
            {
                con.Close();
            }
        }
    }

    protected void showAlert(string message)
    {
        // display a message box
        message = "alert(\"" + message + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", message, true);
    }

    protected void TextChanged_TextChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void CheckChanged_CheckedChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void getChanges()
    {
        int result;
        DateTime temp;
        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        Report.ErrorMessage = "";
        Report.HasErrorMessage = false;

        // General Incident Report Form
        if (ddlShift.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";
            ddlShift.Focus();
            Report.HasErrorMessage = true;
        }
        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            Report.HasErrorMessage = true;
        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            Report.HasErrorMessage = true;
        }
        else
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                Report.HasErrorMessage = true;
            }
        }

        checkTexboxes();

        Report.RunEditMode = true;
        Report.ShiftId = ddlShift.SelectedItem.Value;
        if (Report.HasErrorMessage == false)
        {
            Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
            Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
        }
        SetStaticVariable();
        readFiles(Report.ActiveReport, "checkChanges");
    }

    protected void checkTexboxes()
    {
        int parsedValue;
        if (!int.TryParse(TextBox1.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox1.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox2.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox2.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox3.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox3.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox4.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox4.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox5.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox5.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox6.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox6.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox7.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox7.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox8.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox8.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox9.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox9.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox10.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox10.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox11.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox11.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox12.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox12.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox13.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox13.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox14.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox14.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox15.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox15.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox16.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox16.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox17.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox17.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox18.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox18.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox19.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox19.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox20.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox110.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox21.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox21.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox22.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox22.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox23.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox23.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox24.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox24.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox25.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox25.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox26.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox26.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox27.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox27.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox28.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox28.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox29.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox29.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox30.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox30.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox31.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox31.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox32.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox32.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox33.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox33.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox34.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox34.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox35.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox35.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox36.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox36.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox37.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox37.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox38.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox38.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox39.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox39.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox40.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox40.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox41.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox41.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox42.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox42.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox43.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox43.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox44.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox44.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox45.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox45.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox46.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox46.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox47.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox47.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox48.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox48.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox49.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox49.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox50.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox50.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox51.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox51.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox52.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox52.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox53.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox53.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox54.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox54.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox55.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox55.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox56.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox56.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox57.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox57.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox58.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox58.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox59.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox59.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox60.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox60.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox61.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox61.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox62.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox62.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox63.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox63.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox64.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox64.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox65.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox65.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox66.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox66.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox67.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox67.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox68.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox68.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox69.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox69.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox70.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox70.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox71.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox71.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox72.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox72.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox73.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox73.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox74.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox74.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox75.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox75.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox76.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox76.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox77.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox77.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox78.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox78.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox79.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox79.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox80.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox80.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox81.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox81.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox82.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox82.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox83.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox83.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox84.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox84.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox85.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox85.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox86.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox86.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox87.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox87.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox88.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox88.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox89.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox89.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox90.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox90.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox91.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox91.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox92.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox92.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox93.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox93.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox94.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox94.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox95.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox95.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox96.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox96.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox97.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox97.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox98.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox98.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox99.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox99.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox100.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox100.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox101.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox101.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox102.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox102.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox103.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox103.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox104.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox104.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox105.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox105.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox106.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox106.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox107.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox107.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox108.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox108.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox109.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox109.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox110.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox110.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox111.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox111.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox112.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox112.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox113.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox113.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox114.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox114.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox115.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox115.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox116.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox116.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox117.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox117.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox118.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox118.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox119.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox119.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox120.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox120.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox121.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox121.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox122.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox122.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox123.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox123.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox124.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox124.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox125.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox125.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox126.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox126.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox127.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox127.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox128.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox128.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox129.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox129.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox130.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox130.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox131.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox131.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox132.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox132.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox133.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox133.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox134.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox134.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox135.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox135.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox136.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox136.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox137.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox137.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox138.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox138.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox139.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox139.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox140.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox140.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox141.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox141.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox142.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox142.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox143.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox143.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox144.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox144.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox145.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox145.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox146.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox146.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox147.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox147.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox148.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox148.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox149.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox149.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox150.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox150.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox151.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox151.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox152.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox152.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox153.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox153.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox154.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox154.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox155.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox155.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox156.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox156.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox157.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox157.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox158.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox158.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox159.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox159.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox160.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox160.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox161.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox161.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox162.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox162.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox163.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox163.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox164.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox164.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox165.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox165.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox166.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox166.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox167.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox167.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox168.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox168.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox169.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox169.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox170.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox170.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox171.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox171.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox172.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox172.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox173.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox173.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox174.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox174.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox175.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox175.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox176.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox176.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox177.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox177.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox178.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox178.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox179.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox179.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox180.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox180.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox181.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox181.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox182.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox182.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox183.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox183.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox184.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox184.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox185.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox185.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox186.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox186.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox187.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox187.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox188.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox188.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox189.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox189.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox190.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox190.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox191.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox191.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox192.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox192.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox193.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox193.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox194.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox194.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox195.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox195.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox196.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox196.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox197.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox197.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox198.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox198.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox199.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox199.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox200.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox200.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox201.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox201.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox202.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox202.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox203.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox203.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox204.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox204.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox205.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox205.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox206.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox206.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox207.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox207.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox208.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox208.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox209.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox209.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox210.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox210.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox211.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox211.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox212.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox212.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox213.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox213.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox214.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox214.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox215.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox215.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox216.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox216.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox217.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox217.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox218.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox218.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox219.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox219.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox220.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox220.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox221.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox221.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox222.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox222.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox223.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox223.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox224.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox224.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox225.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox225.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox226.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox226.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox227.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox227.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox228.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox228.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox229.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox229.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox230.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox230.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox231.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox231.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox232.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox232.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox233.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox233.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox234.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox234.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox235.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox235.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox236.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox236.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox237.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox237.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox238.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox238.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox239.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox239.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox240.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox240.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox241.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox241.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox242.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox242.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox243.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox243.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox244.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox244.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox245.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox245.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox246.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox246.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox247.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox247.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox248.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox248.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox249.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox249.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox250.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox250.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox251.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox251.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox252.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox252.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox253.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox253.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox254.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox254.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox255.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox255.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox256.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox256.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox257.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox257.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox258.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox258.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox259.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox259.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox260.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox260.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox261.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox261.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox262.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox262.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox263.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox263.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox264.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox264.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox265.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox265.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox266.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox266.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox267.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox267.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox268.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox268.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox269.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox269.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox270.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox270.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox271.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox271.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox272.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox272.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox273.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox273.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox274.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox274.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox275.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox275.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox276.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox276.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox277.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox277.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox278.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox278.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox279.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox279.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox280.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox280.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox281.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox281.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox282.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox282.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox283.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox283.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox284.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox284.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox285.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox285.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox286.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox286.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox287.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox287.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox288.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox288.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox289.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox289.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox290.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox290.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox291.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox291.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox292.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox292.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox293.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox293.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox294.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox294.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox295.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox295.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox296.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox296.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox297.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox297.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox298.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox298.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox299.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox299.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox300.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox300.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox301.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox301.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox302.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox302.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox303.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox303.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox304.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox304.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox305.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox305.Focus();
            Report.HasErrorMessage = true;
        }

        if (!int.TryParse(TextBox306.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox306.Focus();
            Report.HasErrorMessage = true;
        }
    }

    protected void SetStaticVariable()
    {
        ReportCovidMarshallMr.GeneralComments = txtGeneralComments.Text.Replace("\n", "<br />");
        ReportCovidMarshallMr.TextBox1 = TextBox1.Text;
        ReportCovidMarshallMr.TextBox2 = TextBox2.Text;
        ReportCovidMarshallMr.TextBox3 = TextBox3.Text;
        ReportCovidMarshallMr.TextBox4 = TextBox4.Text;
        ReportCovidMarshallMr.TextBox5 = TextBox5.Text;
        ReportCovidMarshallMr.TextBox6 = TextBox6.Text;
        ReportCovidMarshallMr.TextBox7 = TextBox7.Text;
        ReportCovidMarshallMr.TextBox8 = TextBox8.Text;
        ReportCovidMarshallMr.TextBox9 = TextBox9.Text;
        ReportCovidMarshallMr.TextBox10 = TextBox10.Text;
        ReportCovidMarshallMr.TextBox11 = TextBox11.Text;
        ReportCovidMarshallMr.TextBox12 = TextBox12.Text;
        ReportCovidMarshallMr.TextBox13 = TextBox13.Text;
        ReportCovidMarshallMr.TextBox14 = TextBox14.Text;
        ReportCovidMarshallMr.TextBox15 = TextBox15.Text;
        ReportCovidMarshallMr.TextBox16 = TextBox16.Text;
        ReportCovidMarshallMr.TextBox17 = TextBox17.Text;
        ReportCovidMarshallMr.TextBox18 = TextBox18.Text;
        ReportCovidMarshallMr.TextBox19 = TextBox19.Text;
        ReportCovidMarshallMr.TextBox20 = TextBox20.Text;
        ReportCovidMarshallMr.TextBox21 = TextBox21.Text;
        ReportCovidMarshallMr.TextBox22 = TextBox22.Text;
        ReportCovidMarshallMr.TextBox23 = TextBox23.Text;
        ReportCovidMarshallMr.TextBox24 = TextBox24.Text;
        ReportCovidMarshallMr.TextBox25 = TextBox25.Text;
        ReportCovidMarshallMr.TextBox26 = TextBox26.Text;
        ReportCovidMarshallMr.TextBox27 = TextBox27.Text;
        ReportCovidMarshallMr.TextBox28 = TextBox28.Text;
        ReportCovidMarshallMr.TextBox29 = TextBox29.Text;
        ReportCovidMarshallMr.TextBox30 = TextBox30.Text;
        ReportCovidMarshallMr.TextBox31 = TextBox31.Text;
        ReportCovidMarshallMr.TextBox32 = TextBox32.Text;
        ReportCovidMarshallMr.TextBox33 = TextBox33.Text;
        ReportCovidMarshallMr.TextBox34 = TextBox34.Text;
        ReportCovidMarshallMr.TextBox35 = TextBox35.Text;
        ReportCovidMarshallMr.TextBox36 = TextBox36.Text;
        ReportCovidMarshallMr.TextBox37 = TextBox37.Text;
        ReportCovidMarshallMr.TextBox38 = TextBox38.Text;
        ReportCovidMarshallMr.TextBox39 = TextBox39.Text;
        ReportCovidMarshallMr.TextBox40 = TextBox40.Text;
        ReportCovidMarshallMr.TextBox41 = TextBox41.Text;
        ReportCovidMarshallMr.TextBox42 = TextBox42.Text;
        ReportCovidMarshallMr.TextBox43 = TextBox43.Text;
        ReportCovidMarshallMr.TextBox44 = TextBox44.Text;
        ReportCovidMarshallMr.TextBox45 = TextBox45.Text;
        ReportCovidMarshallMr.TextBox46 = TextBox46.Text;
        ReportCovidMarshallMr.TextBox47 = TextBox47.Text;
        ReportCovidMarshallMr.TextBox48 = TextBox48.Text;
        ReportCovidMarshallMr.TextBox49 = TextBox49.Text;
        ReportCovidMarshallMr.TextBox50 = TextBox50.Text;
        ReportCovidMarshallMr.TextBox51 = TextBox51.Text;
        ReportCovidMarshallMr.TextBox52 = TextBox52.Text;
        ReportCovidMarshallMr.TextBox53 = TextBox53.Text;
        ReportCovidMarshallMr.TextBox54 = TextBox54.Text;
        ReportCovidMarshallMr.TextBox55 = TextBox55.Text;
        ReportCovidMarshallMr.TextBox56 = TextBox56.Text;
        ReportCovidMarshallMr.TextBox57 = TextBox57.Text;
        ReportCovidMarshallMr.TextBox58 = TextBox58.Text;
        ReportCovidMarshallMr.TextBox59 = TextBox59.Text;
        ReportCovidMarshallMr.TextBox60 = TextBox60.Text;
        ReportCovidMarshallMr.TextBox61 = TextBox61.Text;
        ReportCovidMarshallMr.TextBox62 = TextBox62.Text;
        ReportCovidMarshallMr.TextBox63 = TextBox63.Text;
        ReportCovidMarshallMr.TextBox64 = TextBox64.Text;
        ReportCovidMarshallMr.TextBox65 = TextBox65.Text;
        ReportCovidMarshallMr.TextBox66 = TextBox66.Text;
        ReportCovidMarshallMr.TextBox67 = TextBox67.Text;
        ReportCovidMarshallMr.TextBox68 = TextBox68.Text;
        ReportCovidMarshallMr.TextBox69 = TextBox69.Text;
        ReportCovidMarshallMr.TextBox70 = TextBox70.Text;
        ReportCovidMarshallMr.TextBox71 = TextBox71.Text;
        ReportCovidMarshallMr.TextBox72 = TextBox72.Text;
        ReportCovidMarshallMr.TextBox73 = TextBox73.Text;
        ReportCovidMarshallMr.TextBox74 = TextBox74.Text;
        ReportCovidMarshallMr.TextBox75 = TextBox75.Text;
        ReportCovidMarshallMr.TextBox76 = TextBox76.Text;
        ReportCovidMarshallMr.TextBox77 = TextBox77.Text;
        ReportCovidMarshallMr.TextBox78 = TextBox78.Text;
        ReportCovidMarshallMr.TextBox79 = TextBox79.Text;
        ReportCovidMarshallMr.TextBox80 = TextBox80.Text;
        ReportCovidMarshallMr.TextBox81 = TextBox81.Text;
        ReportCovidMarshallMr.TextBox82 = TextBox82.Text;
        ReportCovidMarshallMr.TextBox83 = TextBox83.Text;
        ReportCovidMarshallMr.TextBox84 = TextBox84.Text;
        ReportCovidMarshallMr.TextBox85 = TextBox85.Text;
        ReportCovidMarshallMr.TextBox86 = TextBox86.Text;
        ReportCovidMarshallMr.TextBox87 = TextBox87.Text;
        ReportCovidMarshallMr.TextBox88 = TextBox88.Text;
        ReportCovidMarshallMr.TextBox89 = TextBox89.Text;
        ReportCovidMarshallMr.TextBox90 = TextBox90.Text;
        ReportCovidMarshallMr.TextBox91 = TextBox91.Text;
        ReportCovidMarshallMr.TextBox92 = TextBox92.Text;
        ReportCovidMarshallMr.TextBox93 = TextBox93.Text;
        ReportCovidMarshallMr.TextBox94 = TextBox94.Text;
        ReportCovidMarshallMr.TextBox95 = TextBox95.Text;
        ReportCovidMarshallMr.TextBox96 = TextBox96.Text;
        ReportCovidMarshallMr.TextBox97 = TextBox97.Text;
        ReportCovidMarshallMr.TextBox98 = TextBox98.Text;
        ReportCovidMarshallMr.TextBox99 = TextBox99.Text;
        ReportCovidMarshallMr.TextBox100 = TextBox100.Text;
        ReportCovidMarshallMr.TextBox101 = TextBox101.Text;
        ReportCovidMarshallMr.TextBox102 = TextBox102.Text;
        ReportCovidMarshallMr.TextBox103 = TextBox103.Text;
        ReportCovidMarshallMr.TextBox104 = TextBox104.Text;
        ReportCovidMarshallMr.TextBox105 = TextBox105.Text;
        ReportCovidMarshallMr.TextBox106 = TextBox106.Text;
        ReportCovidMarshallMr.TextBox107 = TextBox107.Text;
        ReportCovidMarshallMr.TextBox108 = TextBox108.Text;
        ReportCovidMarshallMr.TextBox109 = TextBox109.Text;
        ReportCovidMarshallMr.TextBox110 = TextBox110.Text;
        ReportCovidMarshallMr.TextBox111 = TextBox111.Text;
        ReportCovidMarshallMr.TextBox112 = TextBox112.Text;
        ReportCovidMarshallMr.TextBox113 = TextBox113.Text;
        ReportCovidMarshallMr.TextBox114 = TextBox114.Text;
        ReportCovidMarshallMr.TextBox115 = TextBox115.Text;
        ReportCovidMarshallMr.TextBox116 = TextBox116.Text;
        ReportCovidMarshallMr.TextBox117 = TextBox117.Text;
        ReportCovidMarshallMr.TextBox118 = TextBox118.Text;
        ReportCovidMarshallMr.TextBox119 = TextBox119.Text;
        ReportCovidMarshallMr.TextBox120 = TextBox120.Text;
        ReportCovidMarshallMr.TextBox121 = TextBox121.Text;
        ReportCovidMarshallMr.TextBox122 = TextBox122.Text;
        ReportCovidMarshallMr.TextBox123 = TextBox123.Text;
        ReportCovidMarshallMr.TextBox124 = TextBox124.Text;
        ReportCovidMarshallMr.TextBox125 = TextBox125.Text;
        ReportCovidMarshallMr.TextBox126 = TextBox126.Text;
        ReportCovidMarshallMr.TextBox127 = TextBox127.Text;
        ReportCovidMarshallMr.TextBox128 = TextBox128.Text;
        ReportCovidMarshallMr.TextBox129 = TextBox129.Text;
        ReportCovidMarshallMr.TextBox130 = TextBox130.Text;
        ReportCovidMarshallMr.TextBox131 = TextBox131.Text;
        ReportCovidMarshallMr.TextBox132 = TextBox132.Text;
        ReportCovidMarshallMr.TextBox133 = TextBox133.Text;
        ReportCovidMarshallMr.TextBox134 = TextBox134.Text;
        ReportCovidMarshallMr.TextBox135 = TextBox135.Text;
        ReportCovidMarshallMr.TextBox136 = TextBox136.Text;
        ReportCovidMarshallMr.TextBox137 = TextBox137.Text;
        ReportCovidMarshallMr.TextBox138 = TextBox138.Text;
        ReportCovidMarshallMr.TextBox139 = TextBox139.Text;
        ReportCovidMarshallMr.TextBox140 = TextBox140.Text;
        ReportCovidMarshallMr.TextBox141 = TextBox141.Text;
        ReportCovidMarshallMr.TextBox142 = TextBox142.Text;
        ReportCovidMarshallMr.TextBox143 = TextBox143.Text;
        ReportCovidMarshallMr.TextBox144 = TextBox144.Text;
        ReportCovidMarshallMr.TextBox145 = TextBox145.Text;
        ReportCovidMarshallMr.TextBox146 = TextBox146.Text;
        ReportCovidMarshallMr.TextBox147 = TextBox147.Text;
        ReportCovidMarshallMr.TextBox148 = TextBox148.Text;
        ReportCovidMarshallMr.TextBox149 = TextBox149.Text;
        ReportCovidMarshallMr.TextBox150 = TextBox150.Text;
        ReportCovidMarshallMr.TextBox151 = TextBox151.Text;
        ReportCovidMarshallMr.TextBox152 = TextBox152.Text;
        ReportCovidMarshallMr.TextBox153 = TextBox153.Text;
        ReportCovidMarshallMr.TextBox154 = TextBox154.Text;
        ReportCovidMarshallMr.TextBox155 = TextBox155.Text;
        ReportCovidMarshallMr.TextBox156 = TextBox156.Text;
        ReportCovidMarshallMr.TextBox157 = TextBox157.Text;
        ReportCovidMarshallMr.TextBox158 = TextBox158.Text;
        ReportCovidMarshallMr.TextBox159 = TextBox159.Text;
        ReportCovidMarshallMr.TextBox160 = TextBox160.Text;
        ReportCovidMarshallMr.TextBox161 = TextBox161.Text;
        ReportCovidMarshallMr.TextBox162 = TextBox162.Text;
        ReportCovidMarshallMr.TextBox163 = TextBox163.Text;
        ReportCovidMarshallMr.TextBox164 = TextBox164.Text;
        ReportCovidMarshallMr.TextBox165 = TextBox165.Text;
        ReportCovidMarshallMr.TextBox166 = TextBox166.Text;
        ReportCovidMarshallMr.TextBox167 = TextBox167.Text;
        ReportCovidMarshallMr.TextBox168 = TextBox168.Text;
        ReportCovidMarshallMr.TextBox169 = TextBox169.Text;
        ReportCovidMarshallMr.TextBox170 = TextBox170.Text;
        ReportCovidMarshallMr.TextBox171 = TextBox171.Text;
        ReportCovidMarshallMr.TextBox172 = TextBox172.Text;
        ReportCovidMarshallMr.TextBox173 = TextBox173.Text;
        ReportCovidMarshallMr.TextBox174 = TextBox174.Text;
        ReportCovidMarshallMr.TextBox175 = TextBox175.Text;
        ReportCovidMarshallMr.TextBox176 = TextBox176.Text;
        ReportCovidMarshallMr.TextBox177 = TextBox177.Text;
        ReportCovidMarshallMr.TextBox178 = TextBox178.Text;
        ReportCovidMarshallMr.TextBox179 = TextBox179.Text;
        ReportCovidMarshallMr.TextBox180 = TextBox180.Text;
        ReportCovidMarshallMr.TextBox181 = TextBox181.Text;
        ReportCovidMarshallMr.TextBox182 = TextBox182.Text;
        ReportCovidMarshallMr.TextBox183 = TextBox183.Text;
        ReportCovidMarshallMr.TextBox184 = TextBox184.Text;
        ReportCovidMarshallMr.TextBox185 = TextBox185.Text;
        ReportCovidMarshallMr.TextBox186 = TextBox186.Text;
        ReportCovidMarshallMr.TextBox187 = TextBox187.Text;
        ReportCovidMarshallMr.TextBox188 = TextBox188.Text;
        ReportCovidMarshallMr.TextBox189 = TextBox189.Text;
        ReportCovidMarshallMr.TextBox190 = TextBox190.Text;
        ReportCovidMarshallMr.TextBox191 = TextBox191.Text;
        ReportCovidMarshallMr.TextBox192 = TextBox192.Text;
        ReportCovidMarshallMr.TextBox193 = TextBox193.Text;
        ReportCovidMarshallMr.TextBox194 = TextBox194.Text;
        ReportCovidMarshallMr.TextBox195 = TextBox195.Text;
        ReportCovidMarshallMr.TextBox196 = TextBox196.Text;
        ReportCovidMarshallMr.TextBox197 = TextBox197.Text;
        ReportCovidMarshallMr.TextBox198 = TextBox198.Text;
        ReportCovidMarshallMr.TextBox199 = TextBox199.Text;
        ReportCovidMarshallMr.TextBox200 = TextBox200.Text;
        ReportCovidMarshallMr.TextBox201 = TextBox201.Text;
        ReportCovidMarshallMr.TextBox202 = TextBox202.Text;
        ReportCovidMarshallMr.TextBox203 = TextBox203.Text;
        ReportCovidMarshallMr.TextBox204 = TextBox204.Text;
        ReportCovidMarshallMr.TextBox205 = TextBox205.Text;
        ReportCovidMarshallMr.TextBox206 = TextBox206.Text;
        ReportCovidMarshallMr.TextBox207 = TextBox207.Text;
        ReportCovidMarshallMr.TextBox208 = TextBox208.Text;
        ReportCovidMarshallMr.TextBox209 = TextBox209.Text;
        ReportCovidMarshallMr.TextBox210 = TextBox210.Text;
        ReportCovidMarshallMr.TextBox211 = TextBox211.Text;
        ReportCovidMarshallMr.TextBox212 = TextBox212.Text;
        ReportCovidMarshallMr.TextBox213 = TextBox213.Text;
        ReportCovidMarshallMr.TextBox214 = TextBox214.Text;
        ReportCovidMarshallMr.TextBox215 = TextBox215.Text;
        ReportCovidMarshallMr.TextBox216 = TextBox216.Text;
        ReportCovidMarshallMr.TextBox217 = TextBox217.Text;
        ReportCovidMarshallMr.TextBox218 = TextBox218.Text;
        ReportCovidMarshallMr.TextBox219 = TextBox219.Text;
        ReportCovidMarshallMr.TextBox220 = TextBox220.Text;
        ReportCovidMarshallMr.TextBox221 = TextBox221.Text;
        ReportCovidMarshallMr.TextBox222 = TextBox222.Text;
        ReportCovidMarshallMr.TextBox223 = TextBox223.Text;
        ReportCovidMarshallMr.TextBox224 = TextBox224.Text;
        ReportCovidMarshallMr.TextBox225 = TextBox225.Text;
        ReportCovidMarshallMr.TextBox226 = TextBox226.Text;
        ReportCovidMarshallMr.TextBox227 = TextBox227.Text;
        ReportCovidMarshallMr.TextBox228 = TextBox228.Text;
        ReportCovidMarshallMr.TextBox229 = TextBox229.Text;
        ReportCovidMarshallMr.TextBox230 = TextBox230.Text;
        ReportCovidMarshallMr.TextBox231 = TextBox231.Text;
        ReportCovidMarshallMr.TextBox232 = TextBox232.Text;
        ReportCovidMarshallMr.TextBox233 = TextBox233.Text;
        ReportCovidMarshallMr.TextBox234 = TextBox234.Text;
        ReportCovidMarshallMr.TextBox235 = TextBox235.Text;
        ReportCovidMarshallMr.TextBox236 = TextBox236.Text;
        ReportCovidMarshallMr.TextBox237 = TextBox237.Text;
        ReportCovidMarshallMr.TextBox238 = TextBox238.Text;
        ReportCovidMarshallMr.TextBox239 = TextBox239.Text;
        ReportCovidMarshallMr.TextBox240 = TextBox240.Text;
        ReportCovidMarshallMr.TextBox241 = TextBox241.Text;
        ReportCovidMarshallMr.TextBox242 = TextBox242.Text;
        ReportCovidMarshallMr.TextBox243 = TextBox243.Text;
        ReportCovidMarshallMr.TextBox244 = TextBox244.Text;
        ReportCovidMarshallMr.TextBox245 = TextBox245.Text;
        ReportCovidMarshallMr.TextBox246 = TextBox246.Text;
        ReportCovidMarshallMr.TextBox247 = TextBox247.Text;
        ReportCovidMarshallMr.TextBox248 = TextBox248.Text;
        ReportCovidMarshallMr.TextBox249 = TextBox249.Text;
        ReportCovidMarshallMr.TextBox250 = TextBox250.Text;
        ReportCovidMarshallMr.TextBox251 = TextBox251.Text;
        ReportCovidMarshallMr.TextBox252 = TextBox252.Text;
        ReportCovidMarshallMr.TextBox253 = TextBox253.Text;
        ReportCovidMarshallMr.TextBox254 = TextBox254.Text;
        ReportCovidMarshallMr.TextBox255 = TextBox255.Text;
        ReportCovidMarshallMr.TextBox256 = TextBox256.Text;
        ReportCovidMarshallMr.TextBox257 = TextBox257.Text;
        ReportCovidMarshallMr.TextBox258 = TextBox258.Text;
        ReportCovidMarshallMr.TextBox259 = TextBox259.Text;
        ReportCovidMarshallMr.TextBox260 = TextBox260.Text;
        ReportCovidMarshallMr.TextBox261 = TextBox261.Text;
        ReportCovidMarshallMr.TextBox262 = TextBox262.Text;
        ReportCovidMarshallMr.TextBox263 = TextBox263.Text;
        ReportCovidMarshallMr.TextBox264 = TextBox264.Text;
        ReportCovidMarshallMr.TextBox265 = TextBox265.Text;
        ReportCovidMarshallMr.TextBox266 = TextBox266.Text;
        ReportCovidMarshallMr.TextBox267 = TextBox267.Text;
        ReportCovidMarshallMr.TextBox268 = TextBox268.Text;
        ReportCovidMarshallMr.TextBox269 = TextBox269.Text;
        ReportCovidMarshallMr.TextBox270 = TextBox270.Text;
        ReportCovidMarshallMr.TextBox271 = TextBox271.Text;
        ReportCovidMarshallMr.TextBox272 = TextBox272.Text;
        ReportCovidMarshallMr.TextBox273 = TextBox273.Text;
        ReportCovidMarshallMr.TextBox274 = TextBox274.Text;
        ReportCovidMarshallMr.TextBox275 = TextBox275.Text;
        ReportCovidMarshallMr.TextBox276 = TextBox276.Text;
        ReportCovidMarshallMr.TextBox277 = TextBox277.Text;
        ReportCovidMarshallMr.TextBox278 = TextBox278.Text;
        ReportCovidMarshallMr.TextBox279 = TextBox279.Text;
        ReportCovidMarshallMr.TextBox280 = TextBox280.Text;
        ReportCovidMarshallMr.TextBox281 = TextBox281.Text;
        ReportCovidMarshallMr.TextBox282 = TextBox282.Text;
        ReportCovidMarshallMr.TextBox283 = TextBox283.Text;
        ReportCovidMarshallMr.TextBox284 = TextBox284.Text;
        ReportCovidMarshallMr.TextBox285 = TextBox285.Text;
        ReportCovidMarshallMr.TextBox286 = TextBox286.Text;
        ReportCovidMarshallMr.TextBox287 = TextBox287.Text;
        ReportCovidMarshallMr.TextBox288 = TextBox288.Text;
        ReportCovidMarshallMr.TextBox289 = TextBox289.Text;
        ReportCovidMarshallMr.TextBox290 = TextBox290.Text;
        ReportCovidMarshallMr.TextBox291 = TextBox291.Text;
        ReportCovidMarshallMr.TextBox292 = TextBox292.Text;
        ReportCovidMarshallMr.TextBox293 = TextBox293.Text;
        ReportCovidMarshallMr.TextBox294 = TextBox294.Text;
        ReportCovidMarshallMr.TextBox295 = TextBox295.Text;
        ReportCovidMarshallMr.TextBox296 = TextBox296.Text;
        ReportCovidMarshallMr.TextBox297 = TextBox297.Text;
        ReportCovidMarshallMr.TextBox298 = TextBox298.Text;
        ReportCovidMarshallMr.TextBox299 = TextBox299.Text;
        ReportCovidMarshallMr.TextBox300 = TextBox300.Text;
        ReportCovidMarshallMr.TextBox301 = TextBox301.Text;
        ReportCovidMarshallMr.TextBox302 = TextBox302.Text;
        ReportCovidMarshallMr.TextBox303 = TextBox303.Text;
        ReportCovidMarshallMr.TextBox304 = TextBox304.Text;
        ReportCovidMarshallMr.TextBox305 = TextBox305.Text;
        ReportCovidMarshallMr.TextBox306 = TextBox306.Text;
        ReportCovidMarshallMr.CheckBox307 = CheckBox307.Checked.ToString();
        ReportCovidMarshallMr.CheckBox308 = CheckBox308.Checked.ToString();
        ReportCovidMarshallMr.CheckBox309 = CheckBox309.Checked.ToString();
        ReportCovidMarshallMr.CheckBox310 = CheckBox310.Checked.ToString();
        ReportCovidMarshallMr.CheckBox311 = CheckBox311.Checked.ToString();
        ReportCovidMarshallMr.CheckBox312 = CheckBox312.Checked.ToString();
        ReportCovidMarshallMr.CheckBox313 = CheckBox313.Checked.ToString();
        ReportCovidMarshallMr.CheckBox314 = CheckBox314.Checked.ToString();
        ReportCovidMarshallMr.CheckBox315 = CheckBox315.Checked.ToString();
        ReportCovidMarshallMr.CheckBox316 = CheckBox316.Checked.ToString();
        ReportCovidMarshallMr.CheckBox317 = CheckBox317.Checked.ToString();
        ReportCovidMarshallMr.CheckBox318 = CheckBox318.Checked.ToString();
        ReportCovidMarshallMr.CheckBox319 = CheckBox319.Checked.ToString();
        ReportCovidMarshallMr.CheckBox320 = CheckBox320.Checked.ToString();
        ReportCovidMarshallMr.CheckBox321 = CheckBox321.Checked.ToString();
        ReportCovidMarshallMr.CheckBox322 = CheckBox322.Checked.ToString();
        ReportCovidMarshallMr.CheckBox323 = CheckBox323.Checked.ToString();
        ReportCovidMarshallMr.CheckBox324 = CheckBox324.Checked.ToString();
        ReportCovidMarshallMr.TextBox325 = TextBox325.Text.Replace("\n", "<br />");
        ReportCovidMarshallMr.CheckBox326 = CheckBox326.Checked.ToString();
        ReportCovidMarshallMr.CheckBox327 = CheckBox327.Checked.ToString();
        ReportCovidMarshallMr.CheckBox328 = CheckBox328.Checked.ToString();
        ReportCovidMarshallMr.CheckBox329 = CheckBox329.Checked.ToString();
        ReportCovidMarshallMr.TextBox330 = TextBox330.Text.Replace("\n", "<br />");
        ReportCovidMarshallMr.CheckBox331 = CheckBox331.Checked.ToString();
        ReportCovidMarshallMr.CheckBox332 = CheckBox332.Checked.ToString();
        ReportCovidMarshallMr.CheckBox333 = CheckBox333.Checked.ToString();
        ReportCovidMarshallMr.CheckBox334 = CheckBox334.Checked.ToString();
        ReportCovidMarshallMr.TextBox335 = TextBox335.Text.Replace("\n", "<br />");
        ReportCovidMarshallMr.CheckBox336 = CheckBox336.Checked.ToString();
        ReportCovidMarshallMr.CheckBox337 = CheckBox337.Checked.ToString();
        ReportCovidMarshallMr.CheckBox338 = CheckBox338.Checked.ToString();
        ReportCovidMarshallMr.CheckBox339 = CheckBox339.Checked.ToString();
        ReportCovidMarshallMr.TextBox340 = TextBox340.Text.Replace("\n", "<br />");
        ReportCovidMarshallMr.CheckBox341 = CheckBox341.Checked.ToString();
        ReportCovidMarshallMr.CheckBox342 = CheckBox342.Checked.ToString();
        ReportCovidMarshallMr.CheckBox343 = CheckBox343.Checked.ToString();
        ReportCovidMarshallMr.CheckBox344 = CheckBox344.Checked.ToString();
        ReportCovidMarshallMr.TextBox345 = TextBox345.Text.Replace("\n", "<br />");
        ReportCovidMarshallMr.CheckBox346 = CheckBox346.Checked.ToString();
        ReportCovidMarshallMr.CheckBox347 = CheckBox347.Checked.ToString();
        ReportCovidMarshallMr.CheckBox348 = CheckBox348.Checked.ToString();
        ReportCovidMarshallMr.CheckBox349 = CheckBox349.Checked.ToString();
        ReportCovidMarshallMr.TextBox350 = TextBox350.Text.Replace("\n", "<br />");
        ReportCovidMarshallMr.CheckBox351 = CheckBox351.Checked.ToString();
        ReportCovidMarshallMr.CheckBox352 = CheckBox352.Checked.ToString();
        ReportCovidMarshallMr.CheckBox353 = CheckBox353.Checked.ToString();
        ReportCovidMarshallMr.CheckBox354 = CheckBox354.Checked.ToString();
        ReportCovidMarshallMr.TextBox355 = TextBox355.Text.Replace("\n", "<br />");
    }
}