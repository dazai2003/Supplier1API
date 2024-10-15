using AutoMapper;
using Supplier1API.Model;
using Supplier1API.DTO;

namespace Supplier1API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ReadProductDTO>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();

        }
    }
}
