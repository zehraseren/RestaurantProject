﻿using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.ProductDtos
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public StockStatus ProductStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
