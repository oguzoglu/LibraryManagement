using domain.Aggregates.Checkout;
using domain.SeedWork;

namespace Infrastructure.Repositories;

public class CheckoutRepository(BookDbContext context): ICheckoutRepository
{
    private readonly BookDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    public IUnitOfWork UnitOfWork => _context;
    public Checkout Add(Checkout checkout)
    {
        return checkout.IsTransient() ? _context.Checkouts.Add(checkout).Entity : checkout;
    }

    public Checkout Update(Checkout checkout)
    {
        return _context.Checkouts.Update(checkout).Entity;
    }

    public async Task<Checkout> FindByIdAsync(int id)
    {
        var checkout = await _context.Checkouts.FindAsync(id);
        if (checkout is not null)
        {
            await _context.Entry(checkout).Reference(b => b.Book).LoadAsync();
        }
        return checkout;
    }
}