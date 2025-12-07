using System.Collections.Generic;

namespace HexagonalSample.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; } = new List<BookTag>();
    }
}
