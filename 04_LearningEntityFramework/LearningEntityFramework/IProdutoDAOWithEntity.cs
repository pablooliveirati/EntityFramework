using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFramework
{
     interface IProdutoDAOWithEntity
    {
        void Add(Produto p);
        void Update(Produto p);
        void Delete(Produto p);
        IList<Produto> Produtos();

    }
}
