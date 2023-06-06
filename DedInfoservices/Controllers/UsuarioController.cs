using DedInfoservices.Enums;
using DedInfoservices.Filters.Sessao;
using DedInfoservices.Filters.Usuario;
using DedInfoservices.Models;
using DedInfoservices.Services;
using DedInfoservices.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : BaseController
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

        public IActionResult UsuarioSalvar(string guuid)
        {
            Usuario usuario = new Usuario();
            if (!string.IsNullOrEmpty(guuid)) usuario =  _usuarioService.BuscarUsuario(2, guuid);
            if (usuario == null || usuario.Perfil <= 0) usuario = new Usuario();
            return View(usuario);
        }


        [HttpPost]
        public virtual IActionResult UsuariosPagination(string sEcho, int iDisplayStart, int iColumns, int iDisplayLength, string sSearch)
        {

            IEnumerable<Usuario> query = _usuarioService.ListarTodos();

            if (!string.IsNullOrEmpty(sSearch)) query = query.Where(x => x.Nome.ToLower()
                .Contains(SpecialCharacters.RemoveSpecialCharacters(sSearch).ToLower())).AsQueryable();

            int recordsTotal = query.Count();

            List<Usuario> aList = query.OrderBy(x => x.Nome).Skip(iDisplayStart).Take(iDisplayLength).ToList();

            var data = aList.Select(x => new
            {
                nome = $"{x.Nome} {x.Sobrenome}" ,
                perfil = DescriptionEnum.GetEnumDescription((PerfilEnum)x.Perfil),
                data_cadastro = x.Dtc_Inclusao.ToString("dd/MM/yyy HH:mm"),
                qtd_acessos = x.Qtd_Acessos,
                data_ultimo_acesso = x.Dtc_Ultimo_Acesso.HasValue ? x.Dtc_Ultimo_Acesso.Value.ToString("dd/MM/yyy HH:mm") : "",
                editar = $"<a href='{Url.Action("UsuarioSalvar", "Usuario")}?guuid={x.Guuid}' type='button' class='btn btn-warning'>Editar</a>",
                acao = x.Sts_Exclusao == true ? $"<a href='#' type='button' class='btn btn-primary' onclick='reativar(\"{x.Guuid}\")'>Ativar</a>" : $"<a href='#' type='button' class='btn btn-danger' onclick='desativar(\"{x.Guuid}\")'>Desativar</a>"
            }).ToArray();

            return Json(new
            {
                iDraw = 1,
                sEcho,
                iTotalRecords = recordsTotal,
                iTotalDisplayRecords = recordsTotal,
                aaData = data
            });

        }

        [HttpPost]
        public IActionResult SalvarUsuario(SalvarUsuarioFilter filter)
        {
            string error = "";
            bool is_action = false;
            bool retornoEmail = true;
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
                if (string.IsNullOrEmpty(filter.Email)) throw new Exception("Campo Email é obrigatório.");
                if (string.IsNullOrEmpty(filter.Nome)) throw new Exception("Campo Nome é obrigatório.");
                if (string.IsNullOrEmpty(filter.Sobrenome)) throw new Exception("Campo Sobrenome é obrigatório.");
                if (filter.Perfil.GetHashCode() < 1) throw new Exception("Campo Perfil é obrigatório.");

                if (string.IsNullOrEmpty(filter.Guuid)) filter.Senha = senhaEncriptada;

                _usuarioService.SalvarUsuario(filter);

                if (string.IsNullOrEmpty(filter.Guuid)) retornoEmail = _email.EnviarEmail(filter.Email, assunto, mensagem);
                if (!retornoEmail) throw new Exception("Não conseguimos enviar o email com a senha, Por favor, tente mais tarde.");

                is_action = true;

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

        [HttpPost]
        public IActionResult ReativarUsuario(string guuid)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (string.IsNullOrEmpty(guuid)) throw new Exception("Campo Guid é obrigatório.");

                _usuarioService.ReativarDesativarUsuario(1, guuid);

                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

        [HttpPost]
        public IActionResult DesativarUsuario(string guuid)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (string.IsNullOrEmpty(guuid)) throw new Exception("Campo Guid é obrigatório.");

                _usuarioService.ReativarDesativarUsuario(2, guuid);

                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

        [HttpPost]
        public IActionResult BuscarNomeUsuarioLogado()
        {
            string nomeUsuarioLogado = "";
            string error = "";
            bool is_action = false;

            try
            {
                nomeUsuarioLogado = CurrentUser.Nome.ToUpper();
                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error, nomeUsuarioLogado });
        }
    }
}
