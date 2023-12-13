using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly Event_Context _context;

        // Construtor
        public ComentariosEventoRepository()
        {
            _context = new Event_Context();
        }

        // Métodos
        // GET (id) - id do comentario
        public ComentariosEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdComentarioEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET (id) - id do usuário
        public ComentariosEvento BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdEvento == idEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST
        public void Cadastrar(ComentariosEvento comentarioEvento)
        {
            try
            {
                _context.ComentariosEvento.Add(comentarioEvento);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE
        public void Deletar(Guid id)
        {
            try
            {
                ComentariosEvento comentarioEventoBuscado = _context.ComentariosEvento.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentariosEvento.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET - lista
        public List<ComentariosEvento> Listar(Guid id)
        {

            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET - lista
        public List<ComentariosEvento> ListarSomenteExibe(Guid id)
        {

            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.Exibe && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}