using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Products;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return Unit.Value;
            }

            existing.ProductName = request.Name;
            existing.UnitPrice = request.Price;
            existing.CategoryId = request.CategoryId;

            await _repository.UpdateAsync(existing);
            return Unit.Value;
        }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return Unit.Value;
            }

            await _repository.DeleteAsync(existing);
            return Unit.Value;
        }
    }
}
