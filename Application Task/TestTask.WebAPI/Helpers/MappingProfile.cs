using AutoMapper;
using TestTask.Domain.Entities;
using TestTask.WebApi.Dto;

namespace TestTask.WebApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
