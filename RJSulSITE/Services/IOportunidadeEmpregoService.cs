using RJSulSITE.Models;
using System.Collections.Generic;

namespace RJSulSITE.Services
{
    public interface IOportunidadeEmpregoService
    {
        IEnumerable<OportunidadeEmprego> GetAllOportunidades();
        OportunidadeEmprego GetOportunidadeById(int id);
        void AddOportunidade(OportunidadeEmprego oportunidade);
        void UpdateOportunidade(OportunidadeEmprego oportunidade);
        void DeleteOportunidade(int id);
    }
}
