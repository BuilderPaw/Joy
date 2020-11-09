using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Covid_Marshall_Create_v1_v1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStaffName.Text = Session["DisplayName"].ToString();

            // check the current time then set appropriate date
            TimeSpan start = new TimeSpan(0, 0, 0); // 12am
            TimeSpan end = new TimeSpan(6, 0, 0);     // 6am
            TimeSpan now = DateTime.Now.TimeOfDay;  // current time
            DateTime dateTime;
            if ((now > start) && (now < end))
            {
                // current time is between 12am to 6am
                dateTime = DateTime.Now.Date.AddDays(-1);
            }
            else
            {
                // current time is greater than 6am
                dateTime = DateTime.Now.Date;
            }
            // display appropriate trading date
            txtDatePicker.Text = dateTime.ToString("dddd, dd MMMM yyyy");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SearchReport.CreateReportReset(); // takes off the selected report in ddlCreateReport

        // get the last Report ID
        string query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_MerrylandsRSLCovidMarshall";
        int lastRId, result, returnFlag = 2;
        DateTime temp, date = DateTime.Parse(DateTime.Now.ToShortDateString());
        Report.ErrorMessage = "";

        con.Open();
        SqlCommand getRId = new SqlCommand(query, con);
        try
        {
            lastRId = (int)getRId.ExecuteScalar();
            // add plus one to the current report id to be used in this report
            lastRId += 1;
        }
        catch
        {
            lastRId = 10000001;
        }
        con.Close();

        Report.LastReportId = lastRId.ToString();

        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            returnFlag = 1;
        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            returnFlag = 1;
        }
        else if (DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                returnFlag = 1;
            }
        }

        returnFlag = checkTexboxes();

        if (returnFlag == 1)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"" + Report.ErrorMessage + "\");", true);
            return;
        }

        // change the format of the shift date to timestamp format
        DateTime shift_date = DateTime.Parse(txtDatePicker.Text);
        string shift_tDate = shift_date.ToString("yyyyMMdd");

        // separate the shift date day of week value
        string shift_DOW = shift_date.DayOfWeek.ToString();

        // change the format of the entry date to timestamp format
        DateTime entry_date = DateTime.Now;

        // pop a message if shift is unchanged
        if (ddlShift.SelectedItem.Value == "-1")
        {
            showAlert("Please select Shift.");
            ddlShift.Focus();
            return;
        }

        // get staff's id
        string cmdText = "SELECT StaffId FROM Staff WHERE Username = '" + Session["Username"] + "'",
               variable = "getStaff";
        readFiles(cmdText, variable);

        // insert data to table
        using (DataClassesDataContext dc = new DataClassesDataContext())
        {
            Report_MerrylandsRSLCovidMarshall dm = new Report_MerrylandsRSLCovidMarshall();
            dm.ReportId = Int32.Parse(Report.LastReportId);
            dm.RCatId = 10; // MR Covid Marshall Category
            dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
            dm.StaffName = UserCredentials.DisplayName;
            dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
            dm.ShiftDate = shift_date.Date;
            dm.ShiftDOW = shift_DOW;
            dm.EntryDate = entry_date;
            dm.Report_Table = "Report_MerrylandsRSLCovidMarshall";
            dm.AuditVersion = 1;
            dm.ReportStat = "Awaiting Completion";
            dm.Report_Version = 1; // current version
            dm.ReadByList = "," + UserCredentials.StaffId + ",";
            dm.GeneralComments = txtGeneralComments.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._1 = Int32.Parse(TextBox1.Text);
            dm._2 = Int32.Parse(TextBox2.Text);
            dm._3 = Int32.Parse(TextBox3.Text);
            dm._4 = Int32.Parse(TextBox4.Text);
            dm._5 = Int32.Parse(TextBox5.Text);
            dm._6 = Int32.Parse(TextBox6.Text);
            dm._7 = Int32.Parse(TextBox7.Text);
            dm._8 = Int32.Parse(TextBox8.Text);
            dm._9 = Int32.Parse(TextBox9.Text);
            dm._10 = Int32.Parse(TextBox10.Text);
            dm._11 = Int32.Parse(TextBox11.Text);
            dm._12 = Int32.Parse(TextBox12.Text);
            dm._13 = Int32.Parse(TextBox13.Text);
            dm._14 = Int32.Parse(TextBox14.Text);
            dm._15 = Int32.Parse(TextBox15.Text);
            dm._16 = Int32.Parse(TextBox16.Text);
            dm._17 = Int32.Parse(TextBox17.Text);
            dm._18 = Int32.Parse(TextBox18.Text);
            dm._19 = Int32.Parse(TextBox19.Text);
            dm._20 = Int32.Parse(TextBox20.Text);
            dm._21 = Int32.Parse(TextBox21.Text);
            dm._22 = Int32.Parse(TextBox22.Text);
            dm._23 = Int32.Parse(TextBox23.Text);
            dm._24 = Int32.Parse(TextBox24.Text);
            dm._25 = Int32.Parse(TextBox25.Text);
            dm._26 = Int32.Parse(TextBox26.Text);
            dm._27 = Int32.Parse(TextBox27.Text);
            dm._28 = Int32.Parse(TextBox28.Text);
            dm._29 = Int32.Parse(TextBox29.Text);
            dm._30 = Int32.Parse(TextBox30.Text);
            dm._31 = Int32.Parse(TextBox31.Text);
            dm._32 = Int32.Parse(TextBox32.Text);
            dm._33 = Int32.Parse(TextBox33.Text);
            dm._34 = Int32.Parse(TextBox34.Text);
            dm._35 = Int32.Parse(TextBox35.Text);
            dm._36 = Int32.Parse(TextBox36.Text);
            dm._37 = Int32.Parse(TextBox37.Text);
            dm._38 = Int32.Parse(TextBox38.Text);
            dm._39 = Int32.Parse(TextBox39.Text);
            dm._40 = Int32.Parse(TextBox40.Text);
            dm._41 = Int32.Parse(TextBox41.Text);
            dm._42 = Int32.Parse(TextBox42.Text);
            dm._43 = Int32.Parse(TextBox43.Text);
            dm._44 = Int32.Parse(TextBox44.Text);
            dm._45 = Int32.Parse(TextBox45.Text);
            dm._46 = Int32.Parse(TextBox46.Text);
            dm._47 = Int32.Parse(TextBox47.Text);
            dm._48 = Int32.Parse(TextBox48.Text);
            dm._49 = Int32.Parse(TextBox49.Text);
            dm._50 = Int32.Parse(TextBox50.Text);
            dm._51 = Int32.Parse(TextBox51.Text);
            dm._52 = Int32.Parse(TextBox52.Text);
            dm._53 = Int32.Parse(TextBox53.Text);
            dm._54 = Int32.Parse(TextBox54.Text);
            dm._55 = Int32.Parse(TextBox55.Text);
            dm._56 = Int32.Parse(TextBox56.Text);
            dm._57 = Int32.Parse(TextBox57.Text);
            dm._58 = Int32.Parse(TextBox58.Text);
            dm._59 = Int32.Parse(TextBox59.Text);
            dm._60 = Int32.Parse(TextBox60.Text);
            dm._61 = Int32.Parse(TextBox61.Text);
            dm._62 = Int32.Parse(TextBox62.Text);
            dm._63 = Int32.Parse(TextBox63.Text);
            dm._64 = Int32.Parse(TextBox64.Text);
            dm._65 = Int32.Parse(TextBox65.Text);
            dm._66 = Int32.Parse(TextBox66.Text);
            dm._67 = Int32.Parse(TextBox67.Text);
            dm._68 = Int32.Parse(TextBox68.Text);
            dm._69 = Int32.Parse(TextBox69.Text);
            dm._70 = Int32.Parse(TextBox70.Text);
            dm._71 = Int32.Parse(TextBox71.Text);
            dm._72 = Int32.Parse(TextBox72.Text);
            dm._73 = Int32.Parse(TextBox73.Text);
            dm._74 = Int32.Parse(TextBox74.Text);
            dm._75 = Int32.Parse(TextBox75.Text);
            dm._76 = Int32.Parse(TextBox76.Text);
            dm._77 = Int32.Parse(TextBox77.Text);
            dm._78 = Int32.Parse(TextBox78.Text);
            dm._79 = Int32.Parse(TextBox79.Text);
            dm._80 = Int32.Parse(TextBox80.Text);
            dm._81 = Int32.Parse(TextBox81.Text);
            dm._82 = Int32.Parse(TextBox82.Text);
            dm._83 = Int32.Parse(TextBox83.Text);
            dm._84 = Int32.Parse(TextBox84.Text);
            dm._85 = Int32.Parse(TextBox85.Text);
            dm._86 = Int32.Parse(TextBox86.Text);
            dm._87 = Int32.Parse(TextBox87.Text);
            dm._88 = Int32.Parse(TextBox88.Text);
            dm._89 = Int32.Parse(TextBox89.Text);
            dm._90 = Int32.Parse(TextBox90.Text);
            dm._91 = Int32.Parse(TextBox91.Text);
            dm._92 = Int32.Parse(TextBox92.Text);
            dm._93 = Int32.Parse(TextBox93.Text);
            dm._94 = Int32.Parse(TextBox94.Text);
            dm._95 = Int32.Parse(TextBox95.Text);
            dm._96 = Int32.Parse(TextBox96.Text);
            dm._97 = Int32.Parse(TextBox97.Text);
            dm._98 = Int32.Parse(TextBox98.Text);
            dm._99 = Int32.Parse(TextBox99.Text);
            dm._100 = Int32.Parse(TextBox100.Text);
            dm._101 = Int32.Parse(TextBox101.Text);
            dm._102 = Int32.Parse(TextBox102.Text);
            dm._103 = Int32.Parse(TextBox103.Text);
            dm._104 = Int32.Parse(TextBox104.Text);
            dm._105 = Int32.Parse(TextBox105.Text);
            dm._106 = Int32.Parse(TextBox106.Text);
            dm._107 = Int32.Parse(TextBox107.Text);
            dm._108 = Int32.Parse(TextBox108.Text);
            dm._109 = Int32.Parse(TextBox109.Text);
            dm._110 = Int32.Parse(TextBox110.Text);
            dm._111 = Int32.Parse(TextBox111.Text);
            dm._112 = Int32.Parse(TextBox112.Text);
            dm._113 = Int32.Parse(TextBox113.Text);
            dm._114 = Int32.Parse(TextBox114.Text);
            dm._115 = Int32.Parse(TextBox115.Text);
            dm._116 = Int32.Parse(TextBox116.Text);
            dm._117 = Int32.Parse(TextBox117.Text);
            dm._118 = Int32.Parse(TextBox118.Text);
            dm._119 = Int32.Parse(TextBox119.Text);
            dm._120 = Int32.Parse(TextBox120.Text);
            dm._121 = Int32.Parse(TextBox121.Text);
            dm._122 = Int32.Parse(TextBox122.Text);
            dm._123 = Int32.Parse(TextBox123.Text);
            dm._124 = Int32.Parse(TextBox124.Text);
            dm._125 = Int32.Parse(TextBox125.Text);
            dm._126 = Int32.Parse(TextBox126.Text);
            dm._127 = Int32.Parse(TextBox127.Text);
            dm._128 = Int32.Parse(TextBox128.Text);
            dm._129 = Int32.Parse(TextBox129.Text);
            dm._130 = Int32.Parse(TextBox130.Text);
            dm._131 = Int32.Parse(TextBox131.Text);
            dm._132 = Int32.Parse(TextBox132.Text);
            dm._133 = Int32.Parse(TextBox133.Text);
            dm._134 = Int32.Parse(TextBox134.Text);
            dm._135 = Int32.Parse(TextBox135.Text);
            dm._136 = Int32.Parse(TextBox136.Text);
            dm._137 = Int32.Parse(TextBox137.Text);
            dm._138 = Int32.Parse(TextBox138.Text);
            dm._139 = Int32.Parse(TextBox139.Text);
            dm._140 = Int32.Parse(TextBox140.Text);
            dm._141 = Int32.Parse(TextBox141.Text);
            dm._142 = Int32.Parse(TextBox142.Text);
            dm._143 = Int32.Parse(TextBox143.Text);
            dm._144 = Int32.Parse(TextBox144.Text);
            dm._145 = Int32.Parse(TextBox145.Text);
            dm._146 = Int32.Parse(TextBox146.Text);
            dm._147 = Int32.Parse(TextBox147.Text);
            dm._148 = Int32.Parse(TextBox148.Text);
            dm._149 = Int32.Parse(TextBox149.Text);
            dm._150 = Int32.Parse(TextBox150.Text);
            dm._151 = Int32.Parse(TextBox151.Text);
            dm._152 = Int32.Parse(TextBox152.Text);
            dm._153 = Int32.Parse(TextBox153.Text);
            dm._154 = Int32.Parse(TextBox154.Text);
            dm._155 = Int32.Parse(TextBox155.Text);
            dm._156 = Int32.Parse(TextBox156.Text);
            dm._157 = Int32.Parse(TextBox157.Text);
            dm._158 = Int32.Parse(TextBox158.Text);
            dm._159 = Int32.Parse(TextBox159.Text);
            dm._160 = Int32.Parse(TextBox160.Text);
            dm._161 = Int32.Parse(TextBox161.Text);
            dm._162 = Int32.Parse(TextBox162.Text);
            dm._163 = Int32.Parse(TextBox163.Text);
            dm._164 = Int32.Parse(TextBox164.Text);
            dm._165 = Int32.Parse(TextBox165.Text);
            dm._166 = Int32.Parse(TextBox166.Text);
            dm._167 = Int32.Parse(TextBox167.Text);
            dm._168 = Int32.Parse(TextBox168.Text);
            dm._169 = Int32.Parse(TextBox169.Text);
            dm._170 = Int32.Parse(TextBox170.Text);
            dm._171 = Int32.Parse(TextBox171.Text);
            dm._172 = Int32.Parse(TextBox172.Text);
            dm._173 = Int32.Parse(TextBox173.Text);
            dm._174 = Int32.Parse(TextBox174.Text);
            dm._175 = Int32.Parse(TextBox175.Text);
            dm._176 = Int32.Parse(TextBox176.Text);
            dm._177 = Int32.Parse(TextBox177.Text);
            dm._178 = Int32.Parse(TextBox178.Text);
            dm._179 = Int32.Parse(TextBox179.Text);
            dm._180 = Int32.Parse(TextBox180.Text);
            dm._181 = Int32.Parse(TextBox181.Text);
            dm._182 = Int32.Parse(TextBox182.Text);
            dm._183 = Int32.Parse(TextBox183.Text);
            dm._184 = Int32.Parse(TextBox184.Text);
            dm._185 = Int32.Parse(TextBox185.Text);
            dm._186 = Int32.Parse(TextBox186.Text);
            dm._187 = Int32.Parse(TextBox187.Text);
            dm._188 = Int32.Parse(TextBox188.Text);
            dm._189 = Int32.Parse(TextBox189.Text);
            dm._190 = Int32.Parse(TextBox190.Text);
            dm._191 = Int32.Parse(TextBox191.Text);
            dm._192 = Int32.Parse(TextBox192.Text);
            dm._193 = Int32.Parse(TextBox193.Text);
            dm._194 = Int32.Parse(TextBox194.Text);
            dm._195 = Int32.Parse(TextBox195.Text);
            dm._196 = Int32.Parse(TextBox196.Text);
            dm._197 = Int32.Parse(TextBox197.Text);
            dm._198 = Int32.Parse(TextBox198.Text);
            dm._199 = Int32.Parse(TextBox199.Text);
            dm._200 = Int32.Parse(TextBox200.Text);
            dm._201 = Int32.Parse(TextBox201.Text);
            dm._202 = Int32.Parse(TextBox202.Text);
            dm._203 = Int32.Parse(TextBox203.Text);
            dm._204 = Int32.Parse(TextBox204.Text);
            dm._205 = Int32.Parse(TextBox205.Text);
            dm._206 = Int32.Parse(TextBox206.Text);
            dm._207 = Int32.Parse(TextBox207.Text);
            dm._208 = Int32.Parse(TextBox208.Text);
            dm._209 = Int32.Parse(TextBox209.Text);
            dm._210 = Int32.Parse(TextBox210.Text);
            dm._211 = Int32.Parse(TextBox211.Text);
            dm._212 = Int32.Parse(TextBox212.Text);
            dm._213 = Int32.Parse(TextBox213.Text);
            dm._214 = Int32.Parse(TextBox214.Text);
            dm._215 = Int32.Parse(TextBox215.Text);
            dm._216 = Int32.Parse(TextBox216.Text);
            dm._217 = Int32.Parse(TextBox217.Text);
            dm._218 = Int32.Parse(TextBox218.Text);
            dm._219 = Int32.Parse(TextBox219.Text);
            dm._220 = Int32.Parse(TextBox220.Text);
            dm._221 = Int32.Parse(TextBox221.Text);
            dm._222 = Int32.Parse(TextBox222.Text);
            dm._223 = Int32.Parse(TextBox223.Text);
            dm._224 = Int32.Parse(TextBox224.Text);
            dm._225 = Int32.Parse(TextBox225.Text);
            dm._226 = Int32.Parse(TextBox226.Text);
            dm._227 = Int32.Parse(TextBox227.Text);
            dm._228 = Int32.Parse(TextBox228.Text);
            dm._229 = Int32.Parse(TextBox229.Text);
            dm._230 = Int32.Parse(TextBox230.Text);
            dm._231 = Int32.Parse(TextBox231.Text);
            dm._232 = Int32.Parse(TextBox232.Text);
            dm._233 = Int32.Parse(TextBox233.Text);
            dm._234 = Int32.Parse(TextBox234.Text);
            dm._235 = Int32.Parse(TextBox235.Text);
            dm._236 = Int32.Parse(TextBox236.Text);
            dm._237 = Int32.Parse(TextBox237.Text);
            dm._238 = Int32.Parse(TextBox238.Text);
            dm._239 = Int32.Parse(TextBox239.Text);
            dm._240 = Int32.Parse(TextBox240.Text);
            dm._241 = Int32.Parse(TextBox241.Text);
            dm._242 = Int32.Parse(TextBox242.Text);
            dm._243 = Int32.Parse(TextBox243.Text);
            dm._244 = Int32.Parse(TextBox244.Text);
            dm._245 = Int32.Parse(TextBox245.Text);
            dm._246 = Int32.Parse(TextBox246.Text);
            dm._247 = Int32.Parse(TextBox247.Text);
            dm._248 = Int32.Parse(TextBox248.Text);
            dm._249 = Int32.Parse(TextBox249.Text);
            dm._250 = Int32.Parse(TextBox250.Text);
            dm._251 = Int32.Parse(TextBox251.Text);
            dm._252 = Int32.Parse(TextBox252.Text);
            dm._253 = Int32.Parse(TextBox253.Text);
            dm._254 = Int32.Parse(TextBox254.Text);
            dm._255 = Int32.Parse(TextBox255.Text);
            dm._256 = Int32.Parse(TextBox256.Text);
            dm._257 = Int32.Parse(TextBox257.Text);
            dm._258 = Int32.Parse(TextBox258.Text);
            dm._259 = Int32.Parse(TextBox259.Text);
            dm._260 = Int32.Parse(TextBox260.Text);
            dm._261 = Int32.Parse(TextBox261.Text);
            dm._262 = Int32.Parse(TextBox262.Text);
            dm._263 = Int32.Parse(TextBox263.Text);
            dm._264 = Int32.Parse(TextBox264.Text);
            dm._265 = Int32.Parse(TextBox265.Text);
            dm._266 = Int32.Parse(TextBox266.Text);
            dm._267 = Int32.Parse(TextBox267.Text);
            dm._268 = Int32.Parse(TextBox268.Text);
            dm._269 = Int32.Parse(TextBox269.Text);
            dm._270 = Int32.Parse(TextBox270.Text);
            dm._271 = Int32.Parse(TextBox271.Text);
            dm._272 = Int32.Parse(TextBox272.Text);
            dm._273 = Int32.Parse(TextBox273.Text);
            dm._274 = Int32.Parse(TextBox274.Text);
            dm._275 = Int32.Parse(TextBox275.Text);
            dm._276 = Int32.Parse(TextBox276.Text);
            dm._277 = Int32.Parse(TextBox277.Text);
            dm._278 = Int32.Parse(TextBox278.Text);
            dm._279 = Int32.Parse(TextBox279.Text);
            dm._280 = Int32.Parse(TextBox280.Text);
            dm._281 = Int32.Parse(TextBox281.Text);
            dm._282 = Int32.Parse(TextBox282.Text);
            dm._283 = Int32.Parse(TextBox283.Text);
            dm._284 = Int32.Parse(TextBox284.Text);
            dm._285 = Int32.Parse(TextBox285.Text);
            dm._286 = Int32.Parse(TextBox286.Text);
            dm._287 = Int32.Parse(TextBox287.Text);
            dm._288 = Int32.Parse(TextBox288.Text);
            dm._289 = Int32.Parse(TextBox289.Text);
            dm._290 = Int32.Parse(TextBox290.Text);
            dm._291 = Int32.Parse(TextBox291.Text);
            dm._292 = Int32.Parse(TextBox292.Text);
            dm._293 = Int32.Parse(TextBox293.Text);
            dm._294 = Int32.Parse(TextBox294.Text);
            dm._295 = Int32.Parse(TextBox295.Text);
            dm._296 = Int32.Parse(TextBox296.Text);
            dm._297 = Int32.Parse(TextBox297.Text);
            dm._298 = Int32.Parse(TextBox298.Text);
            dm._299 = Int32.Parse(TextBox299.Text);
            dm._300 = Int32.Parse(TextBox300.Text);
            dm._301 = Int32.Parse(TextBox301.Text);
            dm._302 = Int32.Parse(TextBox302.Text);
            dm._303 = Int32.Parse(TextBox303.Text);
            dm._304 = Int32.Parse(TextBox304.Text);
            dm._305 = Int32.Parse(TextBox305.Text);
            dm._306 = Int32.Parse(TextBox306.Text);
            dm._307 = CheckBox307.Checked;
            dm._308 = CheckBox308.Checked;
            dm._309 = CheckBox309.Checked;
            dm._310 = CheckBox310.Checked;
            dm._311 = CheckBox311.Checked;
            dm._312 = CheckBox312.Checked;
            dm._313 = CheckBox313.Checked;
            dm._314 = CheckBox314.Checked;
            dm._315 = CheckBox315.Checked;
            dm._316 = CheckBox316.Checked;
            dm._317 = CheckBox317.Checked;
            dm._318 = CheckBox318.Checked;
            dm._319 = CheckBox319.Checked;
            dm._320 = CheckBox320.Checked;
            dm._321 = CheckBox321.Checked;
            dm._322 = CheckBox322.Checked;
            dm._323 = CheckBox323.Checked;
            dm._324 = CheckBox324.Checked;
            dm._325 = TextBox325.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._326 = CheckBox326.Checked;
            dm._327 = CheckBox327.Checked;
            dm._328 = CheckBox328.Checked;
            dm._329 = CheckBox329.Checked;
            dm._330 = TextBox330.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._331 = CheckBox331.Checked;
            dm._332 = CheckBox332.Checked;
            dm._333 = CheckBox333.Checked;
            dm._334 = CheckBox334.Checked;
            dm._335 = TextBox335.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._336 = CheckBox336.Checked;
            dm._337 = CheckBox337.Checked;
            dm._338 = CheckBox338.Checked;
            dm._339 = CheckBox339.Checked;
            dm._340 = TextBox340.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._341 = CheckBox341.Checked;
            dm._342 = CheckBox342.Checked;
            dm._343 = CheckBox343.Checked;
            dm._344 = CheckBox344.Checked;
            dm._345 = TextBox345.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._346 = CheckBox346.Checked;
            dm._347 = CheckBox347.Checked;
            dm._348 = CheckBox348.Checked;
            dm._349 = CheckBox349.Checked;
            dm._350 = TextBox350.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._351 = CheckBox351.Checked;
            dm._352 = CheckBox352.Checked;
            dm._353 = CheckBox353.Checked;
            dm._354 = CheckBox354.Checked;
            dm._355 = TextBox355.Text.Replace("\n", "<br />").Replace("'", "^");
            dc.Report_MerrylandsRSLCovidMarshalls.InsertOnSubmit(dm);
            dc.SubmitChanges();
        }

        //log the create activity
        RunStoredProcedure rsp = new RunStoredProcedure();
        try
        {
            rsp.Log(4, Int32.Parse(Report.LastReportId));
        }
        catch { }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        "alert('Report Submitted.'); window.location='" +
        Request.ApplicationPath + "Default.aspx';", true);
        SearchReport.SetAccordion = "1";
        SearchReport.RunOnStart = true;
        SearchReport.FromCreateReport = true;
    }

    protected int checkTexboxes()
    {
        int parsedValue, returnFlag = 2;
        if (!int.TryParse(TextBox1.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox1.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox2.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox2.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox3.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox3.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox4.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox4.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox5.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox5.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox6.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox6.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox7.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox7.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox8.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox8.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox9.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox9.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox10.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox10.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox11.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox11.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox12.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox12.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox13.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox13.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox14.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox14.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox15.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox15.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox16.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox16.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox17.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox17.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox18.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox18.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox19.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox19.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox20.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox110.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox21.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox21.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox22.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox22.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox23.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox23.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox24.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox24.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox25.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox25.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox26.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox26.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox27.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox27.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox28.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox28.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox29.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox29.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox30.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox30.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox31.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox31.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox32.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox32.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox33.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox33.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox34.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox34.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox35.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox35.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox36.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox36.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox37.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox37.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox38.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox38.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox39.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox39.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox40.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox40.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox41.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox41.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox42.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox42.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox43.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox43.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox44.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox44.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox45.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox45.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox46.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox46.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox47.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox47.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox48.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox48.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox49.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox49.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox50.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox50.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox51.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox51.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox52.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox52.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox53.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox53.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox54.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox54.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox55.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox55.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox56.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox56.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox57.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox57.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox58.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox58.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox59.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox59.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox60.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox60.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox61.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox61.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox62.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox62.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox63.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox63.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox64.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox64.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox65.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox65.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox66.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox66.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox67.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox67.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox68.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox68.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox69.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox69.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox70.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox70.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox71.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox71.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox72.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox72.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox73.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox73.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox74.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox74.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox75.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox75.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox76.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox76.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox77.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox77.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox78.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox78.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox79.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox79.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox80.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox80.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox81.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox81.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox82.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox82.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox83.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox83.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox84.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox84.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox85.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox85.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox86.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox86.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox87.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox87.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox88.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox88.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox89.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox89.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox90.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox90.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox91.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox91.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox92.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox92.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox93.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox93.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox94.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox94.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox95.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox95.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox96.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox96.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox97.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox97.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox98.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox98.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox99.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox99.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox100.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox100.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox101.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox101.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox102.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox102.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox103.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox103.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox104.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox104.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox105.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox105.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox106.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox106.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox107.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox107.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox108.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox108.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox109.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox109.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox110.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox110.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox111.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox111.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox112.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox112.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox113.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox113.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox114.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox114.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox115.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox115.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox116.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox116.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox117.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox117.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox118.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox118.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox119.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox119.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox120.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox120.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox121.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox121.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox122.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox122.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox123.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox123.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox124.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox124.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox125.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox125.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox126.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox126.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox127.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox127.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox128.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox128.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox129.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox129.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox130.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox130.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox131.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox131.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox132.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox132.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox133.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox133.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox134.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox134.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox135.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox135.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox136.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox136.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox137.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox137.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox138.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox138.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox139.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox139.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox140.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox140.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox141.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox141.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox142.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox142.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox143.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox143.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox144.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox144.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox145.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox145.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox146.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox146.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox147.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox147.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox148.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox148.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox149.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox149.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox150.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox150.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox151.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox151.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox152.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox152.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox153.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox153.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox154.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox154.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox155.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox155.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox156.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox156.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox157.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox157.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox158.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox158.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox159.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox159.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox160.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox160.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox161.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox161.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox162.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox162.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox163.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox163.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox164.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox164.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox165.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox165.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox166.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox166.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox167.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox167.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox168.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox168.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox169.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox169.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox170.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox170.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox171.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox171.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox172.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox172.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox173.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox173.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox174.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox174.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox175.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox175.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox176.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox176.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox177.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox177.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox178.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox178.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox179.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox179.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox180.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox180.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox181.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox181.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox182.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox182.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox183.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox183.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox184.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox184.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox185.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox185.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox186.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox186.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox187.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox187.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox188.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox188.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox189.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox189.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox190.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox190.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox191.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox191.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox192.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox192.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox193.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox193.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox194.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox194.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox195.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox195.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox196.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox196.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox197.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox197.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox198.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox198.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox199.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox199.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox200.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox200.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox201.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox201.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox202.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox202.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox203.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox203.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox204.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox204.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox205.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox205.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox206.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox206.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox207.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox207.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox208.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox208.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox209.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox209.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox210.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox210.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox211.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox211.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox212.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox212.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox213.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox213.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox214.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox214.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox215.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox215.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox216.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox216.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox217.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox217.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox218.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox218.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox219.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox219.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox220.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox220.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox221.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox221.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox222.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox222.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox223.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox223.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox224.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox224.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox225.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox225.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox226.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox226.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox227.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox227.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox228.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox228.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox229.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox229.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox230.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox230.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox231.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox231.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox232.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox232.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox233.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox233.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox234.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox234.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox235.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox235.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox236.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox236.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox237.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox237.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox238.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox238.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox239.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox239.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox240.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox240.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox241.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox241.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox242.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox242.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox243.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox243.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox244.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox244.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox245.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox245.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox246.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox246.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox247.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox247.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox248.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox248.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox249.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox249.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox250.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox250.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox251.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox251.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox252.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox252.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox253.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox253.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox254.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox254.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox255.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox255.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox256.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox256.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox257.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox257.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox258.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox258.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox259.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox259.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox260.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox260.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox261.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox261.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox262.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox262.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox263.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox263.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox264.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox264.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox265.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox265.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox266.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox266.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox267.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox267.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox268.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox268.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox269.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox269.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox270.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox270.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox271.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox271.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox272.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox272.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox273.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox273.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox274.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox274.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox275.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox275.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox276.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox276.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox277.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox277.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox278.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox278.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox279.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox279.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox280.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox280.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox281.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox281.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox282.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox282.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox283.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox283.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox284.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox284.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox285.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox285.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox286.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox286.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox287.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox287.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox288.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox288.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox289.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox289.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox290.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox290.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox291.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox291.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox292.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox292.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox293.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox293.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox294.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox294.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox295.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox295.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox296.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox296.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox297.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox297.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox298.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox298.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox299.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox299.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox300.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox300.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox301.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox301.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox302.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox302.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox303.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox303.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox304.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox304.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox305.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox305.Focus();
            returnFlag = 1;
        }

        if (!int.TryParse(TextBox306.Text, out parsedValue))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* FIELD MUST BE A NUMBER.";
            TextBox306.Focus();
            returnFlag = 1;
        }

        return returnFlag;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtGeneralComments.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox18.Text = "";
        TextBox19.Text = "";
        TextBox10.Text = "";
        TextBox21.Text = "";
        TextBox22.Text = "";
        TextBox23.Text = "";
        TextBox24.Text = "";
        TextBox25.Text = "";
        TextBox26.Text = "";
        TextBox27.Text = "";
        TextBox28.Text = "";
        TextBox29.Text = "";
        TextBox30.Text = "";
        TextBox31.Text = "";
        TextBox32.Text = "";
        TextBox33.Text = "";
        TextBox34.Text = "";
        TextBox35.Text = "";
        TextBox36.Text = "";
        TextBox37.Text = "";
        TextBox38.Text = "";
        TextBox39.Text = "";
        TextBox40.Text = "";
        TextBox41.Text = "";
        TextBox42.Text = "";
        TextBox43.Text = "";
        TextBox44.Text = "";
        TextBox45.Text = "";
        TextBox46.Text = "";
        TextBox47.Text = "";
        TextBox48.Text = "";
        TextBox49.Text = "";
        TextBox50.Text = "";
        TextBox51.Text = "";
        TextBox52.Text = "";
        TextBox53.Text = "";
        TextBox54.Text = "";
        TextBox55.Text = "";
        TextBox56.Text = "";
        TextBox57.Text = "";
        TextBox58.Text = "";
        TextBox59.Text = "";
        TextBox60.Text = "";
        TextBox61.Text = "";
        TextBox62.Text = "";
        TextBox63.Text = "";
        TextBox64.Text = "";
        TextBox65.Text = "";
        TextBox66.Text = "";
        TextBox67.Text = "";
        TextBox68.Text = "";
        TextBox69.Text = "";
        TextBox70.Text = "";
        TextBox71.Text = "";
        TextBox72.Text = "";
        TextBox73.Text = "";
        TextBox74.Text = "";
        TextBox75.Text = "";
        TextBox76.Text = "";
        TextBox77.Text = "";
        TextBox78.Text = "";
        TextBox79.Text = "";
        TextBox80.Text = "";
        TextBox81.Text = "";
        TextBox82.Text = "";
        TextBox83.Text = "";
        TextBox84.Text = "";
        TextBox85.Text = "";
        TextBox86.Text = "";
        TextBox87.Text = "";
        TextBox88.Text = "";
        TextBox89.Text = "";
        TextBox90.Text = "";
        TextBox91.Text = "";
        TextBox92.Text = "";
        TextBox93.Text = "";
        TextBox94.Text = "";
        TextBox95.Text = "";
        TextBox96.Text = "";
        TextBox97.Text = "";
        TextBox98.Text = "";
        TextBox99.Text = "";
        TextBox100.Text = "";
        TextBox101.Text = "";
        TextBox102.Text = "";
        TextBox103.Text = "";
        TextBox104.Text = "";
        TextBox105.Text = "";
        TextBox106.Text = "";
        TextBox107.Text = "";
        TextBox108.Text = "";
        TextBox109.Text = "";
        TextBox110.Text = "";
        TextBox111.Text = "";
        TextBox112.Text = "";
        TextBox113.Text = "";
        TextBox114.Text = "";
        TextBox115.Text = "";
        TextBox116.Text = "";
        TextBox117.Text = "";
        TextBox118.Text = "";
        TextBox119.Text = "";
        TextBox110.Text = "";
        TextBox121.Text = "";
        TextBox122.Text = "";
        TextBox123.Text = "";
        TextBox124.Text = "";
        TextBox125.Text = "";
        TextBox126.Text = "";
        TextBox127.Text = "";
        TextBox128.Text = "";
        TextBox129.Text = "";
        TextBox130.Text = "";
        TextBox131.Text = "";
        TextBox132.Text = "";
        TextBox133.Text = "";
        TextBox134.Text = "";
        TextBox135.Text = "";
        TextBox136.Text = "";
        TextBox137.Text = "";
        TextBox138.Text = "";
        TextBox139.Text = "";
        TextBox140.Text = "";
        TextBox141.Text = "";
        TextBox142.Text = "";
        TextBox143.Text = "";
        TextBox144.Text = "";
        TextBox145.Text = "";
        TextBox146.Text = "";
        TextBox147.Text = "";
        TextBox148.Text = "";
        TextBox149.Text = "";
        TextBox150.Text = "";
        TextBox151.Text = "";
        TextBox152.Text = "";
        TextBox153.Text = "";
        TextBox154.Text = "";
        TextBox155.Text = "";
        TextBox156.Text = "";
        TextBox157.Text = "";
        TextBox158.Text = "";
        TextBox159.Text = "";
        TextBox160.Text = "";
        TextBox161.Text = "";
        TextBox162.Text = "";
        TextBox163.Text = "";
        TextBox164.Text = "";
        TextBox165.Text = "";
        TextBox166.Text = "";
        TextBox167.Text = "";
        TextBox168.Text = "";
        TextBox169.Text = "";
        TextBox170.Text = "";
        TextBox171.Text = "";
        TextBox172.Text = "";
        TextBox173.Text = "";
        TextBox174.Text = "";
        TextBox175.Text = "";
        TextBox176.Text = "";
        TextBox177.Text = "";
        TextBox178.Text = "";
        TextBox179.Text = "";
        TextBox180.Text = "";
        TextBox181.Text = "";
        TextBox182.Text = "";
        TextBox183.Text = "";
        TextBox184.Text = "";
        TextBox185.Text = "";
        TextBox186.Text = "";
        TextBox187.Text = "";
        TextBox188.Text = "";
        TextBox189.Text = "";
        TextBox190.Text = "";
        TextBox191.Text = "";
        TextBox192.Text = "";
        TextBox193.Text = "";
        TextBox194.Text = "";
        TextBox195.Text = "";
        TextBox196.Text = "";
        TextBox197.Text = "";
        TextBox198.Text = "";
        TextBox199.Text = "";
        TextBox200.Text = "";
        TextBox201.Text = "";
        TextBox202.Text = "";
        TextBox203.Text = "";
        TextBox204.Text = "";
        TextBox205.Text = "";
        TextBox206.Text = "";
        TextBox207.Text = "";
        TextBox208.Text = "";
        TextBox209.Text = "";
        TextBox210.Text = "";
        TextBox211.Text = "";
        TextBox212.Text = "";
        TextBox213.Text = "";
        TextBox214.Text = "";
        TextBox215.Text = "";
        TextBox216.Text = "";
        TextBox217.Text = "";
        TextBox218.Text = "";
        TextBox219.Text = "";
        TextBox210.Text = "";
        TextBox221.Text = "";
        TextBox222.Text = "";
        TextBox223.Text = "";
        TextBox224.Text = "";
        TextBox225.Text = "";
        TextBox226.Text = "";
        TextBox227.Text = "";
        TextBox228.Text = "";
        TextBox229.Text = "";
        TextBox230.Text = "";
        TextBox231.Text = "";
        TextBox232.Text = "";
        TextBox233.Text = "";
        TextBox234.Text = "";
        TextBox235.Text = "";
        TextBox236.Text = "";
        TextBox237.Text = "";
        TextBox238.Text = "";
        TextBox239.Text = "";
        TextBox240.Text = "";
        TextBox241.Text = "";
        TextBox242.Text = "";
        TextBox243.Text = "";
        TextBox244.Text = "";
        TextBox245.Text = "";
        TextBox246.Text = "";
        TextBox247.Text = "";
        TextBox248.Text = "";
        TextBox249.Text = "";
        TextBox250.Text = "";
        TextBox251.Text = "";
        TextBox252.Text = "";
        TextBox253.Text = "";
        TextBox254.Text = "";
        TextBox255.Text = "";
        TextBox256.Text = "";
        TextBox257.Text = "";
        TextBox258.Text = "";
        TextBox259.Text = "";
        TextBox260.Text = "";
        TextBox261.Text = "";
        TextBox262.Text = "";
        TextBox263.Text = "";
        TextBox264.Text = "";
        TextBox265.Text = "";
        TextBox266.Text = "";
        TextBox267.Text = "";
        TextBox268.Text = "";
        TextBox269.Text = "";
        TextBox270.Text = "";
        TextBox271.Text = "";
        TextBox272.Text = "";
        TextBox273.Text = "";
        TextBox274.Text = "";
        TextBox275.Text = "";
        TextBox276.Text = "";
        TextBox277.Text = "";
        TextBox278.Text = "";
        TextBox279.Text = "";
        TextBox280.Text = "";
        TextBox281.Text = "";
        TextBox282.Text = "";
        TextBox283.Text = "";
        TextBox284.Text = "";
        TextBox285.Text = "";
        TextBox286.Text = "";
        TextBox287.Text = "";
        TextBox288.Text = "";
        TextBox289.Text = "";
        TextBox290.Text = "";
        TextBox291.Text = "";
        TextBox292.Text = "";
        TextBox293.Text = "";
        TextBox294.Text = "";
        TextBox295.Text = "";
        TextBox296.Text = "";
        TextBox297.Text = "";
        TextBox298.Text = "";
        TextBox299.Text = "";
        TextBox300.Text = "";
        TextBox301.Text = "";
        TextBox302.Text = "";
        TextBox303.Text = "";
        TextBox304.Text = "";
        TextBox305.Text = "";
        TextBox306.Text = "";
        CheckBox307.Checked = false;
        CheckBox308.Checked = false;
        CheckBox309.Checked = false;
        CheckBox310.Checked = false;
        CheckBox311.Checked = false;
        CheckBox312.Checked = false;
        CheckBox313.Checked = false;
        CheckBox314.Checked = false;
        CheckBox315.Checked = false;
        CheckBox316.Checked = false;
        CheckBox317.Checked = false;
        CheckBox318.Checked = false;
        CheckBox319.Checked = false;
        CheckBox320.Checked = false;

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
                    if (method.Equals("getStaff"))
                    {
                        Session["currentStaffId"] = rdr["StaffId"].ToString();
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
}