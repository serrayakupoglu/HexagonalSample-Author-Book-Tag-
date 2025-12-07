using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HexagonalSample.Application.DtoClasses.Authors;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;

namespace HexagonalSample.Application.UseCases.AuthorUseCases
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorResponse>>
    {
        private readonly IAuthorRepository _repository;

        public GetAllAuthorsQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AuthorResponse>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();

            return authors.Select(a => new AuthorResponse
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Bio = a.Bio
            }).ToList();
        }
    }

    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorResponse>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorByIdQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author == null)
            {
                return null;
            }

            return new AuthorResponse
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Bio = author.Bio
            };
        }
    }
}
