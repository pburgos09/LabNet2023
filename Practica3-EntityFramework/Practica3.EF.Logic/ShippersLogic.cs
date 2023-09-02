using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class ShippersLogic : BaseLogic, ILogic<Shippers>
    {

        public ShippersLogic() : base()
        {

        }

        public void Delete(Shippers entity)
        {
            throw new NotImplementedException();
        }

        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }

        public Shippers Insert(Shippers entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Shippers entity)
        {
            throw new NotImplementedException();
        }
    }
}
