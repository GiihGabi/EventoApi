using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class VendaRepositorySqlServer : IVendaRepository
    {
        private readonly SqlContext _context;

        public VendaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteVenda(Venda venda)
        {
            throw new NotImplementedException();
        }

        public Venda GetVendaById(int id)
        {
            return _context.Venda.Find(id);
        }

        public List<Venda> GetVendas()
        {
            return _context.Venda.ToList();
        }

        //public void InsertVenda(Venda venda)
        //{
        //    try
        //    {
        //        _context.Venda.Add(venda);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log exception

        //    }
        //}


        public Venda InsertVenda(int idComprador, int idEvento, DateTime date, int qndIngresso)
        {
            var comprador = _context.Compradores.First(i => i.UserId == idComprador);
            var evento = _context.Eventos.First(i => i.IdEventos == idEvento);

            var venda = new Venda
            {
                Compradores = comprador,
                Eventos = evento,
                Data = date,
                QtdIngresso = qndIngresso
                
            };

            try
            {

                _context.Add(venda);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return venda;
        }

        public void UpdateVenda(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
