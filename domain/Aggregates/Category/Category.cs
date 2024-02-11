using System.Collections.ObjectModel;

namespace domain.Aggregates.Category;
using Book;
public class Category: Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public ICollection<Book> Books { get; set; }

    private Category() { }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
        Books = new List<Book>();
    }
}