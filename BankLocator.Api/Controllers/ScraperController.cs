using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankLocator.Api.Models;
using BankLocator.Api.Tasks;
using AutoMapper;

namespace BankLocator.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Scraper")]
    public class ScraperController : Controller
    {
        private readonly BankLocatorContext _context;

        public ScraperController(BankLocatorContext context)
        {
            _context = context;
        }

        // GET: api/Scraper/{bankName}
        [HttpPost("{bankName}")]
        public async Task LoadBankoffices([FromRoute] string bankName)
        {
            if (bankName == "belfius")
            {
                var task = new BelfiusLocatorTask();
                var result = await task.GetLocationsAsync();

                foreach (var location in result.Locations)
                {
                    var bankOffice = Mapper.Map<Location, Bankoffice>(location);
                    bankOffice.Company = "Belfius";
                    _context.Bankoffices.Add(bankOffice);
                   
                }
                _context.SaveChanges();
            }
            else if (bankName == "fortis")
            {
                FortisLocatorTask task = new FortisLocatorTask();
                var result = task.GetLocations();

                foreach (var location in result.Agence)
                {
                    var bankOffice = Mapper.Map<Agence, Bankoffice>(location);
                    bankOffice.Company = "Fortis";
                    _context.Bankoffices.Add(bankOffice);
                }
                _context.SaveChanges();
            }
        }
    }
}