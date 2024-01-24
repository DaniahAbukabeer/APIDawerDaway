namespace APIDawerDaway.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string description { get; set; }
        public bool open24Hours { get; set; }
        public DateTime openingTime { get; set; }
        public DateTime closedTime { get; set; }
        public double rating { get; set; }

        // navigation propertiyes

        public List<FeedBack>? feedbacks { get; set; }
        public List<PharmaysProduct>? PharmaysProducts { get; set; }

    }
}
