using LostWKND.Helpers;
using LostWKND.Models;
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
        public ActionResult Index(int postID)
        {
            var post = DataBase.GetPosts(0, postID).Single();

            var content = DataBase.GetPostContect(postID);

            post.Content = content;

            if (Request.Browser.IsMobileDevice)
            {
                return View("Index_m", post);
            }
            return View(post);
        }
    }
}