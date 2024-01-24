namespace APIDawerDaway.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string TName { get; set; }
        public string SName { get; set; }
        public string Provider { get; set; }
        public string Country { get; set; }
        public string Dosage { get; set; }
        public string ATCCODE { get; set; }
        public string Categorie { get; set; }
        //navigation prop
        public int UserId { get; set; }
        public List<UserProduct>? UserProducts { get; set; }
        public List<PharmaysProduct>? PharmaysProducts { get; set; }

    }
}
