using LostWKND.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LostWKND.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = DataBase.GetPosts();
            if (Request.Browser.IsMobileDevice)
            {
                return View("Index_m", model);
            }
            return View(model);
        }
    }
}