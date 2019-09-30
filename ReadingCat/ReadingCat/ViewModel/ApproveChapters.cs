using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReadingCat.Models;
namespace ReadingCat.ViewModel
{
    public class ApproveChapters
    {
        public ApproveChapters()
        {
            listOfBooks = new List<Books>();
            listOfChapters = new List<Chapters>();
        }

        public List<Books> listOfBooks { get; set; }
        public List<Chapters> listOfChapters { get; set; }
    }
}