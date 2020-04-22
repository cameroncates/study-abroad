using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vp_project.Models;
using Database.Db.Operations;

namespace vp_project_02.Controllers
{
    public class AdminController : Controller
    {
        Fields FIELD = null;
        Country COUNTRY = null;
        Course COURSE = null;
        Degrees DEGREE = null;
        public AdminController()
        {
            FIELD = new Fields();
            COUNTRY = new Country();
            COURSE = new Course();
            DEGREE = new Degrees();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View("Index", "_Admin");
        }
        public ActionResult ADD_FIELD()
        {
            return View("ADD_FIELD", "_Admin");
        }
        [HttpPost]
        public ActionResult ADD_FIELD(BasicModel GET_DATA)
        {
            var INSERT_DATA = FIELD.INSERT_FIELD(GET_DATA);
            return View("ADD_FIELD", "_Admin");
        }
        public ActionResult ADD_COURSE()
        {
            ViewBag.GET_ALL_COURSE = FIELD._GET_LIMITED_FIELDS(10000, 1000, null);
            return View("ADD_COURSE", "_Admin");
        }
        [HttpPost]
        public ActionResult ADD_COURSE(BasicModel GET_DATA)
        {
            var INSERT_DATA = COURSE.INSERT_COURSE(GET_DATA);
            return View("Index", "_Admin");
        }
        public ActionResult ADD_UNIVERSITY()
        {
            ViewBag.GET_ALL_COUNTRY = COUNTRY._GET_COUNTRY(null, 10000);
            return View("ADD_UNIVERSITY", "_Admin");
        }
        [HttpPost]
        public ActionResult ADD_UNIVERSITY(UniversityModel GET_DATA)
        {
            var INSERT_DATA = COUNTRY.INSERT_UNIVERSITY(GET_DATA);
            return View("Index", "_Admin");
        }
        public ActionResult ADD_DEGREE()
        {
            ViewBag.GET_ALL_UNIVERSITY = COUNTRY._GET_UNIVERSITY();
            ViewBag.GET_ALL_COURSES = COURSE._GET_ONLY_COURSE(10000, null);
            return View("ADD_DEGREE", "_Admin");
        }
        [HttpPost]
        public ActionResult ADD_DEGREE(DegreeModel02 GET_DATA)
        {
            var INSERT_DATA = DEGREE.INSERT_DEGREE(GET_DATA);
            return View("Index", "_Admin");
        }

        public ActionResult DELETE_FIELD()
        {
            ViewBag.GET_FIELD = FIELD._GET_LIMITED_FIELDS(10000, 10000, null);
            return View("DELETE_FIELD", "_Admin");
        }
        [HttpPost]
        public ActionResult DELETE_FIELD(BasicModel GET_DATA)
        {
            FIELD.DELETE_FIELD(GET_DATA);
            return View("Index", "_Admin");
        }

    }
}