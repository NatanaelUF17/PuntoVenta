﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Repository.MasterRepository
{
    public interface IMasterRepository<T>
    {
        public Task Save(T value);
        public Task Update(T value);
        public Task Delete(T value);
        public Task<T> GetOne(int value);
        public Task<List<T>> GetAll();
    }
}