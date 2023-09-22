using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void Cadastrar(PresencaEvento presencaEvento);
        PresencaEvento Deletar(Guid id);
        List<PresencaEvento> BuscarTodos();
        PresencaEvento BuscarPorId(Guid id);
        PresencaEvento Atualizar(Guid id, PresencaEvento presencaEvento);
    }
}
