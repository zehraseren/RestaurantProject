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
            return Ok(_mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            return Ok(_mapper.Map<GetByIdMessageDto>(_messageService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto cmdto)
        {
            _messageService.TAdd(_mapper.Map<Message>(cmdto));
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
        public IActionResult UpdateMessage(UpdateMessageDto umdto)
        {
            _messageService.TUpdate(_mapper.Map<Message>(umdto));
            return Ok("Mesaj başarıyla güncellendi.");
        }
    }
}
