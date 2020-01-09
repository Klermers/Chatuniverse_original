using System;
using System.Collections.Generic;
using System.Text;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.SQL;
using Data_Acces_Layer.InMemory;
using DTO;
using ChatUniverseInterface;
namespace Business_Logic
{
    public class PostContainer
    {
        private UserContainer userContainer;
        private IPostContainer postContainer;
        private CommentContainer commentContainer;
        private string context;

        public List<Post> Posts
        {
            get;
            private set;
        }

        public PostContainer(string context)
        {
            if (context == "SQL")
            {
                this.context = context;
                postContainer = new Postrepository(new PostSQL());
                commentContainer = new CommentContainer(context);
                userContainer = new UserContainer(context);
            }
            else if (context == "MEM")
            {
                this.context = context;
                postContainer = new Postrepository(new PostInMemory());
                commentContainer = new CommentContainer(context);
                userContainer = new UserContainer(context);
            }
        }

        public void GetAllPostsByForumId(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            List<Post> posts = new List<Post>();
            postdtos = postContainer.GetAllPostsByForumId(forumid);
            foreach (var postdto in postdtos)
            {
                commentContainer.GetAllCommentsByPostId(postdto.Id);
                Post post = new Post(postdto, userContainer.GetUserById(forumid), commentContainer.Comments, context);
                posts.Add(post);
            }
            Posts = posts;
        }


        public void GetAllPostsByForumIdDesc(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            List<Post> posts = new List<Post>();
            postdtos = postContainer.GetAllPostsByForumIdDesc(forumid);
            foreach (var postdto in postdtos)
            {
                commentContainer.GetAllCommentsByPostId(postdto.Id);
                Post post = new Post(postdto, userContainer.GetUserById(forumid), commentContainer.Comments, context);
                posts.Add(post);
            }
            Posts = posts;
        }

        public void GetAllPosts()
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            List<Post> posts = new List<Post>();
            postdtos = postContainer.GetAllPosts();
            foreach (var postdto in postdtos)
            {
                commentContainer.GetAllCommentsByPostId(postdto.Id);
                Post post = new Post(postdto, userContainer.GetUserByPostId(postdto.Id), commentContainer.Comments, context);
                posts.Add(post);
            }
            Posts = posts;
        }

        public void GetAllPostsDesc()
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            List<Post> posts = new List<Post>();
            postdtos = postContainer.GetAllPosts();
            foreach (var postdto in postdtos)
            {
                commentContainer.GetAllCommentsByPostId(postdto.Id);
                Post post = new Post(postdto, userContainer.GetUserByPostId(postdto.Id), commentContainer.Comments, context);
                posts.Add(post);
            }
            Posts = posts;
        }

        public Post GetPostById(int postid)
        {
            PostDTO postdto = new PostDTO();
            postdto = postContainer.GetPostById(postid);
            commentContainer.GetAllCommentsByPostId(postdto.Id);
            Post post = new Post(postdto, userContainer.GetUserByPostId(postid), commentContainer.Comments, context);

            return post;
        }
    }
}
