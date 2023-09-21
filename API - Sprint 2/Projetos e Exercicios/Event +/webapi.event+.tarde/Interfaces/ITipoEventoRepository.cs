using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoEvento);
        List<TipoEvento> BuscarTodos();
        TipoEvento BuscarPorId(Guid id);
        void Deletar(Guid id);
        void Atualizar(Guid id, TipoEvento tipoEvento);
    }
}
