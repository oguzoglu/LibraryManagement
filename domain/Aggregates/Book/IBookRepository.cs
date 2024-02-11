namespace domain.Aggregates.Book;

public interface IBookRepository: IRepository<Book>
{
    Task<Book> Add(Book book);
    Book Update(Book book);
    Task<Book> FindByIdAsync(int id);
    IQueryable<Book> GetBooksAsync();
    IQueryable<Book> Filter(string searchString);
}