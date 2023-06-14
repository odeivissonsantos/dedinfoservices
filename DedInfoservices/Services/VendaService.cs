using DedInfoservices.Context;
using DedInfoservices.DTOs.Venda;
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
    }
}
