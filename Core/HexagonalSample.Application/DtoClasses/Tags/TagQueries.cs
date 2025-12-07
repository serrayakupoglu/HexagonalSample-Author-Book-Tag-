using MediatR;
using System.Collections.Generic;

namespace HexagonalSample.Application.DtoClasses.Tags
{
    public class TagResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetAllTagsQuery : IRequest<List<TagResponse>>
    {
    }

    public class GetTagByIdQuery : IRequest<TagResponse>
    {
        public int Id { get; set; }
    }
}
