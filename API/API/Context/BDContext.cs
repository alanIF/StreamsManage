using Microsoft.EntityFrameworkCore;
using StreamsManage.Models;

namespace API.Context
{
    public class BDContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=streambd;Trusted_Connection=True;";

        // aqui seta o tipo de banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


        // adiciona tabela ao banco de dados, a partir do modelo criado
        public DbSet<UserModel> Users { get; set; }
        public DbSet<LinkModel> Links { get; set; }
        public DbSet<StreamerModel> Streamers { get; set; }
    }
}
