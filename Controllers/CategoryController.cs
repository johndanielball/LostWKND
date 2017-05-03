using LostWKND.Helpers;
using LostWKND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LostWKND.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string categoryName)
        {
            var categoryTypeID = LookupHelper.Type["Category"][categoryName].ID;

            var model = DataBase.GetPosts(categoryTypeID);
            if (Request.Browser.IsMobileDevice)
            {
                return View("Index_m", model);
            }
            return View(model);
        }
    }
}