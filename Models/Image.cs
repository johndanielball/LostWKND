using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LostWKND.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Caption { get; set; }
    }
}