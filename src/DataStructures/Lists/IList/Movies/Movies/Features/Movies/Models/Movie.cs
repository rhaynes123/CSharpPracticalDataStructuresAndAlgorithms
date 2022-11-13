using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movies.Features.Movies.Models.Enums;

namespace Movies.Features.Movies.Models
{
    [Index(nameof(Title))]
    public class Movie
    {
        public Movie()
        {
        }
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;
        public Genre Genre { get; set; } = Genre.None;
        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}

