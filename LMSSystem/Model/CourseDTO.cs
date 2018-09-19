using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSSystem.Model
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CourseDetail CourseDetail { get; set; }
        public ICollection<StudentCheckIn> StudentCheckIns { get; set; }
    }
}
