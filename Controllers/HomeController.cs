using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Pirates.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse()
        {
            //new view 
            ViewBag.Message = "Music will be found here. :)";

            return View();
        }

        public ActionResult Profile()
        {
            //previously called About
            ViewBag.Message = "its YOU :O";

            return View();
        }

        public ActionResult Playlists()
        {
            //previously called Contact
            ViewBag.Message = "this is where playlists will live";

            return View();
        }
    }
}