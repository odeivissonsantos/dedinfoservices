using DedInfoservices.Context;
using DedInfoservices.Filters.Login;
using DedInfoservices.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(LoginFilter filter)
        {
            string error = "";
            bool is_action = false;

            try
            {
                var query = _context.Usuario.Where(x => x.Email == filter.Email).FirstOrDefault();

                if (query == null) throw new Exception("Email/Senha inválido. Por favor, tente novamente.");
                if (query.Sts_Exclusao) throw new Exception("Usuário não tem mais acesso ao sistema");

                string senhaEncryptada = Hash.SHA512(filter.Senha);

                if(senhaEncryptada != query.Senha) throw new Exception("Email/Senha inválido. Por favor, tente novamente.");

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
