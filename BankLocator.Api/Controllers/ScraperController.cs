using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankLocator.Api.Models;
using BankLocator.Api.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IEnumerable<Bankoffice> LoadBankoffices()
        {

                return _context.Bankoffices;

        }

        // GET: api/Scraper/{bankName}
        [HttpPost("{bankName}")]
        public async Task LoadBankoffices([FromRoute] string bankName)
        {
            if (bankName == "belfius")
            {
                var temp = new Bankoffice() { Name = "test", Latitude = 5M, Longitude = 4M };
                _context.Bankoffices.Add(temp);
                var task = new BelfiusLocatorTask();
                var result = await task.GetLocationsAsync();

                foreach (var location in result.Locations)
                {
                    var bankOffice = Mapper.Map<Location, Bankoffice>(location);
                    _context.Bankoffices.Add(bankOffice);
                   
                }
                _context.SaveChanges();
            }
        }
    }
}