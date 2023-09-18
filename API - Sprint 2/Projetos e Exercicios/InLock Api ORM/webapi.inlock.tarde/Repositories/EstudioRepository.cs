using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext context = new();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = context.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }
            // Sem o Update funciona, por que: ele salvou as alterações feitas no objeto buscado

            context.Estudios.Update(estudioBuscado!);

            context.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return context.Estudios.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(Estudio estudio)
        {
            context.Estudios.Add(estudio);
            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            context.Estudios.Where(e => e.IdEstudio == id).ExecuteDelete();

            Estudio estudioBuscado = context.Estudios.Find(id)!;

            if (estudioBuscado != null)
                context.Estudios.Remove(estudioBuscado);

            context.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return context.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return context.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
