using Practica3.EF.Entities;
using Practica3.EF.Logic;
using System;
using System.Linq;

namespace Practica3_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogic<Categories> categoriesLogic = new CategoriesLogic();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine("Menú de Categorías:");
                Console.WriteLine("1. Listar Categorías");
                Console.WriteLine("2. Agregar Categoría");
                Console.WriteLine("3. Actualizar Categoría");
                Console.WriteLine("4. Eliminar Categoría");
                Console.WriteLine("5. Salir");

                Console.Write("Por favor, ingresa el número de la opción que deseas: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarCategorias(categoriesLogic);
                        break;
                    case "2":
                        AgregarCategoria(categoriesLogic);
                        break;
                    case "3":
                        ActualizarCategoria(categoriesLogic);
                        break;
                    case "4":
                        EliminarCategoria(categoriesLogic);
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingresa una opción válida.");
                        break;
                }
            }
        }

        static void ListarCategorias(ILogic<Categories> logic)
        {
            var categories = logic.GetAll();
            Console.Clear();
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryID}. {category.CategoryName}");
            }
            Console.WriteLine("Presiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static void AgregarCategoria(ILogic<Categories> logic)
        {
            Console.Clear();
            Console.Write("Ingrese el nombre de la nueva categoría: ");
            string categoryName = Console.ReadLine();
            Console.Write("Ingrese la descripción de la nueva categoría: ");
            string description = Console.ReadLine();

            logic.Insert(new Categories()
            {
                CategoryName = categoryName,
                Description = description,
                Picture = null
            });

            Console.WriteLine("Categoría agregada correctamente.");
            Console.WriteLine("Presiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static void ActualizarCategoria(ILogic<Categories> logic)
        {
            Console.Clear();
            Console.Write("Ingrese el ID de la categoría que desea actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int categoryId))
            {
                var category = logic.GetAll().FirstOrDefault(c => c.CategoryID == categoryId);

                if (category != null)
                {
                    Console.Write("Ingrese el nuevo nombre de la categoría: ");
                    category.CategoryName = Console.ReadLine();
                    Console.Write("Ingrese la nueva descripción de la categoría: ");
                    category.Description = Console.ReadLine();

                    logic.Update(category);

                    Console.WriteLine("Categoría actualizada correctamente.");
                }
                else
                {
                    Console.WriteLine("Categoría no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID de categoría no válido.");
            }

            Console.WriteLine("Presiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static void EliminarCategoria(ILogic<Categories> logic)
        {
            Console.Clear();
            Console.Write("Ingrese el ID de la categoría que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int categoryId))
            {
                var category = logic.GetAll().FirstOrDefault(c => c.CategoryID == categoryId);

                if (category != null)
                {
                    logic.Delete(category);
                    Console.WriteLine("Categoría eliminada correctamente.");
                }
                else
                {
                    Console.WriteLine("Categoría no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID de categoría no válido.");
            }

            Console.WriteLine("Presiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}
