using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Filters.Produto
{
    public class EntradaProdutoFilter
    {
        public string Guuid_Produto { get; set; }
        public string Guuid_Usuario_Inclusao { get; set; }
        public decimal Preco_Compra { get; set; }
        public long Quantidade { get; set; }
        public DateTime Dtc_Compra { get; set; }
        public DateTime Dtc_Recebimento { get; set; }
    }
}
