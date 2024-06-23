using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Core.Dtos.Request
{
    public class EditCarRequest
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [RegularExpression(@"^(200[0-9]|20[1-9][0-9]|2100)$", ErrorMessage = "Year must be between 2000 and 2100.")]
        public string Year { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
