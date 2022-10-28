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
    [Authorize(Roles = "Admin,User,Teacher")]
    public class StudentHubController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentHubController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentHub
        [HttpGet]
        [Authorize(Roles = "Admin,User,Teacher")]
        public async Task<IEnumerable<StudentHub>> GetStudentHub()
        {
            return await _context.StudentHub.ToListAsync();
        }

        // GET: api/StudentHub/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,Teacher")]
        public async Task<StudentHub> GetStudentHub(Guid id)
        {
            var studentHub = await _context.StudentHub.FindAsync(id);

            if (studentHub == null)
            {
                return null;
            }

            return studentHub;
        }

        // PUT: api/StudentHub/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> PutStudentHub(Guid id, StudentHub studentHub)
        {
            if (id != studentHub.SubjectId)
            {
                return BadRequest();
            }

            _context.Entry(studentHub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentHubExists(id))
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

        // POST: api/StudentHub
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<ActionResult<StudentHub>> PostStudentHub(StudentHub studentHub)
        {
            _context.StudentHub.Add(studentHub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentHub", new { id = studentHub.SubjectId }, studentHub);
        }

        // DELETE: api/StudentHub/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentHub(Guid id)
        {
            var studentHub = await _context.StudentHub.FindAsync(id);
            if (studentHub == null)
            {
                return NotFound();
            }

            _context.StudentHub.Remove(studentHub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentHubExists(Guid id)
        {
            return _context.StudentHub.Any(e => e.SubjectId == id);
        }
    }
}
