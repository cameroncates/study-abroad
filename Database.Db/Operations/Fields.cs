using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vp_project.Models;

namespace Database.Db.Operations
{
    public class Fields
    {
        public List<FieldModel> _GET_LIMITED_FIELDS(int FIELD_LIMIT, int COURSE_LIMIT, string KEYWORDS)
        {
            if (KEYWORDS == null)
                KEYWORDS = "";
            using (var CONTEXT = new vpprojectDBEntities())
            {
                var RESULT = (
                    from FIELD in CONTEXT.Fields
                    where FIELD.title.Contains(KEYWORDS)
                    select new FieldModel
                    {
                        id = FIELD.id,
                        title = FIELD.title,
                        courseTitle = (from COURSE
                                      in CONTEXT.Courses
                                      where COURSE.FieldId == FIELD.id
                                       select new CourseModel
                                       {
                                           id = COURSE.id,
                                           title = COURSE.title,
                                           fieldId = COURSE.FieldId
                                       }).Take(COURSE_LIMIT).ToList()
                    }).Take(FIELD_LIMIT).ToList();

                return RESULT;
            }
        }
        public int INSERT_FIELD(BasicModel TITLE)
        {
            using (var context = new vpprojectDBEntities())
            {
                Field FIELD = new Field()
                {
                    title = TITLE.title
                };
                context.Fields.Add(FIELD);
                context.SaveChanges();
                return FIELD.id;
            }
        }
        public void DELETE_FIELD(BasicModel ID)
        {
            using (var context = new vpprojectDBEntities())
            {
                var REMOVE_ITEM = context.Fields.SingleOrDefault(x => x.id == ID.id);
                context.Fields.Remove(REMOVE_ITEM);
                context.SaveChanges();
            }
        }
    }
}
