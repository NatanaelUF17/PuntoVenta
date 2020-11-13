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
    public class ProductServices : IMasterRepository<Product>
    {
        public ProductServices(Context context) { _context = context; }

        private readonly Context _context;

        public async Task Save(Product product)
        {
            if (product.Id > 0)
            {
                await Update(product);
            }
            else
            {
                await Insert(product);
            }
        }

        public async Task Insert(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();        
        }

        public async Task Delete(int id)
        {
            var isFound = await GetOne(id);

            if (isFound.Id > 0)
            {
                _context.Products.Remove(isFound);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetOne(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
