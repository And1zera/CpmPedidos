﻿using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class Cliente : BaseExibivel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual List<Pedido> Pedidos { get; set; }
    }
}