namespace domain.Aggregates.Author;
public interface IAuthorRepository: IRepository<Author>
{
    Author Add(Author author);
    Author Update(Author author);
    IQueryable<Author> GetAuthorsAsync();
    Task<Author> FindByIdAsync(int id);
}
