using Moq;
using Moq.Protected;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
            var sut = new UsersService(httpClient);

            // Act
            await sut.GetAllUsers();

            // Assert [See MockHttpMessageHandler.cs for Reference]
            handlerMock.Protected()
                .Verify("SendAsync", Times.Exactly(1), // Verify that the http message sends exactly once
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get), // verify that http message is of type method = GET
                ItExpr.IsAny<CancellationToken>()); // 2nd argument is a cancellation token 
        }
    }


}
