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
}