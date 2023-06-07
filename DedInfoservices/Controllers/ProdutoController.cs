using DedInfoservices.Filters.Produto;
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

        public IActionResult ProdutoSalvar(string guuid)
        {
            Produto produto = new Produto();
            if (!string.IsNullOrEmpty(guuid)) produto = _produtoService.BuscarProduto(guuid);
            if (produto == null || produto.Ide_Produto <= 0) produto = new Produto();
            return View(produto);
        }

        [HttpPost]
        public IActionResult SalvarProduto(SalvarProdutoFilter filter)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (string.IsNullOrEmpty(filter.Nome)) throw new Exception("Campo Nome é obrigatório.");
                if (filter.Valor <= 0) throw new Exception("Campo Sobrenome é obrigatório.");

                _produtoService.SalvarProduto(filter);

                is_action = true;

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
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
                codigo_barras = x.Codigo_Barras.HasValue ? x.Codigo_Barras.ToString() : "N/C",
                descricao = string.IsNullOrEmpty(x.Descricao) ? "N/C" : x.Descricao,
                data_cadastro = x.Dtc_Inclusao.ToString("dd/MM/yyy HH:mm"),               
                valor_unitario = "R$ " + x.Valor.ToString(),
                editar = $"<a href='{Url.Action("ProdutoSalvar", "Produto")}?guuid={x.Guuid}' type='button' class='btn btn-warning'>Editar</a>",
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
        public IActionResult ReativarProduto(string guuid)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (string.IsNullOrEmpty(guuid)) throw new Exception("Campo Guid é obrigatório.");

                _produtoService.ReativarDesativarProduto(1, guuid);

                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }

        [HttpPost]
        public IActionResult DesativarProduto(string guuid)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (string.IsNullOrEmpty(guuid)) throw new Exception("Campo Guid é obrigatório.");

                _produtoService.ReativarDesativarProduto(2, guuid);

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
