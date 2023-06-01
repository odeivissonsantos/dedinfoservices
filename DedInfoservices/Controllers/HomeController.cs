using DedInfoservices.Models;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sair()
        {
            string error = "";
            bool is_action = false;

            try
            {
                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

        [HttpPost]
        public IActionResult AlterarSenha(string SenhaAtual, string NovaSenha, string ConfirmarSenha)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (NovaSenha != ConfirmarSenha) throw new Exception("Nova senha é diferente da senha de confirmação.");
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
