using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEvento
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            if (comentarioEvento != null)
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);
                _eventContext.SaveChanges();
            }
        }

        public ComentarioEvento Deletar(Guid id)
        {
            ComentarioEvento comentarioEventoBuscado = _eventContext.ComentarioEvento.FirstOrDefault(e => e.IdComentarioEvento == id)!;

            if (comentarioEventoBuscado != null)
            {
                _eventContext.ComentarioEvento.Remove(comentarioEventoBuscado);
                _eventContext.SaveChanges();
                return comentarioEventoBuscado;
            }
            return null!;
        }

        public ComentarioEvento Atualizar(Guid id, ComentarioEvento comentarioEvento)
        {
            ComentarioEvento comentarioEventoBuscado = _eventContext.ComentarioEvento.FirstOrDefault(c => c.IdComentarioEvento == id)!;

            if (comentarioEventoBuscado != null)
            {
                comentarioEventoBuscado = new()
                {
                    IdComentarioEvento = id,
                    Descricao = comentarioEvento.Descricao,
                    Exibe = comentarioEvento.Exibe,
                    IdEvento = comentarioEvento.IdEvento,
                    IdUsuario = comentarioEvento.IdUsuario,
                    Evento = new()
                    {
                        IdTipoEvento = comentarioEvento.Evento.IdTipoEvento,
                        IdInstituicao = comentarioEvento.Evento.IdInstituicao,
                        DataEvento = comentarioEvento.Evento.DataEvento,
                        NomeEvento = comentarioEvento.Evento.NomeEvento,
                        Descricao = comentarioEvento.Evento.Descricao
                    },
                    Usuario = new()
                    {
                        IdUsuario = comentarioEvento.Usuario.IdUsuario,
                        Nome = comentarioEvento.Usuario.Nome,
                        Email = comentarioEvento.Usuario.Email,
                        IdTipoUsuario = comentarioEvento.Usuario.IdTipoUsuario,
                        TipoUsuario = new()
                        {
                            IdTipoUsuario = comentarioEvento.Usuario.IdTipoUsuario,
                            Titulo = comentarioEvento.Usuario.TipoUsuario.Titulo
                        }
                    }
                };
                _eventContext.ComentarioEvento.Update(comentarioEventoBuscado);
                _eventContext.SaveChanges();
                return comentarioEventoBuscado;
            }
            return null!;
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            return _eventContext.ComentarioEvento.Select(comentarioEvento => new ComentarioEvento()
            {
                IdComentarioEvento = id,
                Descricao = comentarioEvento.Descricao,
                Exibe = comentarioEvento.Exibe,
                IdEvento = comentarioEvento.IdEvento,
                IdUsuario = comentarioEvento.IdUsuario,
                Evento = new()
                {
                    IdTipoEvento = comentarioEvento.Evento.IdTipoEvento,
                    IdInstituicao = comentarioEvento.Evento.IdInstituicao,
                    DataEvento = comentarioEvento.Evento.DataEvento,
                    NomeEvento = comentarioEvento.Evento.NomeEvento,
                    Descricao = comentarioEvento.Evento.Descricao
                },
                Usuario = new()
                {
                    IdUsuario = comentarioEvento.Usuario.IdUsuario,
                    Nome = comentarioEvento.Usuario.Nome,
                    Email = comentarioEvento.Usuario.Email,
                    IdTipoUsuario = comentarioEvento.Usuario.IdTipoUsuario,
                    TipoUsuario = new()
                    {
                        IdTipoUsuario = comentarioEvento.Usuario.IdTipoUsuario,
                        Titulo = comentarioEvento.Usuario.TipoUsuario.Titulo
                    }
                }
            }).FirstOrDefault(e => e.IdComentarioEvento == id)!;
        }

        public List<ComentarioEvento> BuscarTodos()
        {
            List<ComentarioEvento> listaComentariosEventos = _eventContext.ComentarioEvento.Select(comentarioEvento => new ComentarioEvento
            {
                IdComentarioEvento = comentarioEvento.IdComentarioEvento,
                Descricao = comentarioEvento.Descricao,
                Exibe = comentarioEvento.Exibe,
                IdEvento = comentarioEvento.IdEvento,
                IdUsuario = comentarioEvento.IdUsuario,
                Evento = new()
                {
                    IdTipoEvento = comentarioEvento.Evento.IdTipoEvento,
                    IdInstituicao = comentarioEvento.Evento.IdInstituicao,
                    DataEvento = comentarioEvento.Evento.DataEvento,
                    NomeEvento = comentarioEvento.Evento.NomeEvento,
                    Descricao = comentarioEvento.Evento.Descricao
                },
                Usuario = new()
                {
                    IdUsuario = comentarioEvento.Usuario.IdUsuario,
                    Nome = comentarioEvento.Usuario.Nome,
                    Email = comentarioEvento.Usuario.Email,
                    IdTipoUsuario = comentarioEvento.Usuario.IdTipoUsuario,
                    TipoUsuario = new()
                    {
                        IdTipoUsuario = comentarioEvento.Usuario.IdTipoUsuario,
                        Titulo = comentarioEvento.Usuario.TipoUsuario.Titulo
                    }
                }
            }).ToList();

            if (listaComentariosEventos != null)
                return listaComentariosEventos;
            return null!;
        }
    }
}