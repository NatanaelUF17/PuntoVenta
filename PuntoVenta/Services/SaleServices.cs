using Microsoft.EntityFrameworkCore;
using PuntoVenta.AppDbContext;
using PuntoVenta.Models;
using PuntoVenta.Repository.MasterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Services
{
    public class SaleServices : IMasterRepository<Sale>
    {
        public SaleServices(Context context) { _context = context; }

        private readonly Context _context;

        public async Task Save(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Sale sale)
        {
            if(sale.Id > 0)
            {
                _context.Entry(sale).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                await Save(sale);
            }
        } 

        public async Task Delete(Sale sale)
        {
            if(sale.Id > 0)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<Sale>> GetAll()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetOne(int id)
        {
            return await _context.Sales.FindAsync(id);
        }
    }
}
