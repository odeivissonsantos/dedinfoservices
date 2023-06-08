using DedInfoservices.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Column("ide_cliente")]
        public long Ide_Cliente { get; set; }

        [Column("guuid")]
        public string Guuid { get; set; } = new Guid().ToString();

        [Column("nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public long Telefone { get; set; }

        [Column("is_whatsapp")]
        public bool Is_Whatsapp { get; set; }

        [Column("dtc_inclusao")]
        public DateTime Dtc_Inclusao { get; set; } = DateTime.Now;

        [Column("sts_exclusao")]
        public bool Sts_Exclusao { get; set; } = false;

        [Column("ide_perfil")]
        public PerfilEnum Perfil { get; set; }
    }
}
