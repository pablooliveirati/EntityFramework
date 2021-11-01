using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LearningEntityFramework
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            

        }

        private static void UmParaMuitos()
        {
            using (var contexto = new LojaContext())
            {
                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");

                var produto = contexto
                    .Produtos
                    .Include(p => p.Compras)
                    .Where(p => p.Id == 3018)
                    .FirstOrDefault();

                Console.WriteLine($"Mostrando as compras do produto {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }

            }
        }

        private static void UmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos menores",
                Complemento = "Casa",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Cadé", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 5.00, Unidade = "Gramas" };


            //Relacionamento N:N entre as classes Promocão e Produto.  
            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataFim = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);


            using (var contexto = new LojaContext())
            {
                contexto.Promocaos.Add(promocaoDePascoa);
                contexto.SaveChanges();

            }
        }

        private static void ExibeProdutoDaPromocao()
        {
            using (var contexto2 = new LojaContext())
            {
                var promocao = contexto2
                    .Promocaos
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                Console.WriteLine("\nMostrando os produtos da Promoção....");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro 2021";
                promocao.DataInicio = new DateTime(2021, 12, 1);
                promocao.DataFim = new DateTime(2021, 12, 31);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "bebidas")
                    .ToList();

                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocaos.Add(promocao);

                contexto.SaveChanges();
            }
        }


    }



}




