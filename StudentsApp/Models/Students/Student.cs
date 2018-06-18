using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsCRUDApp.Models.Students
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastn { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public int Score { get; set; }
    }
}
