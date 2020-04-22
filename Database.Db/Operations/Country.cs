using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vp_project.Models;

namespace Database.Db.Operations
{
    public class Country
    {
        public List<CountryModel> _GET_COUNTRY(string KEYWORDS, int LIMIT)
        {
            if (KEYWORDS == null)
                KEYWORDS = "";
            using (var CONTEXT = new vpprojectDBEntities())
            {
                var RESULT = (
                    from COUNTRY in CONTEXT.Countries
                    where COUNTRY.title.Contains(KEYWORDS)
                    select new CountryModel
                    {
                        id = COUNTRY.id,
                        title = COUNTRY.title,
                    }).Take(LIMIT).ToList();
                return RESULT;
            }
        }
        public List<CountryModel02> _GET_COUNTRY_DETAILS()
        {
            using (var CONTEXT = new vpprojectDBEntities())
            {
                var RESULT = (
                    from COUNTRY in CONTEXT.Countries
                    select new CountryModel02
                    {
                        ID = COUNTRY.id,
                        TITLE = COUNTRY.title,
                        UNIVERSITY_COUNT = (from UNIVERSITY
                                            in CONTEXT.Universities
                                            where UNIVERSITY.countryId == COUNTRY.id
                                            select new BasicModel
                                            {
                                                id = UNIVERSITY.id,
                                                title = UNIVERSITY.title
                                            }).ToList(),
                        DEGREE_COUNT = (from UNIVERSITY
                                        in CONTEXT.Universities
                                        join DEGREEE in CONTEXT.Degrees
                                        on UNIVERSITY.id equals DEGREEE.universityId
                                        where UNIVERSITY.countryId == COUNTRY.id
                                        select new BasicModel
                                        {
                                            id = DEGREEE.degreeId,
                                            title = DEGREEE.degreeTitle
                                        }).ToList()
                        
                    }).ToList();
                return RESULT;
            }
        }
        public int INSERT_UNIVERSITY(UniversityModel UNIVERSITY_MODEL)
        {
            using (var context = new vpprojectDBEntities())
            {
                University UNIVERSITY = new University()
                {
                    title = UNIVERSITY_MODEL.TITLE,
                    countryId = UNIVERSITY_MODEL.COUNTRY_ID,
                    location = UNIVERSITY_MODEL.LOCATION
                    
                };
                context.Universities.Add(UNIVERSITY);
                context.SaveChanges();
                return UNIVERSITY.id;
            }
        }
        public List<BasicModel> _GET_UNIVERSITY()
        {
            using (var CONTEXT = new vpprojectDBEntities())
            {
                var RESULT = (
                    from UNIVERSITY in CONTEXT.Universities
                    select new BasicModel
                    {
                        id = UNIVERSITY.id,
                        title = UNIVERSITY.title
                    }).ToList();

                return RESULT;
            }
        }


    }
}
