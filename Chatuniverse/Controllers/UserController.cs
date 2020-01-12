using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chatuniverse.Models;
using Business_Logic;
using Microsoft.AspNetCore.Http;

namespace Chatuniverse.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult CreateUser(UserViewModel Onpost)
        {
            User user = new User(Onpost.Username, Onpost.Password, "SQL");
            user.CreateUser();
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel onpost)
        {
            User user = new User(onpost.Username, onpost.Password, "SQL");
            if(user.LoginUser() == true)
            {
                HttpContext.Session.SetString("Username", onpost.Username);
                ViewBag.Message = "You are Logged in";
            }
            else
            {
                ViewBag.Message = "Wrong username Or/and Password";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult JoinForum(int forumid, int userid)
        {
            User user = new User(userid, "SQL");
            user.JoinForum(forumid);
            return View();
        }
    }
}