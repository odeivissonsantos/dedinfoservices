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
            return _context.Carrinho.Where(x => x.Guuid_Carrinho == guuid_carrinho && x.Sts_carrinho).ToList();
        }

        public List<Carrinho> BuscarCarrinhoPorCliente(string guuid_cliente)
        {
            return _context.Carrinho.Where(x => x.Guuid_Cliente == guuid_cliente && x.Sts_carrinho).ToList();
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
                _context.Carrinho.Update(query);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
