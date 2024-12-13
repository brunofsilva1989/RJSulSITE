using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RJSulSITE.Data;
using RJSulSITE.Models;

namespace RJSulSITE.Controllers
{
    public class OportunidadeEmpregoController : Controller
    {
        private readonly AppDbContext _context;

        public OportunidadeEmpregoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OportunidadeEmprego
        public async Task<IActionResult> Index()
        {
            return View(await _context.OportunidadesEmprego.ToListAsync());
        }

        // GET: OportunidadeEmprego/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidadeEmprego = await _context.OportunidadesEmprego
                .FirstOrDefaultAsync(m => m.OportunidadeID == id);
            if (oportunidadeEmprego == null)
            {
                return NotFound();
            }

            return View(oportunidadeEmprego);
        }

        public IActionResult Create()
        {
            // Obtem todos os usuários cadastrados para o dropdown
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "UsuarioId", "Nome");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descricao,Localizacao,Salario,UsuarioID")] OportunidadeEmprego oportunidadeEmprego)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Define a data de criação
                    oportunidadeEmprego.DataCriacao = DateTime.Now;

                    // Adiciona a oportunidade ao contexto e salva no banco
                    _context.Add(oportunidadeEmprego);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao salvar: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Erro ao salvar a oportunidade.");
                }
            }

            // Recarrega a lista de usuários para o dropdown em caso de erro
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "UsuarioId", "Nome");
            return View(oportunidadeEmprego);
        }



        // GET: OportunidadeEmprego/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidadeEmprego = await _context.OportunidadesEmprego.FindAsync(id);
            if (oportunidadeEmprego == null)
            {
                return NotFound();
            }
            return View(oportunidadeEmprego);
        }

        // POST: OportunidadeEmprego/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OportunidadeId,Titulo,Descricao,Empresa,DataPublicacao")] OportunidadeEmprego oportunidadeEmprego)
        {
            if (id != oportunidadeEmprego.OportunidadeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oportunidadeEmprego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OportunidadeEmpregoExists(oportunidadeEmprego.OportunidadeID))
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
            return View(oportunidadeEmprego);
        }

        // GET: OportunidadeEmprego/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidadeEmprego = await _context.OportunidadesEmprego
                .FirstOrDefaultAsync(m => m.OportunidadeID == id);
            if (oportunidadeEmprego == null)
            {
                return NotFound();
            }

            return View(oportunidadeEmprego);
        }

        // POST: OportunidadeEmprego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oportunidadeEmprego = await _context.OportunidadesEmprego.FindAsync(id);
            if (oportunidadeEmprego != null)
            {
                _context.OportunidadesEmprego.Remove(oportunidadeEmprego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OportunidadeEmpregoExists(int id)
        {
            return _context.OportunidadesEmprego.Any(e => e.OportunidadeID == id);
        }
    }
}
