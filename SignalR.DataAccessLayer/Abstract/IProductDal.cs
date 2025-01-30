using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        decimal AvgProductPrice();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal AvgProductPriceByHamburger();
    }
}
