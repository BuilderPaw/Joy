using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Caretaker_Edit_v1_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Report.PopulateFields) // checks whether or not the method reads the fields from the database
        {
            List_Location.Items.Clear();
            readFiles(Report.ActiveReport, "getFields");
            Report.PopulateFields = false;
        }
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
                        /* Populate the Checkbox list for Location and tick necessary checkbox */
                        string location = rdr["Spare1"].ToString().Replace("<br />", "\n").Replace("^", "'"), populateLocationList;
                        // set query to populate the location list
                        if (!string.IsNullOrEmpty(location))
                        {
                            location = location.Remove(location.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list
                            // order by query sets the Other value from Description field to be in the last of the the list  "SELECT * FROM [dbo].[List_GallipoliLocation] WHERE [Active] = 1
                            populateLocationList = "SELECT * FROM [dbo].[List_GallipoliLocation] WHERE ([Active] = 1 OR [LocationID] IN (" + location + "))";
                        }
                        else
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateLocationList = "SELECT * FROM [dbo].[List_GallipoliLocation] WHERE [Active] = 1";
                        }
                        // populate the location list
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = populateLocationList;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    item.Value = sdr["LocationId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    List_Location.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }
                        // tick the checkbox for selected location
                        string[] arrLocation = rdr["Spare1"].ToString().Replace("<br />", "\n").Replace("^", "'").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_Location.Items)
                        {
                            for (int i = 0; i < arrLocation.Length; i++)
                            {
                                if (arrLocation[i].ToString().Replace("<br />", "\n").Replace("^", "'").Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        lblReportName.Text = rdr["ReportName"].ToString();
                        lblReportId.Text = rdr["ReportId"].ToString();
                        lblStaffName.Text = rdr["StaffName"].ToString();
                        Report.SelectedStaffId = rdr["StaffId"].ToString();
                        //ddlShift.SelectedIndex = Int32.Parse(rdr["ShiftId"].ToString());
                        //Report.ShiftId = ddlShift.SelectedIndex.ToString();
                        txtDatePicker.Text = Convert.ToDateTime(rdr["ShiftDate"]).ToString("dddd, dd MMMM yyyy");
                        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
                        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
                        lblEntryDetails.Text = Convert.ToDateTime(rdr["EntryDate"]).ToString("dd/MM/yyyy HH:mm");
                        Report.EntryDate = Convert.ToDateTime(rdr["EntryDate"]).ToString();
                        txtOccupancy.Text = rdr["Occupancy"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtMaintenance.Text = rdr["Maintenance"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtGeneralComments.Text = rdr["GeneralComments"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        // set the Global variables to the current fields
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
                        if (ReportCaretakerMr.Location.ToString() != rdr["Spare1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Location";
                        }
                        if (ReportCaretakerMr.Occupancy != rdr["Occupancy"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Occupancy";
                        }
                        if (ReportCaretakerMr.Maintenance != rdr["Maintenance"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Maintenance";
                        }
                        if (ReportCaretakerMr.GeneralComments != rdr["GeneralComments"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "GeneralComments";
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
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void List_Location_SelectedIndexChanged(object sender, EventArgs e)
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
        Report.HasErrorMessage1 = false;

        // General Incident Report Form
        //if (ddlShift.SelectedItem.Value.ToString() == "-1")
        //{
        //    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";
        //    ddlShift.Focus();
        //    Report.HasErrorMessage1 = true;
        //}

        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            Report.HasErrorMessage1 = true;
        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            Report.HasErrorMessage1 = true;
        }
        else
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                Report.HasErrorMessage1 = true;
            }
        }

        Report.RunEditMode = true;
        //Report.ShiftId = ddlShift.SelectedItem.Value;
        if (Report.HasErrorMessage1.Equals(false))
        {
            Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
            Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
        }
        SetStaticVariable();
        readFiles(Report.ActiveReport, "checkChanges");
    }

    protected void SetStaticVariable()
    {
        string Location;
        List<String> YrStrList1 = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_Location.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                YrStrList1.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        Location = String.Join(",", YrStrList1.ToArray());
        List<string> uniques4 = Location.Split(',').Distinct().ToList(); // to remove duplicate values
        Location = string.Join(",", uniques4);
        if (!Location.Equals(""))
        {
            Location += ",";
        }

        ReportCaretakerMr.Location = Location;
        ReportCaretakerMr.Occupancy = txtOccupancy.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportCaretakerMr.Maintenance = txtMaintenance.Text.Replace("\n", "<br />").Replace("'", "^");
        ReportCaretakerMr.GeneralComments = txtGeneralComments.Text.Replace("\n", "<br />").Replace("'", "^");
    }
}