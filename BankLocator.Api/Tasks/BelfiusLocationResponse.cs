using BankLocator.Api.Models;
using System.Collections.Generic;

namespace BankLocator.Api.Tasks
{
    public class BelfiusLocationResponse
    {
        public IEnumerable<Location> Locations { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}