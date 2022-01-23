using Microsoft.EntityFrameworkCore;
using StreamsManage.Models;

namespace StreamsManage.Context
{
    public class BD:DbContext
    {
       
        // aqui seta o tipo de banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\\mssqllocaldb;Database=StreamManage;Trusted_Connection=True;");
        }


        // adiciona tabela ao banco de dados, a partir do modelo criado
        public DbSet<UserModel> Users { get; set; }
        public DbSet<LinkModel> Links { get; set; }
    }
}
