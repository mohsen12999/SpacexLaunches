using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpacexLaunches.Controllers;
using Xunit;

namespace XUnitTestProject
{
    public class SpacexControllerTest
    {
        public class HttpMessageHandlerMock : HttpMessageHandler
        {
            public readonly System.Net.HttpStatusCode _statusCode;

            public HttpMessageHandlerMock(System.Net.HttpStatusCode statusCode)
            {
                _statusCode = statusCode;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage()
                {
                    StatusCode = _statusCode,
                });
            }
        }

        [Fact]
        public async Task ReturnsBadRequest_When_NotFoundAsync()
        {
            var http = new HttpClient(new HttpMessageHandlerMock(System.Net.HttpStatusCode.NotFound));

            var spacexController = new SpacexController(http);

            var result = await spacexController.GetAllLaunchAsync();
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}