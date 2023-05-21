using Microsoft.AspNetCore.Mvc;

namespace Onion.Architecture.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
 
    public ProductController()
    {
        
    }

    [HttpGet(Name = "get-products")]
    public IActionResult GetProducts()
    {
        return Ok();
    }
}

