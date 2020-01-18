using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business_Logic;
using Chatuniverse.Models;
using Data_Acces_Layer;
using DTO;
using ChatUniverseInterface;

namespace Chatuniverse.Controllers
{
    public class PostController : Controller
    {

        private readonly IConnectionString connectionstring;

        public PostController(IConnectionString connectionString)
        {
            this.connectionstring = connectionString;
        }

        [HttpPost]
        public IActionResult CreatePost(PostViewModel postmodel, int forumid, int userid)
        {
            Post post = new Post(connectionstring);
            post.CreatePost(forumid, userid,postmodel.Posttitel);

            return View();
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        public ActionResult ForumPosts(int id)
        {
            ForumContainer forumcontainer = new ForumContainer(connectionstring);

            ForumViewModel forumViewModel = new ForumViewModel(forumcontainer.GetForumById(id));

            return View(forumViewModel);
        }

    }
}