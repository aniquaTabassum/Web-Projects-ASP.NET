using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadingCat.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult BookDetails()
        {
            return View();
        }
    }
}