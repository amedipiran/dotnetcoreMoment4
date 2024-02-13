using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongListApi.Data;
using SongListApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.Include(song => song.Category).ToListAsync();
        }
[HttpPost]
public async Task<ActionResult<Song>> PostSong(Song song)
{

    _context.Songs.Add(song);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
}

// GET by ID för att användas av CreatedAtAction
[HttpGet("{id}")]
public async Task<ActionResult<Song>> GetSong(int id)
{
    var song = await _context.Songs.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);

    if (song == null)
    {
        return NotFound();
    }

    return song;
}

    }
}
