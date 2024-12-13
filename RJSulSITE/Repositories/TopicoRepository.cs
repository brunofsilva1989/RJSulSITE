using RJSulSITE.Data;
using RJSulSITE.Models;


namespace RJSulSITE.Repositories
{
    public class TopicoRepository : ITopicoRepository
    {
        private readonly AppDbContext _context;

        public TopicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Topico ObterTopicoPorId(int id) => _context.Topicos.Find(id);

        public IEnumerable<Topico> ObterTodosTopicos() => _context.Topicos.ToList();

        public void AdicionarTopico(Topico topico)
        {
            _context.Topicos.Add(topico);
            _context.SaveChanges();
        }

        public void AtualizarTopico(Topico topico)
        {
            _context.Topicos.Update(topico);
            _context.SaveChanges();
        }

        public void RemoverTopico(int id)
        {
            var topico = _context.Topicos.Find(id);
            if (topico != null)
            {
                _context.Topicos.Remove(topico);
                _context.SaveChanges();
            }
        }
    }
}