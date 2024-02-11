using AutoMapper;
using BookLibrary.WebApp.Models;
using domain.Aggregates.Checkout;

namespace BookLibrary.WebApp.AutoMapperProfiles
{
    public class CheckoutProfile: Profile
    {
        public CheckoutProfile()
        {
            CreateMap<CheckoutViewModel, Checkout>();
            CreateMap<Checkout,CheckoutViewModel>();
        }
    }
}
