using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vp_project.Models
{
    public class CourseModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? fieldId { get; set; }

        public FieldModel Fields { get; set; }
    }
}
