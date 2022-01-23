﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> store([Bind("Id,Name,titulo,idUser")] LinkModel link) {
            _context.Add(link);
            await _context.SaveChangesAsync();
            return View("Index");

        }
        public IActionResult delete() {
            return View("Index");
        }
    }
}