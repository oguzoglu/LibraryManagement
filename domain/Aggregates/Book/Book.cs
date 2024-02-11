using System.Collections.ObjectModel;

namespace domain.Aggregates.Book;
using Category;
using Author;
using Checkout;
using System.Runtime.CompilerServices;

public class Book: Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public bool IsReturned { get; private set; }

    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    public string ImageUrl { get; set; }

    public int AuthorId { get; private set; }
    public Author Author { get; private set; }

    public ICollection<Checkout> Checkouts { get; set; }

    private Book() { }

    public Book(string name, int categoryId, int authorId, string imageUrl, bool isReturned = true, int? id = null)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        AuthorId = authorId;
        IsReturned = isReturned;
        ImageUrl = imageUrl;
        Checkouts = new List<Checkout>();
    }

    public void AssignCategory(Category category)
    {
        CategoryId = category.Id.Value;
        Category = category;
    }

    public void AssignAuthor(Author author)
    {
        this.AuthorId = author.Id.Value;
        this.Author = author;
    }
    public void AddCheckout(Checkout checkout)
    {
        if (checkout == null)
        {
            throw new ArgumentNullException(nameof(checkout));
        }
        if (!IsReturned)
        {
            throw new InvalidOperationException("Book is not available");
        }
        Checkouts.Add(checkout);
        this.IsReturned = false;
    }
    public void ReturnBook()
    {
        IsReturned = true;
    }
}