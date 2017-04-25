using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LostWKND.Models
{
    public class Issue_Paragraph
    {
        [Column("Issue_ID")]
        public int IssueID { get; set; }

        [Column("Paragraph_ID")]
        public int ParagraphID { get; set; }
    }
}