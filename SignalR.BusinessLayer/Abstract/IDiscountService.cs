using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TChangeStatusToActive(int id);
        void TChangeStatusToPassive(int id);
        List<Discount> TGetDiscountListByStatusActive();
    }
}
