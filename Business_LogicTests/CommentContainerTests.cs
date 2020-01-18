using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.Tests
{
    [TestClass()]
    public class CommentContainerTests
    {
        [TestMethod()]
        public void GetAllCommentsByPostIdTest_NotNull_ReturnEqual()
        {
            //Arrange
            CommentContainer commentcontainer = new CommentContainer();
            //Act
            commentcontainer.GetAllCommentsByPostId(2);
            List<Comment> resultcomments = commentcontainer.Comments;
            //Assert
            CollectionAssert.AllItemsAreUnique(resultcomments);
            CollectionAssert.AllItemsAreNotNull(resultcomments);
        }

        [TestMethod()]
        public void GetAllCommentsByPostIdTest_Null_ReturnEqual()
        {
            //Arrange
            CommentContainer commentcontainer = new CommentContainer();
            List<Comment> expectedcomments = new List<Comment>();
            //Act
            commentcontainer.GetAllCommentsByPostId(1);
            List<Comment> resultcomments = commentcontainer.Comments;
            //Assert
            CollectionAssert.AreEquivalent(expectedcomments, resultcomments);
        }
    }
}