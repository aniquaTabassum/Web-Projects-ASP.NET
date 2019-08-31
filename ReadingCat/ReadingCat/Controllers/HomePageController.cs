using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadingCat.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult HomePage()
        {
            var exemploList = new SelectList(new[] { "Exemplo1:", "Exemplo2", "Exemplo3" });
            ViewBag.ExemploList = exemploList;
            return View();
        }


    }
}