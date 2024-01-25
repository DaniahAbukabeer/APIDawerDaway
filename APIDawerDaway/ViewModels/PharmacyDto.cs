namespace APIDawerDaway.ViewModels
{
    public class PharmacyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public bool Open24Hours { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }
        public double Rating { get; set; }
        public List<FeedbackDto> Feedbacks { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
