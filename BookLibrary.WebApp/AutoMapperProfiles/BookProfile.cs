using AutoMapper;
using BookLibrary.WebApp.Models;
using domain.Aggregates.Book;

namespace BookLibrary.WebApp.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();
            
            CreateMap<Book, CreateBookViewModel>();
            CreateMap<CreateBookViewModel, Book>();
        }
    }
}
