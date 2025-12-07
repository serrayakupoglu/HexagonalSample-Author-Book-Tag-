using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexagonalSample.Domain.Entities;
using MediatR;

namespace HexagonalSample.Application.DtoClasses.Books
{
    using MediatR;

    namespace HexagonalSample.Application.DtoClasses.Books
    {
        public class CreateBookCommand : IRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? PublishedOn { get; set; }
        }

        public class UpdateBookCommand : IRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? PublishedOn { get; set; }
        }

        public class DeleteBookCommand : IRequest
        {
            public int Id { get; set; }
        }
    }

}
