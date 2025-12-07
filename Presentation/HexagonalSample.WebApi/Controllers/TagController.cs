using HexagonalSample.Application.DtoClasses.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HexagonalSample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public record CreateTagRequest(string Name);
        public record UpdateTagRequest(string Name);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTagsQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTagByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            var command = new CreateTagCommand
            {
                Name = request.Name
            };

            await _mediator.Send(command);
            return Ok("Tag created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTagRequest request)
        {
            var command = new UpdateTagCommand
            {
                Id = id,
                Name = request.Name
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTagCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
