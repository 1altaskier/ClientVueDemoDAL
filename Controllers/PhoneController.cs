using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PorchFinal.Data;
using PorchFinal.Models;

[Route("api/[controller]")]
[ApiController]
public class PhonesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PhonesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Phones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Phone>>> GetPhones()
    {
        try
        {
            var phones = await _context.Phones.ToListAsync();
            return Ok(phones);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // GET: api/Phones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Phone>> GetPhone(int id)
    {
        try
        {
            var phone = await _context.Phones.FindAsync(id);

            if (phone == null)
            {
                return NotFound("Phone Not Found");
            }

            return Ok(phone);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Phone>> PostPhone(Phone phone)
    {
        _context.Phones.Add(phone);
        await _context.SaveChangesAsync();

        // Returns 201 Created with a route to the new resource
        return CreatedAtAction(nameof(GetPhone), new { id = phone.PhoneId }, phone);
    }

    // PUT: api/Phones/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Phone>> UpdatePhone(Phone updatedPhone)
    {
        if (updatedPhone.PhoneId != updatedPhone.PhoneId)
        {
            return BadRequest("Phone ID mismatch.");
        }

        var phone = await _context.Phones.FindAsync(updatedPhone.PhoneId);
        if (phone == null)
        {
            return NotFound("Phone Not Found");
        }

        // Update fields (PhoneNumber ONLY)
        phone.PhoneNumber = updatedPhone.PhoneNumber;

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

    // DELETE: api/Phones/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhone(int id)
    {
        try
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Phone Not Found");
        }

    }
}
