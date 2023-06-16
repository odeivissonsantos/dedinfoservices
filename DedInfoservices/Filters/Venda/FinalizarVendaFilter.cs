using DedInfoservices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Filters.Venda
{
    public class FinalizarVendaFilter
    {
        public string Guuid_Carrinho { get; set; }
        public string Guuid_Cliente { get; set; }
        public string Guuid_Usuario_Inclusao { get; set; }
        public TipoPagamentoEnum Tipo_Pagamento { get; set; }

    }
}
