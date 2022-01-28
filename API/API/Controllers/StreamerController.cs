using API.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamsManage.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamerController : ControllerBase
    {
        private readonly BDContext _context;
        public StreamerController(BDContext context)
        {
            _context = context;

        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var streamers = await _context.Streamers.ToListAsync();
            if (streamers null)
            {
                return NotFound();
            }

            return Ok(streamers);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Link,Plataforma")] StreamerModel streamer)
        {
            _context.Add( streamer);
            await _context.SaveChangesAsync(); 
            

            return Ok(streamer);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(int id, [Bind("Id,Nome,Link,Plataforma")] StreamerModel streamer)
        {
            if (id != streamer.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(streamer);
                    await _context.SaveChangesAsync();
                    return Ok(streamer);

                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return NotFound();
            
        }
        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            var streamer = await _context.Streamers.FindAsync(id);
            _context.Links.Remove(streamer);
            await _context.SaveChangesAsync();
            return Ok("streamer excluído com sucesso");

        }
    }
}
