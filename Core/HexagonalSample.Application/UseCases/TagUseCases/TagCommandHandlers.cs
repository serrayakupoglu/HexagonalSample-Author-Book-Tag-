using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Tags;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.TagUseCases
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly ITagRepository _repository;

        public CreateTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                Name = request.Name
            };

            await _repository.CreateAsync(tag);
            return Unit.Value;
        }
    }

    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly ITagRepository _repository;

        public UpdateTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return Unit.Value;
            }

            existing.Name = request.Name;

            await _repository.UpdateAsync(existing);
            return Unit.Value;
        }
    }

    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly ITagRepository _repository;

        public DeleteTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
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
