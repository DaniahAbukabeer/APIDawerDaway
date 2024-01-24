namespace APIDawerDaway.Models
{
    public class UserProduct
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime ViewedAt { get; set; }
        public User? user { get; set; }
        public Product? product { get; set; }


    }
}
