using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;


// my attempt at the homework, might be wrong, see up above for the correct way we did in class

namespace CSharp2Sql {
    public class MajorsController {

        private Connection connection { get; set; }

        public MajorsController(Connection connection) {
            this.connection = connection;
        }

        public bool Remove(int id) {
            var sql = $"DELETE From Major Where Id = {"@id"};";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }



        public bool Change(Major major) {
            var sql = $"UPDATE Major set " +
                        "Code = @code, " +
                        "Description = @description, " +
                        "MinSat = @minsat, " +
                        "Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@code", major.Code);
            cmd.Parameters.AddWithValue("@description", major.Description);
            cmd.Parameters.AddWithValue("@minsat", major.MinSat);
            cmd.Parameters.AddWithValue("@id", major.Id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);

        }




        public bool Create(Major major) {
            var sql = $"INSERT into Major " +
                "(Code, Description, MinSat) " +
                "VALUES (@code, @description, @minsat)";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
           
            cmd.Parameters.AddWithValue("@code", major.Code);
            cmd.Parameters.AddWithValue("@description", major.Description);
            cmd.Parameters.AddWithValue("@minsat", major.MinSat);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);




        }




        public Major getByPk(int id) {
            var sql = $"SELECT * From Major Where id = {id}";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var hasRow = reader.Read();
            if (!hasRow) {
                return null;
            }
            var major = new Major();
            major.Id = Convert.ToInt32(reader["id"]);
            major.Code = reader["Code"].ToString();
            major.Description = reader["Description"].ToString();
            major.MinSat = Convert.ToInt32(reader["MinSat"]);

            reader.Close();
            return major;



        }



        public List<Major> GetAll() {
            var sql = "SELECT * From Major";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var majors = new List<Major>();
            while (reader.Read()) {
                var major = new Major();
                major.Id = Convert.ToInt32(reader["Id"]);
                major.Code = reader["Code"].ToString();
                major.Description = reader["Description"].ToString();
                major.MinSat = Convert.ToInt32(reader["MinSat"]);
                majors.Add(major);
            }
            reader.Close();
            return majors;

        }

    }
}





