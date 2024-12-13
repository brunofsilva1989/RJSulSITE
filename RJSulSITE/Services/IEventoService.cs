using RJSulSITE.Models;



namespace RJSulSITE.Services
{
    public interface IEventoService
    {
        Evento ObterEvento(int id);
        IEnumerable<Evento> ObterTodosEventos();
        void RegistrarEvento(Evento evento);
        void EditarEvento(Evento evento);
        void ExcluirEvento(int id);
    }
}
