namespace domain.Aggregates.Category;

public interface ICategoryRepository: IRepository<Category>
{
    Category Add(Category category);
    Category Update(Category category);
    IQueryable<Category> GetCategoriesAsync();
    Task<Category> FindByIdAsync(int id);
}