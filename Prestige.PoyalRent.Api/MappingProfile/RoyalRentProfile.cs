using AutoMapper;
using Prestige.RoyalRent.Api.Models;

namespace Prestige.RoyalRent.Api.MappingProfile
{
    public class RoyalRentProfile : Profile
    {
        public RoyalRentProfile()
        {
            CreateMapFromBusinessToApi();
            CreateMapFromApiToBusiness();
        }

        private void CreateMapFromBusinessToApi()
        {
            CreateMap<Client.Business.Models.Customer, Customer>();
            CreateMap<Client.Business.Models.Car, Car>();
        }

        private void CreateMapFromApiToBusiness()
        {
            CreateMap<Customer, Client.Business.Models.Customer>();
            CreateMap<Car, Client.Business.Models.Car>();
        }
    }
}
