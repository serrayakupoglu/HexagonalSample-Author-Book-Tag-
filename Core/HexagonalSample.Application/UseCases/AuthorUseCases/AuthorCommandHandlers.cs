using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Authors;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.AuthorUseCases
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _repository;

        public CreateAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Bio = request.Bio
            };

            await _repository.CreateAsync(author);
            return Unit.Value;
        }
    }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _repository;

        public UpdateAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return Unit.Value;
            }

            existing.FirstName = request.FirstName;
            existing.LastName = request.LastName;
            existing.Bio = request.Bio;

            await _repository.UpdateAsync(existing);
            return Unit.Value;
        }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _repository;

        public DeleteAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
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
