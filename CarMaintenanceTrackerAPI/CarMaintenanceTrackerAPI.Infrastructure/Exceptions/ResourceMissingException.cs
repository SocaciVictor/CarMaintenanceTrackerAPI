using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTrackerAPI.Infrastructure.Exceptions
{
    public class ResourceMissingException : Exception
    {
        public ResourceMissingException(string message) : base(message) { }
    }
}
