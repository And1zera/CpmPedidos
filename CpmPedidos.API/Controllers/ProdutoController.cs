using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CpmPedidos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : AppBaseController // -> Estou extendendo do AppBaseController para a injeção de dependencia
    {
        // Construtor da classe PedidoController passando o serviceProvider para o pai AppBaseController pelo base
        public ProdutoController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return rep.Get();
        }

        [HttpGet]
        [Route("search/{text}/{pagina?}")]
        public IEnumerable<Produto> GetSearch(string text, int pagina = 1)
        {
            var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return rep.Search(text, pagina);
        }

        [HttpGet]
        [Route("{id}")]
        public Produto Detail(int? id)
        {
            if (id != null)
            {
                var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
                return rep.Detail(id.Value);
            }
            else
            {
                return null;
            }
        }
    }
}
