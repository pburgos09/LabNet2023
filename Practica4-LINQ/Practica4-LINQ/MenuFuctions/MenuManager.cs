using System;

namespace Practica4_LINQ.MenuFuctions
{
    public class MenuManager
    {
        private MenuFunctions _menuFuctions;

        public MenuManager()
        {
            _menuFuctions = new MenuFunctions();
        }

        public void Run()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Devolver un Customer");
                Console.WriteLine("2. Devolver Productos sin Stock");
                Console.WriteLine("3. Devolver Productos en Stock y que Cuestan Mas de 3 por Unidad");
                Console.WriteLine("4. Devolver Customers de la Región WA");
                Console.WriteLine("5. Devolver Producto con ID 789");
                Console.WriteLine("6. Devolver Customers y Mostrarlos en Mayúsculas y Minúsculas");
                Console.WriteLine("7. Devolver Join entre Customers y Orders de Región WA Mayor a 1/1/1997");
                Console.WriteLine("8. Devolver los 3 Primeros Customers de la Región WA");
                Console.WriteLine("9. Devolver Productos Ordenados por Nombre");
                Console.WriteLine("10. Devolver Productos Ordenados por Unit In Stock de Mayor a Menor");
                Console.WriteLine("11. Devolver Categorías Asociadas a Productos");
                Console.WriteLine("12. Devolver Primer Elemento de Lista de Productos");
                Console.WriteLine("13. Devolver Customers con Órdenes Asociadas");
                Console.WriteLine("14. Salir");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        _menuFuctions.ShowCustomer();
                        ShowMenuMessage();
                        break;
                    case "2":
                        _menuFuctions.ShowProductsOutOfStock();
                        ShowMenuMessage();
                        break;
                    case "3":
                        _menuFuctions.ShowProductsInStockAndCostsMoreThan3();
                        ShowMenuMessage();
                        break;
                    case "4":
                        _menuFuctions.ShowCustormersFromRegionWA();
                        ShowMenuMessage();
                        break;
                    case "5":
                        _menuFuctions.ShowProductWithId789();
                        ShowMenuMessage();
                        break;
                    case "6":
                        _menuFuctions.ShowCustomersCompanyNameInUppercaseAndLowercaseTogether();
                        ShowMenuMessage();
                        break;
                    case "7":
                        _menuFuctions.ShowJoinWACustomersWithOrdersAfter199711();
                        ShowMenuMessage();
                        break;
                    case "8":
                        _menuFuctions.ShowFirstThreeCustomersWA();
                        ShowMenuMessage();
                        break;
                    case "9":
                        _menuFuctions.ShowProductsOrdersByName();
                        ShowMenuMessage();
                        break;
                    case "10":
                        _menuFuctions.ShowProductsOrdersByUnitsInStockAndMajorToMinor();
                        ShowMenuMessage();
                        break;
                    case "11":
                        _menuFuctions.ShowDistinctCategoriesAssociatedToProducts();
                        ShowMenuMessage();
                        break;
                    case "12":
                        _menuFuctions.ShowFirstProduct();
                        ShowMenuMessage();
                        break;
                    case "13":
                        _menuFuctions.ShowCustomersWithOrdersAsocietes();
                        ShowMenuMessage();
                        break;
                    case "14":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Opción Inválida. Por Favor Eliga una Nueva Opción");
                        break;
                }
            }
        }

        private void ShowMenuMessage()
        {
            Console.WriteLine("Presione Cualquier Tecla Para Volver al Menú...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
