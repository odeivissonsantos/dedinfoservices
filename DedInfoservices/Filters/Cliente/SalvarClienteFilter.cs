using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Filters.Cliente
{
    public class SalvarClienteFilter
    {
        public string Guuid { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        public bool Is_Whatsapp { get; set; }

    }
}
