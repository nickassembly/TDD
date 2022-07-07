using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TDD.Tests.Helpers
{
    // Mock HTTP client used only for testing
    // Static method takes a generic resource list and returns a response
    // All based on Http Message Handler
    internal static class MockHttpMessageHandler<T>
    {
        internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };

            mockResponse.Content.Headers.ContentType = 
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return handlerMock;
        }
    }
}   
