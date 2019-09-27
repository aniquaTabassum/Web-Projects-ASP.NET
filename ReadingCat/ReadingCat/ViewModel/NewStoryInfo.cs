using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReadingCat.Models;
using ReadingCat.ViewModel;

namespace ReadingCat.ViewModel
{
    public class NewStoryInfo
    {
        public NewStoryInfo()
        {
            books = new Books();
            tags = new Tags();
            file = new List<HttpPostedFileBase>();
        }

       public Books books { get; set; }
        public Tags tags { get; set; }
        public List<HttpPostedFileBase> file { get; set; }
    }
}