namespace APIDawerDaway.Models
{
    public class User
    {
        public User()
        {
               feedbacks = new List<FeedBack> ();
            userproducts = new List<UserProduct> ();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string PhoneNumber { get; set; }


        // navigation prop
        public List<FeedBack>? feedbacks { get; set; }

        public List<UserProduct>? userproducts { get; set; } 

    }
}
