﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void CreateForumTest()
        {
            //Arrange
            Forum inputforum = new Forum("test", "Dit is een unit test", "MEM");
           
            ForumContainer forumcontainer = new ForumContainer(new Forumrepository(new ForumInMemory()));
            //Act
            inputforum.CreateForum();
            Forum getforum = forumcontainer.GetForumById(5);
            //Assert
            Assert.Equals(getforum, inputforum);
        }
    }
}