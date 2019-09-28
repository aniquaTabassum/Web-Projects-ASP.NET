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
        Books books = new Books();
        public ActionResult ReadBook(int id)
        {
            getChapter(id);
            getAllChapters(books.bookId);
            getBookName(books.bookId);
            return View(books);
        }

        private void getChapter(int id)
        {
            string query = "SELECT *FROM  BookChapters WHERE CHAPTERID = " + id;
            dataSet = databaseModel.selectFunction(query);
            books.currentChapter.chapterName = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
            books.currentChapter.chatpterText = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();
            books.bookId = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[1]);
        }

        private void getAllChapters(int id)
        {
            string query = "SELECT *FROM BookChapters WHERE BOOKID = " + id;
            DataSet dataSet = new DataSet();
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                Chapters chapters = new Chapters();
                chapters.chapterId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[0]);
                chapters.chapterName = dataSet.Tables[0].Rows[i].ItemArray[2].ToString();
                chapters.chatpterText = dataSet.Tables[0].Rows[i].ItemArray[3].ToString();
                books.chapters.Add(chapters);
            }
        }

        private void getBookName(int id)
        {
            string query = "SELECT BOOKNAME FROM BOOKS WHERE BOOKID = " + id;
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            books.bookName = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        }
    }
}