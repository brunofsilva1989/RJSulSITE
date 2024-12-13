using RJSulSITE.Models;
using RJSulSITE.Repositories;


namespace RJSulSITE.Services
{
    public class TopicoService : ITopicoService
    {
        private readonly ITopicoRepository _topicoRepository;

        public TopicoService(ITopicoRepository topicoRepository)
        {
            _topicoRepository = topicoRepository;
        }

        public Topico ObterTopico(int id) => _topicoRepository.ObterTopicoPorId(id);

        public IEnumerable<Topico> ObterTodosTopicos() => _topicoRepository.ObterTodosTopicos();

        public void RegistrarTopico(Topico topico) => _topicoRepository.AdicionarTopico(topico);

        public void EditarTopico(Topico topico) => _topicoRepository.AtualizarTopico(topico);

        public void ExcluirTopico(int id) => _topicoRepository.RemoverTopico(id);
    }
}
