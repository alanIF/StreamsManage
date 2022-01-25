using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamsManage.Context;
using StreamsManage.Models;

namespace StreamsManage.Controllers
{
    public class LinkController : Controller
    {
        private readonly BD _context;
        public LinkController(BD context) {
            _context = context;

        }
        public async Task<IActionResult>  Index()
        {
            return View(await _context.Links.ToListAsync());
        }
        public IActionResult create() { 
            return View();
        }
        // GET: StreamerModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linkModel = await _context.Links.FindAsync(id);
            if (linkModel == null)
            {
                return NotFound();
            }
            return View(linkModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,Name,titulo,idUser")] LinkModel linkModel)
        {
            if (id != linkModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linkModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(linkModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> store([Bind("Id,Name,titulo,idUser")] LinkModel link) {
            _context.Add(link);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        // POST: StreamerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            var linkModel = await _context.Links.FindAsync(id);
            _context.Links.Remove(linkModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
