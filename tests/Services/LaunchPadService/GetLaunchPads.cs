using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Services.LaunchPadService
{
    public class GetLaunchPads
    {
 
        [Fact]
        public async Task Should_ReturnResults()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )

               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("[{'id':'test','full_name':'test','status':'test'}]"),
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);

            var subjectUnderTest = new LaunchPadAPI.Services.LaunchPadService(httpClient);

            var result = await subjectUnderTest
               .GetLaunchPads("http://test.com/", 10, 1);

            Assert.NotEmpty(result);
        }
    }
}
