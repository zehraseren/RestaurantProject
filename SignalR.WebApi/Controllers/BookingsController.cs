using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto cbdto)
        {
            Booking booking = new Booking()
            {
                Name = cbdto.Name,
                Phone = cbdto.Phone,
                Mail = cbdto.Mail,
                PersonCount = cbdto.PersonCount,
                Date = cbdto.Date,
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto ubdto)
        {
            Booking booking = new Booking()
            {
                BookingId = ubdto.BookingId,
                Name = ubdto.Name,
                Phone = ubdto.Phone,
                Mail = ubdto.Mail,
                PersonCount = ubdto.PersonCount,
                Date = ubdto.Date,
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon başarıyla güncellendi.");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
