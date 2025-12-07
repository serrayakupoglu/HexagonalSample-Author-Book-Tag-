namespace HexagonalSample.Domain.Entities
{
    public class BookTag
    {
        public int BookId { get; set; }
        public int TagId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
