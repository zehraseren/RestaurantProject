using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            return Ok(_mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            return Ok(_mapper.Map<GetContactDto>(_contactService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto ccdto)
        {
            _contactService.TAdd(_mapper.Map<Contact>(ccdto));
            return Ok("Rezervasyon başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto ucdto)
        {
            _contactService.TUpdate(_mapper.Map<Contact>(ucdto));
            return Ok("Rezervasyon başarıyla güncellendi.");
        }
    }
}
