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
    public class CategoryServices : IMasterRepository<Category>
    {
        public CategoryServices(Context context) { _context = context; }

        private readonly Context _context;

        public async Task Save(Category category)
        {
            if(category.Id > 0)
            {
                await Update(category);
            }
            else
            {
                await Insert(category);
            }
        }

        public async Task Insert(Category category)
        {
            try
            {
                if(category != null)
                {
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task Update(Category category)
        {
            try
            {
                if (category != null)
                {
                    _context.Entry(category).State = EntityState.Modified;
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
                    _context.Categories.Remove(isFound);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = new List<Category>();

            try
            {
                categories = await _context.Categories.ToListAsync();
            } 
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return categories;
        }

        public async Task<Category> GetOne(int id)
        {
            Category category = new Category();

            try
            {
                if(id > 0)
                {
                    category = await _context.Categories.FindAsync(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return category;
        }
    }
}
