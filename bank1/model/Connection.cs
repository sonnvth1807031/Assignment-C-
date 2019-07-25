using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace bank1.model
{
    public class Connection
    {
        private const string ServerName = "localhost";
        private const string DatabaseName = "bank";
        private const string Username = "root";
        private const string Password = "";
        
        private static MySqlConnection _mySqlConnection;
        public static MySqlConnection GetConnection()
        {
            if (_mySqlConnection == null || _mySqlConnection.State == ConnectionState.Closed)
            {
                _mySqlConnection = new MySqlConnection($"Server={ServerName};Database={DatabaseName};Uid={Username};Pwd={Password};SslMode=none");
                _mySqlConnection.Open();
            }            
            return _mySqlConnection;
        }
        
        public static void CloseConnection()
        {
            if (_mySqlConnection == null || _mySqlConnection.State == ConnectionState.Closed)
            {
                return;
            }            
            _mySqlConnection.Close();
        }

        public static object Instance()
        {
            throw new NotImplementedException();
        }
    }
}