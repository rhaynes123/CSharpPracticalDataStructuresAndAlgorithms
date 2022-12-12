using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RichsRack.Features.Snacks.Models
{
	public class Snack
	{
		[Key]
		public int Id { get; set; }
		[Required(AllowEmptyStrings = false)]
		public required string Name { get; set; }
		[Required, Column(TypeName ="decimal(18,2)"), DataType(DataType.Currency)]
		public decimal Price { get; set; }
	}
}

