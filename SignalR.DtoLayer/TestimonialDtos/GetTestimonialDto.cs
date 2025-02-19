using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.TestimonialDtos
{
    public class GetTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public ReadStatus Status { get; set; }
    }
}
