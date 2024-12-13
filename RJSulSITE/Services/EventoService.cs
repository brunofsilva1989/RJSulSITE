using RJSulSITE.Models;
using RJSulSITE.Repositories;


namespace RJSulSITE.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public Evento ObterEvento(int id) => _eventoRepository.ObterEventoPorId(id);

        public IEnumerable<Evento> ObterTodosEventos() => _eventoRepository.ObterTodosEventos();

        public void RegistrarEvento(Evento evento) => _eventoRepository.AdicionarEvento(evento);

        public void EditarEvento(Evento evento) => _eventoRepository.AtualizarEvento(evento);

        public void ExcluirEvento(int id) => _eventoRepository.RemoverEvento(id);
    }
}
