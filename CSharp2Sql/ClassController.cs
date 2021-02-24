using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace CSharp2Sql {

    public class ClassController {

        private Connection connection { get; set; }

        public ClassController(Connection connection) {
            this.connection = connection;
        }

        public bool Change(Class clss) {
            var sql = $"UPDATE Class Set " +
                        " Code = @code, " +
                        " Subject = @subject, " +
                        " Section = @section, " +
                        " InstructorId = @instuctorid, " +

        }



        public bool Create(Class clss) {
            var sql = $"INSERT into Class " +
                        "( Id, Code, Subject, Section, InstructorId " +
                        " VALUES (@id, @code, @subject, @instructorId)";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@id", clss.Id);
            cmd.Parameters.AddWithValue("@Code", clss.Code);
            cmd.Parameters.AddWithValue("@subject", clss.Subject);
            cmd.Parameters.AddWithValue("@section", clss.Section);
            cmd.Parameters.AddWithValue("@instructorid", clss.InstuctorId);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
            
        }



        public Class getByPk(int id) {
            var sql = $"SELECT * From Class Where Id = {id}";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var hasRow = reader.Read();
            if(!hasRow) {
                return null;
            }
            var clss = new Class();
            clss.Id = Convert.ToInt32(reader["Id"]);
            clss.Code = reader["Code"].ToString();
            clss.Subject = reader["Subject"].ToString();
            clss.Section = Convert.ToInt32(reader["Id"]);
            clss.InstuctorId = Convert.ToInt32(reader["InstructorId"]);

            reader.Close();
            return clss;
        }
        


        public List<Class> GetAll() {
            var sql = "SELECT * From Class";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var classes = new List<Class>();
            while(reader.Read()) {
                var clss = new Class();
                clss.Id = Convert.ToInt32(reader["Id"]);
                clss.Code = reader["Code"].ToString();
                clss.Subject = reader["Subject"].ToString();
                clss.Section = Convert.ToInt32(reader["Section"]);
                clss.InstuctorId = Convert.ToInt32(reader["InstructorId"]);
                classes.Add(clss);
            }
            reader.Close();
            return classes;
             

           

        }


    }

            
}           



            
           


        
    

