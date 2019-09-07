using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadingCat.Models;
using System.Data;
using System.Data.SqlClient;
namespace ReadingCat.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        string connectionString = @"Data Source = DESKTOP-BKFDVUR\SQLEXPRESS; Initial Catalog = ReadingCat; Integrated Security = True";
        [HttpGet]
        public ActionResult Register1()
        {
            return View(new User());
        }
        
        [HttpPost]
        public ActionResult Register1(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "INSERT INTO USERS VALUES (@username, @useremail, @password, null)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", user.username);
                sqlCommand.Parameters.AddWithValue("@useremail", user.useremail);
                sqlCommand.Parameters.AddWithValue("@password", user.password);
                string conpass = user.confirmPassword;
                sqlCommand.ExecuteNonQuery();
            }
            return View("~/Views/Login/Login.cshtml");
            
        }

    }
}