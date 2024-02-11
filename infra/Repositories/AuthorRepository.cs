using domain.Aggregates.Author;
using domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository(BookDbContext context) : IAuthorRepository
{
    private readonly BookDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    public IUnitOfWork UnitOfWork => _context;

    public Author Add(Author author)
    {
        return author.IsTransient() ? _context.Authors.Add(author).Entity : author;
    }

    public Author Update(Author author)
    {
        return _context.Authors.Update(author).Entity;
    }

    public IQueryable<Author> GetAuthorsAsync()
    {
        return _context.Authors.Include(a=> a.Books).AsQueryable();
    }

    public async Task<Author> FindByIdAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author is not null)
        {
            await _context.Entry(author).Collection(c => c.Books).LoadAsync();
        }
        return author;
    }
}