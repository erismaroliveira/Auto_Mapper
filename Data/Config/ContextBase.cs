using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Config
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<ItemTarefa> ItemTarefa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnect());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetStringConnect()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbTarefas2022;Integrated Security=True";
        }
    }
}
