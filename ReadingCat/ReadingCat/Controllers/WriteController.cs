using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadingCat.ViewModel;
using ReadingCat.Models;
using System.Data;

namespace ReadingCat.Controllers
{
    public class WriteController : Controller
    {
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
                    query = "INSERT INTO BOOKS VALUES ('"+bookName+"',"+currentUser+",null,'"+toSave+"','"+boodSummary+"')";
                    DatabaseModel databaseModel = new DatabaseModel();
                    databaseModel.insert(query);
                    query = "SELECT BOOKID FROM BOOKS WHERE BOOKNAME = '" + bookName+"'";
                    DataSet dataSet = new DataSet();
                    dataSet = databaseModel.selectFunction(query);
                    int bookId = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[0]);
                    query = "SELECT TAGID FROM TAGS WHERE TAGNAME = '" + storyInfo.tags.tagName+"'";
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
                return RedirectToAction("Profile","Profile", new { @id = System.Web.HttpContext.Current.Session["Id"]});
        }
    }
}