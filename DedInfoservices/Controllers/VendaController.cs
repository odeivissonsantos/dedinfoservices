using DedInfoservices.DTOs.Venda;
using DedInfoservices.Enums;
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

        public VendaController(VendaService vendaService, ProdutoService produtoService, ClienteService clienteService)
        {
            _vendaService = vendaService;
            _produtoService = produtoService;
            _clienteService = clienteService;
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
    }
}
