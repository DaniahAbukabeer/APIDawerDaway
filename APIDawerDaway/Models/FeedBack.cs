namespace APIDawerDaway.Models
{
    public class FeedBack
    {
        public int UserId { get; set; }
        public int PharmacyId { get; set; }
        public bool Statues { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }

        public User? Users { get; set; }
        public Pharmacy? Pharmacy { get; set; }
    }
}
