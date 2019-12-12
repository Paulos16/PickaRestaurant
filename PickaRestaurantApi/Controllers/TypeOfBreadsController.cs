using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickaRestaurantApi.Models;

namespace PickaRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfBreadsController : ControllerBase
    {
        private readonly s16996Context _context;

        public TypeOfBreadsController(s16996Context context)
        {
            _context = context;
        }

        // GET: api/TypeOfBreads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfBread>>> GetTypeOfBread()
        {
            return await _context.TypeOfBread.ToListAsync();
        }

        // GET: api/TypeOfBreads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfBread>> GetTypeOfBread(string id)
        {
            var typeOfBread = await _context.TypeOfBread.FindAsync(id);

            if (typeOfBread == null)
            {
                return NotFound();
            }

            return typeOfBread;
        }

        // PUT: api/TypeOfBreads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfBread(string id, TypeOfBread typeOfBread)
        {
            if (id != typeOfBread.Name)
            {
                return BadRequest();
            }

            _context.Entry(typeOfBread).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfBreadExists(id))
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

        // POST: api/TypeOfBreads
        [HttpPost]
        public async Task<ActionResult<TypeOfBread>> PostTypeOfBread(TypeOfBread typeOfBread)
        {
            _context.TypeOfBread.Add(typeOfBread);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TypeOfBreadExists(typeOfBread.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTypeOfBread", new { id = typeOfBread.Name }, typeOfBread);
        }

        // DELETE: api/TypeOfBreads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeOfBread>> DeleteTypeOfBread(string id)
        {
            var typeOfBread = await _context.TypeOfBread.FindAsync(id);
            if (typeOfBread == null)
            {
                return NotFound();
            }

            _context.TypeOfBread.Remove(typeOfBread);
            await _context.SaveChangesAsync();

            return typeOfBread;
        }

        private bool TypeOfBreadExists(string id)
        {
            return _context.TypeOfBread.Any(e => e.Name == id);
        }
    }
}
