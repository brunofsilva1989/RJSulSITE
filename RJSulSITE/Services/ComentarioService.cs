using RJSulSITE.Models;
using RJSulSITE.Repositories;

namespace RJSulSITE.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public void AdicionarComentario(Comentario comentario)
        {
            _comentarioRepository.AdicionarComentario(comentario);
        }

        public void RemoverComentario(int comentarioID)
        {
            _comentarioRepository.RemoverComentario(comentarioID);
        }

        public Comentario ObterComentario(int comentarioID)
        {
            return _comentarioRepository.ObterComentario(comentarioID);
        }

        public IEnumerable<Comentario> ListarComentariosPorTopico(int topicoID)
        {
            return _comentarioRepository.ListarComentariosPorTopico(topicoID);
        }
    }
}
