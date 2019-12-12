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
    public class DeliveryDriversController : ControllerBase
    {
        private readonly s16996Context _context;

        public DeliveryDriversController(s16996Context context)
        {
            _context = context;
        }

        // GET: api/DeliveryDrivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDriver>>> GetDeliveryDriver()
        {
            return await _context.DeliveryDriver.ToListAsync();
        }

        // GET: api/DeliveryDrivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDriver>> GetDeliveryDriver(int id)
        {
            var deliveryDriver = await _context.DeliveryDriver.FindAsync(id);

            if (deliveryDriver == null)
            {
                return NotFound();
            }

            return deliveryDriver;
        }

        // PUT: api/DeliveryDrivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryDriver(int id, DeliveryDriver deliveryDriver)
        {
            if (id != deliveryDriver.IdDeliveryDriver)
            {
                return BadRequest();
            }

            _context.Entry(deliveryDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryDriverExists(id))
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

        // POST: api/DeliveryDrivers
        [HttpPost]
        public async Task<ActionResult<DeliveryDriver>> PostDeliveryDriver(DeliveryDriver deliveryDriver)
        {
            _context.DeliveryDriver.Add(deliveryDriver);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliveryDriverExists(deliveryDriver.IdDeliveryDriver))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeliveryDriver", new { id = deliveryDriver.IdDeliveryDriver }, deliveryDriver);
        }

        // DELETE: api/DeliveryDrivers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryDriver>> DeleteDeliveryDriver(int id)
        {
            var deliveryDriver = await _context.DeliveryDriver.FindAsync(id);
            if (deliveryDriver == null)
            {
                return NotFound();
            }

            _context.DeliveryDriver.Remove(deliveryDriver);
            await _context.SaveChangesAsync();

            return deliveryDriver;
        }

        private bool DeliveryDriverExists(int id)
        {
            return _context.DeliveryDriver.Any(e => e.IdDeliveryDriver == id);
        }
    }
}
