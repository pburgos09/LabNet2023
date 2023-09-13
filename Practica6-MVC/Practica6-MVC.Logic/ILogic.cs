using Practica6_MVC.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica6_MVC.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();

        bool Delete(int id);

        void Update(T entity);

        T Insert(T entity);

        T GetById(int id);
    }
}
