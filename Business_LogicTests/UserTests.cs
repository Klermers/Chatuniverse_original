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
            string username = "UnitTestUser";
            string password = "ThisisaTestwith";
            User user = new User(username,password);
            string expected = "You made a account with chatuniverse.";
            //Act
            string result = user.CreateUser();
            //Assert
            Assert.AreEqual(expected, result);
            
        }

        [TestMethod()]
        public void CreateUserTest_UseralreadyExists_ReturnString()
        {
            //Arrange
            string username = "klerm";
            string password = "catlover1214";
            User user = new User(username, password);
            string expected = "This username is already taken or your password is shorter than 15 letters.";
            //Act
            string result = user.CreateUser();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CreateUserTest_PasswordShort_ReturnString()
        {
            //Arrange
            string username = "langejan";
            string password = "nietlang";
            User user = new User(username, password);
            string expected = "This username is already taken or your password is shorter than 15 letters.";
            //Act
            string result = user.CreateUser();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void LeaveForummTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void JoinForumTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoginUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUser_PasswordTest()
        {
            Assert.Fail();
        }
    }
}