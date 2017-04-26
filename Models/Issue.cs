using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LostWKND.Models
{
    public class Issue
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string Year { get; set; }

        public bool Is_Current { get; set; }

        public int CoverImage_ID { get; set; }

        public int Status { get; set; }

        public Image CoverImage { get; set; }

        public List<string> Paragraphs { get; set; }
    }
}