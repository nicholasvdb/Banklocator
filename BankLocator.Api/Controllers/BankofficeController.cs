using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankLocator.Api.Models;

namespace BankLocator.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Bankoffice")]
    public class BankofficeController : Controller
    {
        private readonly BankLocatorContext _context;

        public BankofficeController(BankLocatorContext context)
        {
            _context = context;
        }

        // GET: api/Bankoffice
        [HttpGet]
        public IEnumerable<Bankoffice> GetBankoffices()
        {
            return _context.Bankoffices;
        }

        // GET: api/Bankoffice/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankoffice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankoffice = await _context.Bankoffices.SingleOrDefaultAsync(m => m.BankofficeID == id);

            if (bankoffice == null)
            {
                return NotFound();
            }

            return Ok(bankoffice);
        }

        // PUT: api/Bankoffice/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankoffice([FromRoute] int id, [FromBody] Bankoffice bankoffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankoffice.BankofficeID)
            {
                return BadRequest();
            }

            _context.Entry(bankoffice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankofficeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bankoffice
        [HttpPost]
        public async Task<IActionResult> PostBankoffice([FromBody] Bankoffice bankoffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bankoffices.Add(bankoffice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankoffice", new { id = bankoffice.BankofficeID }, bankoffice);
        }

        // DELETE: api/Bankoffice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankoffice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankoffice = await _context.Bankoffices.SingleOrDefaultAsync(m => m.BankofficeID == id);
            if (bankoffice == null)
            {
                return NotFound();
            }

            _context.Bankoffices.Remove(bankoffice);
            await _context.SaveChangesAsync();

            return Ok(bankoffice);
        }

        private bool BankofficeExists(int id)
        {
            return _context.Bankoffices.Any(e => e.BankofficeID == id);
        }
    }
}