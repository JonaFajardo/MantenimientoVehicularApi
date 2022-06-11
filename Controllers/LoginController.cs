using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MantenimientoVehicularApi.Models;

namespace MantenimientoVehicularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MantenimientoVehicularContext _context;

        public LoginController(MantenimientoVehicularContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
          if (_context.User == null)
          {
              return NotFound();
          }
            return await _context.User.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{username/password}")]
        public  ActionResult<List<User>> LoginUser(string username, string password)
        {
          if (_context.User == null)
          {
              return NotFound();
          }
            var user =  _context.User.Where(usuario => usuario.userName.Equals(username) && usuario.password.Equals(password)).ToList();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Login/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.User == null)
          {
              return Problem("Entity set 'MantenimientoVehicularContext.User'  is null.");
          }
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id }, user);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
