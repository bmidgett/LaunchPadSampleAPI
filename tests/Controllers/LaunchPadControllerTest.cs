using LaunchPadAPI.Controllers;
using LaunchPadAPI.Models;
using LaunchPadAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Controllers
{
    public class LaunchPadControllerTest
    {
        private readonly Mock<ILaunchPadService> _serviceMock;
        private readonly Mock<ILogger<LaunchPadController>> _loggerMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly IEnumerable<LaunchPad> _pads;

        public LaunchPadControllerTest()
        {
            _serviceMock = new Mock<ILaunchPadService>();
            _loggerMock = new Mock<ILogger<LaunchPadController>>();
            _configMock = new Mock<IConfiguration>();

            _pads = new List<LaunchPad>()
            {
                new LaunchPad
                {
                    Id = "xyz",
                    Name = "Test Pad",
                    Status = "active"
                }
            };

            _serviceMock.Setup(s => s.GetLaunchPads(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(_pads);

            var sectionMock = new Mock<IConfigurationSection>();
            sectionMock.Setup(a => a.Value).Returns("https://test.com");

            _configMock.Setup(a => a.GetSection("SpaceX:BaseUri")).Returns(sectionMock.Object);
        }

        [Fact]
        public void Get_Should_ReturnSingleResult()
        {
            var subjectUnderTest = new LaunchPadController(
                    _serviceMock.Object,
                    _loggerMock.Object,
                    _configMock.Object
                );

            var result = subjectUnderTest.Get().Result as OkObjectResult;

            var items = Assert.IsAssignableFrom<List<LaunchPad>>(result.Value);
            Assert.Single(items);
        }
    }
}
