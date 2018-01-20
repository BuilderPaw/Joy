using System;
using System.DirectoryServices;
using System.Text;
using System.Web.Hosting;

/// <summary>
/// This class mimics the Lightweight Directory Access Protocol (LDAP) Authentication stucture
/// wherein users login similar to their computer login - points at the Active Directory path
/// </summary>
public class AuthenticateUser
{
    private string path, filterAttribute;

    public AuthenticateUser(string pathWay)
    {
        path = pathWay;
    }

    public bool IsAuthenticated(string domain, string username, string password)
    {
        string domainAndUsername = domain + @"\" + username;
        DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, password);

        using (HostingEnvironment.Impersonate()) // Provides application-management functions and application services to a managed application within its application domain. Impersonates the user represented by the application identity.
        {
            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");

                foreach (SearchResult result in search.FindAll())
                {
                    if (null != result)
                    {
                        path = result.Path; 
                        filterAttribute = (string)result.Properties["cn"][0]; // Picks up the display name from Active Directory
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }
            return true;
        }
    }

    public string GetGroups()
    {
        DirectorySearcher search = new DirectorySearcher(path);
        search.Filter = "(cn=" + filterAttribute + ")";
        search.PropertiesToLoad.Add("memberOf");
        StringBuilder groupNames = new StringBuilder();

        using (HostingEnvironment.Impersonate())
        {
            try
            {
                SearchResult result = search.FindOne();
                int propertyCount = result.Properties["memberOf"].Count, equalIndex, commaIndex;
                string dn, grp;

                for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                {
                    dn = (string)result.Properties["memberOf"][propertyCounter];
                    equalIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalIndex)
                    {
                        return null;
                    }
                    grp = dn.Substring((equalIndex + 1), (commaIndex - equalIndex) - 1); // Retrieves the Group Name in Active Directory

                    if (grp.Contains("MRReports") || grp.Contains("CUReports")) // if group name contains the following conditions, add it to group names and append a back slash
                    {
                        groupNames.Append(grp);
                        groupNames.Append("|");
                    }
                }
                groupNames.Append(filterAttribute); // append the user's display name after the list of groups
            }
            catch (Exception ex)
            {
                throw new Exception("Error obtaining group names. " + ex.Message);
            }
            return groupNames.ToString();
        }
    }
}