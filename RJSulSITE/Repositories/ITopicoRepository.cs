using RJSulSITE.Models;

namespace RJSulSITE.Repositories
{
    public interface ITopicoRepository
    {
        Topico ObterTopicoPorId(int id);
        IEnumerable<Topico> ObterTodosTopicos();
        void AdicionarTopico(Topico topico);
        void AtualizarTopico(Topico topico);
        void RemoverTopico(int id);
    }
}
