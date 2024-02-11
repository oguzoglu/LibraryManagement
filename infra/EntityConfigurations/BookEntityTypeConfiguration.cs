using domain.Aggregates.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class BookEntityTypeConfiguration: IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");
        builder.Ignore(b => b.DomainEvents);
        builder.Property(b=> b.Name).HasColumnName("name");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.IsReturned).HasColumnName("is_returned").IsRequired();
        builder.Property(b => b.ImageUrl).HasColumnName("image_url");
        builder.Property(b => b.AuthorId).HasColumnName("author_id");
        builder.Property(b => b.CategoryId).HasColumnName("category_id");
        
        builder.HasOne(b => b.Author)
            .WithMany(a=> a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(b => b.Checkouts).WithOne(a => a.Book);
    }
}