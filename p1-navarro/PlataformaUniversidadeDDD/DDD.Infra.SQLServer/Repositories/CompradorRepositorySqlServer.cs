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
    public class CompradorRepositorySqlServer : ICompradorRepository
    {

        private readonly SqlContext _context;

        public CompradorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteComprador(Comprador comprador)
        {
            try
            {
                _context.Set<Comprador>().Remove(comprador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Comprador GetCompradorById(int id)
        {
            return _context.Compradores.Find(id);
        }

        public List<Comprador> GetComprador()
        {
            //return  _context.Compradors.Include(x => x.Disciplinas).ToList();
            return _context.Compradores.ToList();

        }

        public void InsertComprador(Comprador comprador)
        {
            try
            {
                _context.Compradores.Add(comprador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                

            }
        }

        public void UpdateComprador(Comprador comprador)
        {
            try
            {
                _context.Entry(comprador).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
