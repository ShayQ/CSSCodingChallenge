#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Funds
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

        // GET: api/Funds/5
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
