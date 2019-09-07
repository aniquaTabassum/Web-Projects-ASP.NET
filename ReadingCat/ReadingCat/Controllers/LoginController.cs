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
        string connectionString = @"Data Source = DESKTOP-BKFDVUR\SQLEXPRESS; Initial Catalog = ReadingCat; Integrated Security = True";
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            DataSet dataset = new DataSet();
            string realPassword = "";
            string paswordFromUser = "";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT password FROM USERS WHERE username = '"+model.username+"'", sqlConnection);
                sqlDataAdapter.Fill(dataset);  
                    realPassword = dataset.Tables[0].Rows[0].ItemArray[0].ToString();
                paswordFromUser = model.password;
             

            }
            if (realPassword == paswordFromUser)
                return View("~/Views/Profile/Profile.cshtml");
            else
                return View();
        }
    }
}