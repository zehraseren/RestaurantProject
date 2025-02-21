using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDtos;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public NotificationsController(IMapper mapper, INotificationService notificationService)
        {
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            return Ok(_mapper.Map<GetByIdNotificationDto>(_notificationService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto cndto)
        {
            _notificationService.TAdd(_mapper.Map<Notification>(cndto));
            return Ok("Bildirim başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto undto)
        {
            _notificationService.TUpdate(_mapper.Map<Notification>(undto));
            return Ok("Bildirim başarıyla güncellendi.");
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationsByFalse());
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme yapıldı.");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme yapıldı.");
        }
    }
}
