using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroDoces.Data;
using CadastroDoces.Models;

namespace CadastroDoces.Controllers
{
    public class DocesController : Controller
    {
        private readonly CadastroDocesContext _context;

        public DocesController(CadastroDocesContext context)
        {
            _context = context;
        }

        // GET: Doces
        public async Task<IActionResult> Index()
        {
              return View(await _context.Doce.ToListAsync());
        }

        // GET: Doces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doce == null)
            {
                return NotFound();
            }

            var doce = await _context.Doce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doce == null)
            {
                return NotFound();
            }

            return View(doce);
        }

        // GET: Doces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Valor,DataCadastro")] Doce doce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doce);
        }

        // GET: Doces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doce == null)
            {
                return NotFound();
            }

            var doce = await _context.Doce.FindAsync(id);
            if (doce == null)
            {
                return NotFound();
            }
            return View(doce);
        }

        // POST: Doces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Valor,DataCadastro")] Doce doce)
        {
            if (id != doce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoceExists(doce.Id))
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
            return View(doce);
        }

        // GET: Doces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doce == null)
            {
                return NotFound();
            }

            var doce = await _context.Doce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doce == null)
            {
                return NotFound();
            }

            return View(doce);
        }

        // POST: Doces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doce == null)
            {
                return Problem("Entity set 'CadastroDocesContext.Doce'  is null.");
            }
            var doce = await _context.Doce.FindAsync(id);
            if (doce != null)
            {
                _context.Doce.Remove(doce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoceExists(int id)
        {
          return _context.Doce.Any(e => e.Id == id);
        }
    }
}
