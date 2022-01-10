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
    public class FundsController : ControllerBase
    {
        private readonly DBContext _context;

        public FundsController(DBContext context)
        {
            _context = context;
        }

        //// GET: api/Funds
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Fund>>> GetFund()
        //{
        //    return await _context.Fund.ToListAsync();
        //}

        // GET: api/Funds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fund>>> GetFund()
        {
            var results = await _context.Fund
                .Include(f => f.FundValues)
                //.Join(_context.FundValues, f => f.Id, v => v.fund_id, (f, v) => f)
                .ToListAsync();

            //var results =
            //    from f in _context.Fund
            //    join v in _context.FundValues on f.Id equals v.fund_id into fundGroup
            //    //where v.fund_id == col1 && v.Col2 == col2 && v.Col4 == someString
            //    select fundGroup;
            ////.Include(f => f.FundValues)
            ////.ToListAsync();

            //var results = _context.Fund.Include(f => f.FundValues).Select(f => new Fund
            //{
            //    Id = f.Id,
            //    name = f.name,
            //    description = f.description,
            //    FundValues = new FundValues
            //    {
            //        fund_id = f.FundValues.fund_id,
            //        value_date = f.FundValues.value_date,
            //        value = f.FundValues.value,
            //    }
            //}).ToListAsync();

            return results;
        }

        // GET: api/Funds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fund>> GetFund(int id)
        {
            var fund = await _context.Fund.FindAsync(id);

            if (fund == null)
            {
                return NotFound();
            }

            return fund;
        }

        // PUT: api/Funds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFund(int id, Fund fund)
        {
            if (id != fund.Id)
            {
                return BadRequest();
            }

            _context.Entry(fund).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundExists(id))
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

        // POST: api/Funds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fund>> PostFund(Fund fund)
        {
            _context.Fund.Add(fund);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFund", new { id = fund.Id }, fund);
        }

        // DELETE: api/Funds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFund(int id)
        {
            var fund = await _context.Fund.FindAsync(id);
            if (fund == null)
            {
                return NotFound();
            }

            _context.Fund.Remove(fund);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FundExists(int id)
        {
            return _context.Fund.Any(e => e.Id == id);
        }
    }
}
