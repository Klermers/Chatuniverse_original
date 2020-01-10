using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.SQL;
using Data_Acces_Layer.InMemory;
using ChatUniverseInterface;

namespace Business_Logic
{
    public class CommentContainer
    {
        private ICommentRepository commentContainerRepository = new Commentrepository(new CommentSQL());
        private UserContainer userContainer = new UserContainer("SQL");
        private string context;

        public List<Comment> Comments
        {
            get;
            private set;
        }

        public CommentContainer(string context)
        {
            if (context == "SQL")
            {
                this.context = context;
                commentContainerRepository = new Commentrepository(new CommentSQL());
                userContainer = new UserContainer(context);
            }
            else if (context == "MEM")
            {
                this.context = context;
                commentContainerRepository = new Commentrepository(new CommentInMemory());
                userContainer = new UserContainer(context);
            }
        }

        public void GetAllCommentsByPostId(int postid)
        {
            List<CommentDTO> commentdtos = new List<CommentDTO>();
            List<Comment> comments = new List<Comment>();
            commentdtos = commentContainerRepository.GetAllCommentsByPostId(postid);
            foreach (var commentdto in commentdtos)
            {
                Comment comment = new Comment(commentdto, userContainer.GetUserByCommentId(commentdto.Id), context);
                comments.Add(comment);
            }
            Comments = comments;
        }

    }
}
