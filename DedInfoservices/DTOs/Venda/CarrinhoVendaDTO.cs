using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.DTOs.Venda
{
    public class CarrinhoVendaDTO
    {
        public string Cliente { get; set; }
        public string Pedido { get; set; }
        public string UsuarioInclusao { get; set; }
        public string DataVenda { get; set; }
        public string ValorTotal { get; set; }
        public string TipoPagamento { get; set; }
        public List<ItensCarrinhoVendaDTO> Itens { get; set; } = new();


    }
}
