using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Products;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.ProductName,
                Price = p.UnitPrice,
                CategoryId = p.CategoryId
            }).ToList();
        }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.ProductName,
                Price = product.UnitPrice,
                CategoryId = product.CategoryId
            };
        }
    }
}
