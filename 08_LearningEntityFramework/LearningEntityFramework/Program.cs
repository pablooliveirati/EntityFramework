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
            ListarProdutos();
            ExcluirProdutosPorId(2002);
            Console.WriteLine("=============");
            ListarProdutos();

        }

        private static void ListarProdutos()
        {
        using (var repo = new ProdutoDAOWithEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                foreach (var item in produtos)
                {
                    Console.WriteLine($"{item}");
                }
            }

        }

        private static void ExcluirProdutosPorId(int id)
        {
            using (var e = new ProdutoDAOWithEntity())
            {
                IList<Produto> produtos = e.Produtos();
                var excluir = id;
                foreach (var item in produtos)
                {
                    if (item.Id == id)
                    {
                        e.Delete(item);
                    }
                }
            }

        }

    }

}


