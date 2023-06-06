using DedInfoservices.Context;
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
    }
}
