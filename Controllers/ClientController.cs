using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PorchFinal.Data;
using PorchFinal.Models;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        try
        {
            var clients = await _context.Clients
                .Include(c => c.Phones)
                .ToListAsync();
            
            if (clients == null)
            {
                return NotFound("No Clients Not Found");
            }

            return Ok(clients);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // GET: api/Clients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(int id)
    {
        try
        {
            var client = await _context.Clients
            .Include(c => c.Phones)
            .FirstOrDefaultAsync(c => c.ClientId == id);

            if (client == null)
            {
                return NotFound("Client Not Found");
            }

            return Ok(client);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        // Returns 201 Created with a route to the new resource
        return CreatedAtAction(nameof(GetClient), new { id = client.ClientId }, client);
    }

    // PUT: api/Clients/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Client>> UpdateClient(Client updatedClient)
    {
        if (updatedClient.ClientId != updatedClient.ClientId)
        {
            return BadRequest("Client ID mismatch.");
        }

        var client = await _context.Clients.FindAsync(updatedClient.ClientId);
        if (client == null)
        {
            return NotFound("Client Not Found");
        }

        // Update fields
        client.FirstName = updatedClient.FirstName;
        client.LastName = updatedClient.LastName;
        client.Email = updatedClient.Email;
        client.IsArchived = updatedClient.IsArchived;
        //client.Offender = updatedClient.Offender;
        //client.RepeatOffender = updatedClient.RepeatOffender;
        client.Phones = updatedClient.Phones;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return StatusCode(500, "A concurrency error occurred.");
        }

        return NoContent();
    }

    // DELETE: api/Clients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch(Exception ex)
        {
            return NotFound("Client Not Found");
        }

    }
}
