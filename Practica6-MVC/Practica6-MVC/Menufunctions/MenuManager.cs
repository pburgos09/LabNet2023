using System;

namespace Practica6_MVC.Menufunctions
{
    public class MenuManager
    {
        private MenuFunctionsCategories _menuFunctionsCategories;
        private MenuFunctionsShippers _menuFunctionsShippers;

        public MenuManager()
        {
            _menuFunctionsCategories = new MenuFunctionsCategories();
            _menuFunctionsShippers = new MenuFunctionsShippers();
        }

        public void Start()
        {
            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine("1. Categorías");
                Console.WriteLine("2. Shippers");
                Console.WriteLine("3. Salir");
                Console.Write("Por Favor Selecciona una Opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _menuFunctionsCategories.Start();
                        break;
                    case "2":
                        _menuFunctionsShippers.Start();
                        break;
                    case "3":
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("Opción Inválida");
                        break;
                }
            }
        }
    }
}
