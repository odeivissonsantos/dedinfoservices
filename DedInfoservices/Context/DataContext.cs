﻿using DedInfoservices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Context
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ProdutoEstoque> ProdutoEstoque { get; set; }
        public DbSet<ProdutoEntrada> ProdutoEntrada { get; set; }
    }
}
