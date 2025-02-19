using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.BookingDtos
{
    public class ResultBookingStatusCancelledDto
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
