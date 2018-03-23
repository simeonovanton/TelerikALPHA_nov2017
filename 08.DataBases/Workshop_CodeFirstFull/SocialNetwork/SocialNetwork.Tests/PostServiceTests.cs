using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Data;
using SocialNetwork.Data.Contracts;
using SocialNetwork.Logic;
using SocialNetwork.Logic.Models;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class PostServiceTests
    {
        //// If you do not inject the automapper you must initilize it in any test.
        //[ClassInitialize]
        //public static void InitilizeAutomapper(TestContext context)
        //{
        //    AutomapperConfiguration.Initialize();
        //}

        [TestMethod]
        public void AddPost()
        {
            // Arrange
            var mockContext = new Mock<ISocialNetworkDbContext>();
            var mockMapper = new Mock<IMapper>();

            var service = new PostService(mockContext.Object, mockMapper.Object);

            List<Post> posts = new List<Post>() { };
            var postsMock = posts.GetQueryableMockDbSet();

            mockContext.Setup(x => x.Posts).Returns(postsMock);
            mockContext.Setup(x => x.Posts.Add(It.IsAny<Post>())).Callback<Post>(x => posts.Add(x));

            // Act
            var postToAdd = new PostModel()
            {
                Content = "New post is added",
                PostedOn = DateTime.Now
            };

            service.AddPost(postToAdd);

            // Assert
            mockContext.Verify(x => x.Posts.Add(It.IsAny<Post>()), Times.Once);
        }

        [TestMethod]
        public void AddPostEffort()
        {
            // Arrange
            var effortContext = new SocialNetworkDbContext(Effort.DbConnectionFactory.CreateTransient());
            var mockMapper = new Mock<IMapper>();

            var postToReturn = new Post() {
                Content = "New post added map",
                PostedOn = DateTime.Now
            };

            mockMapper.Setup(x => x.Map<Post>(It.IsAny<PostModel>())).Returns(postToReturn);

            var service = new PostService(effortContext, mockMapper.Object);

            // Act
            var postToAdd = new PostModel()
            {
                Content = "New post is added",
                PostedOn = DateTime.Now
            };

            service.AddPost(postToAdd);

            // Assert
            Assert.AreEqual(1, effortContext.Posts.Count());
        }

        [TestMethod]
        public void AddPostTestMapperCalls()
        {
            // Arrange
            var mockContext = new Mock<ISocialNetworkDbContext>();
            var mockMapper = new Mock<IMapper>();

            var service = new PostService(mockContext.Object, mockMapper.Object);

            List<Post> posts = new List<Post>() { };
            var postsMock = posts.GetQueryableMockDbSet();

            mockContext.Setup(x => x.Posts).Returns(postsMock);

            // Mocking the Mapper in case you need to assert against the Mapper calls

            mockMapper.Setup(x => x.Map<Post>(It.IsAny<PostModel>())).Returns(It.IsAny<Post>());

            // Act
            var postToAdd = new PostModel()
            {
                Content = "New post is added",
                PostedOn = DateTime.Now
            };

            service.AddPost(postToAdd);

            // Assert
            // This is assertion agains Mapper calls
            mockMapper.Verify(x => x.Map<Post>(It.IsAny<PostModel>()), Times.Once);
        }
    }

}
