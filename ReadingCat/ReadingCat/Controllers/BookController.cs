using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadingCat.Models;
namespace ReadingCat.Controllers
{
    public class BookController : Controller
    {
        DatabaseModel databaseModel;
        Books books;
        // GET: Book
        public ActionResult BookDetails(int id)
        {
            databaseModel = new DatabaseModel();
            books = new Books();
            getBookDetails(id);
           
            books.bookId = id;
            return View(books);
        }

        private void getBookDetails(int id)
        {
            string query = "SELECT *FROM BOOKS WHERE BOOKID = " + id;
            DataSet dataSet = new DataSet();
            dataSet = databaseModel.selectFunction(query);
            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                books.bookName = dataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                books.rating = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[2]);
                books.bookCover = dataSet.Tables[0].Rows[0].ItemArray[4].ToString();

            }
        }
    }
}