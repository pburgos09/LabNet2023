using Practica3.EF.Data;

namespace Practica3.EF.Logic
{
    public abstract class BaseLogic
    {
        protected NorthwindContext _context;

        public BaseLogic()
        {
            _context = new NorthwindContext();
        }
    }
}
