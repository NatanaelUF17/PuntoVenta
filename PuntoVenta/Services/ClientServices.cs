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
            try
            {
                if(client != null)
                {
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task Update(Client client)
        {
            try
            {
                if(client != null)
                {
                    _context.Entry(client).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task Delete(int  id)
        {
            var isFound = await GetOne(id);

            try
            {
                if (isFound.Id > 0)
                {
                    _context.Clients.Remove(isFound);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public async Task<List<Client>> GetAll()
        {
            List<Client> clients = new List<Client>();

            try
            {
                clients = await _context.Clients.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return clients;
        }

        public async Task<Client> GetOne(int id)
        {
            Client client = new Client();

            try
            {
                if(id > 0)
                {
                    client = await _context.Clients.FindAsync(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return client;
        }
    }
}
