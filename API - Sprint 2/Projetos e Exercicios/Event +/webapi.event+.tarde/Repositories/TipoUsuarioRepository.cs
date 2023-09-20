using Microsoft.AspNetCore.Authorization;
using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        [Authorize("Administrador")]
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        [Authorize("Administrador")]
        public TipoUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TipoUsuario.FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        [Authorize("Administrador")]
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deleta um tipoUsuario do banco de dados por meio de um id especificado
        /// </summary>
        /// <param name="id">Id inserido</param>
        [Authorize("Administrador")]
        public void Deletar(Guid id)
        {
            try
            {
                // Busca tipoUsuario do banco por Id Guid
                TipoUsuario tipoUsuarioBuscado = _eventContext.TipoUsuario.FirstOrDefault(u => u.IdTipoUsuario == id)!;

                // Verifica se o tipoUsuario foi encontrado. Se sim, removerá o tipoUsuario
                if (tipoUsuarioBuscado != null)
                {
                    _eventContext.Remove(tipoUsuarioBuscado);
                }
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Authorize("Administrador")]
        /// <summary>
        /// Lista todos os TipoUsuario do banco de dados
        /// </summary>
        /// <returns>Lista de objetos TipoUsuario</returns>
        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> listaTiposUsuario = _eventContext.TipoUsuario.ToList();

                if (listaTiposUsuario != null)
                {
                    return listaTiposUsuario;
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
