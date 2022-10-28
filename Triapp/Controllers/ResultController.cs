using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Triapp.Server.Data;
using Triapp.Server.Models;

namespace Triapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResultController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Result
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Result>>> GetResult()
        {
            return await _context.Result.OrderByDescending(s => s.ResultId == s.ResultId).ToListAsync();
        }

        // GET: api/Result/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,Teacher")]
        public async Task<ActionResult<Result>> GetResult(Guid id)
        {
            var result = await _context.Result.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            await GetResult();
            return result;
        }

        // PUT: api/Result/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> PutResult(Guid id, Result result)
        {
            if (id != result.ResultId)
            {
                return BadRequest();
            }

            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
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

        // POST: api/Result
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<Result> PostResult(Result result)
        {
            _context.Result.Add(result);
            await _context.SaveChangesAsync();
            var res = await _context.Result.FindAsync(result.ResultId);
            return res;
        }

        // DELETE: api/Result/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteResult(Guid id)
        {
            var result = await _context.Result.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Result.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultExists(Guid id)
        {
            return _context.Result.Any(e => e.ResultId == id);
        }
    }
}
