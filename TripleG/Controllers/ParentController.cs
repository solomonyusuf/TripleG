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
    public class ParentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Parent
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<ParentInfo>> GetParentInfo()
        {
            return await _context.ParentInfo.ToListAsync();
        }

        // GET: api/Parent/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,Teacher")]
        public async Task<ParentInfo> GetParentInfo(Guid id)
        {
            var parentInfo = await _context.ParentInfo.FindAsync(id);

            if (parentInfo == null)
            {
                return null;
            }

            return parentInfo;
        }

        // PUT: api/Parent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> PutParentInfo(Guid id, ParentInfo parentInfo)
        {
            if (id != parentInfo.ParentId)
            {
                return BadRequest();
            }

            _context.Entry(parentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentInfoExists(id))
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

        // POST: api/Parent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,User,Teacher")]
        public async Task<ParentInfo> PostParentInfo(ParentInfo parentInfo)
        {
            _context.ParentInfo.Add(parentInfo);
            await _context.SaveChangesAsync();

            return await GetParentInfo(parentInfo.ParentId);
        }

        // DELETE: api/Parent/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteParentInfo(Guid id)
        {
            var parentInfo = await _context.ParentInfo.FindAsync(id);
            if (parentInfo == null)
            {
                return NotFound();
            }

            _context.ParentInfo.Remove(parentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentInfoExists(Guid id)
        {
            return _context.ParentInfo.Any(e => e.ParentId == id);
        }
    }
}
