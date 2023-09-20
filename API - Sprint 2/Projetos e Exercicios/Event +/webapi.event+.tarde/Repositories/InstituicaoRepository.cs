using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public List<Instituicao> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Instituicao> BuscarTodos()
        {
            List<Instituicao> listaInstituicoes = _eventContext.Instituicao.ToList();

            // Se houver alguma Insituicao salva
            if (listaInstituicoes.Count > 0)
            {
                return listaInstituicoes;
            }
            return null!;
        }

        public void Cadastrar(Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
