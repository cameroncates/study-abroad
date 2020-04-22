using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database.Db.Operations;

namespace vp_project_02.Controllers
{
    public class FieldController : Controller
    {
        Fields FIELD = null;
        public FieldController()
        {
            FIELD = new Fields();
        }
        // GET: Field
        public ActionResult Index()
        {
            ViewBag.GET_LIMITED_FIELD = FIELD._GET_LIMITED_FIELDS(10000, 10000, null);
            return View();
        }
    }
}