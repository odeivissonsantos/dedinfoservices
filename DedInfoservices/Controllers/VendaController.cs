using DedInfoservices.DTOs.Venda;
using DedInfoservices.Enums;
using DedInfoservices.Filters.Venda;
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
    public class VendaController : BaseController
    {
        private readonly VendaService _vendaService;
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;
        private readonly CarrinhoService _carrinhoService;

        public VendaController(VendaService vendaService, ProdutoService produtoService,
            ClienteService clienteService, CarrinhoService carrinhoService)
        {
            _vendaService = vendaService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _carrinhoService = carrinhoService;
        }


        public IActionResult Index()
        {
            ViewBag.Clientes = _clienteService.ListarTodos().Where(x => !x.Sts_Exclusao).ToList();
            return View();
        }

        public IActionResult RegistrarVenda(string guuid_cliente)
        {
            ViewBag.Cliente = _clienteService.ListarTodos().Where(x => x.Guuid == guuid_cliente).FirstOrDefault();
            ViewBag.Produtos = _produtoService.ListarTodos().Where(x => !x.Sts_Exclusao).ToList();
            var guuid_carrinho = _carrinhoService.BuscarCarrinhoPorCliente(guuid_cliente).FirstOrDefault();
            ViewBag.Guuid_Carrinho = guuid_carrinho == null ? "" : guuid_carrinho.Guuid_Carrinho;
            return View();
        }
        
        [HttpPost]
        public virtual IActionResult VendasPagination(string sEcho, int iDisplayStart, int iColumns, int iDisplayLength, string sSearch)
        {

            IEnumerable<VendaDTO> query = _vendaService.ListarTodos();

            if (!string.IsNullOrEmpty(sSearch)) query = query.Where(x => x.Nome_Cliente.ToLower()
                .Contains(SpecialCharacters.RemoveSpecialCharacters(sSearch).ToLower())).AsQueryable();

            int recordsTotal = query.Count();

            List<VendaDTO> aList = query.OrderBy(x => x.Dtc_Inclusao).Skip(iDisplayStart).Take(iDisplayLength).ToList();

            var data = aList.Select(x => new
            {
                nome_cliente = x.Nome_Cliente,
                nome_usuario_inclusao = x.Nome_Usuario_Inclusao,
                data_inclusao = x.Dtc_Inclusao.ToString("dd/MM/yyy HH:mm"),
                qtd_itens = x.Qtd_Itens,
                tipo_pagamento = DescriptionEnum.GetEnumDescription((TipoPagamentoEnum)x.Tipo_Pagamento),
                valor_total = x.Valor_Total,
                sts_venda = x.Sts_Venda ? "Pago" : "Pendente",
                acao = !x.Sts_Exclusao ? "" : $"<a href='#' type='button' class='btn btn-danger' onclick='desativar(\"{x.Guuid_Venda}\")'>Cancelar</a>"
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
        public virtual IActionResult CarrinhoPagination(string sEcho, int iDisplayStart, int iColumns, int iDisplayLength, string sSearch, string guuid_carrinho)
        {

            IEnumerable<Carrinho> query = _carrinhoService.BuscarCarrinho(guuid_carrinho);

            int recordsTotal = query.Count();

            List<Carrinho> aList = query.OrderBy(x => x.Ide_Carrinho).Skip(iDisplayStart).Take(iDisplayLength).ToList();

            var data = aList.Select(x => new
            {
                produto = x.Guuid_Produto,
                valor_produto = x.Produto_Valor_Unitario,
                desconto = x.Desconto,
                valor_final = x.Valor_Final,
                acao = $"<a href='#' type='button' class='btn btn-danger' onclick='removerProduto(\"{x.Ide_Carrinho}\")'>Remover</a>"
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
        public IActionResult AdicionarProduto(AdicionarProdutoFilter filter)
        {
            string error = "";
            bool is_action = false;
            string guuid_carrinho = "";

            try
            {
                Carrinho carrinho = new();
                if (string.IsNullOrEmpty(filter.Guuid_Produto)) throw new Exception("Campo Guid é obrigatório.");

                var produto = _produtoService.BuscarProduto(filter.Guuid_Produto);
                if (produto != null) carrinho = _carrinhoService.AdicionarProduto(filter, produto);

                guuid_carrinho = carrinho.Guuid_Carrinho;

                is_action = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error, guuid_carrinho });
        }

        [HttpPost]
        public IActionResult RemoverProduto(long id)
        {
            string error = "";
            bool is_action = false;

            try
            {
                if (id <= 0) throw new Exception("Campo id é obrigatório.");

                is_action = _carrinhoService.RemoverProduto(id);

                if (!is_action) throw new Exception("Não foi possível rmover o produto, tente novamente mais tarde.");
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { is_action, error });
        }
    }
}
