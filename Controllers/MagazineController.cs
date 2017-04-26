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
    public class MagazineController : Controller
    {
        // GET: Magazine
        public ActionResult Index(int issueID = 0)
        {
            var issues = DataBase.GetIssues();
            if (issueID == 0)
            {
                issueID = issues.Where(item => item.Is_Current).Single().ID;
            }

            var issue = issues.Where(item => issueID == item.ID).Single();

            issue.Paragraphs = DataBase.GetIssueParagraphs(issueID);

            ViewBag.DisplayIssueID = issueID;
            



            if (Request.Browser.IsMobileDevice)
            {
                return View("Index_m");
            }
            return View(issues);
        }
    }
}