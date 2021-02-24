using Microsoft.Data.SqlClient;
using System;


namespace CSharp2Sql {
    public class Edlib {
        // my attempt at making a method select from major, just copied what I had below
        public SqlConnection connection { get; set; }


        // in class assignment, read all classes 
        public void classSelect() {
            var sql = "SELECT * from Class;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read()) {
                var id = Convert.ToInt32(reader["id"]);
                var subject = reader["Subject"].ToString();
                var section = reader["section"].ToString();
                Console.WriteLine($"id = {id}, subject = {subject}|{section}");
            }
            reader.Close();
        }



        public void majorSelect() {
            var sql = "SELECT * from major;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read()) {
                var id = Convert.ToInt32(reader["id"]);
                var description = reader["Description"].ToString();
                var minsat = Convert.ToInt32(reader["MinSat"]); // this is an addition we did in class, something I did not do myself for HW
                Console.WriteLine($"id ={id}, description={description}|{minsat}");
              
            }
            reader.Close();// becca made this herself becasue it kept throwing exceptions before.
        }





       

        public void execSelect() {
            var sql = "SELECT * From Student where id < 5;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read()) {
                var id = Convert.ToInt32(reader["id"]);
                var lastname = reader["Lastname"].ToString();
                Console.WriteLine($"id={id}, lastname={lastname}");
            }
            reader.Close();
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
