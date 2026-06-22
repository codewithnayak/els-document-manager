using Microsoft.AspNetCore.Mvc;

namespace DocumentManagerApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DocumentController : Controller
{
    private readonly ILogger<DocumentController> _logger ;
    
    public DocumentController(ILogger<DocumentController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost]
    [Route("add")]
    public IActionResult Add()
    {
        
        _logger.LogInformation("Document added successfully for correlation id:");
        return Created();
    }
}