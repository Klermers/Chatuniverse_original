using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatuniverse.Models;
using Microsoft.AspNetCore.Mvc;
using Business_Logic;
using DTO;

namespace Chatuniverse.Controllers
{
    public class ForumController : Controller
    {
        [HttpPost]
        public IActionResult CreateForum(ForumViewModel Onpost)
        {
            Forum forum = new Forum(Onpost.ForumTitel, Onpost.Desciption, "SQl");
            forum.CreateForum();
            ViewBag.Created = "Forum got Created";
            return View();
        }

        public ActionResult CreateForum()
        {
            return View();
        }

        public IActionResult GetAllForums()
        {
            ForumContainer forumContainer = new ForumContainer("SQL");
            List<ForumViewModel> forumviewmodels = new List<ForumViewModel>();
            forumContainer.GetAllForums();
            foreach (var forum in forumContainer.Forums)
            {
                ForumViewModel forumViewModel = new ForumViewModel(forum);
                forumviewmodels.Add(forumViewModel);
            }
            ListForumsViewModel listForumsViewModel = new ListForumsViewModel(forumviewmodels);
            return View(listForumsViewModel);
        }




    }
}