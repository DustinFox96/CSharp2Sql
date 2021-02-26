using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class StudentsController {
        /// <summary>
        /// This contains the SqlConnection that every class will need. It must be passed to the constructor of with controller
        /// </summary>
        private Connection connection { get; set; }

        // how we remove more than one id?
        public bool RemovedRanage(params int[] ids) {
            var success = true;
            foreach (var id in ids) {
                success &= Remove(id);
            }
            return success;
        }// this is remove
        public bool Remove(int id) {
            var sql = $"DELETE From Student Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }


        // this is for update I think, it is also a cleaner way of how to do things compared to down below 
        public bool Change(Student student) {
            var sql = $"UPDATE Student Set " +
                       " Firstname = @firstname, " +
                       " Lastname = @lastname, " +
                       " StateCode = @statecode, " +
                       " SAT = @sat," +
                       " GPA = @gpa " +
                       " Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@firstname", student.Firstname);// we are using cmd.Parameters.AddWithValue becasue it's going to add an value to the variable @firstname, so that the value of @firstname will be student.Firstname.
            cmd.Parameters.AddWithValue("@lastname", student.Lastname);
            cmd.Parameters.AddWithValue("@statecode", student.StateCode);
            cmd.Parameters.AddWithValue("@sat", student.SAT);
            cmd.Parameters.AddWithValue("@gpa", student.GPA);
            cmd.Parameters.AddWithValue("@id", student.Id);
            var recsAffected = cmd.ExecuteNonQuery();
            return (recsAffected == 1);
        }


        //these are for inserts I think?
        public bool Create(Student student) {
            var sql = $"INSERT into Student " +
                        " (Firstname, Lastname, StateCode, SAT, GPA) " +
                        $"VALUES ('{student.Firstname}', '{student.Lastname}', " +
                        $" '{student.StateCode}', {student.SAT}, {student.GPA});";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1); // or you could do rowsAffect == 1 ? true: false:

        }


        // we are pulling a student by their id here, this is a method where you can call it and put in the id.
        public Student GetByPk(int id) {
            var sql = $"SELECT * From Student Where id = {id};";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var hasRow = reader.Read();
            if(!hasRow) { // the (!) means has not
                return null;
            }
            var student = new Student();
            student.Id = Convert.ToInt32(reader["Id"]);
            student.Firstname = reader["Firstname"].ToString();
            student.Lastname = reader["LastName"].ToString();
            student.StateCode = reader["StateCode"].ToString();
            student.SAT = Convert.ToInt32(reader["SAT"]);
            student.GPA = Convert.ToDecimal(reader["GPA"]);
            //student.Major = null; // we commented this out because we are not joining 
            //if (reader["Description"] != System.DBNull.Value) {
            //    student.Major = reader["Description"].ToString();

                
            //}
            reader.Close();
            return student;

        }

          
        public List<Student> GetAll() {
            var sql = "SELECT * From Student";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var students = new List<Student>();
            while(reader.Read()) {
                var student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Firstname = reader["Firstname"].ToString();
                student.Lastname = reader["LastName"].ToString();
                student.StateCode = reader["StateCode"].ToString();
                student.SAT = Convert.ToInt32(reader["SAT"]);
                student.GPA = Convert.ToDecimal(reader["GPA"]);
                student.MajorId = null; // have becca explain this whole thing
                if (reader["MajorId"] != System.DBNull.Value) {
                    student.MajorId = Convert.ToInt32(reader["MajorId"]);

                    //student.MajorId = null; // have becca explain this whole thing
                    //if(reader["MajorId"] != System.DBNull.Value) {
                    //    student.MajorId = Convert.ToInt32(reader["MajorID"]);
                }
                students.Add(student);
            }
            reader.Close();
            return students;

        }

        public StudentsController(Connection connection) {
            this.connection = connection;
        }



    }
}
