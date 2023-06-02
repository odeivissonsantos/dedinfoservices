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
        private readonly Email _email;

        public LoginController(DataContext context, Email email)
        {
            _context = context;
            _email = email;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RecuperacaoDeSenha()
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

                query.Qtd_Acessos++;
                query.Dtc_Ultimo_Acesso = DateTime.Now;

                _context.Usuario.Update(query);
                _context.SaveChanges();
                is_action = true;

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

        [HttpPost]
        public IActionResult EsqueceuSenha(string email)
        {
            string error = "";
            bool is_action = false;
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            string novaSenhacriptografada = Hash.SHA512(novaSenha);

            string assunto = "Recuperação de senha";
            string mensagem = $"<strong>Olá,</strong><br>" +
                                $"<br>" +
                                $"A senha associada ao nosso sistema foi alterada.<br>" +
                                $"<br>" +
                                $"Sua nova senha é: {novaSenha}<br>" +
                                $"<br>" +
                                $"<p>Obrigado!";

            try
            {
                var query = _context.Usuario.Where(x => x.Email == email).FirstOrDefault();

                if (query == null) throw new Exception("Email inválido. Por favor, tente novamente.");
                if (query.Sts_Exclusao) throw new Exception("Usuário não tem mais acesso ao sistema");

                bool result = _email.EnviarEmail(email, assunto, mensagem);
                if (!result) throw new Exception("Não conseguimos enviar o email com a nova senha, Por favor, tente mais tarde.");

                query.Senha = novaSenhacriptografada;
                _context.Usuario.Update(query);
                _context.SaveChanges();

                is_action = true;

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
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



    }
}
