using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class ReportRequest : IValidatableObject
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "Select Vending Machine!")]
        public int VendingMachineId { get; set; }
        [Required]
        public ReportType Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (From > To)
            {
                yield return
                  new ValidationResult(errorMessage: "Date To must be equal or greater than Date From",
                                       memberNames: new[] { "To" });
            }
        }
    }
}
