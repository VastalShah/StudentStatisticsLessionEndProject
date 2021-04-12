using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentStatistics.Models
{
    public class StudentModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public int DBMS_Marks { get; set; }
        public int Data_Structures_Marks { get; set; }
    }
}
