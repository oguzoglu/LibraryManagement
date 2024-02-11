using domain.Aggregates.Book;

namespace BookLibrary.WebApp.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public ICollection<Book> Books { get; set; }
    }
}
