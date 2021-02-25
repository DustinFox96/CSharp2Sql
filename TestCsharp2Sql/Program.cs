using CSharp2Sql;
using System;

namespace TestCsharp2Sql {
    class Program {  
        static void Main(string[] args) {
            var conn = new Connection();
            conn.Connect("EdDb");

            var majorController = new MajorsController(conn);

            var newMajor = new Major {
             Code = "UWB2", Description = $"Under Water Basket Weaving2", MinSat = 1200
            };

           
            var success = majorController.Create(newMajor);
            Console.WriteLine($"{success}");

            var majorsList = majorController.GetAll();
            foreach(Major m in majorsList) {
                Console.WriteLine($"{m.Code}, {m.Description}, {m.MinSat}");
            }

            // here we are creating a connection that allows us to connect and view all the tables without having to multipleclass connections for more tables, we are breaking things up to make it more neat
            //var conn = new Connection();
            //conn.Connect("EdDb");
            //var studentController = new StudentsController(conn);

            //this is for the insert I think?
            //var newStudent = new Student {
            //    Id = 0, Firstname = "Joseph", Lastname = "Biden", StateCode = "DC", SAT = 1300, GPA = 3.2m, Major = null
            //};
            //var success = studentController.Create(newStudent); // commented these out so it stops adding more joes

            //newStudent.Id = 61;
            //var success = studentController.Change(newStudent);


            //var student = studentController.GetByPk(61); // have becaa explain this 
            //Console.WriteLine($"{student.Id}|{student.Firstname} {student.Lastname}|");

            //success = studentController.Remove(61);
            //Console.WriteLine($"Remove worked? {success}");

            //success = studentController.RemovedRanage(63, 64, 65);

            //var students = studentController.GetAll();
            //foreach(var s in students) {
            //    Console.WriteLine($"{s.Id}|{s.Firstname} {s.Lastname}|{s.Major}");
            //} // commented these out so it stops adding more joes
            conn.Disconnect();
           











            // format before we started moding it, this is the simple version.
            //var sql = new Edlib();
            //sql.Connect("EdDb");
            //Console.WriteLine("connected successfully!");
            //sql.execSelect();
            //sql.majorSelect(); // my attempt at making a method select from major, just copied what I had already
            //sql.classSelect(); // in class assignment to pull from class
            //sql.Disconnect();
        }
    }
}
