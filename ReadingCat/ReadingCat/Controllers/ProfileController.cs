using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ReadingCat.Models;
using System.IO;

namespace ReadingCat.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Profile()
        {
            return View();
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
                    query = "UPDATE USERS SET PASSWORD = '" + user.password + "', photo = '"+filePath+"' WHERE USERNAME = '" + user.username + "'";
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
           
            return View("~/Views/Profile/Profile.cshtml", loginModel);
            
        }
    }
}