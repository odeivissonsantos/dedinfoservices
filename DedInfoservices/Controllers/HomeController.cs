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
    public class HomeController : Controller
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
                if (filter.NovaSenha != filter.ConfirmarSenha) throw new Exception("Nova senha é diferente da senha de confirmação.");

                
                //if (usuario.Senha == Hash.SHA512(SenhaAtual))
                //{
                //    if (NovaSenha == ConfirmarSenha)
                //    {
                //        NovaSenha = Hash.SHA512(NovaSenha);

                //        usuario.Senha = NovaSenha;
                //        _contatoRepositorio.Atualizar(usuario);
                //        return Ok(new Response<string>("", "Senha alterada com sucesso!", true));
                //    }
                //    else
                //    {
                //        return BadRequest(new Response<string>("", "Nova senha e confirmar nova senha estão diferentes,favor verificar!", false));
                //    }
                //}
                //else
                //{
                //    return BadRequest(new Response<string>("", "Senha atual invalida, tente novamente!", false));
                //}
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

    }
}
