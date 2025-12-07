using System;
using System.Collections.Generic;

namespace HexagonalSample.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedOn { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; } = new List<BookTag>();
    }
}
