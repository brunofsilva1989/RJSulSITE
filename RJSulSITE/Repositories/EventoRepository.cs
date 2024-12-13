using RJSulSITE.Data;
using RJSulSITE.Models;


namespace RJSulSITE.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Evento ObterEventoPorId(int id) => _context.Eventos.Find(id);

        public IEnumerable<Evento> ObterTodosEventos() => _context.Eventos.ToList();

        public void AdicionarEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
        }

        public void AtualizarEvento(Evento evento)
        {
            _context.Eventos.Update(evento);
            _context.SaveChanges();
        }

        public void RemoverEvento(int id)
        {
            var evento = _context.Eventos.Find(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                _context.SaveChanges();
            }
        }
    }
}
