using System.Collections.Generic;

namespace HexagonalSample.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
