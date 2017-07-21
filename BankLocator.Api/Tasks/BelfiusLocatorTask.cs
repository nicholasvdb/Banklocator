using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BankLocator.Api.Tasks
{
    public class BelfiusLocatorTask
    {
        public async Task<BelfiusLocationResponse> GetLocationsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://www.belfius.be/webapps/nl/agentschappen-zoeker/getallbelfiusoffices");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = response.Content.ReadAsStringAsync();
                    var rawLocationResult = JsonConvert.DeserializeObject<BelfiusLocationResponse>(stringResponse.Result);
                    return rawLocationResult;
                }
                return null;
            }
        }
    }
}
