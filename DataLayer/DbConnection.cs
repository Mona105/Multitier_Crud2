using System;
using Microsoft.Data.SqlClient;
using CommanLayer.Models;

namespace DataLayer
{
    public class DbConnection
    {
        public SqlConnection cnn; 

        public DbConnection()
        {
            cnn = new SqlConnection(Connection.ConnectionStr);
        }
    }
}
