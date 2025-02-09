using AutoMapper;
using SignalR.EntityLayer.Concrete;
using SignalR.DtoLayer.NotificationDtos;

namespace SignalR.WebApi.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<ResultNotificationDto, Notification>().ReverseMap();
            CreateMap<CreateNotificationDto, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();
            CreateMap<GetByIdNotificationDto, Notification>().ReverseMap();
        }
    }
}
