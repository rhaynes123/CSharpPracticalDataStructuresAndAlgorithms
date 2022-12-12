using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RichsRack.Features.Transactions
{
	public class Transaction
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();
		[Required, DataType(DataType.Currency), Column(TypeName ="decimal(18,2)")]
		public decimal Amount { get; set; }
		[Required]
		public DateTime TransactionDate { get; set; } = DateTime.Now;
	}
}

