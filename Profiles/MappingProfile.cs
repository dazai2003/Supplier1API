using AutoMapper;
using Supplier1API.Model;
using Supplier1API.DTO;

namespace Supplier1API.Profiles 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, ReadProductDTO>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<QuoteRequestDTO, Product>(); 
            CreateMap<Product, QuoteResponseDTO>(); 
            CreateMap<OrderRequestDTO, Product>(); 
        }
    }
}
