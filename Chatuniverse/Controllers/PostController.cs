using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business_Logic;
using Chatuniverse.Models;
using Data_Acces_Layer;
using DTO;

namespace ChatUniverse.Controllers
{
    public class PostController : Controller
    {

        [HttpPost]
        public IActionResult CreatePost(PostViewModel postmodel, int forumid, int userid)
        {
            PostDTO postdto = new PostDTO();
            ForumDTO forumdto = new ForumDTO(forumid);
            postdto.PostTitel = postmodel.Posttitel;

            Post post = new Post(postmodel.Posttitel, postmodel.Date, "SQL");

            post.CreatePost(forumdto.Id, userid);

            return View();
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        public ActionResult ForumPosts(int id)
        {
            ForumContainer forumcontainer = new ForumContainer("SQL");

            ForumViewModel forumViewModel = new ForumViewModel(forumcontainer.GetForumById(id));

            return View(forumViewModel);
        }

    }
}