using System.Collections.Generic;
using RJSulSITE.Models;

namespace RJSulSITE.Repositories
{
    public interface IComentarioRepository
    {
        void AdicionarComentario(Comentario comentario);
        void RemoverComentario(int comentarioID);
        Comentario ObterComentario(int comentarioID);
        IEnumerable<Comentario> ListarComentariosPorTopico(int topicoID);
    }
}
