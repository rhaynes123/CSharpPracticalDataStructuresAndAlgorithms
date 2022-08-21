using System;
namespace SecretaryOfStateQue.Models
{
    public class Customer
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public int PlaceInLine { get; set; }
    }
}

