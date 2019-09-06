using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadingCat.Models
{
    public class User
    {
        public string username { get; set; }
        public string useremail { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }


}