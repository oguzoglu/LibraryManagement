using domain.Aggregates.Author;
using domain.Aggregates.Book;

namespace BookLibrary.WebApp.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ICollection<BookViewModel> Books { get; set; }
    }
}
