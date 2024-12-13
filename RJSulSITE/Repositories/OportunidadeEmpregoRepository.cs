using RJSulSITE.Data;
using RJSulSITE.Models;
using System.Collections.Generic;
using System.Linq;

namespace RJSulSITE.Repositories
{
    public class OportunidadeEmpregoRepository : IOportunidadeEmpregoRepository
    {
        private readonly AppDbContext _context;

        public OportunidadeEmpregoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OportunidadeEmprego> GetAllOportunidades()
        {
            return _context.OportunidadesEmprego.ToList();
        }

        public OportunidadeEmprego GetOportunidadeById(int id)
        {
            return _context.OportunidadesEmprego.Find(id);
        }

        public void AddOportunidade(OportunidadeEmprego oportunidade)
        {
            _context.OportunidadesEmprego.Add(oportunidade);
            _context.SaveChanges();
        }

        public void UpdateOportunidade(OportunidadeEmprego oportunidade)
        {
            _context.OportunidadesEmprego.Update(oportunidade);
            _context.SaveChanges();
        }

        public void DeleteOportunidade(int id)
        {
            var oportunidade = _context.OportunidadesEmprego.Find(id);
            if (oportunidade != null)
            {
                _context.OportunidadesEmprego.Remove(oportunidade);
                _context.SaveChanges();
            }
        }
    }
}
