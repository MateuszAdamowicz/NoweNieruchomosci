﻿namespace Context.Entities
{
    public class Message:DbTable
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}