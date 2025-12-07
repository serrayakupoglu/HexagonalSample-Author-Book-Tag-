using MediatR;
using System.Collections.Generic;

namespace HexagonalSample.Application.DtoClasses.Authors
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }

    public class GetAllAuthorsQuery : IRequest<List<AuthorResponse>>
    {
    }

    public class GetAuthorByIdQuery : IRequest<AuthorResponse>
    {
        public int Id { get; set; }
    }
}
