using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Configuration;

namespace LostWKND.Models
{
    public static class DataBase
    {
        public static List<Issue> GetIssues()
        {
            var issues = new List<Issue>();

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LostWKNDConnection"].ConnectionString);
            var cmd = new SqlCommand("GetAllIssues", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();

            var reader = cmd.ExecuteReader();

            int issueIDPos = reader.GetOrdinal("Issue_ID");
            int issueNamePos = reader.GetOrdinal("Issue_Name");
            int issueNumberPos = reader.GetOrdinal("Number");
            int issueYearPos = reader.GetOrdinal("Year");
            int issueCoverImgIDPos = reader.GetOrdinal("CoverImage_ID");
            int issueIsCurrentPos = reader.GetOrdinal("Is_Current");
            int issueStatusPos = reader.GetOrdinal("Status");
            int coverImageExtensionPos = reader.GetOrdinal("Extension");
            int coverImageNamePos = reader.GetOrdinal("Image_Name");

            while (reader.Read())
            {
                var issue = new Issue();
                var image = new Image();

                issue.CoverImage = image;
                issue.CoverImage.Extension = reader.GetString(coverImageExtensionPos);
                issue.CoverImage.Name = reader.GetString(coverImageNamePos);

                issue.ID = reader.GetInt32(issueIDPos);
                issue.Name = reader.GetString(issueNamePos);
                issue.Number = reader.GetInt32(issueNumberPos);
                issue.Year = reader.GetString(issueYearPos);
                issue.CoverImage_ID = reader.GetInt32(issueCoverImgIDPos);
                issue.Is_Current = reader.GetBoolean(issueIsCurrentPos);
                issue.Status = reader.GetInt32(issueStatusPos);

                issues.Add(issue);
            }

            return issues;
        }

        public static List<Post> GetPosts(int categoryTypeID = 0)
        {
            var posts = new List<Post>();

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LostWKNDConnection"].ConnectionString);
            var cmd = new SqlCommand("GetPosts", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (categoryTypeID != 0)
            {
                cmd.Parameters.Add("@CategoryTypeID", categoryTypeID);
            }
            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int postIDPos = reader.GetOrdinal("ID");
            int categoryIDPos = reader.GetOrdinal("Category_ID");
            int titleIDPos = reader.GetOrdinal("Title");
            int descriptionIDPos = reader.GetOrdinal("Description");
            int featureImgNameIDPos = reader.GetOrdinal("Name");
            int featureImgExtensionIDPos = reader.GetOrdinal("Extension");
            int featureImgCaptionIDPos = reader.GetOrdinal("Caption");

            while (reader.Read())
            {
                Post post = new Post();
                Image featureImage = new Image();

                post.ID = reader.GetInt32(postIDPos);
                post.Category_ID = reader.GetInt32(categoryIDPos);
                post.Title = reader.GetString(titleIDPos);
                post.Description = reader.GetString(descriptionIDPos);

                featureImage.Name = reader.GetString(featureImgNameIDPos);
                featureImage.Extension = reader.GetString(featureImgExtensionIDPos);
                featureImage.Caption = reader.GetString(featureImgCaptionIDPos);

                post.FeatureImage = featureImage;

                posts.Add(post);
            };
            conn.Close();

            return posts;
        }

        public static List<String> GetIssueParagraphs(int issueID)
        {
            var issueParagraphs = new List<String>();

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LostWKNDConnection"].ConnectionString);
            
            var cmd = new SqlCommand("GetIssueParagraphs", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Issue_ID", issueID));

            conn.Open();

            var reader = cmd.ExecuteReader();

            int paragraphTextPos = reader.GetOrdinal("Text");

            while (reader.Read())
            {
                var issueParagraph = reader.GetString(paragraphTextPos);

                issueParagraphs.Add(issueParagraph);
            }
            conn.Close();

            return issueParagraphs;

        }
    }
}