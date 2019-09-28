using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadingCat.Models
{
    public class Comment
    {
        public int userId { get; set; }
        public int bookId { get; set; }
        public string comment { get; set; }
        public string username { get; set; }
    }
}