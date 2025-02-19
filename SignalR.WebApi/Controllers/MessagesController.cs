using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateMessageDto cmdto)
        {
            Message message = new Message()
            {
                NameSurname = cmdto.NameSurname,
                Mail = cmdto.Mail,
                Phone = cmdto.Phone,
                Subject = cmdto.Subject,
                MessageContent = cmdto.MessageContent,
                MessageSendDate = DateTime.Now,
                Status = cmdto.Status
            };
            _messageService.TAdd(message);
            return Ok("Mesaj başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateMessageDto umdto)
        {
            Message message = new Message()
            {
                MessageId = umdto.MessageId,
                NameSurname = umdto.NameSurname,
                Mail = umdto.Mail,
                Phone = umdto.Phone,
                Subject = umdto.Subject,
                MessageContent = umdto.MessageContent,
                MessageSendDate = umdto.MessageSendDate,
                Status = umdto.Status
            };
            _messageService.TUpdate(message);
            return Ok("Mesaj başarıyla güncellendi.");
        }
    }
}
