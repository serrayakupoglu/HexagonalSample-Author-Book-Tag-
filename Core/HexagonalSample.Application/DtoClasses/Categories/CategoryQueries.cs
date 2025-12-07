using MediatR;
using System.Collections.Generic;

namespace HexagonalSample.Application.DtoClasses.Categories
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GetAllCategoriesQuery : IRequest<List<CategoryResponse>>
    {
    }

    public class GetCategoryByIdQuery : IRequest<CategoryResponse>
    {
        public int Id { get; set; }
    }
}
