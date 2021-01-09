using System; // exception
using System.Configuration; // configuration manager
using System.Data;  // data table, data row
using System.Data.SqlClient; // sql connection, sql command, sql adapter
using System.Text; // encoding

/// <summary>
/// Paolo Santiago 28/03/2018
/// Helper that runs the stored procedure
/// And can return values back to the controller
/// </summary>
public class RunStoredProcedure
{
    public RunStoredProcedure()
    {

    }

    public DataTable ReturnTable(string query)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                SqlCommand returnTable = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(returnTable); // create data adapter
                da.Fill(dt); // this will query your database and return the result to your data table
                conn.Close(); // close connection
                da.Dispose(); // dispose adapter
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: GetTable method under RunStoredProcedure class: " + ex.Message);
            }
        }

        return dt;
    }

    public int ReturnInteger(string query)
    {
        int count = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                SqlCommand returnValue = new SqlCommand(query, conn);
                conn.Open();
                count = (int)returnValue.ExecuteScalar(); // execute query and assign the count integer a value
                conn.Close(); // close connection
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: ReturnInteger method under RunStoredProcedure class: " + ex.Message);
            }
        }

        return count;
    }

    public string ReturnString(string query)
    {
        string value = "";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                SqlCommand returnValue = new SqlCommand(query, conn);
                conn.Open();
                value = (string)returnValue.ExecuteScalar(); // execute query and assign the value string a value
                conn.Close(); // close connection
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: ReturnString method under RunStoredProcedure class: " + ex.Message);
            }
        }

        return value;
    }

    public void UpdatePassword(string username, string password)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                string query = string.Concat("UPDATE [Staff] SET [Password]='", password, "' WHERE Username='", username, "'");
                SqlCommand updatePassword = new SqlCommand(query, conn);
                conn.Open();
                updatePassword.ExecuteNonQuery(); // execute query and assign the count integer a value
                conn.Close(); // close connection
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: UpdatePassword method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    public string EncryptPassword(string password) // encrypts password
    {
        try
        {
            byte[] encryptedByte = new byte[password.Length];
            encryptedByte = Encoding.UTF8.GetBytes(password);
            string encrypted = Convert.ToBase64String(encryptedByte);
            return encrypted;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: EncryptPassword method under RunStoredProcedure class: " + ex.Message);
        }
    }

    public string DecryptPassword(string encrypted)
    {
        UTF8Encoding encoder = new UTF8Encoding();
        Decoder utf8Decode = encoder.GetDecoder();
        byte[] decodeByte = Convert.FromBase64String(encrypted);
        int charCount = utf8Decode.GetCharCount(decodeByte, 0, decodeByte.Length);
        char[] decodedChar = new char[charCount];
        utf8Decode.GetChars(decodeByte, 0, decodeByte.Length, decodedChar, 0);
        string result = new String(decodedChar);
        return result;
    }

    // log the login activity
    public void Log()
    {
        try
        {
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                Log l = new Log();
                // enter log type which is: Login
                l.LogTypeID = 1;
                l.StaffID = Int32.Parse(UserCredentials.StaffId);
                l.DateStamp = DateTime.Now;
                dc.Logs.InsertOnSubmit(l);
                dc.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error: Login method under RunStoredProcedure class: " + ex.Message);
        }
    }

    // log the view/print activity
    public void Log(int logTypeId)
    {
        try
        {
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                Log l = new Log();
                // enter log type it is: 2=View; 3=Print
                l.LogTypeID = logTypeId;
                l.StaffID = Int32.Parse(UserCredentials.StaffId);
                l.ReportID = Int32.Parse(Report.Id);
                l.DateStamp = DateTime.Now;
                dc.Logs.InsertOnSubmit(l);
                dc.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error: Login method under RunStoredProcedure class: " + ex.Message);
        }
    }

    // log the view/print activity
    public void Log(int logTypeId, int reportId)
    {
        try
        {
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                Log l = new Log();
                // enter log type it is: 2=View; 3=Print
                l.LogTypeID = logTypeId;
                l.StaffID = Int32.Parse(UserCredentials.StaffId);
                l.ReportID = reportId;
                l.DateStamp = DateTime.Now;
                dc.Logs.InsertOnSubmit(l);
                dc.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error: Login method under RunStoredProcedure class: " + ex.Message);
        }
    }

    // check whether the user exist
    public bool UserExist(string username)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("Proc_UserExist", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@Username", username));

                var returnParameter = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;

                if (Int32.Parse(result.ToString()) > 0)
                {
                    return true;
                }
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: UserExist method under RunStoredProcedure class: " + ex.Message);
            }
        }
        return false;
    }

    // get user password
    public string GetPassword(string username)
    {
        string password = "";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("Proc_GetPassword", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                password = (cmd.Parameters["@Password"].Value).ToString();

                return password;
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: GetPassword method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    // get user group names
    public string GetGroupNames(string username)
    {
        string groupNames = "";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("Proc_GetGroupNames", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                cmd.Parameters.Add("@GroupNames", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                groupNames = (cmd.Parameters["@GroupNames"].Value).ToString();

                return groupNames;
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: GetGroupNames method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

}