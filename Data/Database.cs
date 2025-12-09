using Microsoft.Data.SqlClient;

namespace WinFormsApp1.Data
{
    public static class Database
    {
        private static readonly string connectionString =
            @"Server=DESKTOP-JK8OSHD\THANHBINHCSDL;
              Database=NET1;
              Trusted_Connection=True;
              Encrypt=False;
              TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
