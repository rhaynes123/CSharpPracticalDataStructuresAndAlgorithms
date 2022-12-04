using System;
using EmergencyDispatch.Features.Emergencies.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmergencyDispatch.Features.Emergencies.Requests
{
    public record EmergencyRequest
    {
        public Guid CaseId { get; set; } = Guid.NewGuid();
        [Range(1, int.MaxValue)]
        public required int category { get; set; }
        public required string Address { get; set; }
        public bool DispatchedTo { get; set; }
        public DateTime ReportedOn { get; set; } = DateTime.Now;
        public DateTime? DateOfIncident { get; set; }
    }
}

