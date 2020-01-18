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
            User user = new User();
            user.CreateUser(Onpost.Username, Onpost.Password);
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel onpost)
        {
            UserContainer usercontainer = new UserContainer();
            User user = usercontainer.GetUserByUsernamePassword(onpost.Username, onpost.Password);
            if(user.Username != null)
            {
                HttpContext.Session.SetInt32("Id", usercontainer.GetUserByUsernamePassword(onpost.Username,onpost.Password).Id) ;
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
            UserContainer usercontainer = new UserContainer();
            Forum forum = forumcontainer.GetForumById(id);
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                int userid = (int)HttpContext.Session.GetInt32("Id");
                User user = new User();
                if(usercontainer.GetUserById(userid).Username != null )
                {
                    user.JoinForum(id,userid);
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