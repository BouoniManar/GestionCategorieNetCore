﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_TP2.Models;

namespace App_TP2.Controllers
{
    public class SousCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SousCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }



		// GET: SousCategories
		public IActionResult Index()
		{
			var souscategories = _context.souscategories.ToList();
			return View(souscategories);
		}

		// GET: SousCategories/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sousCategorie = await _context.souscategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (sousCategorie == null)
            {
                return NotFound();
            }

            return View(sousCategorie);
        }

        // GET: SousCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SousCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomCat")] SousCategorie sousCategorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sousCategorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sousCategorie);
        }

        // GET: SousCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sousCategorie = await _context.souscategories.FindAsync(id);
            if (sousCategorie == null)
            {
                return NotFound();
            }
            return View(sousCategorie);
        }

        // POST: SousCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomCat")] SousCategorie sousCategorie)
        {
            if (id != sousCategorie.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sousCategorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SousCategorieExists(sousCategorie.id))
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
            return View(sousCategorie);
        }

        // GET: SousCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sousCategorie = await _context.souscategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (sousCategorie == null)
            {
                return NotFound();
            }

            return View(sousCategorie);
        }

        // POST: SousCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sousCategorie = await _context.souscategories.FindAsync(id);
            if (sousCategorie != null)
            {
                _context.souscategories.Remove(sousCategorie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SousCategorieExists(int id)
        {
            return _context.souscategories.Any(e => e.id == id);
        }
    }
}
