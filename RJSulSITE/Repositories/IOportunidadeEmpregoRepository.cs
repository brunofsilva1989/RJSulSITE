using RJSulSITE.Models;
using System.Collections.Generic;

namespace RJSulSITE.Repositories
{
    public interface IOportunidadeEmpregoRepository
    {
        IEnumerable<OportunidadeEmprego> GetAllOportunidades();
        OportunidadeEmprego GetOportunidadeById(int id);
        void AddOportunidade(OportunidadeEmprego oportunidade);
        void UpdateOportunidade(OportunidadeEmprego oportunidade);
        void DeleteOportunidade(int id);
    }
}
