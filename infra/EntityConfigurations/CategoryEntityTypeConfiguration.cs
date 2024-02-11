using domain.Aggregates.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class CategoryEntityTypeConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.Ignore(b => b.DomainEvents);
        builder.Property(b=> b.Name).HasColumnName("name");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).HasMaxLength(100);
        builder.HasMany(c => c.Books)
            .WithOne(b => b.Category)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Books_Categories");
    }
}