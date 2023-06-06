using DedInfoservices.Filters.Sessao;
using DedInfoservices.Filters.Usuario;
using DedInfoservices.Models;
using DedInfoservices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Controllers
{
    [PaginaParaUsuarioLogado]
    [PaginaRestritaSomenteAdmin]
    public class HomeController : BaseController
    {
        private readonly UsuarioService _usuarioService;

        public HomeController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AlterarSenha(AlterarSenhaFilter filter)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if(string.IsNullOrEmpty(filter.SenhaAtual)) throw new Exception("Campo Senha Atual é obrigatório.");
                if (string.IsNullOrEmpty(filter.NovaSenha)) throw new Exception("Campo Nova Senha é obrigatório.");
                if (string.IsNullOrEmpty(filter.ConfirmarSenha)) throw new Exception("Campo Confirmação de Nova Senha é obrigatório.");
                if (filter.NovaSenha != filter.ConfirmarSenha) throw new Exception("Nova senha é diferente da senha de confirmação.");

                filter.Guuid = CurrentUser.Guuid;

                _usuarioService.AlterarSenha(filter);

                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

    }
}
