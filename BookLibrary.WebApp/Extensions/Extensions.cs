using BookLibrary.WebApp.AutoMapperProfiles;
using domain.Aggregates.Author;
using domain.Aggregates.Book;
using domain.Aggregates.Category;
using domain.Aggregates.Checkout;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.WebApp.Extensions
{
	internal static class Extensions
	{
		public static void AddApplicationServices(this IHostApplicationBuilder builder)
		{
            // Configure Db Context For postgreSql
            var services = builder.Services;
			var Configuration = builder.Configuration;
			var connectionString = Configuration.GetConnectionString("BookLibDb");
			services.AddDbContext<BookDbContext>(o =>
				o.UseNpgsql(connectionString, x => x.MigrationsAssembly("BookLibrary.WebApp")));

			// Configure mediatR For Future Purposes
			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
			});

            // Configure Dependency injections for Repositories
            services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<IAuthorRepository, AuthorRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICheckoutRepository, CheckoutRepository>();



            // Configure AutoMapper
            //         var mapperConfig = new MapperConfiguration( cfg =>
            //{
            //	cfg.AddProfile(new BookProfile());
            //});
            //         var mapper = mapperConfig.CreateMapper();
            services.AddAutoMapper(
             typeof(BookProfile),
             typeof(CheckoutProfile),
             typeof(AuthorProfile),
             typeof(CategoryProfile)
			 
			 );


        }
    }
}
	
