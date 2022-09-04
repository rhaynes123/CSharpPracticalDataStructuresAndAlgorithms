using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Movies.Features.Models
{
    public class Movie
    {
        public Movie()
        {
        }
        [Key]
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}

