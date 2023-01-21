using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcGLAtelelier2023.Models;

namespace MvcGLAtelelier2023.Controllers
{
    public class HomeController : Controller
    {
        private bdAtelier2023Context bd = new bdAtelier2023Context();
        public ActionResult Index()
        {
            ViewBag.Count = bd.personnes.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}