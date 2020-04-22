using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vp_project.Models
{
    public class FieldModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<CourseModel> courseTitle { get; set; }
        //public string courseTitle { get; set; }
    }
}
