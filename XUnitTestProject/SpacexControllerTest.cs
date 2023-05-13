using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpacexLaunches.Controllers;
using Xunit;

namespace XUnitTestProject
{
    public class SpacexControllerTest
    {
        private class HttpMessageHandlerMock : HttpMessageHandler
        {
            private readonly HttpStatusCode _statusCode;
            private readonly HttpResponseMessage _response;

            public HttpMessageHandlerMock(HttpStatusCode statusCode)
            {
                _statusCode = statusCode;
            }

            public HttpMessageHandlerMock(HttpResponseMessage response)
            {
                _response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (_response != null)
                {
                    return Task.FromResult(_response);
                }
                
                return Task.FromResult(new HttpResponseMessage()
                {
                    StatusCode = _statusCode,
                });
            }
        }

        [Fact]
        public async Task GetAllLaunchAsync_ReturnsBadRequest_When_NotFound()
        {
            var http = new HttpClient(new HttpMessageHandlerMock(HttpStatusCode.NotFound));

            var spacexController = new SpacexController(http);

            var result = await spacexController.GetAllLaunchAsync();
            Assert.IsType<NotFoundObjectResult>(result);
        }
        
        [Fact]
        public async Task GetAllLaunchAsync_ReturnsProblem_When_ProblemInJson()
        {
            var http = new HttpClient(new HttpMessageHandlerMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK, Content = new StringContent("{}")
            }));

            var spacexController = new SpacexController(http);

            var result = await spacexController.GetAllLaunchAsync();
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact]
        public async Task GetAllLaunchAsync_ReturnsOk_When_GoodJson()
        {
            var http = new HttpClient(new HttpMessageHandlerMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK, Content = new StringContent("[{\"flight_number\":1,\"name\":\"FalconSat\",\"id\":\"5eb87d46ffd86e000604b388\",\"rocket\":\"5e9d0d95eda69955f709d1eb\",\"launchpad\":\"5e9d0d95eda69955f709d1eb\",\"date_utc\":\"2006-03-24T22:30:00.000Z\",\"success\":false,\"detail\":\"FalconSat\",\"crew\":[],\"ship\":[]}]")
            }));;

            var spacexController = new SpacexController(http);

            var result = await spacexController.GetAllLaunchAsync();
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async Task GetLaunchByIdAsync_ReturnsBadRequest_When_NotFound()
        {
            var http = new HttpClient(new HttpMessageHandlerMock(System.Net.HttpStatusCode.NotFound));

            var spacexController = new SpacexController(http);

            var result = await spacexController.GetLaunchByIdAsync("1");
            Assert.IsType<NotFoundObjectResult>(result);
        }
        
        [Fact]
        public async Task GetLaunchByIdAsync_ReturnsProblem_When_ProblemInJson()
        {
            var http = new HttpClient(new HttpMessageHandlerMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK, Content = new StringContent("")
            }));

            var spacexController = new SpacexController(http);

            var result = await spacexController.GetLaunchByIdAsync("1");
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact]
        public async Task GetLaunchByIdAsync_ReturnsOk_When_GoodJson()
        {
            var http = new HttpClient(new HttpMessageHandlerMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK, Content = new StringContent("{\"flight_number\":1,\"name\":\"FalconSat\",\"id\":\"5eb87d46ffd86e000604b388\",\"rocket\":\"5e9d0d95eda69955f709d1eb\",\"launchpad\":\"5e9d0d95eda69955f709d1eb\",\"date_utc\":\"2006-03-24T22:30:00.000Z\",\"success\":false,\"detail\":\"FalconSat\",\"crew\":[],\"ship\":[]}")
            }));

            var spacexController = new SpacexController(http);

            var result = await spacexController.GetLaunchByIdAsync("1");
            Assert.IsType<OkObjectResult>(result);
        }
    }
}