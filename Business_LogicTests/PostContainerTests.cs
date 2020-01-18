using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Business_Logic.Tests
{
    [TestClass()]
    public class PostContainerTests
    {
        [TestMethod()]
        public void GetAllPostsByForumIdTest_Null_ReturnEqual()
        {
            //Arrange
            PostContainer postcontainer = new PostContainer();
            List<Post> expectedpsots = new List<Post>();
            //Act
            postcontainer.GetAllPostsByForumId(100);
            List<Post> posts = postcontainer.Posts;
            //Assert
            CollectionAssert.AreEquivalent(expectedpsots, posts);
        }

        [TestMethod()]
        public void GetAllPostsByForumIdTest_NotNull_ReturnEqual()
        {
            //Arrange
            PostContainer postcontainer = new PostContainer();
            List<Post> expectedpsots = new List<Post>();
            //Act
            postcontainer.GetAllPostsByForumId(6);
            List<Post> posts = postcontainer.Posts;
            //Assert
            Assert.IsTrue(posts.Count == 3);
        }

        [TestMethod()]
        public void GetAllPostsByForumIdDescTest_Null_ReturnEqual()
        {
            //Arrange
            PostContainer postcontainer = new PostContainer();
            List<Post> expectedpsots = new List<Post>();
            //Act
            postcontainer.GetAllPostsByForumId(100);
            List<Post> posts = postcontainer.Posts;
            //Assert
            CollectionAssert.AreEquivalent(expectedpsots, posts);
        }

        [TestMethod()]
        public void GetAllPostsByForumIdDescTest_NotNull_ReturnEqual()
        {
            //Arrange
            PostContainer postcontainer = new PostContainer();
            List<Post> expectedpsots = new List<Post>();
            //Act
            postcontainer.GetAllPostsByForumId(6);
            List<Post> posts = postcontainer.Posts;
            //Assert
            Assert.IsTrue(posts.Count == 3);
        }

        [TestMethod()]
        public void GetPostByIdTest_Null_ReturnEqual()
        {
            //Arrange
            PostContainer postcontainer = new PostContainer();
            //Act
            Post post = postcontainer.GetPostById(100);
            //Assert
            Assert.IsNull(post.Posttitel);
        }

        [TestMethod()]
        public void GetPostByIdTest_NotNull_ReturnEqual()
        {
            //Arrange
            PostContainer postcontainer = new PostContainer();
            //Act
            Post post = postcontainer.GetPostById(2);
            //Assert
            Assert.IsNotNull(post.Posttitel);
        }
    }
}