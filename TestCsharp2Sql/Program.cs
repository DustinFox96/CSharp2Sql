using CSharp2Sql;
using System;

namespace TestCsharp2Sql {
    class Program {
        static void Main(string[] args) {

            var sql = new Edlib();
            sql.Connect("EdDb");
            Console.WriteLine("connected successfully!");
            sql.execSelect();

            sql.Disconnect();
        }
    }
}
