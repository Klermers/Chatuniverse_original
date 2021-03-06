﻿using System;
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
        private ICommentRepository commentContainerRepository;
        private UserContainer userContainer;

        public List<Comment> Comments
        {
            get;
            private set;
        }

        public CommentContainer(IConnectionString conn)
        {
            commentContainerRepository = new Commentrepository(new CommentSQL(conn)); ;
            userContainer = new UserContainer(conn);
        }

        public void GetAllCommentsByPostId(int postid)
        {
            List<CommentDTO> commentdtos = new List<CommentDTO>();
            List<Comment> comments = new List<Comment>();
            commentdtos = commentContainerRepository.GetAllCommentsByPostId(postid);
            foreach (var commentdto in commentdtos)
            {
                Comment comment = new Comment(commentdto, userContainer.GetUserByCommentId(commentdto.Id));
                comments.Add(comment);
            }
            Comments = comments;
        }

    }
}
