using ReadingCat.Models;
using ReadingCat.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadingCat.Controllers
{
    public class ApproveController : Controller
    {
        ApproveChapters aproveChapters = new ApproveChapters();
        DatabaseModel databaseModel;
        
        // GET: Approve
        public ActionResult ViewUnapprovedBooks()
        {
            Session["review"] = 1;    
            getUniqueBookList();
            return View(aproveChapters);
        }
       
        public ActionResult Publish(int id)
        {
            String query = "UPDATE BOOKCHAPTERS SET APPROVED = 1 WHERE CHAPTERID = " + id;
            databaseModel = new DatabaseModel();
            databaseModel.update(query);
            return RedirectToAction("ReadBook", "Read", new { @id = id });
        }
        private void getUniqueBookList()
        {
            string query = "SELECT DISTINCT BOOKS.BOOKID, BOOKNAME, USERID, RATING, BOOKCOVER, SUMMARY, TAGS.TagName FROM BOOKS JOIN BookChapters ON BOOKS.BookID = BookChapters.BookId LEFT JOIN BookTags ON BOOKS.BookID = BookTags.BookId LEFT JOIN Tags ON BOOKTAGS.TAGID = Tags.TagID WHERE APPROVED = 0";
            DatabaseModel databaseModel = new DatabaseModel();
            DataSet dataSet = new DataSet();
            dataSet = databaseModel.selectFunction(query);
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                Books books = new Books();
                books.bookId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[0]);
                books.bookName = dataSet.Tables[0].Rows[i].ItemArray[1].ToString();
                books.userId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[2]);
                books.bookCover = dataSet.Tables[0].Rows[i].ItemArray[4].ToString();
                books.summary = dataSet.Tables[0].Rows[i].ItemArray[5].ToString();
                books.tag = dataSet.Tables[0].Rows[i].ItemArray[6].ToString();
                books.reviewing = 1;
                aproveChapters.listOfBooks.Add(books);
            }
        }
        
    }
}