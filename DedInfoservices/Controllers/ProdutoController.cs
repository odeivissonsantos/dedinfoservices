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
    public class ProdutoController : BaseController
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController (ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual IActionResult ProdutosPagination(string sEcho, int iDisplayStart, int iColumns, int iDisplayLength, string sSearch)
        {

            IEnumerable<Produto> query = _produtoService.ListarTodos();

            if (!string.IsNullOrEmpty(sSearch)) query = query.Where(x => x.Nome.ToLower()
                .Contains(SpecialCharacters.RemoveSpecialCharacters(sSearch).ToLower())).AsQueryable();

            int recordsTotal = query.Count();

            List<Produto> aList = query.OrderBy(x => x.Nome).Skip(iDisplayStart).Take(iDisplayLength).ToList();

            var data = aList.Select(x => new
            {
                nome = x.Nome,
                codigo_interno = x.Codigo_Interno,
                codigo_barras = x.Codigo_Barras.HasValue ? x.Codigo_Barras : 0,
                data_cadastro = x.Dtc_Inclusao.ToString("dd/MM/yyy HH:mm"),
                descricao = string.IsNullOrEmpty(x.Descricao) ? "Nenhuma descrição cadastrada." : x.Descricao,
                dtc_inclusao = x.Dtc_Inclusao.ToString("dd/MM/yyy HH:mm"),
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
    }
}
