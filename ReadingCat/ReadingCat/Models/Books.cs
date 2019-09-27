using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadingCat.Models
{
    public class Books
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public int userId { get; set; }
        public int rating { get; set; }
        public string bookCover { get; set; }
        public int inLibrary { get; set; }
        public int addToLibrary { get; set; }
    }
}