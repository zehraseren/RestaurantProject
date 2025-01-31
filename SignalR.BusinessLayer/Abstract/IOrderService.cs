using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TTotalOrderCount();
        public int TTotalActiveOrderCount();
        decimal TLastOrderTotalPrice();
        decimal TTotalDailyEarnings();
    }
}
