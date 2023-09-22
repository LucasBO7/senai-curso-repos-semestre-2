using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Cadastra uma PresencaEvento na tabela do banco
        /// </summary>
        /// <param name="presencaEvento">Objeto do tipo PresencaEvento</param>
        public void Cadastrar(PresencaEvento presencaEvento)
        {
            if (presencaEvento != null)
            {
                _eventContext.PresencaEvento.Add(presencaEvento);
                _eventContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta uma PresencaEvento na tabela do banco
        /// </summary>
        /// <param name="id">Id da PresencaEvento</param>
        /// <returns>Objeto do tipo PresencaEvento</returns>
        public PresencaEvento Deletar(Guid id)
        {
            PresencaEvento presencaEventoBuscado = _eventContext.PresencaEvento.FirstOrDefault(e => e.IdPresencaEvento == id)!;

            if (presencaEventoBuscado != null)
            {
                _eventContext.PresencaEvento.Remove(presencaEventoBuscado);
                _eventContext.SaveChanges();
                return presencaEventoBuscado;
            }
            return null!;
        }


        public PresencaEvento Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento presencaEventoBuscado = _eventContext.PresencaEvento.FirstOrDefault(e => e.IdEvento == id)!;

            if (presencaEventoBuscado != null)
            {
                presencaEventoBuscado = new()
                {
                    IdPresencaEvento = presencaEvento.IdPresencaEvento,
                    Situacao = presencaEvento.Situacao,
                    IdUsuario = presencaEvento.IdUsuario,
                    IdEvento = presencaEvento.IdEvento,
                };
                _eventContext.PresencaEvento.Update(presencaEventoBuscado);
                _eventContext.SaveChanges();
                return presencaEventoBuscado;
            }
            return null!;
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            return _eventContext.PresencaEvento.Select(e => new PresencaEvento()
            {
                IdPresencaEvento = e.IdPresencaEvento,
                Situacao = e.Situacao,
                IdUsuario = e.IdUsuario,
                IdEvento = e.IdEvento,
                Evento = new()
                {
                    DataEvento = e.Evento!.DataEvento,
                    NomeEvento = e.Evento.NomeEvento,
                    Descricao = e.Evento.Descricao,
                    IdTipoEvento = e.Evento.IdTipoEvento,
                    IdInstituicao = e.Evento.IdInstituicao
                },
                Usuario = new()
                {
                    IdUsuario = e.Usuario!.IdUsuario,
                    Nome = e.Usuario.Nome,
                    Email = e.Usuario.Email,
                }
            }).FirstOrDefault(e => e.IdPresencaEvento == id)!;
        }

        public List<PresencaEvento> BuscarTodos()
        {
            List<PresencaEvento> presencaEventos = _eventContext.PresencaEvento.Select(p => new PresencaEvento()
            {
                IdPresencaEvento = p.IdPresencaEvento,
                Situacao = p.Situacao,
                IdUsuario = p.IdUsuario,
                IdEvento = p.IdEvento,
                Evento = new()
                {
                    DataEvento = p.Evento!.DataEvento,
                    NomeEvento = p.Evento.NomeEvento,
                    Descricao = p.Evento.Descricao,
                    IdTipoEvento = p.Evento.IdTipoEvento,
                    IdInstituicao = p.Evento.IdInstituicao
                },
                Usuario = new()
                {
                    IdUsuario = p.Usuario!.IdUsuario,
                    Nome = p.Usuario.Nome,
                    Email = p.Usuario.Email,
                }
            }).ToList();

            if (presencaEventos != null)
            {
                return presencaEventos;
            }
            return null!;
        }
    }
}