using DocumentManagerApi.Controllers;
using DocumentManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace DocumentManagerApiTest.Controllers;

using Xunit;
public class DocumentControllerTest
{
    private readonly DocumentController _documentController;
    private readonly Mock<IDocumentService> _docServiceMock;
    private readonly Mock<ILogger<DocumentController>> _loggerMock;
    public DocumentControllerTest()
    {
        _docServiceMock = new Mock<IDocumentService>();
        _loggerMock = new Mock<ILogger<DocumentController>>();
        var correlationId = Guid.NewGuid().ToString();

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers["X-Correlation-ID"] = correlationId;
        httpContext.Items["X-Correlation-ID"] = correlationId;
       
        _documentController = new DocumentController(_loggerMock.Object, _docServiceMock.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            }
        };
    }
    
    [Fact]
    public async Task Check_Add_Document()
    {
        // Arrange
        _docServiceMock.Setup(x => x.AddDocument()).Returns(Task.CompletedTask);
        
        // Act
        var result = await _documentController.Add();

        // Assert
         Assert.IsType<CreatedResult>(result);
        _docServiceMock.Verify(x => x.AddDocument(), Times.Once);
    }
}