using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        int booId;
        // GET: Book
        public ActionResult BookDetails(int id)
        {
            databaseModel = new DatabaseModel();
            books = new Books();
            books.chapters = new List<Chapters>();
            getBookDetails(id);
            getBookChapters(id);
            getAuthorName(books.userId);
            getComments(id);
            getCommenterName();
            getBookTag(id);
            getReadCount(id);
            booId = id;
            books.bookId = id;
            Session["CurrentBookId"] = id;
            return View(books);
        }
        
        
        [HttpPost]
        public ActionResult BookDetails(Books passedBook)
        {
            string getComment = passedBook.currentComment.comment;
            int commenter = (int)System.Web.HttpContext.Current.Session["Id"];
            int bookCommented = (int)System.Web.HttpContext.Current.Session["CurrentBookId"];
            insertComment(getComment, commenter, bookCommented);
            databaseModel = new DatabaseModel();
            books = new Books();
            books.chapters = new List<Chapters>();
            getBookDetails(bookCommented);
            getBookChapters(bookCommented);
            getReadCount(bookCommented);
            getAuthorName(books.userId);
            getComments(bookCommented);
            getCommenterName();
            getBookTag(bookCommented);
            booId = bookCommented;
            books.bookId = bookCommented;
            books.currentComment = new Comment();
            books.currentComment.comment = "";
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
                books.userId = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[2]);
                books.bookCover = dataSet.Tables[0].Rows[0].ItemArray[4].ToString();
                books.summary = dataSet.Tables[0].Rows[0].ItemArray[5].ToString();
            }

            getLibraryState(id);
        }
        private void getBookChapters(int id)
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
                chapters.approved = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[4]);
                books.chapters.Add(chapters);
            }
        }
        public ActionResult AddBook(int id)
        {
            int userId = (int)System.Web.HttpContext.Current.Session["Id"];
            string query = "INSERT INTO READLOG VALUES (" + userId + ", " + id + ")";
            DataSet dataSet = new DataSet();
            DatabaseModel databaseModel = new DatabaseModel();
            databaseModel.insert(query);
            return RedirectToAction("BookDetails", "Book", new { @id = id });
        }
        private void getLibraryState(int id)
        {
            string query = "SELECT *FROM READLOG WHERE USERID = " + (int)System.Web.HttpContext.Current.Session["Id"] + " AND BOOKID = " + id;
            DataSet dataSet = new DataSet();
            dataSet = databaseModel.selectFunction(query);
            if (dataSet.Tables[0].Rows.Count == 1)
            {
                books.inLibrary = 1;

            }

            else
            {
                books.inLibrary = 0;
            }
        }

        private void getAuthorName(int id)
        {
            string query = "SELECT USERNAME FROM USERS WHERE USERID = " + id;
            DataSet dataSet = new DataSet();
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                books.author = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();

            }
        }

        private void getComments(int id)
        {
            string query = "SELECT *FROM COMMENTS WHERE BOOKID = " + id;
            DataSet dataSet = new DataSet();
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                Comment comment = new Comment();
                comment.userId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[1]);
                comment.bookId = Convert.ToInt32(dataSet.Tables[0].Rows[i].ItemArray[2]);
                comment.comment = dataSet.Tables[0].Rows[i].ItemArray[3].ToString();
                books.comments.Add(comment);
            }
        }

        private void getCommenterName()
        {
            int i = 0;
            foreach (Comment comment in books.comments)
            {
                int userid = comment.userId;
                string query = "SELECT USERNAME FROM USERS WHERE USERID = " + userid;
                DataSet dataSet = new DataSet();
                dataSet = databaseModel.selectFunction(query);
                string username = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                books.comments[i].username = username;
                i += 1;
            }
        }

        private void insertComment(string comment, int commenter, int bookCommented)
        {
            string connectionString = @"Data Source = DESKTOP-BKFDVUR\SQLEXPRESS; Initial Catalog = ReadingCat; Integrated Security = True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "INSERT INTO COMMENTS VALUES (@commenter, @bookCommented, @comment)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@commenter", commenter);
                sqlCommand.Parameters.AddWithValue("@bookCommented", bookCommented);
                sqlCommand.Parameters.AddWithValue("@comment", comment);

                sqlCommand.ExecuteNonQuery();
            }
        }

        private void getBookTag(int id)
        {
            string query = "SELECT TAGNAME FROM TAGS WHERE TAGID = ( SELECT TAGID FROM BOOKTAGS WHERE BOOKID = " + id + ")";
            DataSet dataSet = new DataSet();
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            books.tag = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();

        }

        private void getReadCount(int id)
        {
            string query = " SELECT COUNT(BOOKID), BOOKID FROM READLOG WHERE BOOKID = " + id + " GROUP BY BOOKID";
            DataSet dataSet = new DataSet();
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            books.readCount = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[0]);
        }
    }
}