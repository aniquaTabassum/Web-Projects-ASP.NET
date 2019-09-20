using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ReadingCat.Models;
using System.IO;
using ReadingCat.ViewModel;

namespace ReadingCat.Controllers
{
    public class ProfileController : Controller
    {
        LoginAndBookList loginAndBookList = new LoginAndBookList();
        BooksAndDatabase booksAndDatabase = new BooksAndDatabase();
        string pathName = "";
        [HttpGet]
        public ActionResult Profile(int id)
        {
            getReadList(id);
            getPublishedList(id);
            getProfilePicture(id);
            loginAndBookList.booksAndDatabase = booksAndDatabase;
            loginAndBookList.loginModel = new LoginModel();
            loginAndBookList.loginModel.userid = id;
            loginAndBookList.loginModel.path = pathName;
            return View(loginAndBookList);
        }
        public ActionResult ProfileEdit1(int id)
        {
            DatabaseModel databaseModel = new DatabaseModel();
            User user = new User();
            String query = "SELECT *FROM USERS WHERE USERID = " + id;
            DataSet dataSet = new DataSet();
            dataSet = databaseModel.selectFunction(query);
            
            if(dataSet.Tables[0].Rows.Count == 1)
            {
                user.username = dataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                user.useremail = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                user.password = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();
               // user.paths[0] = dataSet.Tables[0].Rows[0].ItemArray[4].ToString();
                return View(user);
            }

            return View("~/Views/Login/Login.cshtml");
        }
        [HttpPost]
        public ActionResult ProfileEdit1(User user)
        {
            string fileName = "";
            string filePath = "";
            var file = user.File[0];
            string query = "";
            try
            {
                if(file.ContentLength>0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    filePath = Path.Combine(Server.MapPath("~/images"), fileName);
                    file.SaveAs(filePath);
                    string toSave = "~/images/" + fileName;
                    query = "UPDATE USERS SET PASSWORD = '" + user.password + "', photo = '"+toSave+"' WHERE USERNAME = '" + user.username + "'";
                    //ViewBag.Message("Uploaded file saved");
                }
                else
                {
                    query = "UPDATE USERS SET PASSWORD = '" + user.password + "' WHERE USERNAME = '" + user.username + "'";
                }
            }
            catch
            {
               // ViewBag.Message("Uploade file not saved");
            }
            //query = "UPDATE USERS SET PASSWORD = '" + user.password + "' WHERE USERNAME = '" + user.username + "'";
            DatabaseModel databaseModel = new DatabaseModel();
            databaseModel.update(query);

            DatabaseModel databaseModel1 = new DatabaseModel();
            User user1 = new User();
            query = "SELECT *FROM USERS WHERE USEREMAIL = '" + user.useremail+"'";
            DataSet dataSet = new DataSet();
            dataSet = databaseModel1.selectFunction(query);
            LoginModel loginModel = new LoginModel();
            loginModel.userid = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[0]);
            loginModel.username = dataSet.Tables[0].Rows[0].ItemArray[1].ToString();
            loginModel.path = dataSet.Tables[0].Rows[0].ItemArray[4].ToString();
            LoginAndBookList loginAndBookList = new LoginAndBookList();
            loginAndBookList.loginModel = loginModel;

           
            int id = (int)System.Web.HttpContext.Current.Session["Id"];
            return RedirectToAction("Profile", "Profile", new { id = id });
            return View("~/Views/Profile/Profile.cshtml", loginAndBookList);
            
        }

        public ActionResult NewStory()
        {
            return View();
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

        private void getReadList(int id)
        {
            String query = "SELECT *FROM BOOKS WHERE BOOKID IN (SELECT BOOKID FROM READLOG WHERE USERID = "+id+")";
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
                    booksAndDatabase.listOfBooks[0].Add(books);
                }
            }
        }

        private void getProfilePicture(int id)
        {
            String query = "SELECT PHOTO FROM USERS WHERE USERID = " + id; ;
            DataSet dataSet = new DataSet();
            dataSet = booksAndDatabase.databaseModel.selectFunction(query);
            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                pathName = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                
            }
        }
    }
}