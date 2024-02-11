using System.Collections.ObjectModel;

namespace domain.Aggregates.Author;
using Book;
public class Author: Entity, IAggregateRoot
{
    public AuthorName AuthorName { get; private set; }
    public ICollection<Book> Books { get; set; }

    private Author() { }

    public Author(int id, AuthorName authorName)
    {
        Id = id;
        this.AuthorName = authorName;
        Books = new List<Book>();
    }

	public Author(int id)
	{
		Id = id;
        Books = new List<Book>();
	}

	public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }
}