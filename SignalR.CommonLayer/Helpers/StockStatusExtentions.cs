using SignalR.CommonLayer.Enums;

namespace SignalR.CommonLayer.Helpers
{
    public static class StockStatusExtentions
    {
        public static string GetStockStatusString(this StockStatus status)
        {
            return status switch
            {
                StockStatus.InStock => "Stokta Var",
                StockStatus.OutOfStock => "Stokta Yok",
                StockStatus.ComingSoon => "Yakında",
                _ => "Bilinmiyor",
            };
        }
    }
}
