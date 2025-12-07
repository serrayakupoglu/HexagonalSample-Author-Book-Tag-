using System;
using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Products;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = command.Name,
                UnitPrice = command.Price,
                CategoryId = command.CategoryId,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(product);
            return Unit.Value;
        }
    }
}
