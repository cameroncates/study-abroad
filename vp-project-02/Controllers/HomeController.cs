using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vp_project.Models;
using Database.Db.Operations;

namespace vp_project_02.Controllers
{
    public class HomeController : Controller
    {
        Fields FIELD = null;
        Country COUNTRY = null;

        // GET: Home
        public HomeController()
        {
            FIELD = new Fields();
            COUNTRY = new Country();
        }
        public ActionResult Index()
        {
            ViewBag.GET_LIMITED_FIELD = FIELD._GET_LIMITED_FIELDS(9, 4, null);
            ViewBag.GET_LIMITED_COUNTRY = COUNTRY._GET_COUNTRY("", 6);
            return View();
        }
    }
}