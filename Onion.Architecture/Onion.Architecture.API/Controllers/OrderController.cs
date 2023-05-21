using Microsoft.AspNetCore.Mvc;

namespace Onion.Architecture.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
 

    public OrderController()
    {
    }


    [HttpGet(Name = "getorders")]
    public IActionResult GetOrders()
    {
        return  Ok(decimal.One);
    }
}

