using RJSulSITE.Models;
using RJSulSITE.Repositories;
using System.Collections.Generic;

namespace RJSulSITE.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public IEnumerable<Servico> GetAllServicos()
        {
            return _servicoRepository.GetAllServicos();
        }

        public Servico GetServicoById(int id)
        {
            return _servicoRepository.GetServicoById(id);
        }

        public void AddServico(Servico servico)
        {
            _servicoRepository.AddServico(servico);
        }

        public void UpdateServico(Servico servico)
        {
            _servicoRepository.UpdateServico(servico);
        }

        public void DeleteServico(int id)
        {
            _servicoRepository.DeleteServico(id);
        }
    }
}
