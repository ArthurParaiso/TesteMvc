using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteMvcArthur.Data;
using TesteMvcArthur.Models;

namespace TesteMvcArthur.Controllers
{
    public class FilhoController : Controller
    {
        private readonly DataContext _context;


        public FilhoController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filhos.ToListAsync());
        }

        // GET: Filho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filho = await _context.Filhos
                .SingleOrDefaultAsync(m => m.FilhoId == id);
            if (filho == null)
            {
                return NotFound();
            }

            return View(filho);
        }

        // GET: Filho/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilhoId,Nome,Nascimento,FuncionarioId")] FilhosModel filho)
        {
            _context.Add(filho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Filho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Filhos.SingleOrDefaultAsync(m => m.FilhoId == id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Filho/Edit
        [HttpPost("Filho/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilhoId,Nome,Nascimento,FuncionarioId")] FilhosModel filho)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    filho.FilhoId = id;
                    _context.Update(filho);
                    await _context.SaveChangesAsync();
                    var antigo = filho;
                    antigo.FilhoId = antigo.FilhoId - 1;
                    _context.Filhos.Remove(antigo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilhoExists(filho.FilhoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(filho);
        }

        // GET: Filho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filho = await _context.Filhos
                .SingleOrDefaultAsync(m => m.FilhoId == id);
            if (filho == null)
            {
                return NotFound();
            }

            return View(filho);
        }

        // POST: Filho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filho = await _context.Filhos.SingleOrDefaultAsync(m => m.FilhoId == id);
            _context.Filhos.Remove(filho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FilhoExists(int id)
        {
            return _context.Filhos.Any(e => e.FilhoId == id);
        }
    }
}
