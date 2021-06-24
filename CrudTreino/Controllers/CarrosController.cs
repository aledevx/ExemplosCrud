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
    public class CarrosController : Controller
    {
        private readonly Contexto _context;

        public CarrosController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pessoas = _context.Pessoas.FirstOrDefault();
            var carros = _context.Carros.Include(p => p.Pessoa);
            return View(carros.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Modelo = ListaModelos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Carro carro)
        {

            if (VerificarPlaca(carro.Placa))
            {
                ModelState.AddModelError("Placa", "Placa ja cadastrada!");
            }
            if (!ModelState.IsValid)
            {
                return View(carro);
            }
            _context.Add(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int? id)
        {

            var carro = await _context.Carros.Include(p => p.Pessoa).FirstOrDefaultAsync(c => c.Id == id);

            return View(carro);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            var carro = await _context.Carros.Include(p => p.Pessoa).FirstOrDefaultAsync(c => c.Id == id);

            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Carro carro)
        {
            _context.Update(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Carros", new { id = carro.Id });

        }

        public IActionResult Delete(int? id)
        {

            var carro = _context.Carros.Find(id);

            return View(carro);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Carro carro)
        {
            _context.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public Boolean VerificarPlaca(string placa)
        {
            return _context.Carros.Any(c => c.Placa == placa);
        }

        public SelectListItem[] ListaModelos()
        {
            var lista = new[] {

                new SelectListItem () { Value = Costantes.Modelos.Ferrari, Text = Costantes.Modelos.Ferrari },
                new SelectListItem () { Value = Costantes.Modelos.Opala, Text = Costantes.Modelos.Opala },
                new SelectListItem () { Value = Costantes.Modelos.Maveric, Text = Costantes.Modelos.Maveric },
                new SelectListItem () { Value = Costantes.Modelos.Fusca, Text = Costantes.Modelos.Fusca },
            };
            return lista;
        }


    }
}