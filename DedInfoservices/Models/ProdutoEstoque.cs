using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Models
{
    [Table("produto_estoque")]
    public class ProdutoEstoque
    {
        [Key]
        [Column("ide_produto_estoque")]
        public long Ide_Produto_Estoque { get; set; }

        [Column("guuid_produto")]
        public string Guuid_Produto { get; set; }

        [Column("quantidade")]
        public long Quantidade { get; set; }

        [Column("dtc_atualizacao")]
        public DateTime Dtc_Atualizacao { get; set; }
    }
}
