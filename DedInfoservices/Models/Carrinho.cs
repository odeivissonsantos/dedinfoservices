using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Models
{
    [Table("carrinho")]
    public class Carrinho
    {
        [Key]
        [Column("ide_carrinho")]
        public long Ide_Carrinho { get; set; }

        [Column("guuid_carrinho")]
        public string Guuid_Carrinho { get; set; }

        [Column("guuid_cliente")]
        public string Guuid_Cliente { get; set; }

        [Column("guuid_produto")]
        public string Guuid_Produto { get; set; }

        [Column("produto_valor_unitario")]
        public decimal? Produto_Valor_Unitario { get; set; }

        [Column("desconto")]
        public int? Desconto { get; set; }

        [Column("valor_final")]
        public decimal Valor_Final { get; set; }

        [Column("sts_exclusao_carrinho")]
        public bool Sts_Exclusao_Carrinho { get; set; } = false;

        [Column("sts_exclusao_produto")]
        public bool Sts_Exclusao_Produto { get; set; } = false;

        [Column("dtc_inclusao")]
        public DateTime Dtc_Inclusao { get; set; } = DateTime.Now;

        [Column("sts_conclusao_carrinho")]
        public bool Sts_Conclusao_Carrinho { get; set; } = false;
    }
}
