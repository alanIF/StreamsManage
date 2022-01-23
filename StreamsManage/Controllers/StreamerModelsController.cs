#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamsManage.Context;
using StreamsManage.Models;

namespace StreamsManage.Controllers
{
    public class StreamerModelsController : Controller
    {
        private readonly BD _context;

        public StreamerModelsController(BD context)
        {
            _context = context;
        }

        // GET: StreamerModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Streamers.ToListAsync());
        }

        // GET: StreamerModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streamerModel = await _context.Streamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (streamerModel == null)
            {
                return NotFound();
            }

            return View(streamerModel);
        }

        // GET: StreamerModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StreamerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Link,Plataforma")] StreamerModel streamerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(streamerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(streamerModel);
        }

        // GET: StreamerModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streamerModel = await _context.Streamers.FindAsync(id);
            if (streamerModel == null)
            {
                return NotFound();
            }
            return View(streamerModel);
        }

        // POST: StreamerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Link,Plataforma")] StreamerModel streamerModel)
        {
            if (id != streamerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(streamerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreamerModelExists(streamerModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(streamerModel);
        }

        // GET: StreamerModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streamerModel = await _context.Streamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (streamerModel == null)
            {
                return NotFound();
            }

            return View(streamerModel);
        }

        // POST: StreamerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var streamerModel = await _context.Streamers.FindAsync(id);
            _context.Streamers.Remove(streamerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreamerModelExists(int id)
        {
            return _context.Streamers.Any(e => e.Id == id);
        }
    }
}
