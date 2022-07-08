using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TDD.API.Config;
using TDD.API.Models;
using TDD.API.Services;
using TDD.Tests.Fixtures;
using TDD.Tests.Helpers;
using Xunit;

namespace TDD.Tests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            // Arrange
            var expectedResponse = UsersFixture.GetTestUsers(); // gets the test users from fixture
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse); // passes in fake users as expected response in http mock
            var httpClient = new HttpClient(handlerMock.Object); // a real Http client but HttpMessageHandler is the Mock we set up
            var endpoint = "https://example.com";
            var config = Options.Create(new UsersApiOptions { Endpoint = endpoint });
            var sut = new UsersService(httpClient, config);

            // Act
            await sut.GetAllUsers();

            // Assert [See MockHttpMessageHandler.cs for Reference]
            handlerMock.Protected()
                .Verify("SendAsync", Times.Exactly(1), // Verify that the http message sends exactly once
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get), // verify that http message is of type method = GET
                ItExpr.IsAny<CancellationToken>()); // 2nd argument is a cancellation token 
        }

        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        {
            // Arrange
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://example.com";
            var config = Options.Create(new UsersApiOptions { Endpoint = endpoint });
            var sut = new UsersService(httpClient, config);

            // Act
            var result = await sut.GetAllUsers();

            // Assert 
            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
        {
            // Arrange
            var expectedResponse = UsersFixture.GetTestUsers(); 
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse); 
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://example.com";
            var config = Options.Create(new UsersApiOptions { Endpoint = endpoint });
            var sut = new UsersService(httpClient, config);

            // Act
            var result = await sut.GetAllUsers();

            // Assert 
            result.Count.Should().Be(expectedResponse.Count);
        }

        [Fact]
        // todo fix test
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {
            // Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "https://example.com/users";
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse, endpoint);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UsersService(httpClient, config);

            // Act
            var result = await sut.GetAllUsers();

            // Assert 
            handlerMock.Protected()
                 .Verify("SendAsync", Times.Exactly(1), 
                 ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri.ToString() == endpoint), 
                 ItExpr.IsAny<CancellationToken>());
        }

    }


}
