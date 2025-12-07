using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Tags;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.TagUseCases
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagResponse>>
    {
        private readonly ITagRepository _repository;

        public GetAllTagsQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TagResponse>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetAllAsync();

            return tags.Select(t => new TagResponse
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();
        }
    }

    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagResponse>
    {
        private readonly ITagRepository _repository;

        public GetTagByIdQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<TagResponse> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.Id);
            if (tag == null)
            {
                return null;
            }

            return new TagResponse
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}
