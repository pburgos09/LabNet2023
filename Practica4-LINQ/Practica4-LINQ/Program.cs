using Practica4_LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic logic = new CustomersLogic();

            var customers = logic.GetAll();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CompanyName);
            }
            Console.ReadKey();
        }
    }
}
