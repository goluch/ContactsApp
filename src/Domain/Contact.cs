using Domain.Enums;

namespace Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Category Categoty { get; set; }
    }
}
