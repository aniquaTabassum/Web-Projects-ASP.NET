﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadingCat.ViewModel;
using ReadingCat.Models;
using System.Data;
using System.Data.SqlClient;

namespace ReadingCat.Controllers
{
    public class WriteController : Controller
    {
        BooksAndDatabase booksAndDatabase = new BooksAndDatabase();
        [HttpGet]
        public ActionResult NewStory()
        {
            return View();
        }
        // GET: Write
        [HttpPost]
        public ActionResult NewStory(NewStoryInfo storyInfo)
        {
            string fileName = "";
            string filePath = "";
            var file = storyInfo.file[0];
            string bookName = storyInfo.books.bookName;
            string boodSummary = storyInfo.books.summary;
            string query = "";
            int bookId = 0;
            try
            {
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    filePath = Path.Combine(Server.MapPath("~/images/Books"), fileName);
                    string toSave = "~/images/Books/" + fileName;
                    file.SaveAs(filePath);

                    // query = "UPDATE USERS SET PASSWORD = '" + user.password + "', photo = '" + toSave + "' WHERE USERNAME = '" + user.username + "'";
                    //ViewBag.Message("Uploaded file saved");
                    int currentUser = (int)System.Web.HttpContext.Current.Session["Id"];
                    query = "INSERT INTO BOOKS VALUES ('" + bookName + "'," + currentUser + ",null,'" + toSave + "','" + boodSummary + "')";
                    DatabaseModel databaseModel = new DatabaseModel();
                    databaseModel.insert(query);
                    query = "SELECT BOOKID FROM BOOKS WHERE BOOKNAME = '" + bookName + "'";
                    DataSet dataSet = new DataSet();
                    dataSet = databaseModel.selectFunction(query);
                    bookId = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[0]);
                    query = "SELECT TAGID FROM TAGS WHERE TAGNAME = '" + storyInfo.tags.tagName + "'";
                    dataSet = new DataSet();
                    dataSet = databaseModel.selectFunction(query);
                    int tagid = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[0]);
                    query = "INSERT INTO BOOKTAGS VALUES (" + bookId + ", " + tagid + ")";
                    databaseModel.insert(query);
                }
                else
                {
                    //  query = "UPDATE USERS SET PASSWORD = '" + user.password + "' WHERE USERNAME = '" + user.username + "'";
                }
            }
            catch
            {

            }
            return RedirectToAction("WriteStory", "Write", new { @id = bookId });
        }
        public ActionResult ViewPublished()
        {
            int id = (int)System.Web.HttpContext.Current.Session["Id"];
            getPublishedList(id);

            return View(booksAndDatabase);
        }
        [HttpGet]
        public ActionResult WriteStory(int id)
        {
            Session["BookId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult WriteStory(Chapters chapters)
        {
            string title = chapters.chapterName;
            string text = chapters.chatpterText;
            int bookId = (int)System.Web.HttpContext.Current.Session["BookId"];
            chapters.bookId = bookId;
            /* insertChapter(bookId, title, text);
             return RedirectToAction("BookDetails", "Book", new { @id = bookId });
             */
            return RedirectToAction("BookDetals", "Book", new { @id = bookId });
        }

        private void getPublishedList(int id)
        {
            String query = "SELECT *FROM BOOKS WHERE USERID = " + id;
            DataSet dataSet = new DataSet();
            dataSet = booksAndDatabase.databaseModel.selectFunction(query);
            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
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

        private void insertChapter(int id, string title, string text)
        {
            string query = "INSERT INTO BOOKCHAPTERS VALUES (@id,@title, @text, @approved)";

            string connectionString = @"Data Source = DESKTOP-BKFDVUR\SQLEXPRESS; Initial Catalog = ReadingCat; Integrated Security = True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@title", title);
                sqlCommand.Parameters.AddWithValue("@text", text);
                sqlCommand.Parameters.AddWithValue("@approved", 0);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}