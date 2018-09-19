using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSSystem.Model
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int CourseId { get; set; }
        public int CourseCredit { get; set; }
        public int StudentLimit { get; set; }
        public CourseDto Course { get; set; }
    }
}
