using RJSulSITE.Models;

namespace RJSulSITE.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario ObterUsuarioPorId(int id);
        IEnumerable<Usuario> ObterTodosUsuarios();
        void AdicionarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void RemoverUsuario(int id);
    }
}
