using DedInfoservices.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.DTOs.Venda
{
    public class VendaDTO
    {
        public string Guuid_Venda { get; set; }
        public string Nome_Cliente { get; set; }

        public string Nome_Usuario_Inclusao { get; set; }

        public decimal Valor_Total { get; set; }

        public int Qtd_Itens { get; set; }

        public TipoPagamentoEnum Tipo_Pagamento { get; set; }

        public DateTime Dtc_Inclusao { get; set; }
        public bool Sts_Exclusao { get; set; } = false;

        public bool Sts_Venda { get; set; } = true;
    }
}
