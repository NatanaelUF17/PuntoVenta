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
            try
            {
                if(sale != null)
                {
                    _context.Sales.Add(sale);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task Update(Sale sale)
        {
            try
            {
                if(sale != null)
                {
                    _context.Entry(sale).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        } 

        public async Task Delete(int id)
        {
            var isFound = await GetOne(id);

            try
            {
                if (isFound.Id > 0)
                {
                    _context.Sales.Remove(isFound);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task<List<Sale>> GetAll()
        {
            List<Sale> sales = new List<Sale>();

            try
            {
                sales = await _context.Sales.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return sales;
        }

        public async Task<Sale> GetOne(int id)
        {
            Sale sale = new Sale();

            try
            {
                if(id > 0)
                {
                    sale = await _context.Sales.Where(i => i.Id == id)
                    .Include(s => s.SaleDetails)
                    .FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return sale;
        }
    }
}
