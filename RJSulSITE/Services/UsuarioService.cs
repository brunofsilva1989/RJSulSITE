using RJSulSITE.Models;
using RJSulSITE.Repositories;




namespace RJSulSITE.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario ObterUsuario(int id) => _usuarioRepository.ObterUsuarioPorId(id);

        public IEnumerable<Usuario> ObterTodosUsuarios() => _usuarioRepository.ObterTodosUsuarios();

        public void RegistrarUsuario(Usuario usuario) => _usuarioRepository.AdicionarUsuario(usuario);

        public void EditarUsuario(Usuario usuario) => _usuarioRepository.AtualizarUsuario(usuario);

        public void ExcluirUsuario(int id) => _usuarioRepository.RemoverUsuario(id);
    }
}
