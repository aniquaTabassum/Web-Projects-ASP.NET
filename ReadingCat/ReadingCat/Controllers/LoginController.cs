using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ReadingCat.Models;
using ReadingCat.ViewModel;
using System.Web.Routing;

namespace ReadingCat.Controllers
{
    public class LoginController : Controller
    {
       // string connectionString = @"Data Source = DESKTOP-BKFDVUR\SQLEXPRESS; Initial Catalog = ReadingCat; Integrated Security = True";
        private int userid;
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new DatabaseCombinedWithOtherModel());
        }
        [HttpPost]
        public ActionResult Login(DatabaseCombinedWithOtherModel model)
        {
            string realPassword = "";
            string paswordFromUser = "";


            string query = "SELECT password, userid, photo FROM USERS WHERE username = '" + model.LoginModel.username + "'";
            string photo = "";
            DataSet dataSet;
            DatabaseModel databaseModel = model.DatabaseModel;
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            realPassword = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();

            paswordFromUser = model.LoginModel.password;
            if (realPassword == paswordFromUser)
            {
                userid = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[1]);
                photo = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                model.LoginModel.userid = userid;
                model.LoginModel.path = photo;

                LoginAndBookList loginAndBookList = new LoginAndBookList();
                loginAndBookList.loginModel = new LoginModel();
                loginAndBookList.loginModel = model.LoginModel;
                loginAndBookList.loginModel.userid = userid;
                Session["Id"] = loginAndBookList.loginModel.userid;
           
                return RedirectToAction("Profile", "Profile", new {id = userid } );
             
            }
            else
                return View();
        }

    }
}