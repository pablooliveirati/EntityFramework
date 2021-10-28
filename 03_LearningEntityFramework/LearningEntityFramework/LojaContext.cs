using Microsoft.EntityFrameworkCore;
using System;
using static LearningEntityFramework.Program;

namespace LearningEntityFramework
{
    //Criando contexto (Nome do modelo de negócio + sufixo Context) = LojaContext.
    public class LojaContext : DbContext
    {
        //Informando quais classes serão persistidas, no nosso exemplo é Produto. 
        //Informando o nome da tabela do banco de dados, no nosso exemplo é Produtos.
        public DbSet<Produto> Produtos { get; set; }

        //Definindo o banco de dados que será utilizado e o local. Para isso é precisso sobescrever
        // o método da classe DbContext.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}