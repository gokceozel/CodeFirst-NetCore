using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Data.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int GradeCode { get; set; }
        public Grade Grade { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
