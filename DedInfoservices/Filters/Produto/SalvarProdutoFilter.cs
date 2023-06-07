using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Filters.Produto
{
    public class SalvarProdutoFilter
    {
        public string Guuid { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public long? Codigo_Barras { get; set; }
        public string Descricao { get; set; }
    }
}
