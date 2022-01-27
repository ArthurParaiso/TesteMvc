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
    public class FuncionarioController : Controller
    {
        private readonly DataContext _context;


        public FuncionarioController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .SingleOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,Nascimento,Salario")] FuncionariosModel funcionario)
        {
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Funcionarios.SingleOrDefaultAsync(m => m.FuncionarioId == id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Funcionario/Edit
        [HttpPost("Funcionario/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,Nascimento,Salario")] FuncionariosModel funcionario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    funcionario.FuncionarioId = id;
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                    var antigo = funcionario;
                    antigo.FuncionarioId = antigo.FuncionarioId - 1;
                    _context.Funcionarios.Remove(antigo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioId))
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
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .SingleOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(m => m.FuncionarioId == id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioId == id);
        }
    }
}
