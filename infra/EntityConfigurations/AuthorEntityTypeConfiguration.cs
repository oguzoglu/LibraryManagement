using domain.Aggregates.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class AuthorEntityTypeConfiguration: IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("authors");
        builder.Ignore(b => b.DomainEvents);
        builder.HasKey(b => b.Id);
		builder.OwnsOne(b => b.AuthorName, x =>
		{
			x.Property(e => e.FirstName).HasColumnName("first_name");
			x.Property(e => e.LastName).HasColumnName("last_name");
		});
		//builder.OwnsOne(product => product.AuthorName,
		//  navigationBuilder =>
		//  {
		//	  navigationBuilder.Property(n => n.FirstName)
		//					   .HasColumnName("first_name");
		//	  navigationBuilder.Property(n => n.LastName)
		//					   .HasColumnName("first_name");
		//  });
		builder.HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Books_Authors");
    }
}