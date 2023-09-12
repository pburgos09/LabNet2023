using Practica6_MVC.Data;

namespace Practica6_MVC.Logic
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
