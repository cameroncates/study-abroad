using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vp_project.Models;
using Database.Db.Operations;

namespace vp_project_02.Controllers
{
    public class DegreeController : Controller
    {
        Fields FIELD = null;
        Country COUNTRY = null;
        Course COURSE = null;
        Degrees DEGREE = null;

        public DegreeController()
        {
            FIELD = new Fields();
            COUNTRY = new Country();
            COURSE = new Course();
            DEGREE = new Degrees();
        }

        // GET: Degree
        public ActionResult Index(int COURSE_ID = 0, int FIELD_ID = 0,int COUNTRY_ID = 0, string GRADUATION_ID = null)
        {
            ViewBag.GET_DEGREE = DEGREE.GET_DEGREE(COURSE_ID, FIELD_ID, COUNTRY_ID, GRADUATION_ID);
            return View();
        }
    }
}