using RJSulSITE.Models;
using System.Collections.Generic;

namespace RJSulSITE.Repositories
{
    public interface IServicoRepository
    {
        IEnumerable<Servico> GetAllServicos();
        Servico GetServicoById(int id);
        void AddServico(Servico servico);
        void UpdateServico(Servico servico);
        void DeleteServico(int id);
    }
}
