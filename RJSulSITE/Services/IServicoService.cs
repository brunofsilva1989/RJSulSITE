using RJSulSITE.Models;
using System.Collections.Generic;

namespace RJSulSITE.Services
{
    public interface IServicoService
    {
        IEnumerable<Servico> GetAllServicos();
        Servico GetServicoById(int id);
        void AddServico(Servico servico);
        void UpdateServico(Servico servico);
        void DeleteServico(int id);
    }
}
