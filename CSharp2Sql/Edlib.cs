using Microsoft.Data.SqlClient;
using System;


namespace CSharp2Sql {
    public class Edlib {

        public SqlConnection connection { get; set; }
       

        public void execSelect() {
            var sql = "SELECT * From Student";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read()) {
                var id = Convert.ToInt32(reader["id"]);
                var lastname = reader["Lastname"].ToString();
                Console.WriteLine($"id={id}, lastname={lastname}");
            }
        }


        // this process is creating a estbalish connection to our sql database 
        public void Connect(string database) {
            var connStr = $"server=localhost\\sqlexpress;" +
                            $"database ={database};" +
                            "trusted_connection=true;";
            connection = new SqlConnection(connStr);
            connection.Open();
            if(connection.State != System.Data.ConnectionState.Open) {
                throw new Exception("connection is not open!");
            }
        }
        public void Disconnect() {
            connection.Close();
        }
    }
}
