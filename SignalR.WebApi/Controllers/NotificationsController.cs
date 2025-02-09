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
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto cndto)
        {
            Notification notification = new Notification()
            {
                Type = cndto.Type,
                Icon = cndto.Icon,
                Description = cndto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = cndto.Status,
            };
            _notificationService.TAdd(notification);
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
            Notification notification = new Notification()
            {
                NotificationId = undto.NotificationId,
                Type = undto.Type,
                Icon = undto.Icon,
                Description = undto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = undto.Status,
            };
            _notificationService.TUpdate(notification);
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
