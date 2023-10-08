using DDD.Domain.GeralContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IVendaRepository
    {
        public List<Venda> GetVendas();
        public Venda GetVendaById(int id);
        public Venda InsertVenda(int idComprador, int idEvento, DateTime date, int qndIngress);
        public void UpdateVenda(Venda venda);
        public void DeleteVenda(Venda venda);
    }
}
