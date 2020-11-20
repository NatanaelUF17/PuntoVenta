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
            try
            {
                if(product != null)
                {
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task Update(Product product)
        {
            try
            {
                if(product != null)
                {
                    _context.Entry(product).State = EntityState.Modified;
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
                    _context.Products.Remove(isFound);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> products = new List<Product>();

            try
            {
                products = await _context.Products.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return products;
        }

        public async Task<Product> GetOne(int id)
        {
            Product product = new Product();

            try
            {
                if(id > 0)
                {
                    product = await _context.Products.FindAsync(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return product;
        }

        public async Task ReduceStock(int id, int stock)
        {
            var isFoundProduct = await GetOne(id);

            try
            {
                if (isFoundProduct != null)
                {
                    if (isFoundProduct.Stock > 0)
                    {
                        isFoundProduct.Stock = isFoundProduct.Stock - stock;
                        await Update(isFoundProduct);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
