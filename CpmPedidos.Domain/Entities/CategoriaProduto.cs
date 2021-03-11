using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class CategoriaProduto : BaseExibivel
    {
        public string Nome { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}
