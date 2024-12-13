using RJSulSITE.Models;



namespace RJSulSITE.Services
{
    public interface ITopicoService
    {
        Topico ObterTopico(int id);
        IEnumerable<Topico> ObterTodosTopicos();
        void RegistrarTopico(Topico topico);
        void EditarTopico(Topico topico);
        void ExcluirTopico(int id);
    }
}
