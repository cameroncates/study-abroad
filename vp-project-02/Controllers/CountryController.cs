using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database.Db.Operations;

namespace vp_project_02.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        Country COUNTRY = null;

        public CountryController()
        {
            COUNTRY = new Country();
        }
        public ActionResult Index()
        {
            ViewBag.GET_LIMITED_COUNTRY = COUNTRY._GET_COUNTRY_DETAILS();
            return View();
        }
    }
}