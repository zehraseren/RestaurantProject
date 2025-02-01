namespace SignalR.DtoLayer.DashboardCountDtos
{
    public class DashboardCountDto
    {
        public int CategoryCount { get; set; }
        public int ProductCount { get; set; }
        public int ActiveCategoryCount { get; set; }
        public int PassiveCategoryCount { get; set; }
        public int ProductCountByCategoryNameHamburger { get; set; }
        public int ProductCountByCategoryNameDrink { get; set; }
        public string AvgProductPrice { get; set; }
        public string AvgProductPriceByHamburger { get; set; }
        public string ProductNameByMaxPrice { get; set; }
        public string ProductNameByMinPrice { get; set; }
        public int MenuTableCount { get; set; }
        public int TotalActiveOrderCount { get; set; }
        public string LastOrderTotalPrice { get; set; }
        public int TotalOrderCount { get; set; }
        public string TotalDailyEarnings { get; set; }
        public string TotalMoneyCaseAmount { get; set; }
    }
}
