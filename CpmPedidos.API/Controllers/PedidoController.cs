using Microsoft.AspNetCore.Mvc;
using System;

namespace CpmPedidos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : AppBaseController // -> Estou extendendo do AppBaseController para a injeção de dependencia
    {
        // Construtor da classe PedidoController passando o serviceProvider para o pai AppBaseController pelo base
        public PedidoController (IServiceProvider serviceProvider) : base(serviceProvider) { }

    }
}
