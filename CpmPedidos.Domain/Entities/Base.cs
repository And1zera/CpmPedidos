using System;

namespace CpmPedidos.Domain
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Create()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
