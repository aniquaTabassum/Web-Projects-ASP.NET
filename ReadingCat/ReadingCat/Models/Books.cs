using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadingCat.Models
{
    public class Books
    {
        public Books()
        {
            chapters = new List<Chapters>();
            currentChapter = new Chapters();
            comments = new List<Comment>();
            currentComment = new Comment();
        }
        public int bookId { get; set; }
        public string bookName { get; set; }
        public int userId { get; set; }
        public int rating { get; set; }
        public string bookCover { get; set; }
        public int inLibrary { get; set; }
        public int addToLibrary { get; set; }
        public string summary { get; set; }
        public string author { get; set; }
        public string tag { get; set; }
        public int readCount { get; set; }
        public Chapters currentChapter { get; set; }
        public Comment currentComment { get; set; }
        public List<Chapters> chapters { get; set; }
        public List<Comment> comments { get; set; }
    }
}