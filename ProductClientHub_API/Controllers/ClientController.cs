using Microsoft.AspNetCore.Mvc;
using ProductClientHub_API.UseCase.Clients.Delete;
using ProductClientHub_API.UseCase.Clients.GetAll;
using ProductClientHub_API.ÙseCase.Clients.Register;
using ProductClientHub_API.UseCase.Products.DeleteProductUseCase;
using ProductClientHub_Communication.Request;
using ProductClientHub_Communication.Response;

namespace ProductClientHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody]RequestClientJson request)
        {
            var useCase = new RegisterClientUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
        {
            var useCase = new UpdateClientsUseCase();

            useCase.Execute(id, request);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllClientsUseCase();

            var response = useCase.Execute();

            
            if(response.Clients.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid Id)
        {
            var useCase = new DeleteClientUseCase();

            useCase.Execute(Id);

            return NoContent();
        }
    }
}
