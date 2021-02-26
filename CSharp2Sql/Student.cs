using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    public class Student {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StateCode { get; set; }
        public int SAT { get; set; }
        public decimal GPA { get; set; }
        public int? MajorId { get; set; } // this was added so we could do a join froms student to major, have becca explain this
        //public int? MajorId { get; set; } // the (?) after int means it allows it to be null// sql null and C# null are not the same thing

    }
}
