using SignalR.EntityLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public decimal LastOrderTotalPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.OrderByDescending(x => x.OrderId).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public int TotalActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
