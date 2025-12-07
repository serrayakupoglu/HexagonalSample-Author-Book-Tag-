using MediatR;

namespace HexagonalSample.Application.DtoClasses.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
