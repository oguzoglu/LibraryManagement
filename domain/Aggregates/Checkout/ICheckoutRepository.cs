namespace domain.Aggregates.Checkout;

public interface ICheckoutRepository: IRepository<Checkout>
{
    Checkout Add(Checkout checkout);
    Checkout Update(Checkout checkout);
    Task<Checkout> FindByIdAsync(int id);
}