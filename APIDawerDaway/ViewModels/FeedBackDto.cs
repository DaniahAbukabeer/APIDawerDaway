namespace APIDawerDaway.ViewModels
{
    public class FeedbackDto
    {
        public bool Statues { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public int UserId { get; set; }
        public int PharmacyId { get; set; }
    }
}
