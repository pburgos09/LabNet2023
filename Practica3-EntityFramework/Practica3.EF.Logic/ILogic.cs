﻿using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();

        void Delete(T entity);

        void Update(T entity);

        T Insert(T entity);
    }
}
