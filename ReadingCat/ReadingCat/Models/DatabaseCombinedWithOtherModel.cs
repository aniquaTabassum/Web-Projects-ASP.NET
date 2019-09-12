using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadingCat.Models
{
    public class DatabaseCombinedWithOtherModel
    {
       public DatabaseModel DatabaseModel { get; set; }
        public LoginModel LoginModel { get; set; }
    }
}