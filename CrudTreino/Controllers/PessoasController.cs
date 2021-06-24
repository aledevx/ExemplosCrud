using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudTreino.Models;
using CrudTreino.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudTreino.Controllers
{
    public class PessoasController : Controller
    {
        private readonly Contexto _context;

        public PessoasController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pessoas = _context.Pessoas;
            return View(pessoas.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Pessoas", new { id = pessoa.Id });
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoas
            .FirstOrDefaultAsync(m => m.Id == id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Pessoas", new { id = pessoa.Id });
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}