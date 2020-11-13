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
    public class ClientServices : IMasterRepository<Client>
    {
        public ClientServices(Context context) { _context = context; }
        
        private readonly Context _context;

        public async Task Save(Client client)
        {
            if(client.Id > 0)
            {
                await Update(client);
            }
            else
            {
                await Insert(client);
            }
        }

        public async Task Insert(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int  id)
        {
            var isFound = await GetOne(id);

            if (isFound.Id > 0)
            {
                _context.Clients.Remove(isFound);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetOne(int id)
        {
            return await _context.Clients.FindAsync(id);
        }
    }
}
