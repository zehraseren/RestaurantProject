using AutoMapper;
using SignalR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.WebApi.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
        }
    }
}
