using System;
using System.ComponentModel.DataAnnotations;

namespace PartyPlanner.Features.Parties.Models
{
    public class Party
    {
        public Party()
        {
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!;
        [Required, EmailAddress]
        public string OwnerEmail { get; set; } = default!;
        [Required,Display(Name = "Party Date and Time")]
        public DateTime DateTimeOf { get; set; } = default!;
        [Required, Display(Name = "Create On")]
        public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    }
}

