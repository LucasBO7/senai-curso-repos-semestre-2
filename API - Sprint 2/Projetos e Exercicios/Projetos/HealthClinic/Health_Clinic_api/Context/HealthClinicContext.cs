using Health_Clinic_api.Domains;
using Microsoft.EntityFrameworkCore;

namespace Health_Clinic_api.Context
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Especializacao> Especializacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Consulta> Consulta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = NOTE14-S15; initial catalog = health_clinic_api; User Id=sa; Pwd=Senai@134; TrustServerCertificate = true;", x => x.UseDateOnlyTimeOnly());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
