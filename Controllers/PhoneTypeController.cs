using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PorchFinal.Data;
using PorchFinal.Models;

[Route("api/[controller]")]
[ApiController]
public class PhoneTypesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PhoneTypesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/PhoneTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PhoneType>>> GetPhoneTypes()
    {
        try
        {
            var phoneTypes = await _context.PhoneTypes.ToListAsync();
            return Ok(phoneTypes);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // GET: api/PhoneTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Phone>> GetPhoneType(int id)
    {
        try
        {
            var phoneType = await _context.PhoneTypes.FindAsync(id);

            if (phoneType == null)
            {
                return NotFound("Phone Type Not Found");
            }

            return Ok(phoneType);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    //[HttpPost]
    //public async Task<ActionResult<PhoneType>> PostPhoneType(PhoneType phoneType)
    //{
    //    _context.Phone.Add(phoneType);
    //    await _context.SaveChangesAsync();

    //    // Returns 201 Created with a route to the new resource
    //    return CreatedAtAction(nameof(GetPhone), new { id = phone.PhoneId }, phone);
    //}

    // PUT: api/PhoneTypes/5
    [HttpPut("{id}")]
    public async Task<ActionResult<PhoneType>> UpdatePhoneType(PhoneType updatedPhoneType)
    {
        if (updatedPhoneType.PhoneTypeId != updatedPhoneType.PhoneTypeId)
        {
            return BadRequest("Phone ID mismatch.");
        }

        var phone = await _context.Phones.FindAsync(updatedPhoneType.PhoneTypeId);
        if (phone == null)
        {
            return NotFound("Phone Not Found");
        }

        // Update fields (PhoneNumber ONLY)
        //updatedPhoneType.PhoneTypeId = updatedPhone.PhoneNumber;

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

    // DELETE: api/PhoneTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhone(int id)
    {
        try
        {
            var phoneType = await _context.PhoneTypes.FindAsync(id);
            if (phoneType == null)
            {
                return NotFound();
            }

            _context.PhoneTypes.Remove(phoneType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Phone Type Not Found");
        }

    }
}

