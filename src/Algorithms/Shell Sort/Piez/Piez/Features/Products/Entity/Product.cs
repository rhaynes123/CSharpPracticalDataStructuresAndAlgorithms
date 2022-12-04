using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piez.Features.Products.Entity
{
	public class Product: IComparable<Product>
    {
        [Key]
		public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
        [Range(0, double.MaxValue), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int CompareTo(Product? other)
        {
            if (other is null || other == default)
            {
                return -1;
            }
            if (Price == other.Price)
            {
                return 0;
            }
            if (Price > other.Price)
            {
                return -1;
            }
            if (Price < other.Price)
            {
                return 1;
            }
            return -1;
        }
    }
}

