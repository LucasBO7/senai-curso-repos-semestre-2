using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Cadastra um novo Evento no banco
        /// </summary>
        /// <param name="evento">Objeto do tipo Evento</param>
        public void Cadastrar(Evento evento)
        {
            if (evento != null)
            {
                _eventContext.Evento.Add(evento);
                _eventContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta um Evento por id
        /// </summary>
        /// <param name="id">Id do Evento</param>
        public Evento Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

            if (eventoBuscado != null)
            {
                _eventContext.Evento.Remove(eventoBuscado);
                _eventContext.SaveChanges();
                return eventoBuscado;
            }
            return null!;
        }

        /// <summary>
        /// Atualiza um Evento por id
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <param name="evento"></param>
        public Evento Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado = new()
                {
                    IdTipoEvento = evento.IdTipoEvento,
                    IdInstituicao = evento.IdInstituicao,
                    DataEvento = evento.DataEvento,
                    NomeEvento = evento.NomeEvento,
                    Descricao = evento.Descricao,
                };
                _eventContext.Evento.Update(eventoBuscado);
                _eventContext.SaveChanges();
                return eventoBuscado;
            }
            return null!;
        }

        /// <summary>
        /// Busca um Evento por id
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <returns>Objeto do tipo Evento</returns>
        public Evento BuscarPorId(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.Select(e => new Evento()
            {
                IdEvento = e.IdEvento,
                DataEvento = e.DataEvento,
                NomeEvento = e.NomeEvento,
                Descricao = e.Descricao,
                IdTipoEvento = e.IdTipoEvento,
                TipoEvento = new()
                {
                    IdTipoEvento = e.TipoEvento!.IdTipoEvento,
                    Titulo = e.TipoEvento.Titulo
                },
                Instituicao = new()
                {
                    IdInstituicao = e.Instituicao!.IdInstituicao,
                    CNPJ = e.Instituicao.CNPJ!,
                    Endereco = e.Instituicao.Endereco,
                    NomeFantasia = e.Instituicao.NomeFantasia
                }
            }).FirstOrDefault(e => e.IdEvento == id)!;

            return eventoBuscado;
        }

        /// <summary>
        /// Busca todos os eventos do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Evento</returns>
        public List<Evento> BuscarTodos()
        {
            List<Evento> listaEventos = _eventContext.Evento.Select(e => new Evento()
            {
                IdEvento = e.IdEvento,
                DataEvento = e.DataEvento,
                NomeEvento = e.NomeEvento,
                Descricao = e.Descricao,
                IdTipoEvento = e.IdTipoEvento,
                TipoEvento = new()
                {
                    IdTipoEvento = e.TipoEvento!.IdTipoEvento,
                    Titulo = e.TipoEvento.Titulo
                },
                Instituicao = new()
                {
                    IdInstituicao = e.Instituicao!.IdInstituicao,
                    CNPJ = e.Instituicao.CNPJ!,
                    Endereco = e.Instituicao.Endereco,
                    NomeFantasia = e.Instituicao.NomeFantasia
                }
            }).ToList();

            if (listaEventos != null)
            {
                return listaEventos;
            }
            return null!;
        }
    }
}