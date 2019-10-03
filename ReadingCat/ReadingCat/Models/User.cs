using System.Collections.Generic;
using System.Web;

namespace ReadingCat.Models
{
    public class User
    {
        public User()
        {
            File = new List<HttpPostedFileBase>();
            paths = new List<string>();
        }
        public int userid { get; set; }
        public string username { get; set; }
        public string useremail { get; set; }
        public string bio { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }

        public List<HttpPostedFileBase> File { get; set; }
        public List<string> paths { get; set; }
    }


}