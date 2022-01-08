#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test5.Model;

namespace test5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundValuesController : ControllerBase
    {
        private readonly DBContext _context;

        public FundValuesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/FundValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FundValues>>> GetFundValues()
        {
            return await _context.FundValues.ToListAsync();
        }

        // GET: api/FundValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FundValues>> GetFundValues(int id)
        {
            var fundValues = await _context.FundValues.FindAsync(id);

            if (fundValues == null)
            {
                return NotFound();
            }

            return fundValues;
        }

        // PUT: api/FundValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundValues(int id, FundValues fundValues)
        {
            if (id != fundValues.fund_id)
            {
                return BadRequest();
            }

            _context.Entry(fundValues).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundValuesExists(id))
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

        // POST: api/FundValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FundValues>> PostFundValues(FundValues fundValues)
        {
            _context.FundValues.Add(fundValues);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FundValuesExists(fundValues.fund_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFundValues", new { id = fundValues.fund_id }, fundValues);
        }

        // DELETE: api/FundValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundValues(int id)
        {
            var fundValues = await _context.FundValues.FindAsync(id);
            if (fundValues == null)
            {
                return NotFound();
            }

            _context.FundValues.Remove(fundValues);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FundValuesExists(int id)
        {
            return _context.FundValues.Any(e => e.fund_id == id);
        }
    }
}
