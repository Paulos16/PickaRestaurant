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
    public class PizzaToppingsController : ControllerBase
    {
        private readonly s16996Context _context;

        public PizzaToppingsController(s16996Context context)
        {
            _context = context;
        }

        // GET: api/PizzaToppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaTopping>>> GetPizzaTopping()
        {
            return await _context.PizzaTopping.ToListAsync();
        }

        // GET: api/PizzaToppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaTopping>> GetPizzaTopping(int id)
        {
            var pizzaTopping = await _context.PizzaTopping.FindAsync(id);

            if (pizzaTopping == null)
            {
                return NotFound();
            }

            return pizzaTopping;
        }

        // PUT: api/PizzaToppings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaTopping(int id, PizzaTopping pizzaTopping)
        {
            if (id != pizzaTopping.PizzaIdPizza)
            {
                return BadRequest();
            }

            _context.Entry(pizzaTopping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaToppingExists(id))
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

        // POST: api/PizzaToppings
        [HttpPost]
        public async Task<ActionResult<PizzaTopping>> PostPizzaTopping(PizzaTopping pizzaTopping)
        {
            _context.PizzaTopping.Add(pizzaTopping);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PizzaToppingExists(pizzaTopping.PizzaIdPizza))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPizzaTopping", new { id = pizzaTopping.PizzaIdPizza }, pizzaTopping);
        }

        // DELETE: api/PizzaToppings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PizzaTopping>> DeletePizzaTopping(int id)
        {
            var pizzaTopping = await _context.PizzaTopping.FindAsync(id);
            if (pizzaTopping == null)
            {
                return NotFound();
            }

            _context.PizzaTopping.Remove(pizzaTopping);
            await _context.SaveChangesAsync();

            return pizzaTopping;
        }

        private bool PizzaToppingExists(int id)
        {
            return _context.PizzaTopping.Any(e => e.PizzaIdPizza == id);
        }
    }
}
