using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DedInfoservices.Models
{
    [Table("perfil")]
    public class Perfil
    {
        [Key]
        [Column("ide_perfil")]
        public int Ide_Perfil { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("sts_exclusao")]
        public bool Sts_Exclusao { get; set; }
    }
}
