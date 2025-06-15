using Microsoft.Data.SqlClient;
namespace SchoolManagementSystemTest.Forms;
public static class HandleConnection
{
    public static readonly string ConnectionString = $"Server=DESKTOP-IBQJ98S\\SQLEXPRESS;Database=sms;Trusted_Connection=true;TrustServerCertificate=true;";
    public static SqlConnection? GetConnection()
    {
        SqlConnection? conn = new SqlConnection(ConnectionString);
        try
        {
            conn.Open();
            return conn;
        }
        catch (SqlException ex)
        {
            MessageBox.Show("Connection failed: " + ex.Message);
            return null;
        }
    }
}
