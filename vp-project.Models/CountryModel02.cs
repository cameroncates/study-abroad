using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vp_project.Models
{
    public class CountryModel02
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public List<BasicModel> UNIVERSITY_COUNT { get; set; }
        public List<BasicModel> DEGREE_COUNT { get; set; }
    }
}
