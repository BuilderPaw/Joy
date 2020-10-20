using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_CU_Covid_Marshall_Create_v1_v1 : System.Web.UI.Page
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
        string query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_ClubUminaCovidMarshall";
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
            lastRId = 11000001;
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
            Report_ClubUminaCovidMarshall dm = new Report_ClubUminaCovidMarshall();
            dm.ReportId = Int32.Parse(Report.LastReportId);
            dm.RCatId = 11; // CU Covid Marshall Category
            dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
            dm.StaffName = UserCredentials.DisplayName;
            dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
            dm.ShiftDate = shift_date.Date;
            dm.ShiftDOW = shift_DOW;
            dm.EntryDate = entry_date;
            dm.Report_Table = "Report_ClubUminaCovidMarshall";
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
            dm._65 = CheckBox65.Checked;
            dm._66 = CheckBox66.Checked;
            dm._67 = CheckBox67.Checked;
            dm._68 = CheckBox68.Checked;
            dm._69 = CheckBox69.Checked;
            dm._70 = CheckBox70.Checked;
            dm._71 = CheckBox71.Checked;
            dm._72 = CheckBox72.Checked;
            dm._73 = CheckBox73.Checked;
            dm._74 = CheckBox74.Checked;
            dm._75 = CheckBox75.Checked;
            dm._76 = CheckBox76.Checked;
            dm._77 = CheckBox77.Checked;
            dm._78 = CheckBox78.Checked;
            dm._79 = CheckBox79.Checked;
            dm._80 = CheckBox80.Checked;
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
            dm._145 = CheckBox145.Checked;
            dm._146 = CheckBox146.Checked;
            dm._147 = CheckBox147.Checked;
            dm._148 = CheckBox148.Checked;
            dm._149 = CheckBox149.Checked;
            dm._150 = CheckBox150.Checked;
            dm._151 = CheckBox151.Checked;
            dm._152 = CheckBox152.Checked;
            dm._153 = CheckBox153.Checked;
            dm._154 = CheckBox154.Checked;
            dm._155 = CheckBox155.Checked;
            dm._156 = CheckBox156.Checked;
            dm._157 = CheckBox157.Checked;
            dm._158 = CheckBox158.Checked;
            dm._159 = CheckBox159.Checked;
            dm._160 = CheckBox160.Checked;
            dm._161 = CheckBox161.Checked;
            dm._162 = CheckBox162.Checked;
            dm._163 = CheckBox163.Checked;
            dm._164 = CheckBox164.Checked;
            dm._165 = CheckBox165.Checked;
            dm._166 = CheckBox166.Checked;
            dm._167 = CheckBox167.Checked;
            dm._168 = CheckBox168.Checked;
            dm._169 = CheckBox169.Checked;
            dm._170 = CheckBox170.Checked;
            dm._171 = CheckBox171.Checked;
            dm._172 = CheckBox172.Checked;
            dm._173 = CheckBox173.Checked;
            dm._174 = CheckBox174.Checked;
            dm._175 = CheckBox175.Checked;
            dm._176 = CheckBox176.Checked;
            dm._177 = CheckBox177.Checked;
            dm._178 = CheckBox178.Checked;
            dm._179 = TextBox179.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._180 = CheckBox180.Checked;
            dm._181 = CheckBox181.Checked;
            dm._182 = CheckBox182.Checked;
            dm._183 = CheckBox183.Checked;
            dm._184 = TextBox184.Text.Replace("\n", "<br />").Replace("'", "^");
            dm._185 = CheckBox185.Checked;
            dm._186 = CheckBox186.Checked;
            dm._187 = CheckBox187.Checked;
            dm._188 = CheckBox188.Checked;
            dm._189 = TextBox189.Text.Replace("\n", "<br />").Replace("'", "^");
            dc.Report_ClubUminaCovidMarshalls.InsertOnSubmit(dm);
            dc.SubmitChanges();
        }

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
        CheckBox65.Checked = false;
        CheckBox66.Checked = false;
        CheckBox67.Checked = false;
        CheckBox68.Checked = false;
        CheckBox69.Checked = false;
        CheckBox70.Checked = false;
        CheckBox71.Checked = false;
        CheckBox72.Checked = false;
        CheckBox73.Checked = false;
        CheckBox74.Checked = false;
        CheckBox75.Checked = false;
        CheckBox76.Checked = false;
        CheckBox77.Checked = false;
        CheckBox78.Checked = false;
        CheckBox79.Checked = false;
        CheckBox80.Checked = false;
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
        CheckBox145.Checked = false;
        CheckBox146.Checked = false;
        CheckBox147.Checked = false;
        CheckBox148.Checked = false;
        CheckBox149.Checked = false;
        CheckBox150.Checked = false;
        CheckBox151.Checked = false;
        CheckBox152.Checked = false;
        CheckBox153.Checked = false;
        CheckBox154.Checked = false;
        CheckBox155.Checked = false;
        CheckBox156.Checked = false;
        CheckBox157.Checked = false;
        CheckBox158.Checked = false;
        CheckBox159.Checked = false;
        CheckBox160.Checked = false;
        CheckBox161.Checked = false;
        CheckBox162.Checked = false;
        CheckBox163.Checked = false;
        CheckBox164.Checked = false;
        CheckBox165.Checked = false;
        CheckBox166.Checked = false;
        CheckBox167.Checked = false;
        CheckBox168.Checked = false;
        CheckBox169.Checked = false;
        CheckBox170.Checked = false;
        CheckBox171.Checked = false;
        CheckBox172.Checked = false;
        CheckBox173.Checked = false;
        CheckBox174.Checked = false;
        CheckBox175.Checked = false;
        CheckBox176.Checked = false;
        CheckBox177.Checked = false;
        CheckBox178.Checked = false;
        TextBox179.Text = "";
        CheckBox180.Checked = false;
        CheckBox181.Checked = false;
        CheckBox182.Checked = false;
        CheckBox183.Checked = false;
        TextBox184.Text = "";
        CheckBox185.Checked = false;
        CheckBox186.Checked = false;
        CheckBox187.Checked = false;
        CheckBox188.Checked = false;
        TextBox189.Text = "";
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