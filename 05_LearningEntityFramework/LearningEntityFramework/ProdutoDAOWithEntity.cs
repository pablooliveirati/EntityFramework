using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFramework
{
    public class ProdutoDAOWithEntity : IProdutoDAOWithEntity, IDisposable
    {
        private LojaContext Contexto;

        public ProdutoDAOWithEntity()
        {
            this.Contexto = new LojaContext();
        }

        public void Add(Produto p)
        {
            Contexto.Produtos.Add(p);
            Contexto.SaveChanges();
        }

        public void Delete(Produto p)
        {
            Contexto.Remove(p);
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return Contexto.Produtos.ToList();
        }

        public void Update(Produto p)
        {
            Contexto.Update(p);
            Contexto.SaveChanges();
        }
    }
}