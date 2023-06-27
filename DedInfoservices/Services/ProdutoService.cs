using DedInfoservices.Context;
using DedInfoservices.Filters.Produto;
using DedInfoservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Services
{
    public class ProdutoService
    {
        private readonly DataContext _context;

        public ProdutoService(DataContext context)
        {
            _context = context;
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produto.ToList();
        }

        public Produto BuscarProduto(string guuid)
        {
            return _context.Produto.Where(x => x.Guuid == guuid).FirstOrDefault();
        }

        public void ReativarDesativarProduto(int tipoExecuxao, string guuid)
        {
            //1 - Reativa; 2 - Desativa
            var produto = BuscarProduto(guuid);
            if (produto == null) throw new Exception("Produto não encontrado.");

            produto.Sts_Exclusao = tipoExecuxao == 1 ? false : true;

            _context.Produto.Update(produto);
            _context.SaveChanges();
        }

        public void SalvarProduto(SalvarProdutoFilter filter)
        {
            bool novo = true;
            Produto produto = new();

            produto = BuscarProduto(filter.Guuid);
            if (produto != null) novo = false;
            if (produto == null) produto = new();

            produto.Nome = filter.Nome;
            produto.Valor = !filter.Valor.Contains(".") ? decimal.Parse(filter.Valor.Replace(".", ",")) : decimal.Parse(filter.Valor);
            produto.Codigo_Barras = filter.Codigo_Barras;
            produto.Codigo_Interno = new Random().Next(10000, 99999);
            produto.Descricao = filter.Descricao;

            if (novo)
            {
                produto.Guuid = Guid.NewGuid().ToString();
                _context.Produto.Add(produto);


                ProdutoEstoque produtoEstoque = new()
                {
                    Guuid_Produto = produto.Guuid,
                    Dtc_Atualizacao = DateTime.Now,
                    Quantidade = 0
                };

                _context.ProdutoEstoque.Add(produtoEstoque);
            }
            else
            {
                _context.Produto.Update(produto);
            }

            _context.SaveChanges();


        }


        public List<ProdutoEntrada> ListarTodasEntradasProduto()
        {
            return _context.ProdutoEntrada.ToList();
        }

        public bool EntradaProduto(EntradaProdutoFilter filter)
        {
            bool result = false;

            var produto = BuscarProduto(filter.Guuid_Produto);
            if (produto == null) throw new Exception("Produto não encontrado.");

            var query = _context.ProdutoEstoque.Where(x => x.Guuid_Produto == filter.Guuid_Produto).FirstOrDefault();

            ProdutoEntrada newEntrada = new()
            {
                Guuid_Produto = filter.Guuid_Produto,
                Guuid_Usuario_Inclusao = filter.Guuid_Usuario_Inclusao,
                Preco_Compra = !filter.Preco_Compra.Contains(".") ? decimal.Parse(filter.Preco_Compra.Replace(".", ",")) : decimal.Parse(filter.Preco_Compra),
                Dtc_Compra = filter.Dtc_Compra,
                Dtc_Recebimento = filter.Dtc_Recebimento,
                Quantidade = filter.Quantidade
            };

            query.Quantidade = query.Quantidade + filter.Quantidade;
            query.Dtc_Atualizacao = DateTime.Now;

            _context.ProdutoEntrada.Add(newEntrada);
            _context.ProdutoEstoque.Update(query);     
            _context.SaveChanges();

            if (newEntrada.Ide_Produto_Entrada > 0) result = true;

            return result;
        }

        public ProdutoEstoque BuscarEstoque(string guuid)
        {
            return _context.ProdutoEstoque.Where(x => x.Guuid_Produto == guuid).FirstOrDefault();
        }
    }
}
