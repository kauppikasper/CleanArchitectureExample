using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.Application.Services;
using CleanArchitectureExample.Domain.Entities;
using CleanArchitectureExample.Domain.Interfaces;
using CleanArchitectureExample.WebAPI.Controllers;
using CleanArchitectureExample.WebAPI.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace CleanArchitectureExample.WebAPI.Controllers
{
    public class UserRegistrationServiceTests
    {
        [Fact]

        public async Task RegisterUserAsync_ReturnsFalse_IfEmailExists()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.EmailExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            var service = new UserRegistrationService(mockRepo.Object);

            var result = await service.RegisterUserAsync("Test User", "test@example.com");

            Assert.False(result);
        }

        [Fact]

        public async Task RegisterUserAsync_ReturnsTrue_IfRegistrationSucceeds()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.EmailExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var service = new UserRegistrationService(mockRepo.Object);

            var result = await service.RegisterUserAsync("New User", "new@example.com");

            Assert.True(result);
        }

    }
}
