using domain.Aggregates.Book;

namespace BookLibrary.WebApp.Models
{
    public class CheckoutViewModel
    {
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public string Borrower { get; private set; }
        public BookViewModel Book { get; private set; }
        public int BookId { get; private set; }
    }
}
