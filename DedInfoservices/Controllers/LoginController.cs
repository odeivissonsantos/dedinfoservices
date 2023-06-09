﻿using DedInfoservices.Context;
using DedInfoservices.Filters.Login;
using DedInfoservices.Helpers;
using DedInfoservices.Models;
using DedInfoservices.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DedInfoservices.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        private readonly Email _email;
        private readonly SessionHelper _sessao;

        public LoginController(DataContext context, Email email, SessionHelper sessao)
        {
            _context = context;
            _email = email;
            _sessao = sessao;
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
            Usuario usuario = new();

            try
            {
                usuario = _context.Usuario.Where(x => x.Email == filter.Email).FirstOrDefault();

                if (usuario == null) throw new Exception("Email/Senha inválido. Por favor, tente novamente.");
                if (usuario.Sts_Exclusao) throw new Exception("Usuário não tem mais acesso ao sistema");

                string senhaEncryptada = Hash.SHA512(filter.Senha);

                if(senhaEncryptada != usuario.Senha) throw new Exception("Email/Senha inválido. Por favor, tente novamente.");

                var claims = new List<Claim>();
                claims.Add(new Claim("login", usuario.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Email));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(claimsPrincipal);

                _sessao.CreateCurrentUser(usuario);

                usuario.Qtd_Acessos++;
                usuario.Dtc_Ultimo_Acesso = DateTime.Now;

                _context.Usuario.Update(usuario);
                _context.SaveChanges();



                is_action = true;

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error, usuario });
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
                HttpContext.SignOutAsync();
                _sessao.KillCurrentUser();
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
