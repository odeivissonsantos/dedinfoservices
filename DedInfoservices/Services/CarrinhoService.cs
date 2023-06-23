using DedInfoservices.Context;
using DedInfoservices.Filters.Venda;
using DedInfoservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Services
{
    public class CarrinhoService
    {
        private readonly DataContext _context;

        public CarrinhoService(DataContext context)
        {
            _context = context;
        }

        public List<Carrinho> BuscarCarrinho(string guuid_carrinho)
        {
            return _context.Carrinho.Where(x => x.Guuid_Carrinho == guuid_carrinho && !x.Sts_Conclusao_Carrinho && !x.Sts_Exclusao_Produto).ToList();
        }

        public List<Carrinho> BuscarCarrinhoPorCliente(string guuid_cliente)
        {
            return _context.Carrinho.Where(x => x.Guuid_Cliente == guuid_cliente && !x.Sts_Conclusao_Carrinho).ToList();
        }

        public Carrinho AdicionarProduto(AdicionarProdutoFilter filter, Produto produto)
        {
            Carrinho carrinho = new();

            carrinho.Guuid_Carrinho = string.IsNullOrEmpty(filter.Guuid_Carrinho) ? Guid.NewGuid().ToString() : filter.Guuid_Carrinho;
            carrinho.Guuid_Cliente = filter.Guuid_Cliente;
            carrinho.Guuid_Produto = filter.Guuid_Produto;
            carrinho.Produto_Valor_Unitario = produto.Valor;
            carrinho.Desconto = filter.Desconto <= 0 ? 0 : filter.Desconto;
            double calculoDesconto = (double)carrinho.Produto_Valor_Unitario - ((double)carrinho.Desconto / (double)100) * (double)carrinho.Produto_Valor_Unitario;
            carrinho.Valor_Final = (decimal)calculoDesconto;

             _context.Carrinho.Add(carrinho);
            _context.SaveChanges();

            return carrinho;
        }

        public bool RemoverProduto(long id)
        {
            bool result = false;
            var query = _context.Carrinho.Where(x => x.Ide_Carrinho == id).FirstOrDefault();

            if (query != null)
            {
                query.Sts_Exclusao_Produto = true;
                _context.Carrinho.Update(query);
                _context.SaveChanges();
                result = true;
            }

            VerificaItensAtivos(query.Guuid_Carrinho);

            return result;
        }

        public bool ExcluirCarrinho(string guuid_carrinho)
        {
            bool result = false;
            var query = _context.Carrinho.Where(x => x.Guuid_Carrinho == guuid_carrinho && !x.Sts_Exclusao_Carrinho).ToList();

            if (query != null)
            {
                foreach (var item in query) {

                    item.Sts_Exclusao_Carrinho = true;
                    item.Sts_Exclusao_Produto = true;
                    item.Sts_Conclusao_Carrinho = true;

                    _context.Carrinho.Update(item);
                }

                Venda venda = new()
                {
                    Guuid_Venda = Guid.NewGuid().ToString(),
                    Guuid_Carrinho = query.FirstOrDefault().Guuid_Carrinho,
                    Guuid_Cliente = query.FirstOrDefault().Guuid_Cliente,
                    Guuid_Usuario_Inclusao = "85a7c8f5-59b5-40b5-8c04-56fe824a7799",
                    Valor_Total = 0,
                    Qtd_Itens = 0,
                    Tipo_Pagamento = Enums.TipoPagamentoEnum.NadaConsta,
                    Sts_Exclusao = true
                };

                _context.Venda.Add(venda);
                _context.SaveChanges();

                result = true;
            }

            return result;
        }


        //Cancela Carrinho se todos os itens forem cancelados
        public void VerificaItensAtivos(string guuid_carrinho)
        {
            var query = _context.Carrinho.Where(x => x.Guuid_Carrinho == guuid_carrinho && !x.Sts_Exclusao_Produto).ToList();

            if (query.Count() <= 0)
            {
                bool result = ExcluirCarrinho(guuid_carrinho);
            }

        }
    }
}
