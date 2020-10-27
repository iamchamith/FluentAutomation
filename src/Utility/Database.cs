using System.Data;
using System.Data.SqlClient;

namespace FluentAutomation.Utility
{
    public class Database
    {
        public string _connectionString { get; set; }
        private IDbConnection _sqlConnection { get; set; }
        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection GetConnection() {

            if (_sqlConnection.IsNull())
                _sqlConnection = new SqlConnection(_connectionString);
            if (_sqlConnection.State != ConnectionState.Open)
                _sqlConnection.Open();
            return _sqlConnection;
        }
    }
}
