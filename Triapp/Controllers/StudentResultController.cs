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
    public class StudentResultController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentResult
        [HttpGet]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IEnumerable<StudentResult>> GetStudentResult()
        {
            return await _context.StudentResult.OrderByDescending(s => s.ResultId == s.ResultId).ToListAsync();
        }

        // GET: api/StudentResult/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,Teacher")]
        public async Task<ActionResult<StudentResult>> GetStudentResult(Guid id)
        {
            var studentResult = await _context.StudentResult.FindAsync(id);

            if (studentResult == null)
            {
                return NotFound();
            }

            return studentResult;
        }

        // PUT: api/StudentResult/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutStudentResult(Guid id, StudentResult studentResult)
        {
            if (id != studentResult.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentResultExists(id))
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

        // POST: api/StudentResult
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<ActionResult<StudentResult>> PostStudentResult(StudentResult studentResult)
        {
            _context.StudentResult.Add(studentResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentResult", new { id = studentResult.StudentId }, studentResult);
        }

        // DELETE: api/StudentResult/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentResult(Guid id)
        {
            var studentResult = await _context.StudentResult.FindAsync(id);
            if (studentResult == null)
            {
                return NotFound();
            }

            _context.StudentResult.Remove(studentResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentResultExists(Guid id)
        {
            return _context.StudentResult.Any(e => e.StudentId == id);
        }
    }
}
