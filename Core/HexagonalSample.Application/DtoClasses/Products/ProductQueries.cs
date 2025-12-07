using MediatR;
using System.Collections.Generic;

namespace HexagonalSample.Application.DtoClasses.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
    }

    public class GetAllProductsQuery : IRequest<List<ProductResponse>>
    {
    }

    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
