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
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            if(category.Id > 0)
            {
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                await Save(category);
            }
        }

        public async Task Delete(Category category)
        {
            if(category.Id > 0)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetOne(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
