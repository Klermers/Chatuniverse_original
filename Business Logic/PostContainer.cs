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
        private IPostContainer postrepository;
        private CommentContainer commentContainer;

        public List<Post> Posts
        {
            get;
            private set;
        }

        public PostContainer()
        {

        }

        public PostContainer(IPostContainer post, ICommentContainer comment, IUserContainer user)
        {
            postrepository = post;
            commentContainer = new CommentContainer(comment,user);
            userContainer = new UserContainer(user);
        }

        public void GetAllPostsByForumId(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            List<Post> posts = new List<Post>();
            postdtos = postrepository.GetAllPostsByForumId(forumid);
            foreach (var postdto in postdtos)
            {
                commentContainer.GetAllCommentsByPostId(postdto.Id);
                Post post = new Post(postdto, userContainer.GetUserByPostId(postdto.Id), commentContainer.Comments);
                posts.Add(post);
            }
            Posts = posts;
        }


        public void GetAllPostsByForumIdDesc(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            List<Post> posts = new List<Post>();
            postdtos = postrepository.GetAllPostsByForumIdDesc(forumid);
            foreach (var postdto in postdtos)
            {
                commentContainer.GetAllCommentsByPostId(postdto.Id);
                Post post = new Post(postdto, userContainer.GetUserByPostId(postdto.Id), commentContainer.Comments);
                posts.Add(post);
            }
            Posts = posts;
        }

        public Post GetPostById(int postid)
        {
            PostDTO postdto = new PostDTO();
            postdto = postrepository.GetPostById(postid);
            commentContainer.GetAllCommentsByPostId(postdto.Id);
            Post post = new Post(postdto, userContainer.GetUserByPostId(postid), commentContainer.Comments);

            return post;
        }
    }
}
