using FifaFinderAPI.Controllers;
using FifaFinderAPI.Library.Interfaces;
using FifaFinderAPI.Library.Models;
using FifaFinderAPI.Library.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FifaFinderTest
{
    public class UserControllerTest
    {
        private Mock<ILogger<UserController>> _logger;
        private Mock<IRepositoryWrapper> mockRepo;
        private UserController userController;
        private User user;
        private RegisterUser registerUser;
        private LoginUser loginUser;
        private Mock<ILoginUser> loginUserMock;
        private Mock<IRegisterUser> registerUserMock;
        private List<User> users;
        private Mock<IUser> userMock;
        private List<IUser> usersMock;
        

        public UserControllerTest()
        {
            //mock setup
            userMock = new Mock<IUser>();
            usersMock = new List<IUser> { userMock.Object };
            user = new User();
            users = new List<User>();

            //sample models


            //controller setup
            //courseControllerMock = new Mock<ICourseController>();
            _logger = new Mock<ILogger<UserController>>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allUsers = GetUsers();
            userController = new UserController(_logger.Object, mockRepo.Object);
        }

        [Fact]
        public void GetUsers_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Users.FindAll()).Returns(GetUsers());
            // act 
            var controllerActionResult = userController.GetUsers();
            // assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void LoginUser_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Users.FindByCondition(u => u.ID == It.IsAny<int>())).Returns(GetUsers());
            LoginUser potentialUser = new LoginUser() { Username = "BarryBoy", Password = "password" };
            // act 
            var controllerJsonResult = userController.LoginUser(potentialUser);
            // assert
            Assert.NotNull(controllerJsonResult);
            Assert.IsType<JsonResult>(controllerJsonResult);
        }
        [Fact]
        public void RegisterUser_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Users.FindByCondition(u => u.ID == It.IsAny<int>())).Returns(GetUsers());
            RegisterUser potentialUser = new RegisterUser() { Username = "BarryBoy", Email = "barryboy@gmail.com", Password = "password" };
            // act 
            var controllerJsonResult = userController.RegisterUser(potentialUser);
            // assert
            Assert.NotNull(controllerJsonResult);
            Assert.IsType<JsonResult>(controllerJsonResult);
        }
        [Fact]
        public void DeleteUser_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Users.FindByCondition(u => u.ID == It.IsAny<int>())).Returns(GetUsers());
            mockRepo.Setup(repo => repo.Users.Delete(GetUser()));
            // act 
            var controllerJsonResult = userController.DeleteUser(It.IsAny<int>());
            // assert
            Assert.NotNull(controllerJsonResult);
        }


        private IEnumerable<User> GetUsers()
        {
            var users = new List<User> {
            new User(){ID = 1, Username = "JoeBloggs", Email = "joebloggs@gmail.com", Password="password", CreatedAt = DateTime.Now},
            new User(){ID = 2, Username = "SallyBobert", Email = "sallybobert@gmail.com", Password="password", CreatedAt = DateTime.Now}
            };
            return users;
        }
        private User GetUser()
        {
            return GetUsers().ToList()[0];
        }
    }
}
