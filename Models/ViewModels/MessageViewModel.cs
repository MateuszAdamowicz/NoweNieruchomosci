using System;

namespace Models.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}