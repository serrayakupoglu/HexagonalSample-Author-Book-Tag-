using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Categories;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.CategoryUseCases
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoriesQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();

            return categories.Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.CategoryName,
                Description = c.Description
            }).ToList();
        }
    }

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return null;
            }

            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.CategoryName,
                Description = category.Description
            };
        }
    }
}
