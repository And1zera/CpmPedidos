using CpmPedidos.Domain;
using System.Collections.Generic;

namespace CpmPedidos.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> Get();
        List<Produto> Search(string text, int pagina);
        Produto Detail(int id);

    }
}
