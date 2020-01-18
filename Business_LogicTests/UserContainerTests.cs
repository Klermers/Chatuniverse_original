using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.SQL;
using DTO;

namespace Business_Logic.Tests
{
    [TestClass()]
    public class UserContainerTests
    {
        [TestMethod()]
        public void GetAllUsersByForumIdTest_ReturnUsers()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            List<User> expectedusers = new List<User>();
            //Act
            User user = usercontainer.GetUserByForumId(5, 4);
            expectedusers.Add(user);
            usercontainer.GetAllUsersByForumId(5);
            List<User> users = usercontainer.Users;
            //Assert
            CollectionAssert.Contains(expectedusers, user);
        }

        [TestMethod()]
        public void GetAllUsersByForumIdTest_ReturnNull()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            //Act
            User user = usercontainer.GetUserByForumId(5, 4);
            usercontainer.GetAllUsersByForumId(6);
            List<User> users = usercontainer.Users;
            //Assert
            CollectionAssert.DoesNotContain(users, user);
        }

        [TestMethod()]
        public void GetUserByPostIdTest_NotNull_ReturnEqual()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserById(4);
            User user = usercontainer.GetUserByPostId(2);
            //Assert
            Assert.AreEqual(Usercheck.Username, user.Username);
        }

        [TestMethod()]
        public void GetUserByPostIdTest_Null_ReturnEqual()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserById(4);
            User user = usercontainer.GetUserByPostId(1);
            //Assert
            Assert.AreNotEqual(Usercheck.Username, user.Username);
        }

        [TestMethod()]
        public void GetUserByCommentIdTest_NotNull_ReturnEqual()
        {
            //Assert
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserById(4);
            User user = usercontainer.GetUserByCommentId(1);
            //Assert
            Assert.AreEqual(Usercheck.Username, user.Username);
        }

        [TestMethod()]
        public void GetUserByCommentIdTest_Null_ReturnEqual()
        {
            //Assert
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserById(4);
            User user = usercontainer.GetUserByUsernamePassword("wrongusername", "wrongpassowrd");
            //Assert
            Assert.AreNotEqual(Usercheck.Username, user.Username);
        }

        [TestMethod()]
        public void GetUserByUsernamePasswordTest_NotNull_ReturnEqual()
        {
            //Assert
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserById(4);
            User user = usercontainer.GetUserByUsernamePassword("username", "password");
            //Assert
            Assert.AreNotEqual(Usercheck.Username, user.Username);
        }

        [TestMethod()]
        public void GetUserByIdTest_NotNull_ReturnEqual()
        {
            //Assert
            string username = "username";
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserById(4);
            //Assert
            Assert.AreEqual(Usercheck.Username, username);
        }

        [TestMethod()]
        public void GetUserByIdTest_Null_ReturnEqual()
        {
            //Assert
            string username = "username";
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserById(0);
            //Assert
            Assert.AreNotEqual(Usercheck.Username, username);
        }

        [TestMethod()]
        public void GetUserByForumIdTest_Null_ReturnEqual()
        {
            string username = "";
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserByForumId(5,4);
            //Assert
            Assert.AreNotEqual(Usercheck.Username, username);
        }

        [TestMethod()]
        public void GetUserByForumIdTest_NotNull_ReturnEqual()
        {
            string username = "username";
            UserContainer usercontainer = new UserContainer();
            //Act
            User Usercheck = usercontainer.GetUserByForumId(5,4);
            //Assert
            Assert.AreEqual(Usercheck.Username, username);
        }
    }
}