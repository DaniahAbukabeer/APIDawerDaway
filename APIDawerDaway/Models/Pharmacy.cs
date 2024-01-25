namespace APIDawerDaway.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string description { get; set; }
        public bool Open24Hours { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public double Rating { get; set; }

        // navigation propertiyes

        public List<FeedBack>? feedbacks { get; set; }
        public List<PharmaysProduct>? PharmaysProducts { get; set; }

    }
}
