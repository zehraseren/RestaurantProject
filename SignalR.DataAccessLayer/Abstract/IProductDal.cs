using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
    }
}
