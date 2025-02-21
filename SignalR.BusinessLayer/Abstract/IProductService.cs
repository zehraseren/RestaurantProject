using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();
        decimal TAvgProductPrice();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TAvgProductPriceByHamburger();
        List<Product> TGetLast9Products();
    }
}
