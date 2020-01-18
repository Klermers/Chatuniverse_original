using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.Tests
{
    [TestClass()]
    public class CommentTests
    {
        [TestMethod()]
        public void CreateCommentTest_NeedMoreLetters_ReturnString()
        {
            //Arrange
            string text = "Testcomment";
            string expect = "You need a minimum of 20 letters";
            Comment comment = new Comment(text);
            //Act
            string result = comment.CreateComment(2, 4);
            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod()]
        public void CreateCommentTest_MinimalTextlengh_ReturnString()
        {
            //Arrange
            string text = "ThisCommentneedstobetwentywordlong";
            string expect = "Comment is created ";
            Comment comment = new Comment(text);
            //Act
            string result = comment.CreateComment(2, 4);
            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod()]
        public void UpdateComment_CommentTest()
        {
            //Arrange
            string text = "ThisCommentwillupdatetheolderone";
            string expect = "Comment is Changed ";
            Comment comment = new Comment(1,text);
            //Act
            string result = comment.UpdateComment_Text();
            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod()]
        public void UpdateComment_CommentTest1()
        {
            //Arrange
            string text = "ThisComment";
            string expect = "You need a minimum of 20 letters";
            Comment comment = new Comment(1, text);
            //Act
            string result = comment.UpdateComment_Text();
            //Assert
            Assert.AreEqual(expect, result);
        }
    }
}