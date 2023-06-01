using DedInfoservices.Filters.Usuario;
using DedInfoservices.Services;
using DedInfoservices.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly Email _email;

        public UsuarioController(UsuarioService usuarioService, Email email)
        {
            _usuarioService = usuarioService;
            _email = email;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalvarUsuario(SalvarUsuarioFilter filter)
        {
            string error = "";
            bool is_action = false;
            string senhaNaoEncriptada = Guid.NewGuid().ToString().Substring(0, 8);
            string senhaEncriptada = Hash.SHA512(senhaNaoEncriptada);

            string assunto = "Senha de acesso ao sistema";
            string mensagem = $"<strong>Olá,</strong><br>" +
                                $"<br>" +
                                $"Seja bem vindo ao sistema de gerenciamento DeD InfoServices.<br>" +
                                $"<br>" +
                                $"Sua senha de acesso é: {senhaNaoEncriptada}<br>" +
                                $"<br>" +
                                $"<p>Obrigado!";

            try
            {
                filter.Guuid = Guid.NewGuid().ToString();
                filter.Senha = senhaEncriptada;
                _usuarioService.SalvarUsuario(filter);

                if (string.IsNullOrEmpty(filter.Email)) throw new Exception("Campo Email é obrigatório.");
                if (string.IsNullOrEmpty(filter.Nome)) throw new Exception("Campo Nome é obrigatório.");
                if (string.IsNullOrEmpty(filter.Sobrenome)) throw new Exception("Campo Sobrenome é obrigatório.");
                if (filter.Perfil.GetHashCode() < 1) throw new Exception("Campo Perfil é obrigatório.");

                bool retornoEmail = _email.EnviarEmail(filter.Email, assunto, mensagem);
                if (!retornoEmail) throw new Exception("Não conseguimos enviar o email com a senha, Por favor, tente mais tarde.");

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
