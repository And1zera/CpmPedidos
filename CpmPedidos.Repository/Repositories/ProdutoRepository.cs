using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CpmPedidos.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public List<Produto> Get()
        {
            return _dbContext.Produtos
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<Produto> Search(string text, int pagina)
        {
            return _dbContext.Produtos
                .Include(x => x.Categoria)
                .Where( x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper())) || (x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(tamanhoPagina * (pagina - 1))
                .Take(tamanhoPagina)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public Produto Detail(int id)
        {
            return _dbContext.Produtos
                .Include(x => x.Categoria)
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .FirstOrDefault();
        }
    }
}
