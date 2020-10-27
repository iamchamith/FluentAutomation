using System.Data;
using System.Data.SqlClient;

namespace FluentAutomation.Utility
{
    public class Database
    {
        public string ConnectionString { get; set; }
        private IDbConnection _sqlConnection { get; set; }
        public Database(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public IDbConnection GetConnection() {

            if (_sqlConnection.IsNull())
                _sqlConnection = new SqlConnection(ConnectionString);
            if (_sqlConnection.State != ConnectionState.Open)
                _sqlConnection.Open();
            return _sqlConnection;
        }
    }
}
