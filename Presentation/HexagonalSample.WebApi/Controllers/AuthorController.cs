using HexagonalSample.Application.DtoClasses.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HexagonalSample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public record CreateAuthorRequest(string FirstName, string LastName, string Bio);
        public record UpdateAuthorRequest(string FirstName, string LastName, string Bio);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAuthorByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequest request)
        {
            var command = new CreateAuthorCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Bio = request.Bio
            };

            await _mediator.Send(command);
            return Ok("Author created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorRequest request)
        {
            var command = new UpdateAuthorCommand
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Bio = request.Bio
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
