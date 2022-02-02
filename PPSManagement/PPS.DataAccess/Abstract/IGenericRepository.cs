﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T t);
        Task<T> Update(T t);
        Task Delete(int id);
    }
}
