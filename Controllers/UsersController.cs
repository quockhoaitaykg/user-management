using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Information>>> GetInformation()
        {
            return await _context.Information.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Information>> GetInformation(int id)
        {
            var information = await _context.Information.FindAsync(id);

            if (information == null)
            {
                return NotFound();
            }

            return information;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformation(int id, Information information)
        {
            if (id != information.Id)
            {
                return BadRequest();
            }

            _context.Entry(information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Information>> PostInformation(Information information)
        {
            _context.Information.Add(information);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformation", new { id = information.Id }, information);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Information>> DeleteInformation(int id)
        {
            var information = await _context.Information.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }

            _context.Information.Remove(information);
            await _context.SaveChangesAsync();

            return information;
        }

        private bool InformationExists(int id)
        {
            return _context.Information.Any(e => e.Id == id);
        }
    }
}
