using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadingCat.Models;
namespace ReadingCat.Controllers
{
    public class ReadBookController : Controller
    {
        // GET: ReadBook
        
        public ActionResult Index(int id)
        {
            Books books = new Books();
            books.bookId = id;
            return View(books);
        }
    }
}