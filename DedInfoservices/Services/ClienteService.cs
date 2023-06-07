﻿using DedInfoservices.Context;
using DedInfoservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Services
{
    public class ClienteService
    {
        private readonly DataContext _context;

        public ClienteService(DataContext context)
        {
            _context = context;
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Cliente.ToList();
        }

        public Cliente BuscarCliente(string guuid)
        {
            return _context.Cliente.Where(x => x.Guuid == guuid).FirstOrDefault();
        }

        public void ReativarDesativarCliente(int tipoExecuxao, string guuid)
        {
            //1 - Reativa; 2 - Desativa
            var cliente = BuscarCliente(guuid);
            if (cliente == null) throw new Exception("Produto não encontrado.");

            cliente.Sts_Exclusao = tipoExecuxao == 1 ? false : true;

            _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }
    }
}
