using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RJSulSITE.Data;
using RJSulSITE.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RJSulSITE.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        // POST: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,TipoUsuario,Senha")] Usuario usuario)
        {
            // Remover validação de DataCadastro se necessário
            ModelState.Remove("DataCadastro");

            // Verificar se o ModelState é válido
            if (!ModelState.IsValid)
            {
                // Captura e exibe os erros do ModelState no depurador ou log
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                // Opcional: Logar os erros (ou exibir na interface)
                Console.WriteLine("Erros no ModelState:");
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }

                // Retorna a view com os dados do usuário e os erros de validação
                return View(usuario);
            }

            try
            {
                // Define a data de cadastro
                usuario.DataCadastro = DateTime.Now;

                // Adiciona o usuário ao contexto
                _context.Add(usuario);

                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync();

                // Redireciona para a tela de listagem
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Loga o erro para depuração
                Console.WriteLine($"Erro ao salvar o usuário: {ex.Message}");

                // Adiciona uma mensagem de erro ao ModelState
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar o usuário. Tente novamente.");
            }

            // Retorna a view com os dados do usuário caso ocorra erro
            return View(usuario);
        }



        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nome,Email,TipoUsuario,DataCadastro")] Usuario usuario, string Senha)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }

        private string GerarHashSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return null;

            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
