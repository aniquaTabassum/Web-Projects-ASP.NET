using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadingCat.Models
{
    public class Tags
    {
        public Tags()
        {
            listOfTags = new List<Tags>();
        }
        public int tagId { get; set; }
        public string tagName { get; set; }
        public Boolean isSelected { get; set; }

        public List<Tags> listOfTags { get; set; }
    }
}