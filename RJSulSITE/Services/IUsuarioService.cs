using RJSulSITE.Models;



namespace RJSulSITE.Services
{
    public interface IUsuarioService
    {
        Usuario ObterUsuario(int id);
        IEnumerable<Usuario> ObterTodosUsuarios();
        void RegistrarUsuario(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        void ExcluirUsuario(int id);
    }
}
