using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripleG.Server.Data;
using TripleG.Server.Models;

namespace TripleG.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Staffs
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Staffs>>> GetStaffs()
        {
            return await _context.Staffs.ToListAsync();
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Staffs>> GetStaffs(Guid id)
        {
            var staffs = await _context.Staffs.FindAsync(id);

            if (staffs == null)
            {
                return NotFound();
            }

            return staffs;
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutStaffs(Guid id, Staffs staffs)
        {
            if (id != staffs.id)
            {
                return BadRequest();
            }

            _context.Entry(staffs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffsExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Staffs>> PostStaffs(Staffs staffs)
        {
            _context.Staffs.Add(staffs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffs", new { id = staffs.id }, staffs);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStaffs(Guid id)
        {
            var staffs = await _context.Staffs.FindAsync(id);
            if (staffs == null)
            {
                return NotFound();
            }

            _context.Staffs.Remove(staffs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffsExists(Guid id)
        {
            return _context.Staffs.Any(e => e.id == id);
        }
    }
}
