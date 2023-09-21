using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório de Tipo de Evento
    /// </summary>
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Cadastra um TipoUsuario na tabela do banco
        /// </summary>
        /// <param name="tipoEvento">Objeto do tipo TipoEvento</param>
        public void Cadastrar(TipoEvento tipoEvento)
        {
            if (tipoEvento != null)
            {
                _eventContext.TipoEvento.Add(tipoEvento);
                _eventContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta um TipoEvento da tabela do banco
        /// </summary>
        /// <param name="id">Id do TipoEvento</param>
        public void Deletar(Guid id)
        {
            TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.FirstOrDefault(t => t.IdTipoEvento == id)!;

            if (tipoEventoBuscado != null)
            {
                _eventContext.TipoEvento.Remove(tipoEventoBuscado);
                _eventContext.SaveChanges();
            }
        }

        /// <summary>
        /// Atualizar um TipoEvento buscado por id
        /// </summary>
        /// <param name="id">Id do TipoEvento</param>
        /// <param name="tipoEvento">Objeto do tipo TipoEvento</param>
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.Find(id)!;

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.Titulo = tipoEvento.Titulo;
                _eventContext.TipoEvento.Update(tipoEventoBuscado);
                _eventContext.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um TipoEvento por id
        /// </summary>
        /// <param name="id">Id do TipoEvento</param>
        /// <returns>Objeto do tipo TipoEvento</returns>
        public TipoEvento BuscarPorId(Guid id)
        {
            return _eventContext.TipoEvento.FirstOrDefault(t => t.IdTipoEvento == id)!;
        }

        /// <summary>
        /// Busca todos os TipoEvento da tabela do banco
        /// </summary>
        /// <returns>Lista de Objetos do tipo TipoEvento</returns>
        public List<TipoEvento> BuscarTodos()
        {
            List<TipoEvento> listaTiposEvento = _eventContext.TipoEvento.ToList();

            if (listaTiposEvento != null)
            {
                return listaTiposEvento;
            }
            return null!;
        }
    }
}
