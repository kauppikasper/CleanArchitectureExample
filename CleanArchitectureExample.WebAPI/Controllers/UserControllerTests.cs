﻿using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.WebAPI.Controllers;
using CleanArchitectureExample.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace CleanArchitectureExample.WebAPI.Controllers
{
    public class UserControllerTests
    {
        [Fact]

        public async Task ReqisterUserAsync_ReturnCreatedResult_WhenRegistrationSucceeds()
        {
            //Arrange

            var mockService = new Mock<IUserRegistrationService>();

            mockService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            var controller = new UsersController(mockService.Object);

            var result = await controller.RegisterUserAsync(new UserRegistrationRequest { Name = "Testi", Email = "testi@test.com" });

            Assert.IsType < CreatedResult>(result);

        }

        [Fact]

        public async Task ReqisterUserAsync_ReturnsBadRequest_WhenRegistrationFails()
        {
            //Arrange

            var mockService = new Mock<IUserRegistrationService>();

            mockService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(false);

            var controller = new UsersController(mockService.Object);

            var result = await controller.RegisterUserAsync(new UserRegistrationRequest { Name = "Testi", Email = "fail@test.com" });

            Assert.IsType<BadRequestObjectResult>(result);

        }

    }
}
