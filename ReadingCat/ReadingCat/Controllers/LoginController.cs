using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ReadingCat.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        
        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }
    }
}