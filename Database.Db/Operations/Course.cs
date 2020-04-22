using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vp_project.Models;

namespace Database.Db.Operations
{
    public class Course
    {
        public List<BasicModel> _GET_ONLY_COURSE(int LIMIT, string KEYWORDS)
        {
            if (KEYWORDS == null)
                KEYWORDS = "";
            using (var CONTEXT = new vpprojectDBEntities())
            {
                var RESULT = (
                    from COURSE in CONTEXT.Courses
                    where COURSE.title.Contains(KEYWORDS)
                    select new BasicModel
                    {
                        id = COURSE.id,
                        title = COURSE.title,
                    }).Take(LIMIT).ToList();

                return RESULT;
            }
        }
        public int INSERT_COURSE(BasicModel TITLE)
        {
            using (var context = new vpprojectDBEntities())
            {
                Cours COURSE = new Cours()
                {
                    title = TITLE.title,
                    FieldId = TITLE.id
                };
                context.Courses.Add(COURSE);
                context.SaveChanges();
                return COURSE.id;
            }
        }


    }
}
