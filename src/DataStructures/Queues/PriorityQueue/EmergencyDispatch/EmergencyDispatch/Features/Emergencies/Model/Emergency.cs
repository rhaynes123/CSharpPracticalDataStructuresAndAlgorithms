using System;
using System.ComponentModel.DataAnnotations;
using EmergencyDispatch.Features.Emergencies.Model.Enums;
using Newtonsoft.Json;

namespace EmergencyDispatch.Features.Emergencies.Model
{
	[JsonObject]
	public class Emergency
	{
		[Key]
		public int Id { get; set; }
		[Required, JsonProperty("caseId")]
		public Guid CaseId { get; set; }
        [Required]
        public Category category { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage ="A Location Must be Provided"), JsonProperty("address")]
		public required string Address { get; set; }
        [Required]
        public bool DispatchedTo { get; set; }
        [Required]
        public DateTime ReportedOn { get; set; } = DateTime.Now;
		public DateTime? DateOfIncident { get; set; }
	}
}

