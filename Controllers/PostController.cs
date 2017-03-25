using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LostWKND.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
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