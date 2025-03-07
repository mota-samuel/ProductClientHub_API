using Microsoft.AspNetCore.Mvc;
using ProductClientHub_API.ÙseCase.Clients.Register;
using ProductClientHub_API.UseCase.Products.RegisterProductUseCase;
using ProductClientHub_Communication.Request;
using ProductClientHub_Communication.Response;

namespace ProductClientHub_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    [Route("{clientId}")]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromRoute]Guid clientId,[FromBody] RequestProductJson request)
    {
        var useCase = new RegisterProductUseCase();

        var response = useCase.Execute(clientId, request);

        return Created(string.Empty, response);
    }
}
