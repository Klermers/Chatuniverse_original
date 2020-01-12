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
            ForumContainer forumContainer = new ForumContainer("SQL");
            PostContainer postContainer = new PostContainer("SQL");
            ForumPostViewModel forumPostViewModel = new ForumPostViewModel(forumContainer.GetForumById(forumid), postContainer.GetPostById(id));

            return View(forumPostViewModel);
        }
        /* public PostModel GetPost(int forumid,int postid)
         {
             PostContainer postcontainer = new PostContainer();
             PostDTO postdto = new PostDTO();
             postdto = postcontainer.GetPost(forumid,postid);

             return new PostModel
             {
                 Id = postdto.Id,
                 Posttitel = postdto.PostTitel
             };
         }
         */
        [HttpPost]
        public IActionResult CreateComment(CommentViewModel Commentmodel, int postid, int userid)
        {
            Comment comment = new Comment(Commentmodel.Text, "SQL");

            comment.CreateComment(postid, userid);
            return View();
        }
        public ActionResult CreateComment()
        {
            return View();
        }
    }
}