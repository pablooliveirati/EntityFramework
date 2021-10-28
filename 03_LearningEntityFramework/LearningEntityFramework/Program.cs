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
                foreach (var p in produtos)
                {
                    //listando todos os produtos
                    Console.WriteLine(p);
                }

                Console.WriteLine("============");

                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    //listando status do monitoramento
                    Console.WriteLine(e);
                }

                //Alterando último produto da lista.
                var p1 = produtos.Last();
                p1.Nome = "Iphone 6";

                Console.WriteLine("============");
                // ChangeTracker o status de todas as entidades que sofreram alteração no contexto.
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e);

                    contexto.SaveChanges();
                }

            }
                GetProdutosWithEntity();

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
                    Console.WriteLine($"Produto: {item.Nome}");
                }
            }
        }

        private static void SaveUsingEntity()
        {
            Produto p = new Produto();
            p.Nome = "Iphone 10";
            p.Categoria = "Eletrônico";
            p.Preco = 3000;

            using (var contexto = new ProdutoDAOWithEntity())
            {
                contexto.Add(p);

            };
        }

    }
}
