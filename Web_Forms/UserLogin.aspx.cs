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
                    groups = authUser.GetGroups(); // retrieve user groups + display name
                    groupArray = groups.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    Session["Username"] = txtUsername.Text;
                    UserCredentials.Username = txtUsername.Text; // record username
                    //UserCredentials.Password = EncryptPassword(txtPassword.Text); // record password

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

                    bool isCookiePersistent = false; // Create the ticket, and add the groups.
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(120), isCookiePersistent, groups);

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket); //Encrypt the ticket.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket); //Create a cookie, and then add the encrypted ticket to the cookie as data.

                    if (true == isCookiePersistent)
                        authCookie.Expires = authTicket.Expiration;

                    Response.Cookies.Add(authCookie); //Add the cookie to the outgoing cookies collection.
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text, false), false); //You can redirect now.
                }
                else
                {
                    errorLabel.Text = "Invalid details. Please check your username and password.";
                }
            }
        }
        catch (Exception ex)
        {
            errorLabel.Text = "Error logging in user. " + ex.Message;
        }
    }

    //public static string EncryptPassword(string password) // encrypts password
    //{
    //    try
    //    {
    //        byte[] encryptedByte = new byte[password.Length];
    //        encryptedByte = Encoding.UTF8.GetBytes(password);
    //        string encrypted = Convert.ToBase64String(encryptedByte);
    //        return encrypted;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Error: " + ex.Message);
    //    }
    //}   
}