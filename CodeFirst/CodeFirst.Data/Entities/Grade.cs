using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Data.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public List<Student> Students { get; set; }
    }
}
