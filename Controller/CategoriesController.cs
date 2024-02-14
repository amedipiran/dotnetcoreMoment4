using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongListApi.Data;
using SongListApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

[HttpPost]
public async Task<ActionResult<Category>> PostCategory(Category category)
{
    _context.Categories.Add(category);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
}

// GET by ID för att användas av CreatedAtAction
[HttpGet("{id}")]
public async Task<ActionResult<Category>> GetCategory(int id)
{
    var category = await _context.Categories.FindAsync(id);

    if (category == null)
    {
        return NotFound();
    }

    return category;
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteCategory(int id)
{
    var category = await _context.Categories.Include(c => c.Songs).FirstOrDefaultAsync(c => c.Id == id);
    if (category == null)
    {
        return NotFound();
    }

    if (category.Songs.Any())
    {
        // Returnera ett felmeddelande om det finns låtar som tillhör kategorin
        return BadRequest("Kategorin kan inte tas bort eftersom den har tillhörande låtar.");
    }

    _context.Categories.Remove(category);
    await _context.SaveChangesAsync();

    return NoContent(); 
}

    }
}
