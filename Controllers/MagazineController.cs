using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LostWKND.Controllers
{
    public class MagazineController : Controller
    {
        // GET: Magazine
        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return View("Index_m");
            }
            return View();
        }
    }
}