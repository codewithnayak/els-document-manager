using DocumentManagerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagerApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DocumentController : Controller
{
    private readonly ILogger<DocumentController> _logger ;
    private readonly IDocumentService _documentService;
    public DocumentController(ILogger<DocumentController> logger , IDocumentService documentService)
    {
        _logger = logger;
        _documentService = documentService;
    }
    
    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add()
    {
        var correlationId = HttpContext.Items["X-Correlation-ID"]?.ToString();
        await _documentService.AddDocument();
        _logger.LogInformation("Document added successfully for correlation id:{correlationId}" , correlationId);
        return Created();
    }
}