using System;
using NUnit.Framework;
using Moq;
using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.Business_Logic_Layer.Services;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.PLL.Views;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.Data_Access_Layer.Entites;
using SocialNetwork.Data_Access_Layer.Repositories;
namespace TestAddFriends

{
    [TestFixture]
    public class UserServiceTests
    {
        /// <summary>
        /// Успешное добавление друга
        /// </summary>
        [Test]
        public void AddFriends_ShouldAddFriendSuccessfully()
        {
            // Arrange
            var mockFriendRepository = new Mock<IFriendRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockMessageService = new Mock<MessageService>();

            var userService = new UserService
            {
                userRepository = mockUserRepository.Object,
                friendRepository = mockFriendRepository.Object,
                messageService = mockMessageService.Object
            };

            var userEntity = new UserEntity
            {
                id = 1,
                firstname = "John",
                lastname = "Doe",
                password = "password",
                email = "john.doe@example.com",
                photo = "photo.jpg",
                favorite_movie = "Movie",
                favorite_book = "Book"
            };

            mockUserRepository.Setup(repo => repo.FindByEmail("friend@example.com")).Returns(userEntity);
            mockFriendRepository.Setup(repo => repo.Create(It.IsAny<FriendEntity>())).Returns(1);

            var userAddindFriendsData = new UserAddindFriendsData
            {
                Email = "friend@example.com",
                UserId = 1
            };

            // Act
            userService.AddFriends(userAddindFriendsData);

            // Assert
            mockFriendRepository.Verify(repo => repo.Create(It.IsAny<FriendEntity>()), Times.Once);
        }
        /// <summary>
        /// Ошибка, если пользователь не найден.
        /// </summary>
        [Test]
        public void AddFriends_ShouldThrowExceptionIfUserNotFound()
        {
            // Arrange
            var mockFriendRepository = new Mock<IFriendRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockMessageService = new Mock<MessageService>();

            var userService = new UserService
            {
                userRepository = mockUserRepository.Object,
                friendRepository = mockFriendRepository.Object,
                messageService = mockMessageService.Object
            };

            mockUserRepository.Setup(repo => repo.FindByEmail("friend@example.com")).Returns((UserEntity)null);

            var userAddindFriendsData = new UserAddindFriendsData
            {
                Email = "friend@example.com",
                UserId = 1
            };

            // Act & Assert
            Assert.Throws<UserNotFoundException>(() => userService.AddFriends(userAddindFriendsData));
        }
        /// <summary>
        /// Ошибка, если создание друга не удалось.
        /// </summary>
        [Test]
        public void AddFriends_ShouldThrowExceptionIfFriendCreationFails()
        {
            // Arrange
            var mockFriendRepository = new Mock<IFriendRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockMessageService = new Mock<MessageService>();

            var userService = new UserService
            {
                userRepository = mockUserRepository.Object,
                friendRepository = mockFriendRepository.Object,
                messageService = mockMessageService.Object
            };

            var userEntity = new UserEntity
            {
                id = 1,
                firstname = "John",
                lastname = "Doe",
                password = "password",
                email = "john.doe@example.com",
                photo = "photo.jpg",
                favorite_movie = "Movie",
                favorite_book = "Book"
            };

            mockUserRepository.Setup(repo => repo.FindByEmail("friend@example.com")).Returns(userEntity);
            mockFriendRepository.Setup(repo => repo.Create(It.IsAny<FriendEntity>())).Returns(0);

            var userAddindFriendsData = new UserAddindFriendsData
            {
                Email = "friend@example.com",
                UserId = 1
            };

            // Act & Assert
            Assert.Throws<Exception>(() => userService.AddFriends(userAddindFriendsData));
        }
    }
}