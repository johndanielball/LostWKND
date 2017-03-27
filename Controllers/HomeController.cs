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

            var model = new List<Post>();

            SqlConnection conn = new SqlConnection((ConfigurationManager.ConnectionStrings["LostWKNDConnection"].ConnectionString));

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = "SELECT p.ID, p.Category_ID, p.Title, p.[Description], i.Name, i.Extension, i.Caption" +
                              " FROM Post p" +
                              " INNER JOIN" +
                              " Post_Image pi" +
                              " ON p.ID = pi.Post_ID" +
                              " INNER JOIN" +
                              " Image i" +
                              " ON pi.Image_ID = i.ID" +
                              " WHERE pi.Is_Feature = 1";

            conn.Open();
            SqlDataReader reader  = cmd.ExecuteReader();

            int postIDpos = reader.GetOrdinal("ID");
            int categoryIDpos = reader.GetOrdinal("Category_ID");
            int titleIDpos = reader.GetOrdinal("Title");
            int descriptionIDpos = reader.GetOrdinal("Description");
            int featureImgNameIDpos = reader.GetOrdinal("Name");
            int featureImgExtensionIDpos = reader.GetOrdinal("Extension");
            int featureImgCaptionIDpos = reader.GetOrdinal("Caption");

            while (reader.Read())
            {
                Post post = new Post();
                Image featureImage = new Image();

                post.ID = reader.GetInt32(postIDpos);
                post.Category_ID = reader.GetInt32(categoryIDpos);
                post.Title = reader.GetString(titleIDpos);
                post.Description = reader.GetString(descriptionIDpos);

                featureImage.Name = reader.GetString(featureImgNameIDpos);
                featureImage.Extension = reader.GetString(featureImgExtensionIDpos);
                featureImage.Caption = reader.GetString(featureImgCaptionIDpos);

                post.FeatureImage = featureImage;

                model.Add(post);
            };
            conn.Close();

            if (Request.Browser.IsMobileDevice)
            {
                return View("Index_m");
            }
            return View();
        }
    }
}