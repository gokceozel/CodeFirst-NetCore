using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
