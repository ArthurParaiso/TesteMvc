using Microsoft.EntityFrameworkCore;
using TesteMvcArthur.Models;

namespace TesteMvcArthur.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        public DbSet<FilhosModel> Filhos { get; set; }
        public DbSet<FuncionariosModel> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FilhosModel>();
            builder.Entity<FuncionariosModel>();
        }
    }
}
