using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        void ChangeStatusToActive(int id);
        void ChangeStatusToPassive(int id);
        List<Discount> GetDiscountListByStatusActive();
    }
}
