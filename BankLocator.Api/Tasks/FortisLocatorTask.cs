using Newtonsoft.Json;
using System.IO;

namespace BankLocator.Api.Tasks
{
    public class FortisLocatorTask
    {
        public FortisLocationResponse GetLocations()
        {
            var rawLocationResult = JsonConvert.DeserializeObject<FortisLocationResponse>(File.ReadAllText(@"C:\Users\nicho\Desktop\fortis.json"));
            return rawLocationResult;
        }
    }
}
