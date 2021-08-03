using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutor_Course_Details_API.Models
{
    public class TutorDetails
    {
        public long Id { get; set; }
        public string TutorName { get; set; }
        public string DepartmentName { get; set; }
        public string CourseName { get; set; }
    }
}
