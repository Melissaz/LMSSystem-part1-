using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSSystem.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public int CourseLimit{ get; set; }

        public ICollection<StudentCheckIn> StudentCheckIns { get; set; }
    }
}
