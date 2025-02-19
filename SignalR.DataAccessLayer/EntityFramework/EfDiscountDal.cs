using SignalR.CommonLayer.Enums;
using SignalR.EntityLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatusToActive(int id)
        {
            using var context = new SignalRContext();
            var values = context.Discounts.Find(id);
            values.Status = AvailableStatus.Available;
            context.SaveChanges();
        }

        public void ChangeStatusToPassive(int id)
        {
            using var context = new SignalRContext();
            var values = context.Discounts.Find(id);
            values.Status = AvailableStatus.Unavailable;
            context.SaveChanges();
        }

        public List<Discount> GetDiscountListByStatusActive()
        {
            using var context = new SignalRContext();
            var values = context.Discounts.Where(x => x.Status == AvailableStatus.Available).ToList();
            return values;
        }
    }
}
