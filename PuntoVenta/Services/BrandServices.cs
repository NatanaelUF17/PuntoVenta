using Microsoft.AspNetCore.Components;
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
        private readonly Context _context;
        public BrandServices(Context context) { _context = context; }

        public async Task Save(Brand brand)
        {
            if (brand.Id > 0)
            {
                await Update(brand);
            }
            else
            {
                await Insert(brand);
            }
        }

        public async Task Insert(Brand brand)
        {
            try
            {
                if(brand != null)
                {
                    _context.Brands.Add(brand);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task Update(Brand brand)
        {
            try
            {
                if(brand != null)
                {
                    _context.Entry(brand).State = EntityState.Modified;
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
                    _context.Brands.Remove(isFound);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task<List<Brand>> GetAll()
        {
            List<Brand> brands = new List<Brand>();

            try
            {
                brands = await _context.Brands.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return brands;
        }

        public async Task<Brand> GetOne(int id)
        {
            Brand brand = new Brand();

            try
            {
                if(id > 0)
                {
                    brand = await _context.Brands.FindAsync(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return brand;
        }
    }
}
