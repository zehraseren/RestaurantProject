using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IMoneyCaseDal : IGenericDal<MoneyCase>
    {
        decimal TotalMoneyCaseAmount();
    }
}
