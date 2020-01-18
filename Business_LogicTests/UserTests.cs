using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Data_Acces_Layer.Repository;

namespace Business_Logic.Tests
{
    [TestClass()]
    public class UserTests
    {
        //intergration test
        [TestMethod()]
        public void CreateUserTest_DifferentUsername_ReturnString()
        {
            //Arrange
            string username = "username";
            string password = "ditiseenlange";
            UserContainer usercontainer = new UserContainer();
            string expected = "You made a account with chatuniverse.";
            //Act
            User user = usercontainer.GetUserByUsernamePassword(username, password);
            string result = user.CreateUser(username,password);
            //Assert

            Assert.AreEqual(expected, result);
            
        }
        [TestMethod()]
        public void CreateUserTest_UseralreadyExists_ReturnString()
        {
            //Arrange
            string username = "username";
            string password = "ditiseenlange";
            UserContainer usercontainer = new UserContainer();
            string expected = "This username is already taken or your password is shorter than 15 letters.";
            //Act
            User user = usercontainer.GetUserByUsernamePassword(username, password);
            string result = user.CreateUser(username, password);
            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CreateUserTest_PasswordShort_ReturnString()
        {
            //Arrange
            string username = "username2";
            string password = "ditisee";
            UserContainer usercontainer = new UserContainer();
            string expected = "This username is already taken or your password is shorter than 15 letters.";
            //Act
            User user = usercontainer.GetUserByUsernamePassword(username, password);
            string result = user.CreateUser(username, password);
            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void LeaveForummTest_UserNotJoined_ReturnString()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            User user = usercontainer.GetUserByForumId(5,4);
            string expected = "You aren't a user so you can'tjoin a forum";
            //Act
            string result = user.LeaveForum(1);
            //Assert
            Assert.AreEqual(expected, result);

        }
        [TestMethod()]
        public void LeaveForummTest_Userexist_ReturnString()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            User user = usercontainer.GetUserByForumId(5,4);
            string expected = "You left the forum";
            //Act
            string result = user.LeaveForum(5);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void JoinForumTest_UserExists_ReturnString()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            User user = usercontainer.GetUserByForumId(5, 4);
            string expected = "User has already join the forum"; ;
            //Act
            string result = user.JoinForum(5,3);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void JoinForumTest_UserNotJoined_ReturnString()
        {
            //Arrange
            UserContainer usercontainer = new UserContainer();
            User user = usercontainer.GetUserByForumId(5, 4);
            string expected = "User Has joined this forum"; 
            //Act
            string result = user.JoinForum(5,4);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}