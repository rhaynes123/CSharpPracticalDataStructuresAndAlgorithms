using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Models
{
    [Index(nameof(Price)), Index(nameof(Service.Name))]
    public record Service()
    {
        [Key]
        public int Id { get; init; }
        [Required, StringLength(100)]
        public string Name { get; init; } = default!;
        public decimal Price { get; init; }
    }
}

