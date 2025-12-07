using MediatR;

namespace HexagonalSample.Application.DtoClasses.Products
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
    }

    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
