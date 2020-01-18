using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chatuniverse.Models;
using Business_Logic;
using DTO;

namespace Chatuniverse.Controllers
{
    public class CommentController : Controller
    {
        public ActionResult GetComments(int id, int forumid)
        {
            ForumContainer forumContainer = new ForumContainer();
            PostContainer postContainer = new PostContainer();
            ForumPostViewModel forumPostViewModel = new ForumPostViewModel(forumContainer.GetForumById(forumid), postContainer.GetPostById(id));

            return View(forumPostViewModel);
        }
        [HttpPost]
        public IActionResult CreateComment(CommentViewModel Commentmodel, int postid, int userid)
        {
            Comment comment = new Comment();

            comment.CreateComment(postid, userid, Commentmodel.Text);
            return View();
        }
        public ActionResult CreateComment()
        {
            return View();
        }
    }
}