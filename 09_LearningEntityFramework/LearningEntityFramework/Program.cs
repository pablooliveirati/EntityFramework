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
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Cadé", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas"};
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 5.00, Unidade = "Gramas"};




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

    }



}




