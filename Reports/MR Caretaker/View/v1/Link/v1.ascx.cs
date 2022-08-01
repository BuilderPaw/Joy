using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Caretaker_View_v1_Link_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserCredentials.GroupsQuery.Contains("Caretaker") || UserCredentials.GroupsQuery.Contains("Senior Manager") || UserCredentials.GroupsQuery.Contains("Override"))  // if it is a member of Senior Manager display the report
        {
            dmReport.Visible = true;
            readFiles(Report.LinkedReport, "getFields");
        }
        else
        {
            dmReport.Visible = false;
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

                        // Populate the Checkbox for Location and tick necessary checkbox
                        string locationVariable = rdr["Spare1"].ToString(), cmdQuery2;

                        if (!string.IsNullOrEmpty(locationVariable))
                        {
                            locationVariable = locationVariable.Remove(locationVariable.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list

                            cmdQuery2 = "SELECT * FROM [dbo].[List_GallipoliLocation] WHERE ([Active] = 1 OR [LocationID] IN (" + locationVariable + "))";
                        }
                        else
                        {
                            cmdQuery2 = "SELECT * FROM [dbo].[List_GallipoliLocation] WHERE [Active] = 1";
                        }

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = cmdQuery2;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["LocationId"].ToString();
                                    List_Location.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        string[] arrLocation = rdr["Spare1"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_Location.Items)
                        {
                            for (int i = 0; i < arrLocation.Length; i++)
                            {
                                if (arrLocation[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
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