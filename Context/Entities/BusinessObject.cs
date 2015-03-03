using System;

namespace Context.Entities
{
    public class BusinessObject
    {
        public BusinessObject()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}