using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_CU_Covid_Marshall_Edit_v1_v1 : System.Web.UI.UserControl
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
                        CheckBox65.Checked = Convert.ToBoolean(rdr["65"]);
                        CheckBox66.Checked = Convert.ToBoolean(rdr["66"]);
                        CheckBox67.Checked = Convert.ToBoolean(rdr["67"]);
                        CheckBox68.Checked = Convert.ToBoolean(rdr["68"]);
                        CheckBox69.Checked = Convert.ToBoolean(rdr["69"]);
                        CheckBox70.Checked = Convert.ToBoolean(rdr["70"]);
                        CheckBox71.Checked = Convert.ToBoolean(rdr["71"]);
                        CheckBox72.Checked = Convert.ToBoolean(rdr["72"]);
                        CheckBox73.Checked = Convert.ToBoolean(rdr["73"]);
                        CheckBox74.Checked = Convert.ToBoolean(rdr["74"]);
                        CheckBox75.Checked = Convert.ToBoolean(rdr["75"]);
                        CheckBox76.Checked = Convert.ToBoolean(rdr["76"]);
                        CheckBox77.Checked = Convert.ToBoolean(rdr["77"]);
                        CheckBox78.Checked = Convert.ToBoolean(rdr["78"]);
                        CheckBox79.Checked = Convert.ToBoolean(rdr["79"]);
                        CheckBox80.Checked = Convert.ToBoolean(rdr["80"]);
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
                        CheckBox145.Checked = Convert.ToBoolean(rdr["145"]);
                        CheckBox146.Checked = Convert.ToBoolean(rdr["146"]);
                        CheckBox147.Checked = Convert.ToBoolean(rdr["147"]);
                        CheckBox148.Checked = Convert.ToBoolean(rdr["148"]);
                        CheckBox149.Checked = Convert.ToBoolean(rdr["149"]);
                        CheckBox150.Checked = Convert.ToBoolean(rdr["150"]);
                        CheckBox151.Checked = Convert.ToBoolean(rdr["151"]);
                        CheckBox152.Checked = Convert.ToBoolean(rdr["152"]);
                        CheckBox153.Checked = Convert.ToBoolean(rdr["153"]);
                        CheckBox154.Checked = Convert.ToBoolean(rdr["154"]);
                        CheckBox155.Checked = Convert.ToBoolean(rdr["155"]);
                        CheckBox156.Checked = Convert.ToBoolean(rdr["156"]);
                        CheckBox157.Checked = Convert.ToBoolean(rdr["157"]);
                        CheckBox158.Checked = Convert.ToBoolean(rdr["158"]);
                        CheckBox159.Checked = Convert.ToBoolean(rdr["159"]);
                        CheckBox160.Checked = Convert.ToBoolean(rdr["160"]);
                        CheckBox161.Checked = Convert.ToBoolean(rdr["161"]);
                        CheckBox162.Checked = Convert.ToBoolean(rdr["162"]);
                        CheckBox163.Checked = Convert.ToBoolean(rdr["163"]);
                        CheckBox164.Checked = Convert.ToBoolean(rdr["164"]);
                        CheckBox165.Checked = Convert.ToBoolean(rdr["165"]);
                        CheckBox166.Checked = Convert.ToBoolean(rdr["166"]);
                        CheckBox167.Checked = Convert.ToBoolean(rdr["167"]);
                        CheckBox168.Checked = Convert.ToBoolean(rdr["168"]);
                        CheckBox169.Checked = Convert.ToBoolean(rdr["169"]);
                        CheckBox170.Checked = Convert.ToBoolean(rdr["170"]);
                        CheckBox171.Checked = Convert.ToBoolean(rdr["171"]);
                        CheckBox172.Checked = Convert.ToBoolean(rdr["172"]);
                        CheckBox173.Checked = Convert.ToBoolean(rdr["173"]);
                        CheckBox174.Checked = Convert.ToBoolean(rdr["174"]);
                        CheckBox175.Checked = Convert.ToBoolean(rdr["175"]);
                        CheckBox176.Checked = Convert.ToBoolean(rdr["176"]);
                        CheckBox177.Checked = Convert.ToBoolean(rdr["177"]);
                        CheckBox178.Checked = Convert.ToBoolean(rdr["178"]);
                        TextBox179.Text = rdr["179"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox180.Checked = Convert.ToBoolean(rdr["180"]);
                        CheckBox181.Checked = Convert.ToBoolean(rdr["181"]);
                        CheckBox182.Checked = Convert.ToBoolean(rdr["182"]);
                        CheckBox183.Checked = Convert.ToBoolean(rdr["183"]);
                        TextBox184.Text = rdr["184"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        CheckBox185.Checked = Convert.ToBoolean(rdr["185"]);
                        CheckBox186.Checked = Convert.ToBoolean(rdr["186"]);
                        CheckBox187.Checked = Convert.ToBoolean(rdr["187"]);
                        CheckBox188.Checked = Convert.ToBoolean(rdr["188"]);
                        TextBox189.Text = rdr["189"].ToString().Replace("<br />", "\n").Replace("^", "'");

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
                        if (ReportCovidMarshallCu.GeneralComments != rdr["GeneralComments"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "GeneralComments";
                        }
                        if (ReportCovidMarshallCu.TextBox1 != rdr["1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox1";
                        }
                        if (ReportCovidMarshallCu.TextBox2 != rdr["2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox2";
                        }
                        if (ReportCovidMarshallCu.TextBox3 != rdr["3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox3";
                        }
                        if (ReportCovidMarshallCu.TextBox4 != rdr["4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox4";
                        }
                        if (ReportCovidMarshallCu.TextBox5 != rdr["5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox5";
                        }
                        if (ReportCovidMarshallCu.TextBox6 != rdr["6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox6";
                        }
                        if (ReportCovidMarshallCu.TextBox7 != rdr["7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox7";
                        }
                        if (ReportCovidMarshallCu.TextBox8 != rdr["8"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox8";
                        }
                        if (ReportCovidMarshallCu.TextBox9 != rdr["9"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox9";
                        }
                        if (ReportCovidMarshallCu.TextBox10 != rdr["10"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox10";
                        }
                        if (ReportCovidMarshallCu.TextBox11 != rdr["11"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox11";
                        }
                        if (ReportCovidMarshallCu.TextBox12 != rdr["12"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox12";
                        }
                        if (ReportCovidMarshallCu.TextBox13 != rdr["13"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox13";
                        }
                        if (ReportCovidMarshallCu.TextBox14 != rdr["14"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox14";
                        }
                        if (ReportCovidMarshallCu.TextBox15 != rdr["15"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox15";
                        }
                        if (ReportCovidMarshallCu.TextBox16 != rdr["16"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox16";
                        }
                        if (ReportCovidMarshallCu.TextBox17 != rdr["17"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox17";
                        }
                        if (ReportCovidMarshallCu.TextBox18 != rdr["18"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox18";
                        }
                        if (ReportCovidMarshallCu.TextBox19 != rdr["19"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox19";
                        }
                        if (ReportCovidMarshallCu.TextBox20 != rdr["20"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox20";
                        }
                        if (ReportCovidMarshallCu.TextBox21 != rdr["21"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox21";
                        }
                        if (ReportCovidMarshallCu.TextBox22 != rdr["22"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox22";
                        }
                        if (ReportCovidMarshallCu.TextBox23 != rdr["23"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox23";
                        }
                        if (ReportCovidMarshallCu.TextBox24 != rdr["24"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox24";
                        }
                        if (ReportCovidMarshallCu.TextBox25 != rdr["25"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox25";
                        }
                        if (ReportCovidMarshallCu.TextBox26 != rdr["26"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox26";
                        }
                        if (ReportCovidMarshallCu.TextBox27 != rdr["27"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox27";
                        }
                        if (ReportCovidMarshallCu.TextBox28 != rdr["28"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox28";
                        }
                        if (ReportCovidMarshallCu.TextBox29 != rdr["29"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox29";
                        }
                        if (ReportCovidMarshallCu.TextBox30 != rdr["30"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox30";
                        }
                        if (ReportCovidMarshallCu.TextBox31 != rdr["31"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox31";
                        }
                        if (ReportCovidMarshallCu.TextBox32 != rdr["32"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox32";
                        }
                        if (ReportCovidMarshallCu.TextBox33 != rdr["33"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox33";
                        }
                        if (ReportCovidMarshallCu.TextBox34 != rdr["34"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox34";
                        }
                        if (ReportCovidMarshallCu.TextBox35 != rdr["35"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox35";
                        }
                        if (ReportCovidMarshallCu.TextBox36 != rdr["36"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox36";
                        }
                        if (ReportCovidMarshallCu.TextBox37 != rdr["37"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox37";
                        }
                        if (ReportCovidMarshallCu.TextBox38 != rdr["38"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox38";
                        }
                        if (ReportCovidMarshallCu.TextBox39 != rdr["39"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox39";
                        }
                        if (ReportCovidMarshallCu.TextBox40 != rdr["40"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox40";
                        }
                        if (ReportCovidMarshallCu.TextBox41 != rdr["41"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox41";
                        }
                        if (ReportCovidMarshallCu.TextBox42 != rdr["42"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox42";
                        }
                        if (ReportCovidMarshallCu.TextBox43 != rdr["43"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox43";
                        }
                        if (ReportCovidMarshallCu.TextBox44 != rdr["44"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox44";
                        }
                        if (ReportCovidMarshallCu.TextBox45 != rdr["45"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox45";
                        }
                        if (ReportCovidMarshallCu.TextBox46 != rdr["46"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox46";
                        }
                        if (ReportCovidMarshallCu.TextBox47 != rdr["47"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox47";
                        }
                        if (ReportCovidMarshallCu.TextBox48 != rdr["48"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox48";
                        }
                        if (ReportCovidMarshallCu.TextBox49 != rdr["49"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox49";
                        }
                        if (ReportCovidMarshallCu.TextBox50 != rdr["50"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox50";
                        }
                        if (ReportCovidMarshallCu.TextBox51 != rdr["51"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox51";
                        }
                        if (ReportCovidMarshallCu.TextBox52 != rdr["52"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox52";
                        }
                        if (ReportCovidMarshallCu.TextBox53 != rdr["53"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox53";
                        }
                        if (ReportCovidMarshallCu.TextBox54 != rdr["54"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox54";
                        }
                        if (ReportCovidMarshallCu.TextBox55 != rdr["55"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox55";
                        }
                        if (ReportCovidMarshallCu.TextBox56 != rdr["56"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox56";
                        }
                        if (ReportCovidMarshallCu.TextBox57 != rdr["57"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox57";
                        }
                        if (ReportCovidMarshallCu.TextBox58 != rdr["58"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox58";
                        }
                        if (ReportCovidMarshallCu.TextBox59 != rdr["59"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox59";
                        }
                        if (ReportCovidMarshallCu.TextBox60 != rdr["60"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox60";
                        }
                        if (ReportCovidMarshallCu.TextBox61 != rdr["61"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox61";
                        }
                        if (ReportCovidMarshallCu.TextBox62 != rdr["62"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox62";
                        }
                        if (ReportCovidMarshallCu.TextBox63 != rdr["63"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox63";
                        }
                        if (ReportCovidMarshallCu.TextBox64 != rdr["64"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox64";
                        }
                        if (ReportCovidMarshallCu.CheckBox65.ToString() != Convert.ToBoolean(rdr["65"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox65";
                        }
                        if (ReportCovidMarshallCu.CheckBox66.ToString() != Convert.ToBoolean(rdr["66"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox66";
                        }
                        if (ReportCovidMarshallCu.CheckBox67.ToString() != Convert.ToBoolean(rdr["67"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox67";
                        }
                        if (ReportCovidMarshallCu.CheckBox68.ToString() != Convert.ToBoolean(rdr["68"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox68";
                        }
                        if (ReportCovidMarshallCu.CheckBox69.ToString() != Convert.ToBoolean(rdr["69"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox69";
                        }
                        if (ReportCovidMarshallCu.CheckBox70.ToString() != Convert.ToBoolean(rdr["70"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox70";
                        }
                        if (ReportCovidMarshallCu.CheckBox71.ToString() != Convert.ToBoolean(rdr["71"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox71";
                        }
                        if (ReportCovidMarshallCu.CheckBox72.ToString() != Convert.ToBoolean(rdr["72"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox72";
                        }
                        if (ReportCovidMarshallCu.CheckBox73.ToString() != Convert.ToBoolean(rdr["73"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox73";
                        }
                        if (ReportCovidMarshallCu.CheckBox74.ToString() != Convert.ToBoolean(rdr["74"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox74";
                        }
                        if (ReportCovidMarshallCu.CheckBox75.ToString() != Convert.ToBoolean(rdr["75"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox75";
                        }
                        if (ReportCovidMarshallCu.CheckBox76.ToString() != Convert.ToBoolean(rdr["76"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox76";
                        }
                        if (ReportCovidMarshallCu.CheckBox77.ToString() != Convert.ToBoolean(rdr["77"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox77";
                        }
                        if (ReportCovidMarshallCu.CheckBox78.ToString() != Convert.ToBoolean(rdr["78"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox78";
                        }
                        if (ReportCovidMarshallCu.CheckBox79.ToString() != Convert.ToBoolean(rdr["79"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox79";
                        }
                        if (ReportCovidMarshallCu.CheckBox80.ToString() != Convert.ToBoolean(rdr["80"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox80";
                        }
                        if (ReportCovidMarshallCu.TextBox81 != rdr["81"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox81";
                        }
                        if (ReportCovidMarshallCu.TextBox82 != rdr["82"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox82";
                        }
                        if (ReportCovidMarshallCu.TextBox83 != rdr["83"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox83";
                        }
                        if (ReportCovidMarshallCu.TextBox84 != rdr["84"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox84";
                        }
                        if (ReportCovidMarshallCu.TextBox85 != rdr["85"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox85";
                        }
                        if (ReportCovidMarshallCu.TextBox86 != rdr["86"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox86";
                        }
                        if (ReportCovidMarshallCu.TextBox87 != rdr["87"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox87";
                        }
                        if (ReportCovidMarshallCu.TextBox88 != rdr["88"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox88";
                        }
                        if (ReportCovidMarshallCu.TextBox89 != rdr["89"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox89";
                        }
                        if (ReportCovidMarshallCu.TextBox90 != rdr["90"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox90";
                        }
                        if (ReportCovidMarshallCu.TextBox91 != rdr["91"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox91";
                        }
                        if (ReportCovidMarshallCu.TextBox92 != rdr["92"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox92";
                        }
                        if (ReportCovidMarshallCu.TextBox93 != rdr["93"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox93";
                        }
                        if (ReportCovidMarshallCu.TextBox94 != rdr["94"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox94";
                        }
                        if (ReportCovidMarshallCu.TextBox95 != rdr["95"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox95";
                        }
                        if (ReportCovidMarshallCu.TextBox96 != rdr["96"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox96";
                        }
                        if (ReportCovidMarshallCu.TextBox97 != rdr["97"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox97";
                        }
                        if (ReportCovidMarshallCu.TextBox98 != rdr["98"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox98";
                        }
                        if (ReportCovidMarshallCu.TextBox99 != rdr["99"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox99";
                        }
                        if (ReportCovidMarshallCu.TextBox100 != rdr["100"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox100";
                        }
                        if (ReportCovidMarshallCu.TextBox101 != rdr["101"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox101";
                        }
                        if (ReportCovidMarshallCu.TextBox102 != rdr["102"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox102";
                        }
                        if (ReportCovidMarshallCu.TextBox103 != rdr["103"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox103";
                        }
                        if (ReportCovidMarshallCu.TextBox104 != rdr["104"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox104";
                        }
                        if (ReportCovidMarshallCu.TextBox105 != rdr["105"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox105";
                        }
                        if (ReportCovidMarshallCu.TextBox106 != rdr["106"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox106";
                        }
                        if (ReportCovidMarshallCu.TextBox107 != rdr["107"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox107";
                        }
                        if (ReportCovidMarshallCu.TextBox108 != rdr["108"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox108";
                        }
                        if (ReportCovidMarshallCu.TextBox109 != rdr["109"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox109";
                        }
                        if (ReportCovidMarshallCu.TextBox110 != rdr["110"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox110";
                        }
                        if (ReportCovidMarshallCu.TextBox111 != rdr["111"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox111";
                        }
                        if (ReportCovidMarshallCu.TextBox112 != rdr["112"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox112";
                        }
                        if (ReportCovidMarshallCu.TextBox113 != rdr["113"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox113";
                        }
                        if (ReportCovidMarshallCu.TextBox114 != rdr["114"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox114";
                        }
                        if (ReportCovidMarshallCu.TextBox115 != rdr["115"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox115";
                        }
                        if (ReportCovidMarshallCu.TextBox116 != rdr["116"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox116";
                        }
                        if (ReportCovidMarshallCu.TextBox117 != rdr["117"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox117";
                        }
                        if (ReportCovidMarshallCu.TextBox118 != rdr["118"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox118";
                        }
                        if (ReportCovidMarshallCu.TextBox119 != rdr["119"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox119";
                        }
                        if (ReportCovidMarshallCu.TextBox120 != rdr["120"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox120";
                        }
                        if (ReportCovidMarshallCu.TextBox121 != rdr["121"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox121";
                        }
                        if (ReportCovidMarshallCu.TextBox122 != rdr["122"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox122";
                        }
                        if (ReportCovidMarshallCu.TextBox123 != rdr["123"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox123";
                        }
                        if (ReportCovidMarshallCu.TextBox124 != rdr["124"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox124";
                        }
                        if (ReportCovidMarshallCu.TextBox125 != rdr["125"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox125";
                        }
                        if (ReportCovidMarshallCu.TextBox126 != rdr["126"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox126";
                        }
                        if (ReportCovidMarshallCu.TextBox127 != rdr["127"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox127";
                        }
                        if (ReportCovidMarshallCu.TextBox128 != rdr["128"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox128";
                        }
                        if (ReportCovidMarshallCu.TextBox129 != rdr["129"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox129";
                        }
                        if (ReportCovidMarshallCu.TextBox130 != rdr["130"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox130";
                        }
                        if (ReportCovidMarshallCu.TextBox131 != rdr["131"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox131";
                        }
                        if (ReportCovidMarshallCu.TextBox132 != rdr["132"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox132";
                        }
                        if (ReportCovidMarshallCu.TextBox133 != rdr["133"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox133";
                        }
                        if (ReportCovidMarshallCu.TextBox134 != rdr["134"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox134";
                        }
                        if (ReportCovidMarshallCu.TextBox135 != rdr["135"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox135";
                        }
                        if (ReportCovidMarshallCu.TextBox136 != rdr["136"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox136";
                        }
                        if (ReportCovidMarshallCu.TextBox137 != rdr["137"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox137";
                        }
                        if (ReportCovidMarshallCu.TextBox138 != rdr["138"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox138";
                        }
                        if (ReportCovidMarshallCu.TextBox139 != rdr["139"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox139";
                        }
                        if (ReportCovidMarshallCu.TextBox140 != rdr["140"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox140";
                        }
                        if (ReportCovidMarshallCu.TextBox141 != rdr["141"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox141";
                        }
                        if (ReportCovidMarshallCu.TextBox142 != rdr["142"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox142";
                        }
                        if (ReportCovidMarshallCu.TextBox143 != rdr["143"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox143";
                        }
                        if (ReportCovidMarshallCu.TextBox144 != rdr["144"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox144";
                        }
                        if (ReportCovidMarshallCu.CheckBox145.ToString() != Convert.ToBoolean(rdr["145"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox145";
                        }
                        if (ReportCovidMarshallCu.CheckBox146.ToString() != Convert.ToBoolean(rdr["146"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox146";
                        }
                        if (ReportCovidMarshallCu.CheckBox147.ToString() != Convert.ToBoolean(rdr["147"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox147";
                        }
                        if (ReportCovidMarshallCu.CheckBox148.ToString() != Convert.ToBoolean(rdr["148"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox148";
                        }
                        if (ReportCovidMarshallCu.CheckBox149.ToString() != Convert.ToBoolean(rdr["149"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox149";
                        }
                        if (ReportCovidMarshallCu.CheckBox150.ToString() != Convert.ToBoolean(rdr["150"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox150";
                        }
                        if (ReportCovidMarshallCu.CheckBox151.ToString() != Convert.ToBoolean(rdr["151"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox151";
                        }
                        if (ReportCovidMarshallCu.CheckBox152.ToString() != Convert.ToBoolean(rdr["152"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox152";
                        }
                        if (ReportCovidMarshallCu.CheckBox153.ToString() != Convert.ToBoolean(rdr["153"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox153";
                        }
                        if (ReportCovidMarshallCu.CheckBox154.ToString() != Convert.ToBoolean(rdr["154"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox154";
                        }
                        if (ReportCovidMarshallCu.CheckBox155.ToString() != Convert.ToBoolean(rdr["155"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox155";
                        }
                        if (ReportCovidMarshallCu.CheckBox156.ToString() != Convert.ToBoolean(rdr["156"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox156";
                        }
                        if (ReportCovidMarshallCu.CheckBox157.ToString() != Convert.ToBoolean(rdr["157"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox157";
                        }
                        if (ReportCovidMarshallCu.CheckBox158.ToString() != Convert.ToBoolean(rdr["158"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox158";
                        }
                        if (ReportCovidMarshallCu.CheckBox159.ToString() != Convert.ToBoolean(rdr["159"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox159";
                        }
                        if (ReportCovidMarshallCu.CheckBox160.ToString() != Convert.ToBoolean(rdr["160"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox160";
                        }
                        if (ReportCovidMarshallCu.CheckBox161.ToString() != Convert.ToBoolean(rdr["161"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox161";
                        }
                        if (ReportCovidMarshallCu.CheckBox162.ToString() != Convert.ToBoolean(rdr["162"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox162";
                        }
                        if (ReportCovidMarshallCu.CheckBox163.ToString() != Convert.ToBoolean(rdr["163"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox163";
                        }
                        if (ReportCovidMarshallCu.CheckBox164.ToString() != Convert.ToBoolean(rdr["164"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox164";
                        }
                        if (ReportCovidMarshallCu.CheckBox165.ToString() != Convert.ToBoolean(rdr["165"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox165";
                        }
                        if (ReportCovidMarshallCu.CheckBox166.ToString() != Convert.ToBoolean(rdr["166"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox166";
                        }
                        if (ReportCovidMarshallCu.CheckBox167.ToString() != Convert.ToBoolean(rdr["167"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox167";
                        }
                        if (ReportCovidMarshallCu.CheckBox168.ToString() != Convert.ToBoolean(rdr["168"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox168";
                        }
                        if (ReportCovidMarshallCu.CheckBox169.ToString() != Convert.ToBoolean(rdr["169"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox169";
                        }
                        if (ReportCovidMarshallCu.CheckBox170.ToString() != Convert.ToBoolean(rdr["170"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox170";
                        }
                        if (ReportCovidMarshallCu.CheckBox171.ToString() != Convert.ToBoolean(rdr["171"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox171";
                        }
                        if (ReportCovidMarshallCu.CheckBox172.ToString() != Convert.ToBoolean(rdr["172"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox172";
                        }
                        if (ReportCovidMarshallCu.CheckBox173.ToString() != Convert.ToBoolean(rdr["173"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox173";
                        }
                        if (ReportCovidMarshallCu.CheckBox174.ToString() != Convert.ToBoolean(rdr["174"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox174";
                        }
                        if (ReportCovidMarshallCu.CheckBox175.ToString() != Convert.ToBoolean(rdr["175"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox175";
                        }
                        if (ReportCovidMarshallCu.CheckBox176.ToString() != Convert.ToBoolean(rdr["176"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox176";
                        }
                        if (ReportCovidMarshallCu.CheckBox177.ToString() != Convert.ToBoolean(rdr["177"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox177";
                        }
                        if (ReportCovidMarshallCu.CheckBox178.ToString() != Convert.ToBoolean(rdr["178"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox178";
                        }
                        if (ReportCovidMarshallCu.TextBox179 != rdr["179"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox179";
                        }
                        if (ReportCovidMarshallCu.CheckBox180.ToString() != Convert.ToBoolean(rdr["180"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox180";
                        }
                        if (ReportCovidMarshallCu.CheckBox181.ToString() != Convert.ToBoolean(rdr["181"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox181";
                        }
                        if (ReportCovidMarshallCu.CheckBox182.ToString() != Convert.ToBoolean(rdr["182"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox182";
                        }
                        if (ReportCovidMarshallCu.CheckBox183.ToString() != Convert.ToBoolean(rdr["183"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox183";
                        }
                        if (ReportCovidMarshallCu.TextBox184 != rdr["184"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox184";
                        }
                        if (ReportCovidMarshallCu.CheckBox185.ToString() != Convert.ToBoolean(rdr["185"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox185";
                        }
                        if (ReportCovidMarshallCu.CheckBox186.ToString() != Convert.ToBoolean(rdr["186"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox186";
                        }
                        if (ReportCovidMarshallCu.CheckBox187.ToString() != Convert.ToBoolean(rdr["187"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox187";
                        }
                        if (ReportCovidMarshallCu.CheckBox188.ToString() != Convert.ToBoolean(rdr["188"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CheckBox188";
                        }
                        if (ReportCovidMarshallCu.TextBox189 != rdr["189"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TextBox189";
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
    }

    protected void SetStaticVariable()
    {
        ReportCovidMarshallCu.GeneralComments = txtGeneralComments.Text.Replace("\n", "<br />");
        ReportCovidMarshallCu.TextBox1 = TextBox1.Text;
        ReportCovidMarshallCu.TextBox2 = TextBox2.Text;
        ReportCovidMarshallCu.TextBox3 = TextBox3.Text;
        ReportCovidMarshallCu.TextBox4 = TextBox4.Text;
        ReportCovidMarshallCu.TextBox5 = TextBox5.Text;
        ReportCovidMarshallCu.TextBox6 = TextBox6.Text;
        ReportCovidMarshallCu.TextBox7 = TextBox7.Text;
        ReportCovidMarshallCu.TextBox8 = TextBox8.Text;
        ReportCovidMarshallCu.TextBox9 = TextBox9.Text;
        ReportCovidMarshallCu.TextBox10 = TextBox10.Text;
        ReportCovidMarshallCu.TextBox11 = TextBox11.Text;
        ReportCovidMarshallCu.TextBox12 = TextBox12.Text;
        ReportCovidMarshallCu.TextBox13 = TextBox13.Text;
        ReportCovidMarshallCu.TextBox14 = TextBox14.Text;
        ReportCovidMarshallCu.TextBox15 = TextBox15.Text;
        ReportCovidMarshallCu.TextBox16 = TextBox16.Text;
        ReportCovidMarshallCu.TextBox17 = TextBox17.Text;
        ReportCovidMarshallCu.TextBox18 = TextBox18.Text;
        ReportCovidMarshallCu.TextBox19 = TextBox19.Text;
        ReportCovidMarshallCu.TextBox20 = TextBox20.Text;
        ReportCovidMarshallCu.TextBox21 = TextBox21.Text;
        ReportCovidMarshallCu.TextBox22 = TextBox22.Text;
        ReportCovidMarshallCu.TextBox23 = TextBox23.Text;
        ReportCovidMarshallCu.TextBox24 = TextBox24.Text;
        ReportCovidMarshallCu.TextBox25 = TextBox25.Text;
        ReportCovidMarshallCu.TextBox26 = TextBox26.Text;
        ReportCovidMarshallCu.TextBox27 = TextBox27.Text;
        ReportCovidMarshallCu.TextBox28 = TextBox28.Text;
        ReportCovidMarshallCu.TextBox29 = TextBox29.Text;
        ReportCovidMarshallCu.TextBox30 = TextBox30.Text;
        ReportCovidMarshallCu.TextBox31 = TextBox31.Text;
        ReportCovidMarshallCu.TextBox32 = TextBox32.Text;
        ReportCovidMarshallCu.TextBox33 = TextBox33.Text;
        ReportCovidMarshallCu.TextBox34 = TextBox34.Text;
        ReportCovidMarshallCu.TextBox35 = TextBox35.Text;
        ReportCovidMarshallCu.TextBox36 = TextBox36.Text;
        ReportCovidMarshallCu.TextBox37 = TextBox37.Text;
        ReportCovidMarshallCu.TextBox38 = TextBox38.Text;
        ReportCovidMarshallCu.TextBox39 = TextBox39.Text;
        ReportCovidMarshallCu.TextBox40 = TextBox40.Text;
        ReportCovidMarshallCu.TextBox41 = TextBox41.Text;
        ReportCovidMarshallCu.TextBox42 = TextBox42.Text;
        ReportCovidMarshallCu.TextBox43 = TextBox43.Text;
        ReportCovidMarshallCu.TextBox44 = TextBox44.Text;
        ReportCovidMarshallCu.TextBox45 = TextBox45.Text;
        ReportCovidMarshallCu.TextBox46 = TextBox46.Text;
        ReportCovidMarshallCu.TextBox47 = TextBox47.Text;
        ReportCovidMarshallCu.TextBox48 = TextBox48.Text;
        ReportCovidMarshallCu.TextBox49 = TextBox49.Text;
        ReportCovidMarshallCu.TextBox50 = TextBox50.Text;
        ReportCovidMarshallCu.TextBox51 = TextBox51.Text;
        ReportCovidMarshallCu.TextBox52 = TextBox52.Text;
        ReportCovidMarshallCu.TextBox53 = TextBox53.Text;
        ReportCovidMarshallCu.TextBox54 = TextBox54.Text;
        ReportCovidMarshallCu.TextBox55 = TextBox55.Text;
        ReportCovidMarshallCu.TextBox56 = TextBox56.Text;
        ReportCovidMarshallCu.TextBox57 = TextBox57.Text;
        ReportCovidMarshallCu.TextBox58 = TextBox58.Text;
        ReportCovidMarshallCu.TextBox59 = TextBox59.Text;
        ReportCovidMarshallCu.TextBox60 = TextBox60.Text;
        ReportCovidMarshallCu.TextBox61 = TextBox61.Text;
        ReportCovidMarshallCu.TextBox62 = TextBox62.Text;
        ReportCovidMarshallCu.TextBox63 = TextBox63.Text;
        ReportCovidMarshallCu.TextBox64 = TextBox64.Text;
        ReportCovidMarshallCu.CheckBox65 = CheckBox65.Checked.ToString();
        ReportCovidMarshallCu.CheckBox66 = CheckBox66.Checked.ToString();
        ReportCovidMarshallCu.CheckBox67 = CheckBox67.Checked.ToString();
        ReportCovidMarshallCu.CheckBox68 = CheckBox68.Checked.ToString();
        ReportCovidMarshallCu.CheckBox69 = CheckBox69.Checked.ToString();
        ReportCovidMarshallCu.CheckBox70 = CheckBox70.Checked.ToString();
        ReportCovidMarshallCu.CheckBox71 = CheckBox71.Checked.ToString();
        ReportCovidMarshallCu.CheckBox72 = CheckBox72.Checked.ToString();
        ReportCovidMarshallCu.CheckBox73 = CheckBox73.Checked.ToString();
        ReportCovidMarshallCu.CheckBox74 = CheckBox74.Checked.ToString();
        ReportCovidMarshallCu.CheckBox75 = CheckBox75.Checked.ToString();
        ReportCovidMarshallCu.CheckBox76 = CheckBox76.Checked.ToString();
        ReportCovidMarshallCu.CheckBox77 = CheckBox77.Checked.ToString();
        ReportCovidMarshallCu.CheckBox78 = CheckBox78.Checked.ToString();
        ReportCovidMarshallCu.CheckBox79 = CheckBox79.Checked.ToString();
        ReportCovidMarshallCu.CheckBox80 = CheckBox80.Checked.ToString();
        ReportCovidMarshallCu.TextBox81 = TextBox81.Text;
        ReportCovidMarshallCu.TextBox82 = TextBox82.Text;
        ReportCovidMarshallCu.TextBox83 = TextBox83.Text;
        ReportCovidMarshallCu.TextBox84 = TextBox84.Text;
        ReportCovidMarshallCu.TextBox85 = TextBox85.Text;
        ReportCovidMarshallCu.TextBox86 = TextBox86.Text;
        ReportCovidMarshallCu.TextBox87 = TextBox87.Text;
        ReportCovidMarshallCu.TextBox88 = TextBox88.Text;
        ReportCovidMarshallCu.TextBox89 = TextBox89.Text;
        ReportCovidMarshallCu.TextBox90 = TextBox90.Text;
        ReportCovidMarshallCu.TextBox91 = TextBox91.Text;
        ReportCovidMarshallCu.TextBox92 = TextBox92.Text;
        ReportCovidMarshallCu.TextBox93 = TextBox93.Text;
        ReportCovidMarshallCu.TextBox94 = TextBox94.Text;
        ReportCovidMarshallCu.TextBox95 = TextBox95.Text;
        ReportCovidMarshallCu.TextBox96 = TextBox96.Text;
        ReportCovidMarshallCu.TextBox97 = TextBox97.Text;
        ReportCovidMarshallCu.TextBox98 = TextBox98.Text;
        ReportCovidMarshallCu.TextBox99 = TextBox99.Text;
        ReportCovidMarshallCu.TextBox100 = TextBox100.Text;
        ReportCovidMarshallCu.TextBox101 = TextBox101.Text;
        ReportCovidMarshallCu.TextBox102 = TextBox102.Text;
        ReportCovidMarshallCu.TextBox103 = TextBox103.Text;
        ReportCovidMarshallCu.TextBox104 = TextBox104.Text;
        ReportCovidMarshallCu.TextBox105 = TextBox105.Text;
        ReportCovidMarshallCu.TextBox106 = TextBox106.Text;
        ReportCovidMarshallCu.TextBox107 = TextBox107.Text;
        ReportCovidMarshallCu.TextBox108 = TextBox108.Text;
        ReportCovidMarshallCu.TextBox109 = TextBox109.Text;
        ReportCovidMarshallCu.TextBox110 = TextBox110.Text;
        ReportCovidMarshallCu.TextBox111 = TextBox111.Text;
        ReportCovidMarshallCu.TextBox112 = TextBox112.Text;
        ReportCovidMarshallCu.TextBox113 = TextBox113.Text;
        ReportCovidMarshallCu.TextBox114 = TextBox114.Text;
        ReportCovidMarshallCu.TextBox115 = TextBox115.Text;
        ReportCovidMarshallCu.TextBox116 = TextBox116.Text;
        ReportCovidMarshallCu.TextBox117 = TextBox117.Text;
        ReportCovidMarshallCu.TextBox118 = TextBox118.Text;
        ReportCovidMarshallCu.TextBox119 = TextBox119.Text;
        ReportCovidMarshallCu.TextBox120 = TextBox120.Text;
        ReportCovidMarshallCu.TextBox121 = TextBox121.Text;
        ReportCovidMarshallCu.TextBox122 = TextBox122.Text;
        ReportCovidMarshallCu.TextBox123 = TextBox123.Text;
        ReportCovidMarshallCu.TextBox124 = TextBox124.Text;
        ReportCovidMarshallCu.TextBox125 = TextBox125.Text;
        ReportCovidMarshallCu.TextBox126 = TextBox126.Text;
        ReportCovidMarshallCu.TextBox127 = TextBox127.Text;
        ReportCovidMarshallCu.TextBox128 = TextBox128.Text;
        ReportCovidMarshallCu.TextBox129 = TextBox129.Text;
        ReportCovidMarshallCu.TextBox130 = TextBox130.Text;
        ReportCovidMarshallCu.TextBox131 = TextBox131.Text;
        ReportCovidMarshallCu.TextBox132 = TextBox132.Text;
        ReportCovidMarshallCu.TextBox133 = TextBox133.Text;
        ReportCovidMarshallCu.TextBox134 = TextBox134.Text;
        ReportCovidMarshallCu.TextBox135 = TextBox135.Text;
        ReportCovidMarshallCu.TextBox136 = TextBox136.Text;
        ReportCovidMarshallCu.TextBox137 = TextBox137.Text;
        ReportCovidMarshallCu.TextBox138 = TextBox138.Text;
        ReportCovidMarshallCu.TextBox139 = TextBox139.Text;
        ReportCovidMarshallCu.TextBox140 = TextBox140.Text;
        ReportCovidMarshallCu.TextBox141 = TextBox141.Text;
        ReportCovidMarshallCu.TextBox142 = TextBox142.Text;
        ReportCovidMarshallCu.TextBox143 = TextBox143.Text;
        ReportCovidMarshallCu.TextBox144 = TextBox144.Text;
        ReportCovidMarshallCu.CheckBox145 = CheckBox145.Checked.ToString();
        ReportCovidMarshallCu.CheckBox146 = CheckBox146.Checked.ToString();
        ReportCovidMarshallCu.CheckBox147 = CheckBox147.Checked.ToString();
        ReportCovidMarshallCu.CheckBox148 = CheckBox148.Checked.ToString();
        ReportCovidMarshallCu.CheckBox149 = CheckBox149.Checked.ToString();
        ReportCovidMarshallCu.CheckBox150 = CheckBox150.Checked.ToString();
        ReportCovidMarshallCu.CheckBox151 = CheckBox151.Checked.ToString();
        ReportCovidMarshallCu.CheckBox152 = CheckBox152.Checked.ToString();
        ReportCovidMarshallCu.CheckBox153 = CheckBox153.Checked.ToString();
        ReportCovidMarshallCu.CheckBox154 = CheckBox154.Checked.ToString();
        ReportCovidMarshallCu.CheckBox155 = CheckBox155.Checked.ToString();
        ReportCovidMarshallCu.CheckBox156 = CheckBox156.Checked.ToString();
        ReportCovidMarshallCu.CheckBox157 = CheckBox157.Checked.ToString();
        ReportCovidMarshallCu.CheckBox158 = CheckBox158.Checked.ToString();
        ReportCovidMarshallCu.CheckBox159 = CheckBox159.Checked.ToString();
        ReportCovidMarshallCu.CheckBox160 = CheckBox160.Checked.ToString();
        ReportCovidMarshallCu.CheckBox161 = CheckBox161.Checked.ToString();
        ReportCovidMarshallCu.CheckBox162 = CheckBox162.Checked.ToString();
        ReportCovidMarshallCu.CheckBox163 = CheckBox163.Checked.ToString();
        ReportCovidMarshallCu.CheckBox164 = CheckBox164.Checked.ToString();
        ReportCovidMarshallCu.CheckBox165 = CheckBox165.Checked.ToString();
        ReportCovidMarshallCu.CheckBox166 = CheckBox166.Checked.ToString();
        ReportCovidMarshallCu.CheckBox167 = CheckBox167.Checked.ToString();
        ReportCovidMarshallCu.CheckBox168 = CheckBox168.Checked.ToString();
        ReportCovidMarshallCu.CheckBox169 = CheckBox169.Checked.ToString();
        ReportCovidMarshallCu.CheckBox170 = CheckBox170.Checked.ToString();
        ReportCovidMarshallCu.CheckBox171 = CheckBox171.Checked.ToString();
        ReportCovidMarshallCu.CheckBox172 = CheckBox172.Checked.ToString();
        ReportCovidMarshallCu.CheckBox173 = CheckBox173.Checked.ToString();
        ReportCovidMarshallCu.CheckBox174 = CheckBox174.Checked.ToString();
        ReportCovidMarshallCu.CheckBox175 = CheckBox175.Checked.ToString();
        ReportCovidMarshallCu.CheckBox176 = CheckBox176.Checked.ToString();
        ReportCovidMarshallCu.CheckBox177 = CheckBox177.Checked.ToString();
        ReportCovidMarshallCu.CheckBox178 = CheckBox178.Checked.ToString();
        ReportCovidMarshallCu.TextBox179 = TextBox179.Text.Replace("\n", "<br />");
        ReportCovidMarshallCu.CheckBox180 = CheckBox180.Checked.ToString();
        ReportCovidMarshallCu.CheckBox181 = CheckBox181.Checked.ToString();
        ReportCovidMarshallCu.CheckBox182 = CheckBox182.Checked.ToString();
        ReportCovidMarshallCu.CheckBox183 = CheckBox183.Checked.ToString();
        ReportCovidMarshallCu.TextBox184 = TextBox184.Text.Replace("\n", "<br />");
        ReportCovidMarshallCu.CheckBox185 = CheckBox185.Checked.ToString();
        ReportCovidMarshallCu.CheckBox186 = CheckBox186.Checked.ToString();
        ReportCovidMarshallCu.CheckBox187 = CheckBox187.Checked.ToString();
        ReportCovidMarshallCu.CheckBox188 = CheckBox188.Checked.ToString();
        ReportCovidMarshallCu.TextBox189 = TextBox189.Text.Replace("\n", "<br />");
    }
}