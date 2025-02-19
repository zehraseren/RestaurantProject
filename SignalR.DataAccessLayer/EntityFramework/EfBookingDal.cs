using SignalR.CommonLayer.Enums;
using SignalR.EntityLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Status = ReservationStatus.Approved;
            context.SaveChanges();
        }

        public int BookingStatusApprovedCount()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == ReservationStatus.Approved).Count();
            return values;
        }

        public void BookingStatusCanceled(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Status = ReservationStatus.Cancelled;
            context.SaveChanges();
        }

        public List<Booking> GetBookingStatusApproved()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == ReservationStatus.Approved).ToList();
            return values;
        }

        public List<Booking> GetBookingStatusCanceled()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == ReservationStatus.Cancelled).ToList();
            return values;
        }

        public List<Booking> GetBookingStatusReceived()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == ReservationStatus.Received).ToList();
            return values;
        }
    }
}
