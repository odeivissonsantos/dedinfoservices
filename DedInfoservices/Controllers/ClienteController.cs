using DedInfoservices.Filters.Sessao;
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
    public class ClienteController : BaseController
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual IActionResult ClientesPagination(string sEcho, int iDisplayStart, int iColumns, int iDisplayLength, string sSearch)
        {

            IEnumerable<Cliente> query = _clienteService.ListarTodos();

            if (!string.IsNullOrEmpty(sSearch)) query = query.Where(x => x.Nome.ToLower()
                .Contains(SpecialCharacters.RemoveSpecialCharacters(sSearch).ToLower())).AsQueryable();

            int recordsTotal = query.Count();

            List<Cliente> aList = query.OrderBy(x => x.Nome).Skip(iDisplayStart).Take(iDisplayLength).ToList();

            var data = aList.Select(x => new
            {
                nome = $"{x.Nome} {x.Sobrenome}",
                email = string.IsNullOrEmpty(x.Email) ? "N/C" : x.Email,
                telefone = x.Telefone,
                is_whatsapp = x.Is_Whatsapp ? "SIM" : "NÃO",
                data_cadastro = x.Dtc_Inclusao.ToString("dd/MM/yyy HH:mm"),
                editar = $"<a href='{Url.Action("ClienteSalvar", "Cliente")}?guuid={x.Guuid}' type='button' class='btn btn-warning'>Editar</a>",
                acao = x.Sts_Exclusao ? $"<a href='#' type='button' class='btn btn-primary' onclick='reativar(\"{x.Guuid}\")'>Ativar</a>" : $"<a href='#' type='button' class='btn btn-danger' onclick='desativar(\"{x.Guuid}\")'>Desativar</a>"
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
        public IActionResult ReativarCliente(string guuid)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (string.IsNullOrEmpty(guuid)) throw new Exception("Campo Guid é obrigatório.");

                _clienteService.ReativarDesativarCliente(1, guuid);

                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

        [HttpPost]
        public IActionResult DesativarCliente(string guuid)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (string.IsNullOrEmpty(guuid)) throw new Exception("Campo Guid é obrigatório.");

                _clienteService.ReativarDesativarCliente(2, guuid);

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
