namespace domain.Aggregates.Checkout;
using Book;
public class Checkout: Entity, IAggregateRoot
{
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }
    public string Borrower { get; private set; }
    public Book Book { get; private set; }
    public int BookId { get; private set; }

    private Checkout() { } 

    public Checkout(int bookId, DateTime startTime, DateTime?endTime, string borrower, int? id = null)
    {
        Id = id;
		this.BookId = bookId;
        StartTime = startTime;
        EndTime = endTime;
        Borrower = borrower;
    }

    public void CompleteCheckout(DateTime endTime)
    {
        EndTime = endTime;
    }
}