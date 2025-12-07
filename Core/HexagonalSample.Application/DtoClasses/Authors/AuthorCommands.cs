using MediatR;

namespace HexagonalSample.Application.DtoClasses.Authors
{
    public class CreateAuthorCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }

    public class UpdateAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }

    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
