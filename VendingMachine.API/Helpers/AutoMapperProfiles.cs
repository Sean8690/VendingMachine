using AutoMapper;
using VendingMachine.API.Dtos;
using VendingMachine.API.Models;

namespace VendingMachine.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RestockInventoryForUpdate, Can>();
        }
    }
}