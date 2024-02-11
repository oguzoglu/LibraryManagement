using AutoMapper;
using BookLibrary.WebApp.Models;
using domain.Aggregates.Author;

namespace BookLibrary.WebApp.AutoMapperProfiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorViewModel, Author>()
                .ForMember(x => x.AuthorName, memberOptions:opt => opt.MapFrom(src => new AuthorName(src.FirstName, src.LastName)))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
            
            CreateMap<Author, AuthorViewModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.AuthorName.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.AuthorName.LastName))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
        }
    }
}
