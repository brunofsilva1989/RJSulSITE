using RJSulSITE.Models;

namespace RJSulSITE.Repositories
{
    public interface IEventoRepository
    {
        Evento ObterEventoPorId(int id);
        IEnumerable<Evento> ObterTodosEventos();
        void AdicionarEvento(Evento evento);
        void AtualizarEvento(Evento evento);
        void RemoverEvento(int id);
    }
}
