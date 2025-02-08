using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusCanceled(int id);
        void BookingStatusApproved(int id);
        int BookingStatusApprovedCount();
        List<Booking> GetBookingStatusApproved();
        List<Booking> GetBookingStatusCanceled();
        List<Booking> GetBookingStatusReceived();
    }
}
