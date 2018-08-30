using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeometricWebApi.Controllers
{
    public class JsUiController : Controller
    {
        // GET: JsUi
        public ActionResult Index()
        {
	        ViewBag.Title = "JavaScript UI";
            return View();
        }
    }
}