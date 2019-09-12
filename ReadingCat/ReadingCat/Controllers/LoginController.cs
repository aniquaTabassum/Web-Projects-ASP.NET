using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ReadingCat.Models;

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


            string query = "SELECT password, userid FROM USERS WHERE username = '" + model.LoginModel.username + "'";
            DataSet dataSet;
            DatabaseModel databaseModel = model.DatabaseModel;
            databaseModel = new DatabaseModel();
            dataSet = databaseModel.selectFunction(query);
            if (realPassword == paswordFromUser)
            {
                userid = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[1]);
                model.LoginModel.userid = userid;
                return View("~/Views/Profile/Profile.cshtml", model.LoginModel);
            }
            else
                return View();
        }

    }
}