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
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto ccdto)
        {
            Contact contact = new Contact()
            {
                Location = ccdto.Location,
                PhoneNumber = ccdto.PhoneNumber,
                Mail = ccdto.Mail,
                FooterDescription = ccdto.FooterDescription,
            };
            _contactService.TAdd(contact);
            return Ok("Rezervasyon başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto ucdto)
        {
            Contact contact = new Contact()
            {
                ContactId = ucdto.ContactId,
                Location = ucdto.Location,
                PhoneNumber = ucdto.PhoneNumber,
                Mail = ucdto.Mail,
                FooterDescription = ucdto.FooterDescription,
            };
            _contactService.TUpdate(contact);
            return Ok("Rezervasyon başarıyla güncellendi.");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
}
