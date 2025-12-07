using HexagonalSample.Application.DtoClasses.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalSample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public record CreateCategoryRequest(string Name, string Description);
        public record UpdateCategoryRequest(string Name, string Description);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand
            {
                Name = request.Name,
                Description = request.Description
            };

            await _mediator.Send(command);
            return Ok("Category created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryRequest request)
        {
            var command = new UpdateCategoryCommand
            {
                Id = id,
                Name = request.Name,
                Description = request.Description
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
