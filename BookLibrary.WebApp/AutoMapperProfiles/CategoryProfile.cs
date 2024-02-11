using AutoMapper;
using BookLibrary.WebApp.Models;
using domain.Aggregates.Category;

namespace BookLibrary.WebApp.AutoMapperProfiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel,Category>();
        }
    }
}
