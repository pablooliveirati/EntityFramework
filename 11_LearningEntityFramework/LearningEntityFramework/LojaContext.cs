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
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocaos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        //Método subscrito para criar chaves compostas nas classes insridas nesse contexto.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<PromocaoProduto>()
                 .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });
            base.OnModelCreating(modelBuilder);

            //Nomeando a tabela no banco de dados para Enderecos.
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            //Criando a propriedade ClienteID no banco daddados
            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            //Definindo chave primária ClienteID no banco de dados.
            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");

        }

        //Definindo o banco de dados que será utilizado e o local. Para isso é precisso sobescrever
        // o método da classe DbContext.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}