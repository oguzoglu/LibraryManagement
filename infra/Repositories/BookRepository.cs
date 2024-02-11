using domain.Aggregates.Book;
using domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public BookRepository(BookDbContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Book> Add(Book book)
    {
        return book.IsTransient() ? (await _context.Books.AddAsync(book)).Entity : book;
    }

    public Book Update(Book book)
    {
        return _context.Books.Update(book).Entity;
    }

    public async Task<Book> FindByIdAsync(int id)
    {
        var book = await _context.Books.Include(c=> c.Checkouts).FirstOrDefaultAsync(x=> x.Id == id);
        if (book is null) return book;
        await _context.Entry(book).Reference(b => b.Author).LoadAsync();
        await _context.Entry(book).Reference(b => b.Category).LoadAsync();
        return book;
    }

    public IQueryable<Book> GetBooksAsync()
    {

        var books = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Category)
            .Include(b => b.Checkouts)
            .OrderBy(b => b.Name)
            .AsQueryable();
        return books;
    }

    public IQueryable<Book> Filter(string searchString)
    {
        var books = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Category)
            .Include(b => b.Checkouts)
            .Where(x =>
                    x.Name.Contains(searchString) ||
                    x.Category.Name.Contains(searchString) ||
                    x.Author.AuthorName.FirstName.Contains(searchString) ||
                    x.Author.AuthorName.LastName.Contains(searchString))
            .OrderBy(b => b.Name)
            .AsQueryable();
        return books;
    }
}