namespace APIDawerDaway.ViewModels
{
    public class UserProductDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool IsFavorite { get; set; }
        public SimpleProductDto Product { get; set; }  // Use a nested ProductDto with only tName
        public DateTime ViewedAt { get; set; }
    }
}
