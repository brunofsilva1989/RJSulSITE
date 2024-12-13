using System.Collections.Generic;
using System.Linq;
using RJSulSITE.Models;
using Microsoft.EntityFrameworkCore;
using RJSulSITE.Data;

namespace RJSulSITE.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDbContext _context;

        public ComentarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AdicionarComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
        }

        public void RemoverComentario(int comentarioID)
        {
            var comentario = _context.Comentarios.Find(comentarioID);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                _context.SaveChanges();
            }
        }

        public Comentario ObterComentario(int comentarioID)
        {
            return _context.Comentarios.Include(c => c.Usuario).FirstOrDefault(c => c.ComentarioID == comentarioID);
        }

        public IEnumerable<Comentario> ListarComentariosPorTopico(int topicoID)
        {
            return _context.Comentarios
                .Where(c => c.TopicoID == topicoID)
                .Include(c => c.Usuario)
                .OrderByDescending(c => c.DataComentario)
                .ToList();
        }
    }
}
