using AutoMapper;
using SignalR.DtoLayer.SliderDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.WebApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
        }
    }
}
