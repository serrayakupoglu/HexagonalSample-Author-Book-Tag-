using System;
using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Categories;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.CategoryUseCases
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                CategoryName = command.Name,
                Description = command.Description,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(category);
            return Unit.Value;
        }
    }
}
