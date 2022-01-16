#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Controllers
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

        // get all funds showing latest fundvalues data if there is more than 1 and ignoring the fund if there is no fundvalues data
        [HttpGet]
        public IQueryable<Fund> GetFunds()
        {
            var results = _context.Fund
                .Include(f => f.FundValues)
                .Where(f => f.FundValues.Count() > 0)
                .Select(f => new Fund
                {
                    Id = f.Id,
                    name = f.name,
                    description = f.description,
                    FundValues = f.FundValues.OrderByDescending(v => v.value_date).Take(1)
                });

            return results;
        }

        // get all fundvalues data of 1 fund 
        [HttpGet("{id}")]
        public IQueryable<Fund> GetFundHistory(int id)
        {
            var results = _context.Fund
                .Where(f => f.Id == id)
                .Include(f => f.FundValues);

            return results;
        }
    }
}
