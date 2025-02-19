using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.CommonLayer.Enums;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _mapper = mapper;
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
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
                Description = cbdto.Description,
                Date = cbdto.Date,
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
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
                Description = ubdto.Description,
                PersonCount = ubdto.PersonCount,
                Date = ubdto.Date,
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon başarıyla güncellendi.");
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon durumu değiştirildi.");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCanceled(id);
            return Ok("Rezervasyon durumu değiştirildi.");
        }

        [HttpGet("BookingStatusApprovedCount")]
        public IActionResult BookingStatusApprovedCount()
        {
            return Ok(_bookingService.TBookingStatusApprovedCount());
        }

        [HttpGet("GetBookingStatusApproved")]
        public IActionResult GetBookingStatusApproved()
        {
            var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == ReservationStatus.Approved).ToList();
            return Ok(values);
        }

        [HttpGet("GetBookingStatusCancelled")]
        public IActionResult GetBookingStatusCancelled()
        {
            var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == ReservationStatus.Cancelled).ToList();
            return Ok(values);
        }

        [HttpGet("GetBookingStatusReceived")]
        public IActionResult GetBookingStatusReceived()
        {
            var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == ReservationStatus.Received).ToList();
            return Ok(values);
        }
    }
}
