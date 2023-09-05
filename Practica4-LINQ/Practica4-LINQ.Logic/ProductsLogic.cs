using Practica4_LINQ.Data;
using Practica4_LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Practica4_LINQ.Logic
{
    public class ProductsLogic : BaseLogic, ILogic<Products>
    {
        public ProductsLogic() : base()
        {
        }

        public void Delete(Products entity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == entity.ProductID);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Products> GetAll()
        {
            return _context.Products.ToList();
        }

        public Products Insert(Products entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(Products entity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == entity.ProductID);
            if (product != null)
            {
                product.ProductName = entity.ProductName;
                product.SupplierID = entity.SupplierID;
                product.CategoryID = entity.CategoryID;
                product.QuantityPerUnit = entity.QuantityPerUnit;
                product.UnitPrice = entity.UnitPrice;
                product.UnitsInStock = entity.UnitsInStock;
                product.UnitsOnOrder = entity.UnitsOnOrder;
                product.ReorderLevel = entity.ReorderLevel;
                product.Discontinued = entity.Discontinued;
                _context.SaveChanges();
            }   
        }

        public List<Products> ReturnProductsOutOfStockQS()
        {
            var products = from p in _context.Products
                           where p.UnitsInStock == 0
                           select p;
            return products.ToList();
        }

        public List<Products> ReturnProductsOutOfStockMS()
        {
            var products = _context.Products.Where(p => p.UnitsInStock == 0);
            return products.ToList();
        }

        public List<Products> ReturnProductsInStockAndCostsMoreThan3QS()
        {
            var products = from p in _context.Products
                           where p.UnitsInStock > 0 && p.UnitPrice > 3
                           select p;
            return products.ToList();
        }

        public List<Products> ReturnProductsInStockAndCostsMoreThan3MS()
        {
            var products = _context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            return products.ToList();
        }

        public Products ProductWithId789QS()
        {
            var product = from p in _context.Products
                          where p.ProductID == 789
                          select p;
            return product.FirstOrDefault();
        }

        public Products ProductWithId789MS()
        {
            var product = _context.Products.Where(p => p.ProductID == 789);
            return product.FirstOrDefault();
        }

        public List<Products> ProductsOrdersByNameQS()
        {
            var products = from p in _context.Products
                           orderby p.ProductName
                           select p;
            return products.ToList();
        }

        public List<Products> ProductsOrdersByNameMS()
        {
            var products = _context.Products.OrderBy(p => p.ProductName);
            return products.ToList();
        }

        public List<Products> ProductsOrdersByUnitsInStockAndMajorToMinorQS()
        {
            var products = from p in _context.Products
                           orderby p.UnitsInStock descending
                           select p;
            return products.ToList();
        }

        public List<Products> ProductsOrdersByUnitsInStockAndMajorToMinorMS()
        {
            var products = _context.Products.OrderByDescending(p => p.UnitsInStock);
            return products.ToList();
        }

        public List<string> DistinctCategoriesAssociatedToProductsQS()
        {
            var distinctCategories = (from p in _context.Products
                                      select p.Categories.CategoryName).Distinct().ToList();
            return distinctCategories;
        }

        public List<string> DistinctCategoriesAssociatedToProductsMS()
        {
            var distinctCategories = _context.Products.Select(p => p.Categories.CategoryName).Distinct().ToList();
            return distinctCategories;
        }

        public Products FirstProductQS()
        {
            var product = (from p in _context.Products
                           select p).FirstOrDefault();
            return product;
        }

        public Products FirstProductMS()
        {
            var product = _context.Products.FirstOrDefault();
            return product;
        }
    }
}
