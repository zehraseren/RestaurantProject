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
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Createtestimonial(CreateTestimonialDto ctdto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Name = ctdto.Name,
                Title = ctdto.Title,
                Comment = ctdto.Comment,
                ImageUrl = ctdto.ImageUrl,
                Status = ctdto.Status,
            };
            _testimonialService.TAdd(testimonial);
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
            Testimonial testimonial = new Testimonial()
            {
                TestimonialId = utdto.TestimonialId,
                Name = utdto.Name,
                Title = utdto.Title,
                Comment = utdto.Comment,
                ImageUrl = utdto.ImageUrl,
                Status = utdto.Status,
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans başarıyla güncellendi.");
        }
    }
}
