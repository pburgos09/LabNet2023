using Practica4_LINQ.Data;
using Practica4_LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4_LINQ.Logic
{
    public class CustomersLogic : BaseLogic, ILogic<Customers>
    {
        public CustomersLogic() : base()
        {
        }

        public void Delete(Customers entity)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == entity.CustomerID);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customers Insert(Customers entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(Customers entity)
        {
            var Customers = _context.Customers.FirstOrDefault(c => c.CustomerID == entity.CustomerID);
            if (Customers != null)
            {
                Customers.CompanyName = entity.CompanyName;
                Customers.ContactName = entity.ContactName;
                Customers.ContactTitle = entity.ContactTitle;
                Customers.Address = entity.Address;
                Customers.City = entity.City;
                Customers.Region = entity.Region;
                Customers.PostalCode = entity.PostalCode;
                Customers.Country = entity.Country;
                Customers.Phone = entity.Phone;
                Customers.Fax = entity.Fax;
                _context.SaveChanges();
            }   
        }

        public Customers CustomersQS()
        {
            var customers = from c in _context.Customers
                            where c.CustomerID == "ALFKI"
                            select c;
            return customers.FirstOrDefault();
        }

        public Customers CustomersMS()
        {
            var customers = _context.Customers.Where(c => c.CustomerID == "ALFKI");
            return customers.FirstOrDefault();
        }

        public List<Customers> CustormersFromRegionWAQS()
        {
            var customers = from c in _context.Customers
                            where c.Region == "WA"
                            select c;
            return customers.ToList();
        }

        public List<Customers> CustormersFromRegionWAMS()
        {
            var customers = _context.Customers.Where(c => c.Region == "WA");
            return customers.ToList();
        }

        public List<Customers> CustomersCompanyNameInUppercaseAndLowercaseTogetherQS()
        {
            var customers = from c in _context.Customers
                            select new
                            {
                                CustomerID = c.CustomerID,
                                CompanyName = c.CompanyName.ToUpper() + " " + c.CompanyName.ToLower()
                            };

            var customerList = customers.ToList()
                .Select(c => new Customers
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName
                })
                .ToList();

            return customerList;
        }


        public List<Customers> CustomersCompanyNameInUppercaseAndLowercaseTogetherMS()
        {
            var customers = _context.Customers.Select(c => new
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName.ToUpper() + " " + c.CompanyName.ToLower()
            });

            var customerList = customers.ToList()
                .Select(c => new Customers
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName
                })
                .ToList();

            return customerList;
        }

        public List<Customers> JoinWACustomersWithOrdersAfter199711QS()
        {
            var customers = _context.Customers
                .Where(c => c.Region == "WA")
                .Include(c => c.Orders)
                .ToList();

            var filteredCustomers = customers
                .Where(c => c.Orders.Any(o => o.OrderDate > new DateTime(1997, 11, 1)))
                .ToList();

            return filteredCustomers;
        }


        public List<Customers> JoinWACustomersWithOrdersAfter199711MS()
        {
            var customers = _context.Customers
                .Where(c => c.Region == "WA")
                .Include(c => c.Orders)
                .Join(_context.Orders,
                    c => c.CustomerID,
                    o => o.CustomerID,
                    (c, o) => new { Customer = c, Order = o })
                .Where(co => co.Order.OrderDate > new DateTime(1997, 11, 1))
                .Select(co => co.Customer)
                .ToList();

            return customers;
        }

        public List<Customers> FirstThreeCustomersWAQS()
        {
            var customers = (from c in _context.Customers
                             where c.Region == "WA"
                             select c).Take(3);
            return customers.ToList();
        }

        public List<Customers> FirstThreeCustomersWAMS()
        {
            var customers = _context.Customers.Where(c => c.Region == "WA").Take(3);
            return customers.ToList();
        }

        public List<(Customers Customer, int OrderCount)> CustomersWithOrdersAsocietesQS()
        {
            var customerIDsWithOrders = _context.Orders.Select(o => o.CustomerID).Distinct().ToList();

            var customersWithOrders = (from c in _context.Customers
                                       where customerIDsWithOrders.Contains(c.CustomerID)
                                       select c).ToList();

            var result = customersWithOrders.Select(c => (c, _context.Orders.Count(o => o.CustomerID == c.CustomerID))).ToList();

            return result;
        }

        public List<(Customers Customer, int OrderCount)> CustomersWithOrdersAsocietesMS()
        {
            var customerIDsWithOrders = _context.Orders.Select(o => o.CustomerID).Distinct().ToList();

            var customersWithOrders = _context.Customers.Where(c => customerIDsWithOrders.Contains(c.CustomerID)).ToList();

            var result = customersWithOrders.Select(c => (c, _context.Orders.Count(o => o.CustomerID == c.CustomerID))).ToList();

            return result;
        }
    }
}
