using AutoMapper;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.WebApi.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, ResultBasketDto>().ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.ProductName)).ReverseMap();
        }
    }
}
