using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingsController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _mapper = mapper;
            _bookingService = bookingService;
            _validator = validator;
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
            var value = _mapper.Map<GetBookingDto>(_bookingService.TGetById(id));
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto cbdto)
        {
            var validate = _validator.Validate(cbdto);
            if (!validate.IsValid)
            {
                return BadRequest(validate.Errors);
            }

            _bookingService.TAdd(_mapper.Map<Booking>(cbdto));
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
            _bookingService.TUpdate(_mapper.Map<Booking>(ubdto));
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
