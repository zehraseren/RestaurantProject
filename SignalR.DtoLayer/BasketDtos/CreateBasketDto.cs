namespace SignalR.DtoLayer.BasketDtos
{
    public class CreateBasketDto
    {
        public int ProductId { get; set; }
        public int MenuTableId { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
