using HexagonalSample.Application.DtoClasses.Books;
using HexagonalSample.Application.DtoClasses.Books.HexagonalSample.Application.DtoClasses.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HexagonalSample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public record CreateBookRequest(string Title, string Description, DateTime? PublishedOn, int AuthorId, int CategoryId);
        public record UpdateBookRequest(string Title, string Description, DateTime? PublishedOn, int AuthorId, int CategoryId);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest request)
        {
            var command = new CreateBookCommand
            {
                Title = request.Title,
                Description = request.Description,
                PublishedOn = request.PublishedOn,

            };

            await _mediator.Send(command);
            return Ok("Book created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookRequest request)
        {
            var command = new UpdateBookCommand
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                PublishedOn = request.PublishedOn,

            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
