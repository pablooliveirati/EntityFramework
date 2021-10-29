using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (var contexto = new LojaContext())
            {
                var produtos = contexto.Produtos.ToList();

                ExibeEntries(contexto.ChangeTracker.Entries());

                var removep1 = produtos.First();
                contexto.Produtos.Remove(removep1);

                ExibeEntries(contexto.ChangeTracker.Entries());

                //Mais uma forma de exibir o estado.
                //foreach (var item in contexto.ChangeTracker.Entries())
                //{
                //    Console.WriteLine(item.State);
                //}

                contexto.SaveChanges();

                ExibeEntries(contexto.ChangeTracker.Entries());
            }

        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("==============");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }

        private static void GetProdutosWithEntity()
        {
            using (var repo = new ProdutoDAOWithEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                foreach (var item in produtos)
                {
                    Console.WriteLine($"Produto: {item.Nome}");
                }
            }
        }
    }
}

