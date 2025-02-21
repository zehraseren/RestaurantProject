using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDtos;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITestimonialService _testimonialService;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Gettestimonial(int id)
        {
            return Ok(_mapper.Map<GetTestimonialDto>(_testimonialService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult Createtestimonial(CreateTestimonialDto ctdto)
        {
            _testimonialService.TAdd(_mapper.Map<Testimonial>(ctdto));
            return Ok("Referans başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletetestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Referans başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult Updatetestimonial(UpdateTestimonialDto utdto)
        {
            _testimonialService.TUpdate(_mapper.Map<Testimonial>(utdto));
            return Ok("Referans başarıyla güncellendi.");
        }
    }
}
