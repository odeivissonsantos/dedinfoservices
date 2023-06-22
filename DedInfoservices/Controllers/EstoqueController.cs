using DedInfoservices.Filters.Produto;
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
    public class EstoqueController : BaseController
    {

        private readonly ProdutoService _produtoService;
        private readonly UsuarioService _usuarioService;
        public EstoqueController(ProdutoService produtoService, UsuarioService usuarioService)
        {
            _produtoService = produtoService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public virtual IActionResult EntradaProdutosPagination(string sEcho, int iDisplayStart, int iColumns, int iDisplayLength, string sSearch)
        {

            IEnumerable<ProdutoEntrada> query = _produtoService.ListarTodasEntradasProduto();

            if (!string.IsNullOrEmpty(sSearch)) query = query.Where(x => x.Guuid_Produto.ToLower()
                .Contains(SpecialCharacters.RemoveSpecialCharacters(sSearch).ToLower())).AsQueryable();

            int recordsTotal = query.Count();

            List<ProdutoEntrada> aList = query.OrderBy(x => x.Dtc_Inclusao).Skip(iDisplayStart).Take(iDisplayLength).ToList();

            var data = aList.Select(x => new
            {
                produto = _produtoService.BuscarProduto(x.Guuid_Produto).Nome,
                preco_compra = "R$ " + x.Preco_Compra.ToString().Replace(".", ","),
                quantidade = x.Quantidade,
                dtc_compra = x.Dtc_Compra.ToString("dd/MM/yyy HH:mm"),
                dtc_recebimento = x.Dtc_Recebimento.ToString("dd/MM/yyy HH:mm"),
                data_cadastro = x.Dtc_Inclusao.ToString("dd/MM/yyy HH:mm"),
                usuario_inclusao = _usuarioService.BuscarUsuario(2, x.Guuid_Usuario_Inclusao).Nome,
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

        public IActionResult Index()
        {
            ViewBag.Produtos = _produtoService.ListarTodos().Where(x => !x.Sts_Exclusao);
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEntrada(EntradaProdutoFilter filter)
        {
            string error = "";
            bool is_action = false;

            try
            {
                filter.Guuid_Usuario_Inclusao = CurrentUser.Guuid;
                _produtoService.EntradaProduto(filter);

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
