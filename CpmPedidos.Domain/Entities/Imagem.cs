using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class Imagem : Base
    {
        public string Nome { get; set; }
        public string NomeDoArquivo { get; set; }
        public bool Principal { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}
