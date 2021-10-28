using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            //SaveUsingEntity();
            //GetProdutosWithEntity();
            //DeleteProdutoWithEntity();
            //UpdadteProdutosWithEntity();

        }

        private static void UpdadteProdutosWithEntity()
        {
            using (var repo = new ProdutoDAOWithEntity())
            {
                Produto firstProduct = repo.Produtos().First();
                firstProduct.Nome = "Xiaomi Poco F2 Pró Editado";
                repo.Update(firstProduct);
               

            }
        }

        private static void DeleteProdutoWithEntity()
        {
            using (var repo = new ProdutoDAOWithEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine($"Foram encontrados e removido {produtos.Count()} produtos(s)");
                foreach (var item in produtos)
                {
                    repo.Delete(item);

                }
            }
        }

        private static void GetProdutosWithEntity()
        {
            using (var repo = new ProdutoDAOWithEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                foreach (var item in produtos)
                {
                    Console.WriteLine($"{item.Nome}");
                }
            }
        }

        private static void SaveUsingEntity()
        {
            Produto p = new Produto();
            p.Nome = "Xiaomi Poco F2 Pró";
            p.Categoria = "Eletrônico";
            p.Preco = 4000;

            using (var contexto = new ProdutoDAOWithEntity())
            {
                contexto.Add(p);
                
            };
        }

    }
}
