using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // String Builder
using System.Web; // Http Cookie
using System.Web.Hosting; // Hosting Environment
using System.Web.Security; // Forms Authentication
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string groups, displayName;
        string[] groupArray;
        StringBuilder groupsList = new StringBuilder();

        AuthenticateUser authUser = new AuthenticateUser("LDAP://MRSLGROUP");
        try
        {
            using (HostingEnvironment.Impersonate())
            {
                if (true == authUser.IsAuthenticated("MRSLGROUP", txtUsername.Text, txtPassword.Text)) // check if login details are valid - checking from Active Directory User Account details
                {
                    groups = authUser.GetGroups(txtUsername.Text); // retrieve user groups + display name
                    groupArray = groups.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    Session["Username"] = txtUsername.Text;
                    UserCredentials.Username = txtUsername.Text; // record username

                    SearchReport.UnreadDateLength = "-14"; // set the Unread Date Limit to, currently 14 days earlier
                    Session["UnreadDateLength"] = SearchReport.UnreadDateLength.Substring(1, SearchReport.UnreadDateLength.Length-1);


                    displayName = groupArray[groupArray.Length - 1];
                    Session["DisplayName"] = displayName;
                    UserCredentials.DisplayName = displayName;
                    groupArray = groupArray.Take(groupArray.Count() - 1).ToArray(); // delete the last array item (display name), to keep this array variable set to usr groups only
                    for(int i =0; i <groupArray.Length; i++)
                    {
                        groupsList.Append(groupArray[i]); // store group name
                        groupsList.Append("|"); // add a back slash delimeter
                    }
                    groups = groupsList.ToString(); // set user groups
                    UserCredentials.Groups = groups;

                    SqlQuery sqlQuery = new SqlQuery();
                    string query = "SELECT * FROM Staff WHERE Username = '" + Session["Username"] + "'",
                           data = "CheckStaffExist";
                    sqlQuery.RetrieveData(query, data); // check if staff is registered in the database

                    sqlQuery.RetrieveData(query, data); // run this method again just in case the Staff Name has just been created

                    RunStoredProcedure rsp = new RunStoredProcedure();
                    // encrypt password
                    string encryptedPassword = rsp.EncryptPassword(txtPassword.Text);
                    // update password stored in the database
                    rsp.UpdatePassword(txtUsername.Text, encryptedPassword);

                    // log the login activity
                    try
                    {
                        rsp.Log();
                    }
                    catch { }

                    bool isCookiePersistent = false; // Create the ticket, and add the groups.
                                                     // set expiration of the authentication ticket - current set: 720 minutes / 12 hours
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(720), isCookiePersistent, groups);

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket); //Encrypt the ticket.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket); //Create a cookie, and then add the encrypted ticket to the cookie as data.

                    if (true == isCookiePersistent)
                        authCookie.Expires = authTicket.Expiration;

                    Response.Cookies.Add(authCookie); //Add the cookie to the outgoing cookies collection.
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text, false), false); //You can redirect now.
                }
                else
                {
                    bool passwordGiven = CheckIfPasswordIsGiven();

                    if (!passwordGiven)
                    {
                        errorLabel.Text = "Invalid details. Please check your username and password.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            bool passwordGiven = CheckIfPasswordIsGiven();

            if (!passwordGiven)
            {
                errorLabel.Text = "Error logging in user. " + ex.Message;
            }
        }
    }

    private bool CheckIfPasswordIsGiven()
    {
        bool passwordGiven = true;

        RunStoredProcedure rsp = new RunStoredProcedure();
        string userPassword = rsp.GetPassword(txtUsername.Text);

        if (string.Equals(userPassword, txtPassword.Text))
        {
            // hide the current objetcs displayed and display a textbox to write their new password
            divLogin.Visible = false;
            divNewPassword.Visible = true;
            txtNewPassword.Focus();
            passwordGiven = true;
        }
        else
        {
            passwordGiven = false;
        }

        return passwordGiven;
    }

    protected void btnUpdatePassword_Click(object sender, EventArgs e)
    {
        // once the new password is submitted, redirect them to the default url
        // update the password for this user
        RunStoredProcedure rsp = new RunStoredProcedure();
        // join these two methods together
        // encrypt password
        string encryptedPassword = rsp.EncryptPassword(txtNewPassword.Text);
        // update password stored in the database
        rsp.UpdatePassword(txtUsername.Text, encryptedPassword);
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password updated');location.href='/Web_Forms/Default.aspx';", true); // show alert textbox first then redirect to default url

        AlertMessage alert = new AlertMessage();
        alert.DisplayMessage("Password updated!");

        // hide the current objetcs displayed and display a textbox to write their new password
        divLogin.Visible = true;
        divNewPassword.Visible = false;
        txtUsername.Focus();
    }
}