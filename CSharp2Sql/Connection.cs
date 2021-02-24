using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {

    public class Connection { 
        // here we are creating a Sqlconnection that allows us to connent and view all the tables without having to have multiple methods beside our connection, this is to make things more neat.
        public SqlConnection sqlconnection { get; set; }

        public void Connect(string database) {
            var connStr = $"server=localhost\\sqlexpress;" +
                          $"database={database};" +
                          $"trusted_connection=true;";
            sqlconnection = new SqlConnection(connStr);
            sqlconnection.Open();
            if(sqlconnection.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection did not open");
            }
        }

        public void Disconnect() {
            sqlconnection.Close();
        }
    }
}
