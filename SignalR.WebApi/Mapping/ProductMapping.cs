using AutoMapper;
using SignalR.EntityLayer.Concrete;
using SignalR.DtoLayer.ProductDtos;

namespace SignalR.WebApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategory>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName));
        }
    }
}
