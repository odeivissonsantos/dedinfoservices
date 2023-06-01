using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Filters.Usuario
{
    public class AlterarSenhaFilter
    {
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmarSenha { get; set; }

    }
}
