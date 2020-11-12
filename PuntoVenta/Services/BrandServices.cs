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
    public class BrandServices : IMasterRepository<Brand>
    {
        public BrandServices(Context context) { _context = context; }

        private readonly Context _context;

        public async Task Save(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Brand brand)
        {
            if(brand.Id > 0)
            {
                _context.Entry(brand).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                await Save(brand);
            }
        }

        public async Task Delete(Brand brand)
        {
            if(brand.Id > 0)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<Brand>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetOne(int id)
        {
            return await _context.Brands.FindAsync(id);
        }
    }
}
