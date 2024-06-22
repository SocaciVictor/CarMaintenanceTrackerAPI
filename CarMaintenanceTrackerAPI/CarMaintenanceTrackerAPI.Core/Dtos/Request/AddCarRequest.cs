using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarMaintenanceTrackerAPI.Core.Dtos.Request
{
    public class AddCarRequest
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
        public string UserId { get; set; }
    }
}
