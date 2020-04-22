using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vp_project.Models;

namespace Database.Db.Operations
{
    public class Degrees
    {
        public List<DegreeModel> GET_DEGREE(int COURSE_ID, int FIELD_ID, int COUNTRY_ID, string GRADUATION)
        {
            if (GRADUATION == null || GRADUATION.Equals(0+""))
                GRADUATION = "null";
            using (var CONTEXT = new vpprojectDBEntities())
            {
                var RESULT = (
                    from COURSE in CONTEXT.Courses
                    join DEGREE in CONTEXT.Degrees
                    on COURSE.id equals DEGREE.courseId
                    join FIELD in CONTEXT.Fields
                    on COURSE.FieldId equals FIELD.id
                    join UNIVERSITY in CONTEXT.Universities
                    on DEGREE.universityId equals UNIVERSITY.id
                    join COUNTRY in CONTEXT.Countries
                    on UNIVERSITY.countryId equals COUNTRY.id
                    where
                    (
                        COURSE.id == COURSE_ID ||
                        COURSE_ID == 0
                    ) &&
                    (
                        DEGREE.graduation.Equals(GRADUATION) ||
                        GRADUATION.Equals("null")
                    ) &&
                    (
                        COUNTRY_ID == 0 ||
                        COUNTRY.id == COUNTRY_ID
                    ) &&
                    (
                        FIELD.id == FIELD_ID ||
                        FIELD_ID == 0
                    )

                    select new DegreeModel
                    {
                        ID = DEGREE.degreeId,
                        TITLE = DEGREE.degreeTitle,
                        UNIVERSITY_TITLE = UNIVERSITY.title,
                        COUNTRY_TITLE = COUNTRY.title,
                        COURSE_TITLE = COURSE.title,
                        GRADUATION = DEGREE.graduation,
                        DURATION = DEGREE.duration,
                        LOCATION = UNIVERSITY.location,
                        FIELD_TITLE = FIELD.title
                    }).Take(10).ToList();
                return RESULT;
            }
        }
        public int INSERT_DEGREE(DegreeModel02 DEGREE_MODEL)
        {
            using (var context = new vpprojectDBEntities())
            {
                Degree DEGREE = new Degree()
                {
                    degreeTitle = DEGREE_MODEL.DEGREE_TITLE,
                    duration = DEGREE_MODEL.DURATION,
                    graduation = DEGREE_MODEL.GRADUATION,
                    courseId = DEGREE_MODEL.COURSE_ID,
                    universityId = DEGREE_MODEL.UNIVERSITY_ID
                };
                context.Degrees.Add(DEGREE);
                context.SaveChanges();
                return DEGREE.degreeId;
            }
        }
    }
}
