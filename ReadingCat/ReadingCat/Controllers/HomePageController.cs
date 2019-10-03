using System;
using System.Data;
using System.Web.Mvc;
using ReadingCat.Models;
using ReadingCat.ViewModel;

namespace ReadingCat.Controllers
{
    public class HomePageController : Controller
    {

        BooksAndDatabase booksAndDatabase = new BooksAndDatabase();
        // GET: HomePage
        public ActionResult HomePage()
        {
            var exemploList = new SelectList(new[] { "Exemplo1:", "Exemplo2", "Exemplo3" });
            ViewBag.ExemploList = exemploList;
            GetRecommendation();
            GetNewRelease();
            return View(booksAndDatabase);
        }

        private void GetNewRelease()
        {
            string query = "SELECT *FROM BOOKS";
            DatabaseModel databaseModel = new DatabaseModel();
            DataSet dataSet = new DataSet();
            dataSet = databaseModel.selectFunction(query);
            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                int size = dataSet.Tables[0].Rows.Count;
                size -= 1;
                for (int i = size; i >= 10; i--)
                {
                    Books books = new Books();
                    books.bookId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[0]);
                    books.bookName = dataSet.Tables[0].Rows[i].ItemArray[1].ToString();
                    books.userId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[2]);
                    books.bookCover = dataSet.Tables[0].Rows[i].ItemArray[4].ToString();
                    booksAndDatabase.listOfBooks[1].Add(books);
                }
            }
        }

        private void GetRecommendation()
        {
            string query = "SELECT COUNT(READLOG.BOOKID), READLOG.BOOKID, BOOKS.BookName, BOOKS.BookCover, BOOKS.UserId, Books.Rating, BOOKS.BookCover, BOOKTAGS.TAGID FROM READLOG LEFT JOIN BOOKTAGS ON ReadLog.BookId = BookTags.BookId LEFT JOIN Books ON ReadLog.BookId = BOOKS.BookID GROUP BY READLOG.BookId, BookTags.TAGID, BOOKS.BookName, BOOKS.BookCover, BOOKS.Rating, BOOKS.UserId EXCEPT SELECT COUNT(READLOG.BOOKID), READLOG.BOOKID, BOOKS.BookName, BOOKS.BookCover, BOOKS.UserId, Books.Rating, BOOKS.BookCover, BOOKTAGS.TAGID FROM READLOG LEFT JOIN BOOKTAGS ON ReadLog.BookId = BookTags.BookId LEFT JOIN Books ON ReadLog.BookId = BOOKS.BookID WHERE ReadLog.UserId = " + (int)System.Web.HttpContext.Current.Session["Id"] + " GROUP BY READLOG.BookId, BookTags.TAGID, BOOKS.BookName, BOOKS.BookCover, BOOKS.Rating, BOOKS.UserId";
            DatabaseModel databaseModel = new DatabaseModel();
            DataSet dataSet = databaseModel.selectFunction(query);

            for (int i = (dataSet.Tables[0].Rows.Count - 1); i >= 0; i--)
            {

                Books book = new Books();
                book.bookId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[1]);
                book.bookName = dataSet.Tables[0].Rows[i].ItemArray[2].ToString();
                book.bookCover = dataSet.Tables[0].Rows[i].ItemArray[3].ToString();
                book.userId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[4]);
                // book.rating = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[4]);
                booksAndDatabase.listOfBooks[2].Add(book);
            }
        }


    }
}