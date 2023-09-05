using Practica4_LINQ.Logic;
using System;

namespace Practica4_LINQ.MenuFuctions
{
    public class MenuFunctions
    {
        private CustomersLogic _customersLogic;
        private ProductsLogic _productsLogic;

        public MenuFunctions()
        {
            _customersLogic = new CustomersLogic();
            _productsLogic = new ProductsLogic();
        }

        public void ShowCustomer()
        {
            var returnCustomer = _customersLogic.CustomersMS();
            Console.WriteLine(returnCustomer.CompanyName);
        }

        public void ShowProductsOutOfStock()
        {
            var returnProducts = _productsLogic.ReturnProductsOutOfStockQS();
            
            foreach (var product in returnProducts)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        public void ShowProductsInStockAndCostsMoreThan3()
        {
            var returnProducts = _productsLogic.ReturnProductsInStockAndCostsMoreThan3MS();
            
            foreach (var product in returnProducts)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        public void ShowCustormersFromRegionWA()
        {
            var returnCustomers = _customersLogic.CustormersFromRegionWAQS();
            
            foreach (var customer in returnCustomers)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        public void ShowProductWithId789()
        {
            var returnProduct = _productsLogic.ProductWithId789MS();
            
            if (returnProduct != null)
            {
                Console.WriteLine($"{returnProduct.ProductName} - {returnProduct.ProductID}");
            }
            else
            {
                Console.WriteLine("No existe el producto");
            }
        }

        public void ShowCustomersCompanyNameInUppercaseAndLowercaseTogether()
        {
            var returnCustomers = _customersLogic.CustomersCompanyNameInUppercaseAndLowercaseTogetherQS();
            
            foreach (var customer in returnCustomers)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        public void ShowJoinWACustomersWithOrdersAfter199711()
        {
            var returnCustomer = _customersLogic.JoinWACustomersWithOrdersAfter199711MS();

            foreach (var customer in returnCustomer)
            {
                Console.WriteLine($"{customer.CompanyName} - {customer.Region}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"    Order ID: {order.OrderID}, Order Date: {order.OrderDate}");
                }
            }
        }

        public void ShowFirstThreeCustomersWA()
        {
            var returnCustomer = _customersLogic.FirstThreeCustomersWAQS();
            foreach (var customer in returnCustomer)
            {
                Console.WriteLine($"{customer.CompanyName} - {customer.Region}");
            }
        }

        public void ShowProductsOrdersByName()
        {
            var returnProduct = _productsLogic.ProductsOrdersByNameMS();

            foreach (var product in returnProduct)
            {
                Console.WriteLine($"{product.ProductName}");
            }
        }

        public void ShowProductsOrdersByUnitsInStockAndMajorToMinor()
        {
            var returnProduct = _productsLogic.ProductsOrdersByUnitsInStockAndMajorToMinorMS();

            foreach (var product in returnProduct)
            {
                Console.WriteLine($"{product.ProductName} - {product.UnitsInStock}");
            }
        }

        public void ShowDistinctCategoriesAssociatedToProducts()
        {
            var returnProduct = _productsLogic.DistinctCategoriesAssociatedToProductsQS();

            foreach (var product in returnProduct)
            {
                Console.WriteLine($"{product}");
            }
        }

        public void ShowFirstProduct()
        {
            var returnProduct7 = _productsLogic.FirstProductQS();

            Console.WriteLine($"{returnProduct7.ProductName}");
        }

        public void ShowCustomersWithOrdersAsocietes()
        {
            var returnCustomer = _customersLogic.CustomersWithOrdersAsocietesMS();

            foreach (var customerTuple in returnCustomer)
            {
                var customer = customerTuple.Customer;
                var orderCount = customerTuple.OrderCount;

                Console.WriteLine($"Customer: {customer.CustomerID} - {customer.CompanyName}");
                Console.WriteLine($"Order Count: {orderCount}");
            }
        }
    }
}
