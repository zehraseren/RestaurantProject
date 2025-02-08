using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TBookingStatusApproved(int id)
        {
            _bookingDal.BookingStatusApproved(id);
        }

        public int TBookingStatusApprovedCount()
        {
            return _bookingDal.BookingStatusApprovedCount();
        }

        public void TBookingStatusCanceled(int id)
        {
            _bookingDal.BookingStatusCanceled(id);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> TGetBookingStatusApproved()
        {
            return _bookingDal.GetBookingStatusApproved();
        }

        public List<Booking> TGetBookingStatusCanceled()
        {
            return _bookingDal.GetBookingStatusCanceled();
        }

        public List<Booking> TGetBookingStatusReceived()
        {
            return _bookingDal.GetBookingStatusReceived();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
