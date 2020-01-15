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
            User user = new User(onpost.Username, onpost.Password);
            UserContainer usercontainer = new UserContainer();
            if(user.LoginUser() == true)
            {
                HttpContext.Session.SetInt32("Id", usercontainer.GetUserByUsername(onpost.Username).Id) ;
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

        public IActionResult JoinForum(int id)
        {
            ForumContainer forumcontainer = new ForumContainer();
            Forum forum = forumcontainer.GetForumById(id);
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                int userid = (int)HttpContext.Session.GetInt32("Id");
                User user = new User(userid);
                if(forum.IsUserInForum(userid) == false )
                {
                    user.JoinForum(id);
                }
                else
                {
                    TempData["login"] = "You are alreasy a member of this forum.";
                }
            }
            else
            {
                TempData["login"] =  "You aren't Logged in";
            }
            return RedirectToAction("ForumPosts", "Post", new { id= id });
        }
    }
}