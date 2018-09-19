using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSSystem.Model
{
    public class StudentCheckIn
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        
        public CourseDto CourseDto { get; set; }
        public Student Student { get; set; }
    }
}
