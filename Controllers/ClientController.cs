using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MantenimientoVehicularApi.Models.DTOs;
using MantenimientoVehicularApi.Models;


namespace MantenimientoVehicularApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        
        private readonly MantenimientoVehicularContext _context;
        public ClientController(MantenimientoVehicularContext context)
        {
            _context=context;
        }

        //GET: api/client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>>GetClients()
        {
            return await _context.Client
                    .Select(x=> ClientToDTO(x))
                    .ToListAsync();
        }
        //GET: api/client/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClientById(long id)
        {
            var client=await _context.Client.FindAsync(id);

            if (client==null)
            {
                return NotFound();
            }

            return ClientToDTO(client);

        }
        //PUT: api/client/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(long id, ClientDTO clientDTO)
        {
            /*
            if(id != clientDTO.Id)
            {
                return BadRequest();
            }*/

            var client= await _context.Client.FindAsync(id);
            if(client==null)
            {
                return NotFound();
            }

            client.FirstName=clientDTO.FirstName;
            client.SecondName=clientDTO.SecondName;
            client.FirstLastName=clientDTO.FirstLastName;
            client.SecondLastName=clientDTO.SecondLastName;
            client.Identification=clientDTO.Identification;
            client.IsActive=clientDTO.IsActive;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when(!ClientExist(id))
            {
                return NotFound();
            }

            return NoContent();
            
        }
        //POST: api/client
        [HttpPost]
        public async Task<ActionResult<ClientDTO>> CreateClient( ClientDTO clientItemDTO)
        {
            var client= new Client
            {
                Id=clientItemDTO.Id,
                FirstName=clientItemDTO.FirstName,
                SecondName=clientItemDTO.SecondName,
                FirstLastName=clientItemDTO.FirstLastName,
                SecondLastName=clientItemDTO.SecondLastName,
                Identification=clientItemDTO.Identification,
                IsActive=true,
                RegisterDate= DateTime.Now,
                RegisterUser="dtorres"
            };          

        _context.Client.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetClients),
           // new{id=client.Id},
            ClientToDTO(client));
        }
        //DELETE: api/client/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            var client = await _context.Client.FindAsync(id);
            if(client==null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExist(long id)
        {
            return _context.Client.Any(e=> e.Id==id);
        }
        private static ClientDTO ClientToDTO(Client clientItem) =>
            new ClientDTO
            {
                Id=clientItem.Id,
                FirstName =clientItem.FirstName,
                SecondName =clientItem.SecondName,
                FirstLastName =clientItem.FirstLastName,
                SecondLastName =clientItem.SecondLastName,
                Identification =clientItem.Identification,
                IsActive =clientItem.IsActive
            };

    }

}