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

        /// <summary>
        /// Atualiza uma Instituicao por id do banco
        /// </summary>
        /// <param name="id">Id da Instituicao</param>
        /// <param name="instituicao">Objeto do tipo Instituicao</param>
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.CNPJ = instituicao.CNPJ;
                instituicaoBuscada.Endereco = instituicao.Endereco;
                instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;

                _eventContext.Instituicao.Update(instituicaoBuscada); _eventContext.SaveChanges();
            }
        }

        /// <summary>
        /// Busca uma Instituicao por id do banco
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Objeto do tipo Insituicao</returns>
        public Instituicao BuscarPorId(Guid id)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

            if (instituicaoBuscada != null)
            {
                return instituicaoBuscada;
            }
            return null!;
        }

        /// <summary>
        /// Busca todas as Instituicoes salvas
        /// </summary>
        /// <returns>Lista de Objetos tipo Instituicao</returns>
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

        /// <summary>
        /// Cadastra uma nova Instituicao no banco de dados
        /// </summary>
        /// <param name="instituicao">Objeto do tipo Instituicao</param>
        public void Cadastrar(Instituicao instituicao)
        {
            if (instituicao != null)
            {
                _eventContext.Instituicao.Add(instituicao); _eventContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta uma Instituicao por id no banco de dados
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(Guid id)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.FirstOrDefault(i => i.IdInstituicao == id)!;

            if (instituicaoBuscada != null)
            {
                _eventContext.Remove(instituicaoBuscada); _eventContext.SaveChanges();
            }
        }
    }
}
