namespace APIDawerDaway.ViewModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string TName { get; set; }
        public string SName { get; set; }
        public int UserId { get; set; }
        public string Provider { get; set; }
        public string Country { get; set; }
        public double Dosage { get; set; }
        public string AtcCode { get; set; }
        public string Categorie { get; set; }
        public double? PublicPrice { get; set; }
        public double? Quantity { get; set; }
        public int? Amount { get; set; }
        public double? PrivatePrice { get; set; }
        public int PharmacyId { get; set; }
        public int ProductId { get; set; }
    }
}
