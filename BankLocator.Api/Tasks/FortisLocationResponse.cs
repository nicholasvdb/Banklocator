using System.Collections.Generic;

namespace BankLocator.Api.Tasks
{
    public class FortisLocationResponse
    {

        public IEnumerable<Agence> Agence { get; set; }
    }

    public class Agence
    {
        public string Nom { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
