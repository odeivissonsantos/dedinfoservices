using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Models
{
    [Table("produto_entrada")]
    public class ProdutoEntrada
    {
        [Key]
        [Column("ide_produto_entrada")]
        public long Ide_Produto_Entrada { get; set; }

        [Column("guuid_produto")]
        public string Guuid_Produto { get; set; }

        [Column("guuid_usuario_inclusao")]
        public string Guuid_Usuario_Inclusao { get; set; }

        [Column("preco_compra")]
        public decimal Preco_Compra { get; set; }

        [Column("quantidade")]
        public long Quantidade { get; set; }

        [Column("dtc_inclusao")]
        public DateTime Dtc_Inclusao { get; set; } = DateTime.Now;

        [Column("dtc_compra")]
        public DateTime Dtc_Compra { get; set; }

        [Column("dtc_recebimento")]
        public DateTime Dtc_Recebimento { get; set; }

    }
}
