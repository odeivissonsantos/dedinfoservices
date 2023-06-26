using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.DTOs.Venda
{
    public class ItensCarrinhoVendaDTO
    {
        public string NomeProduto { get; set; }
        public string ValorUnitarioProduto { get; set; }
        public string PercentualDesconto { get; set; }
        public string ValorUnitarioDesconto { get; set; }
        public string ValorFinalPosDesconto { get; set; }
        public string StatusItem { get; set; }
    }
}
