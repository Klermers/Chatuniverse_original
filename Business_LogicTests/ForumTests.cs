using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.InMemory;

namespace Business_Logic.Tests
{
    [TestClass()]
    public class ForumTests
    {
        [TestMethod()]
        public void CreateForumTest_NotTitelMinimumLength_ReturnString()
        {
            //Arrange
            string titel = "Thistitel";
            string description = "Thisdescriptionisprettylong";
            Forum forum = new Forum(titel, description);
            string expected = "Titel is lower than 10 or Description is lower than 20";
            //Act
            string result = forum.CreateForum();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CreateForumTest_PasswordMinimumLength_ReturnString()
        {
            //Arrange
            string titel = "Thistitelislongenough";
            string description = "This";
            Forum forum = new Forum(titel, description);
            string expected = "Titel is lower than 10 or Description is lower than 20";
            //Act
            string result = forum.CreateForum();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CreateForumTest_MinimumLength_ReturnString()
        {
            //Arrange
            string titel = "Thistitelislongenough";
            string description = "Thisdescriptionisprettylong";
            Forum forum = new Forum(titel, description);
            string expected = "forum is Created";
            //Act
            string result = forum.CreateForum();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void UpdateForum_DescriptionTest()
        {
            //Arrange
            string titel = "Thistitelislongenough";
            string description = "Thisdescriptionisprettylong";
            Forum forum = new Forum(titel, description);
            string expected = "forum is Created";
            //Act
            string result = forum.CreateForum();
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}