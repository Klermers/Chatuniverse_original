using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.Tests
{
    [TestClass()]
    public class PostTests
    {
        [TestMethod()]
        public void CreatePostTest_MinumumLetters_ReturnString()
        {
            //Arrange
            string posttitel = "ZooAnimals are dying";
            Post post = new Post(posttitel);
            string expected = "Post is Created";
            //Act
            string result = post.CreatePost(5, 4);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CreatePostTest_MoreLetter_ReturnString()
        {
            //Arrange
            string posttitel = "ZooAnimal";
            Post post = new Post(posttitel);
            string expected = "Titel needs a minimum of 10";
            //Act
            string result = post.CreatePost(5, 4);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}