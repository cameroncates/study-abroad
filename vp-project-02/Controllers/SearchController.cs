using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using vp_project.Models;
using Database.Db.Operations;

namespace vp_project_02.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        Fields FIELD = null;
        Country COUNTRY = null;
        Course COURSE = null;
        public SearchController()
        {
            FIELD = new Fields();
            COUNTRY = new Country();
            COURSE = new Course();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult _GET_BY_FIELD(SearchModel Search)
        {
            var GET_RESULT = FIELD._GET_LIMITED_FIELDS(10, 4, Search.KEYWORDS);
            var json = JsonConvert.SerializeObject(GET_RESULT);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult _GET_BY_COUNTRY(SearchModel Search)
        {
            var GET_RESULT = COUNTRY._GET_COUNTRY(Search.KEYWORDS, 1000);
            var json = JsonConvert.SerializeObject(GET_RESULT);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult _GET_BY_COURSE(SearchModel Search)
        {
            var GET_RESULT = COURSE._GET_ONLY_COURSE(10, Search.KEYWORDS);
            var json = JsonConvert.SerializeObject(GET_RESULT);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult _GET_BY_GRADUATION(BasicModel Search)
        {
            List<BasicModel> GET_RESULT = new List<BasicModel>();
            GET_RESULT.Add(new BasicModel() { id =1 , title="graduate"});
            GET_RESULT.Add(new BasicModel() { id = 2, title = "undergraduate" });

            var json = JsonConvert.SerializeObject(GET_RESULT);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}