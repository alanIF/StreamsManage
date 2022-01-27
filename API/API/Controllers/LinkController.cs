using API.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamsManage.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly BDContext _context;
        public LinkController(BDContext context)
        {
            _context = context;

        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var links = await _context.Links.ToListAsync();
            if (links is null)
            {
                return NotFound();
            }

            return Ok(links);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([Bind("Id,Name,titulo,idUser")] LinkModel link)
        {
            _context.Add(link);
            await _context.SaveChangesAsync(); 
            

            return Ok(link);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(int id, [Bind("Id,Name,titulo,idUser")] LinkModel linkModel)
        {
            if (id != linkModel.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(linkModel);
                    await _context.SaveChangesAsync();
                    return Ok(linkModel);

                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return NotFound();
            
        }
        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            var linkModel = await _context.Links.FindAsync(id);
            _context.Links.Remove(linkModel);
            await _context.SaveChangesAsync();
            return Ok("Link excluído com sucesso");

        }
    }
}
