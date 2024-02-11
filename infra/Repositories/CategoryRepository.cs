using domain.Aggregates.Category;
using domain.SeedWork;

namespace Infrastructure.Repositories;
public class CategoryRepository(BookDbContext context) : ICategoryRepository
{
    private readonly BookDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    public IUnitOfWork UnitOfWork => _context;

    public Category Add(Category category)
    {
        return category.IsTransient() ? _context.Categories.Add(category).Entity : category;
    }

    public Category Update(Category category)
    {
        return _context.Categories.Update(category).Entity;
    }

    public IQueryable<Category> GetCategoriesAsync()
    {
        return _context.Categories.AsQueryable();
    }

    public async Task<Category> FindByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is not null)
        {
            await _context.Entry(category).Collection(c => c.Books).LoadAsync();
        }
        return category;
    }
}