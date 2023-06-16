using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Filters.Venda
{
    public class AdicionarProdutoFilter
    {
        public string Guuid_Carrinho { get; set; }
        public string Guuid_Cliente { get; set; }
        public string Guuid_Produto { get; set; }
        public int Desconto { get; set; }
    }
}
