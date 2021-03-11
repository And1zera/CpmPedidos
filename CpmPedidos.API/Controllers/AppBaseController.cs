using Microsoft.AspNetCore.Mvc;
using System;

namespace CpmPedidos.API.Controllers
{
    public class AppBaseController : ControllerBase // -> Aqui ele extende o ControllerBase
    {
        // Propriedade de IServiceProvider para fazer a injeção de dependencia
        protected readonly IServiceProvider _serviceProvider;

        // Construtor da classe passando o IServiceProvider como injeção de dependencia
        public AppBaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
