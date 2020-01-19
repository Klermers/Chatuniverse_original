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
        private ICommentContainer commentContainerRepository;
        private UserContainer userContainer;

        public List<Comment> Comments
        {
            get;
            private set;
        }

        public CommentContainer(ICommentContainer comment, IUserContainer user)
        {
            commentContainerRepository = comment;
            userContainer = new UserContainer(user);
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
