using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        [Column("ide_produto")]
        public long Ide_Produto { get; set; }

        [Column("guuid")]
        public string Guuid { get; set; } = new Guid().ToString();

        [Column("nome")]
        public string Nome { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("codigo_interno")]
        public long Codigo_Interno { get; set; }

        [Column("codigo_barras")]
        public long? Codigo_Barras { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("dtc_inclusao")]
        public DateTime Dtc_Inclusao { get; set; } = DateTime.Now;

        [Column("sts_exclusao")]
        public bool Sts_Exclusao { get; set; } = false;


    }
}
