using DedInfoservices.Context;
using DedInfoservices.DTOs.Venda;
using DedInfoservices.Enums;
using DedInfoservices.Filters.Venda;
using DedInfoservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Services
{
    public class VendaService
    {
        private readonly DataContext _context;

        public VendaService(DataContext context)
        {
            _context = context;
        }

        public List<VendaDTO> ListarTodos()
        {
            List<VendaDTO> listVendas = new();
            var query = _context.Venda.ToList();

            if (query.Any())
            {
                foreach(var item in query)
                {
                    var cliente = _context.Cliente.Where(x => x.Guuid == item.Guuid_Cliente).FirstOrDefault();
                    var usuario = _context.Usuario.Where(x => x.Guuid == item.Guuid_Usuario_Inclusao).FirstOrDefault();

                    VendaDTO venda = new()
                    {
                        Guuid_Venda = item.Guuid_Venda,
                        Nome_Cliente = $"{cliente.Nome} {cliente.Sobrenome}",
                        Nome_Usuario_Inclusao = $"{usuario.Nome} {usuario.Sobrenome}",
                        Dtc_Inclusao = item.Dtc_Inclusao,
                        Qtd_Itens = item.Qtd_Itens,
                        Sts_Exclusao = item.Sts_Exclusao,
                        Sts_Venda = item.Sts_Venda,
                        Tipo_Pagamento = item.Tipo_Pagamento,
                        Valor_Total = item.Valor_Total
                    };

                    listVendas.Add(venda);

                }
            }

            return listVendas;
        }

        public void FinalizarVenda(FinalizarVendaFilter filter)
        {
            List<Carrinho> listCarrinho = _context.Carrinho.Where(x => x.Guuid_Carrinho == filter.Guuid_Carrinho).ToList();

            List<Carrinho> itensAtivosCarrinho = listCarrinho.Where(x => !x.Sts_Exclusao_Produto).ToList();

            Venda venda = new()
            {
                Guuid_Venda = Guid.NewGuid().ToString(),
                Guuid_Carrinho = filter.Guuid_Carrinho,
                Guuid_Cliente = filter.Guuid_Cliente,
                Guuid_Usuario_Inclusao = filter.Guuid_Usuario_Inclusao,
                Valor_Total = itensAtivosCarrinho.Select(x => x.Valor_Final).Sum(),
                Qtd_Itens = itensAtivosCarrinho.Count(),
                Tipo_Pagamento = filter.Tipo_Pagamento,
                Sts_Venda = true        
            };

            _context.Venda.Add(venda);

            foreach (var item in itensAtivosCarrinho)
            {
                var query = _context.ProdutoEstoque.Where(x => x.Guuid_Produto == item.Guuid_Produto).FirstOrDefault();

                if(query != null)
                {
                    query.Quantidade--;
                    query.Dtc_Atualizacao = DateTime.Now;
                }
                _context.ProdutoEstoque.Update(query);
            }

            foreach (var item in listCarrinho) 
            {
                item.Sts_Conclusao_Carrinho = true;
                _context.Carrinho.Update(item);
            }

            _context.SaveChanges();

        }

        public void CancelarVenda(string guuid_venda)
        {
            var query = _context.Venda.Where(x => x.Guuid_Venda == guuid_venda && !x.Sts_Exclusao).FirstOrDefault();

            if (query != null)
            {
                List<Carrinho> listCarrinho = _context.Carrinho.Where(x => x.Guuid_Carrinho == query.Guuid_Carrinho).ToList();
                List<Carrinho> lisitensAtivotCarrinho = listCarrinho.Where(x => !x.Sts_Exclusao_Produto).ToList();

                query.Sts_Exclusao = true;
                _context.Venda.Update(query);

                foreach (var item in lisitensAtivotCarrinho)
                {
                    var queryProdutoEstoque = _context.ProdutoEstoque.Where(x => x.Guuid_Produto == item.Guuid_Produto).FirstOrDefault();
                    
                    if (queryProdutoEstoque != null)
                    {
                        queryProdutoEstoque.Quantidade++;
                        queryProdutoEstoque.Dtc_Atualizacao = DateTime.Now;                        
                    }

                    _context.ProdutoEstoque.Update(queryProdutoEstoque);
                    
                }

                foreach (var item in listCarrinho)
                {

                    item.Sts_Exclusao_Carrinho = true;
                    _context.Carrinho.Update(item);
                }

                _context.SaveChanges();
            }  

        }


    }
}
