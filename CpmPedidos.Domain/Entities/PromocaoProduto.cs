namespace CpmPedidos.Domain
{
    public class PromocaoProduto : BaseExibivel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public int IdImagem { get; set; }
        public virtual Imagem Imagem { get; set; }

        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
