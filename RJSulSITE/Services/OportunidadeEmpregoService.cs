using RJSulSITE.Models;
using RJSulSITE.Repositories;
using System.Collections.Generic;

namespace RJSulSITE.Services
{
    public class OportunidadeEmpregoService : IOportunidadeEmpregoService
    {
        private readonly IOportunidadeEmpregoRepository _oportunidadeRepository;

        public OportunidadeEmpregoService(IOportunidadeEmpregoRepository oportunidadeRepository)
        {
            _oportunidadeRepository = oportunidadeRepository;
        }

        public IEnumerable<OportunidadeEmprego> GetAllOportunidades()
        {
            return _oportunidadeRepository.GetAllOportunidades();
        }

        public OportunidadeEmprego GetOportunidadeById(int id)
        {
            return _oportunidadeRepository.GetOportunidadeById(id);
        }

        public void AddOportunidade(OportunidadeEmprego oportunidade)
        {
            _oportunidadeRepository.AddOportunidade(oportunidade);
        }

        public void UpdateOportunidade(OportunidadeEmprego oportunidade)
        {
            _oportunidadeRepository.UpdateOportunidade(oportunidade);
        }

        public void DeleteOportunidade(int id)
        {
            _oportunidadeRepository.DeleteOportunidade(id);
        }
    }
}
