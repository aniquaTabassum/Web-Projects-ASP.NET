﻿using ReadingCat.Models;
using ReadingCat.ViewModel;
using System;
using System.Data;
using System.Web.Mvc;

//This Controller can only be used by the admins of ReadingCat
//This Controller is responsible for viewing approving the chapters that the writers publish in the website
namespace ReadingCat.Controllers
{
    public class ApproveController : Controller
    {
        //This object contains a list of unique books that contain unapproved chapters
        UnapprovedChapters aproveChapters = new UnapprovedChapters();
        //DatabaseModel is used to access database functions such as insert, update, select
        DatabaseModel databaseModel;
        
        // GET: Approve
        //This method is responsible for viewing the unique books that have 
        //unapproved chapters
        
        public ActionResult ViewUnapprovedBooks()
        {
            //By setting review to 1, we are letting the admin enter the review mode
            //He can now view and approve chapters
            Session["review"] = 1;    
            GetUniqueBookList();
            return View(aproveChapters);
        }
       

        //This method is responsible for approving and publishing an unapproved chapter
        public ActionResult Publish(int id)
        {
            //Setting the Approved attribute to 1 in the database
            //This will make the newly published chapter visible to the users
            String query = "UPDATE BOOKCHAPTERS SET APPROVED = 1 WHERE CHAPTERID = " + id;
            databaseModel = new DatabaseModel();
            databaseModel.update(query);
            return RedirectToAction("ReadBook", "Read", new { @id = id });
        }

        //This method is responsible for retrieving the unique booklist from the database
        
        private void GetUniqueBookList()
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
               // books.reviewing = 1;
                aproveChapters.unapprovedListOfBooks.Add(books);
            }
        }
        
    }
}