namespace DocumentManagerApi.Services;

public class DocumentService : IDocumentService
{
    private readonly ILogger<DocumentService> _logger;
    
    public DocumentService(ILogger<DocumentService> logger)
    {
        _logger = logger;
    }
    
    //Return response object
    public async Task AddDocument()
    {
        _logger.LogInformation("Document added successfully");
         await AddDocumentAsync();
    }
    
    private async Task AddDocumentAsync()
    {
        await Task.Delay(1000);
    }
}