using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Fansoft.Store.Data.ADO
{
    public class FanSoftStoreDataContext : IDisposable
    {
        private readonly SqlConnection _conn;
        public FanSoftStoreDataContext()
        {
            var connString = 
                ConfigurationManager.ConnectionStrings["FansoftStoreDB"].ConnectionString;
            _conn = new SqlConnection(connString);
            _conn.Open();
        }

        public void ExecuteCMD(string sql)
        {
            var command = new SqlCommand() {
                CommandText = sql,
                CommandType = System.Data.CommandType.Text,
                Connection = _conn
            };
            command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteCommandWithReturn(string sql)
        {
            var command = new SqlCommand(sql, _conn);
            return command.ExecuteReader();
        }


        public void Dispose()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Close();
        }
    }
}
