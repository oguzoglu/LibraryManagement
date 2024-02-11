

using domain.Aggregates.Author;
using domain.Aggregates.Book;
using domain.Aggregates.Category;
using domain.Aggregates.Checkout;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
	internal static class SeedData
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			// Generate seed data for categories
			modelBuilder.Entity<Category>().HasData(
				new Category(1, "Fiction"),
				new Category(2, "Novel"),
				new Category(3, "Science")
			);

			//// Generate seed data for authors
			modelBuilder.Entity<Author>(p =>
			{
				p.HasData(
					new Author(1),
					new Author(2),
					new Author(3)
				);
				p.OwnsOne(pr => pr.AuthorName)
					.HasData(
						new { AuthorId = 1, FirstName = "Yaşar", LastName= "Kemal" },
						new { AuthorId = 2, FirstName = "Orhan", LastName= "Pamuk" },
						new { AuthorId = 3, FirstName = "Oğuz", LastName= "Atay" }
					);
			});


			//// Generate seed data for books
			modelBuilder.Entity<Book>().HasData(
				new Book( "İnce Memed 1", 1, 1,"1.jfif", isReturned: false,1),
				new Book( "Yılanı Öldürseler", 1, 1,"2.jfif",id: 2),
				new Book( "Mausmiyet Müzesi", 2, 2,"3.jfif",id:3),
				new Book( "Kırmızı Saçlı Kadın", 2, 2,"4.jpg",id:4),
				new Book( "Tutunamayanlar", 2, 3,"5.jpg",id:5),
				new Book( "Tehlikeli Oyunlar", 2, 3,"6.jpg",id:6),
				new Book( "EylemBilim", 2, 3,"7.jpg",id:7)
			);

			//// Generate seed data for checkouts
			modelBuilder.Entity<Checkout>().HasData(
				new Checkout( 1, DateTime.UtcNow, DateTime.UtcNow, "Kayıhan Nedim",1),
				new Checkout( 1, DateTime.UtcNow, DateTime.UtcNow, "Emine Münevver",2),
				new Checkout( 2, DateTime.UtcNow, DateTime.UtcNow, "Fatma Özlem",3),
				new Checkout( 1, DateTime.UtcNow, DateTime.UtcNow, "Emre Ayberk",4)
			);
		}
	}
}
