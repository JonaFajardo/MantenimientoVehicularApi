using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MantenimientoVehicularApi.Models;

namespace MantenimientoVehicularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carController : ControllerBase
    {
        private readonly MantenimientoVehicularContext _context;

        public carController(MantenimientoVehicularContext context)
        {
            _context = context;
        }

        // GET: api/car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<car>>> Getcar()
        {
          if (_context.Car == null)
          {
              return NotFound();
          }
            return await _context.Car.ToListAsync();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<car>> GetCar(int id)
        {
          if (_context.Car == null)
          {
              return NotFound();
          }
            var car = await _context.Car.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/car/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcar(int id, car car)
        {
            if (id != car.id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carExists(id))
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

        // POST: api/car
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<car>> Postcar(car car)
        {
          if (_context.Car == null)
          {
              return Problem("Entity set 'MantenimientoVehicularContext.car'  is null.");
          }
            _context.Car.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcar", new { id = car.id }, car);
        }

        // DELETE: api/car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecar(int id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool carExists(int id)
        {
            return (_context.Car?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
