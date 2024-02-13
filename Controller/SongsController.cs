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


    }
}
