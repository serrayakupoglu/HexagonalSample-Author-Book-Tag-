using MediatR;

namespace HexagonalSample.Application.DtoClasses.Tags
{
    public class CreateTagCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class UpdateTagCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DeleteTagCommand : IRequest
    {
        public int Id { get; set; }
    }
}
