using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Books
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedOn { get; set; }
    }

    public class GetAllBooksQuery : IRequest<List<BookResponse>>
    {
    }

    public class GetBookByIdQuery : IRequest<BookResponse>
    {
        public int Id { get; set; }
    }
}
