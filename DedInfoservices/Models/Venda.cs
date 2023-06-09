using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Models
{
    [Table("venda")]
    public class Venda
    {
        [Key]
        [Column("ide_venda")]
        public long Ide_Venda { get; set; }

        [Column("guuid_venda")]
        public string Guuid_Venda { get; set; } = new Guid().ToString();

        [Column("guuid_carrinho")]
        public string Guuid_Carrinho { get; set; }

        [Column("guuid_cliente")]
        public string Guuid_Cliente { get; set; }

        [Column("guuid_usuario_inclusao")]
        public string Guuid_Usuario_Inclusao { get; set; }

        [Column("valor_total")]
        public decimal Valor_Total { get; set; }

        [Column("qtd_itens")]
        public int Qtd_Itens { get; set; }

        [Column("tipo_pagamento")]
        public int Tipo_Pagamento { get; set; }

        [Column("dtc_inclusao")]
        public DateTime Dtc_Inclusao { get; set; } = DateTime.Now;

        [Column("sts_exclusao")]
        public bool Sts_Exclusao { get; set; } = false;

        [Column("sts_venda")]
        public bool Sts_Venda { get; set; }
    }
}
