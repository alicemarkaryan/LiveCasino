using System.Globalization;

namespace LiveCasino.DLL
{
    public class Client
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }
        public string Country {  get; set; }
        public DateTime BirthDate { get; set; }
        public decimal AccountBalance { get; set; }

    }
}
