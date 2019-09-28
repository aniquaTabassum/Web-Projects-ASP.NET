using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadingCat.Models;
using ReadingCat.ViewModel;

namespace ReadingCat.Controllers
{
    public class ReadController : Controller
    {
        // GET: Read
        DatabaseModel databaseModel = new DatabaseModel();
        DataSet dataSet = new DataSet();
        Chapters chapters = new Chapters();
        public ActionResult ReadBook(int id)
        {
            getChapter(id);
            return View(chapters);
        }

        private void getChapter(int id)
        {
            string query = "SELECT *FROM  BookChapters WHERE CHAPTERID = " + id;
            dataSet = databaseModel.selectFunction(query);
            chapters.chapterName = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
            chapters.chatpterText = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();

        }
    }
}