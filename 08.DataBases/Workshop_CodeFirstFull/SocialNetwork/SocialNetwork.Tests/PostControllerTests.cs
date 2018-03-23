using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.ConsoleClient.Controllers;
using SocialNetwork.Logic.Contracts;
using SocialNetwork.Logic.Models;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class PostControllerTests
    {
        //// If you do not inject the automapper you must initilize it in any test.
        //[ClassInitialize]
        //public static void InitilizeAutomapper(TestContext context)
        //{
        //    AutomapperConfiguration.Initialize();
        //}

        [TestMethod]
        public void CreatePost()
        {
            // Arrange
            var mockService = new Mock<IPostService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new PostController(mockService.Object, mockMapper.Object);

            // Act
            controller.CreatePost("New post created");

            // Assert
            mockService.Verify(x => x.AddPost(It.IsAny<PostModel>()), Times.Once);
        }
    }
}
