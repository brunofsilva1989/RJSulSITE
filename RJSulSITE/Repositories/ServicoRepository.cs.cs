using RJSulSITE.Data;
using RJSulSITE.Models;
using System.Collections.Generic;
using System.Linq;

namespace RJSulSITE.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Servico> GetAllServicos()
        {
            return _context.Servicos.ToList();
        }

        public Servico GetServicoById(int id)
        {
            return _context.Servicos.Find(id);
        }

        public void AddServico(Servico servico)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
        }

        public void UpdateServico(Servico servico)
        {
            _context.Servicos.Update(servico);
            _context.SaveChanges();
        }

        public void DeleteServico(int id)
        {
            var servico = _context.Servicos.Find(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
                _context.SaveChanges();
            }
        }
    }
}
