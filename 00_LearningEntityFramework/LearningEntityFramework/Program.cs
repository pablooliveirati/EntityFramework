using System;

namespace LearningEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            SaveUsingEntity();
        }

        private static void SaveUsingEntity()
        {
            Produto p = new Produto();
            p.Nome = "Xiami Poco F2 Pró";
            p.Categoria = "Eletrônico";
            p.Preco = 4000;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            };
        }
    }
}
