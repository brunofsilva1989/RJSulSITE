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
    public class TopicoController : Controller
    {
        private readonly AppDbContext _context;

        public TopicoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Topico
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Topicos.Include(t => t.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Topico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topico = await _context.Topicos
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.TopicoId == id);
            if (topico == null)
            {
                return NotFound();
            }

            return View(topico);
        }

        // GET: Topico/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nome");
            return View();
        }

        // POST: Topico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TopicoId,Titulo,Descricao,Conteudo,DataCriacao,UsuarioId")] Topico topico)
        {
            if (ModelState.IsValid)
            {
                // Definindo automaticamente a data de criação
                topico.DataCriacao = DateTime.Now;

                _context.Add(topico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nome", topico.UsuarioId);
            return View(topico);
        }

        // GET: Topico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topico = await _context.Topicos.FindAsync(id);
            if (topico == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nome", topico.UsuarioId);
            return View(topico);
        }

        // POST: Topico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TopicoId,Titulo,Descricao,Conteudo,DataCriacao,UsuarioId")] Topico topico)
        {
            if (id != topico.TopicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicoExists(topico.TopicoId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nome", topico.UsuarioId);
            return View(topico);
        }

        // GET: Topico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topico = await _context.Topicos
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.TopicoId == id);
            if (topico == null)
            {
                return NotFound();
            }

            return View(topico);
        }

        // POST: Topico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topico = await _context.Topicos.FindAsync(id);
            if (topico != null)
            {
                _context.Topicos.Remove(topico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicoExists(int id)
        {
            return _context.Topicos.Any(e => e.TopicoId == id);
        }
    }
}
