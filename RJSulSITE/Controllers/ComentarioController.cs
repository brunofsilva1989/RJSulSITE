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
    public class ComentarioController : Controller
    {
        private readonly AppDbContext _context;

        public ComentarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Comentario
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Comentarios.Include(c => c.Topico).Include(c => c.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Comentario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .Include(c => c.Topico)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComentarioID == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentario/Create
        public IActionResult Create()
        {
            ViewData["TopicoID"] = new SelectList(_context.Topicos, "TopicoId", "TopicoId");
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Comentario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComentarioID,TopicoID,UsuarioID,Conteudo,DataComentario")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TopicoID"] = new SelectList(_context.Topicos, "TopicoId", "TopicoId", comentario.TopicoID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            ViewData["TopicoID"] = new SelectList(_context.Topicos, "TopicoId", "TopicoId", comentario.TopicoID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", comentario.UsuarioID);
            return View(comentario);
        }

        // POST: Comentario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComentarioID,TopicoID,UsuarioID,Conteudo,DataComentario")] Comentario comentario)
        {
            if (id != comentario.ComentarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.ComentarioID))
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
            ViewData["TopicoID"] = new SelectList(_context.Topicos, "TopicoId", "TopicoId", comentario.TopicoID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .Include(c => c.Topico)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComentarioID == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.ComentarioID == id);
        }
    }
}
