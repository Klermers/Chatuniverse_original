using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chatuniverse.Models;
using Business_Logic;
using DTO;
using ChatUniverseInterface;

namespace Chatuniverse.Controllers
{
    public class CommentController : Controller
    {
        private readonly IConnectionString connectionstring;

        public CommentController(IConnectionString connectionString)
        {
            this.connectionstring = connectionString;
        }

        public ActionResult GetComments(int id, int forumid)
        {
            ForumContainer forumContainer = new ForumContainer(connectionstring);
            PostContainer postContainer = new PostContainer();
            ForumPostViewModel forumPostViewModel = new ForumPostViewModel(forumContainer.GetForumById(forumid), postContainer.GetPostById(id));

            return View(forumPostViewModel);
        }
        [HttpPost]
        public IActionResult CreateComment(CommentViewModel Commentmodel, int postid, int userid)
        {
            Comment comment = new Comment(connectionstring);

            comment.CreateComment(postid, userid, Commentmodel.Text);
            return View();
        }
        public ActionResult CreateComment()
        {
            return View();
        }
    }
}