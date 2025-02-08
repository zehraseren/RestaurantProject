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
            values.Status = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public int BookingStatusApprovedCount()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == "Rezervasyon Alındı").Count();
            return values;
        }

        public void BookingStatusCanceled(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Status = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }

        public List<Booking> GetBookingStatusApproved()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == "Rezervasyon Onaylandı").ToList();
            return values;
        }

        public List<Booking> GetBookingStatusCanceled()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == "Rezervasyon İptal Edildi").ToList();
            return values;
        }

        public List<Booking> GetBookingStatusReceived()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Where(x => x.Status == "Rezervasyon Alındı").ToList();
            return values;
        }
    }
}
