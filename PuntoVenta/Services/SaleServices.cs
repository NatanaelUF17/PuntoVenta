using Microsoft.EntityFrameworkCore;
using PuntoVenta.AppDbContext;
using PuntoVenta.Models;
using PuntoVenta.Repository.MasterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PuntoVenta.Services;

namespace PuntoVenta.Services
{
    public class SaleServices : IMasterRepository<Sale>
    {
        public SaleServices(Context context) { _context = context; }

        private readonly Context _context;
        ProductServices ProductServices;

        public async Task Save(Sale sale)
        {
            if (sale.Id > 0)
            {
                await Update(sale);
            }
            else
            {
                await Insert(sale);
            }
        }

        public async Task Insert(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Sale sale)
        {
            _context.Entry(sale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        } 

        public async Task Delete(int id)
        {
            var isFound = await GetOne(id);

            if (isFound.Id > 0)
            {
                _context.Sales.Remove(isFound);
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
            return await _context.Sales.Where(i => i.Id == id)
                .Include(s => s.SaleDetails)
                .FirstOrDefaultAsync();
        }
    }
}
