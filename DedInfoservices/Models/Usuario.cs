using DedInfoservices.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DedInfoservices.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("ide_usuario")]
        public long Ide_Usuario { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [Column("guid")]
        public string Guid { get; set; } = new Guid().ToString();

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("dtc_inclusao")]
        public DateTime Dtc_Inclusao { get; set; } = DateTime.Now;

        [Column("sts_exclusao")]
        public bool Sts_Exclusao { get; set; } = false;

        [Column("qtd_acessos")]
        public long Qtd_Acessos { get; set; } = 0;

        [Column("dtc_ultimo_acesso")]
        public DateTime? Dtc_Ultimo_Acesso { get; set; }

        [Column("ide_perfil")]
        public PerfilEnum Ide_Perfil { get; set; }
    }
}
