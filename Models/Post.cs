using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LostWKND.Models
{
    public class Post
    {
        public int ID { get; set; }

        public int Template_ID { get; set; }

        public int Category_ID { get; set; }

        public int Status_ID { get; set; }

        public string Author { get; set; }

        public string Photographer { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Image FeatureImage { get; set; }

        public List<object> Content { get; set; }
    }
}