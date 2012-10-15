namespace TDCContactsAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }        
        public bool HasImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }        

        public static Contact CreateContact(int id, 
            string firstName = "", 
            string lastName = "", 
            string phoneNumber = "", 
            bool hasImage = true, 
            string address = "", 
            string city = "", 
            string email = "", 
            string zip = "")
        {
            return new Contact()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    City = city,
                    Email = email,
                    Zip = zip,
                    HasImage = hasImage
                };
        }
    }
}