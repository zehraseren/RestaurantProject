using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int TotalOrderCount();
        int TotalActiveOrderCount();
        decimal LastOrderTotalPrice();
    }
}
