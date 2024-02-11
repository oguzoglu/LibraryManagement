using domain.Aggregates.Checkout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class CheckoutEntityTypeConfiguration: IEntityTypeConfiguration<Checkout>
{
    public void Configure(EntityTypeBuilder<Checkout> builder)
    {
        builder.ToTable("checkouts");
        builder.Ignore(b => b.DomainEvents);
        builder.Property(b => b.StartTime).HasColumnName("start_time").IsRequired().HasDefaultValue(DateTime.UtcNow);
		builder.Property(b => b.EndTime).HasColumnName("end_time").IsRequired();
		builder.HasKey(b => b.Id);
        builder.Property(b => b.Borrower).HasColumnName("borrower").HasMaxLength(200);
        builder.Property(b => b.StartTime).IsRequired();
        builder.Property(b => b.BookId).HasColumnName("book_id");
        builder.HasOne(b=> b.Book)
            .WithMany( c => c.Checkouts)
            .HasForeignKey(b => b.BookId)
			.OnDelete(DeleteBehavior.Restrict);

	}
}