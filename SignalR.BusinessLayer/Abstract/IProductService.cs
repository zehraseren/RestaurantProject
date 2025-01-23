using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
    }
}
