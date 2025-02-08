using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusCanceled(int id);
        void TBookingStatusApproved(int id);
        int TBookingStatusApprovedCount();
        List<Booking> TGetBookingStatusApproved();
        List<Booking> TGetBookingStatusCanceled();
        List<Booking> TGetBookingStatusReceived();
    }
}
