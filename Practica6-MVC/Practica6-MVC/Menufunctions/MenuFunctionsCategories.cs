using Practica6_MVC.Logic;
using Practica6_MVC.Logic.DTO;
using System;

namespace Practica6_MVC.Menufunctions
{
    public class MenuFunctionsCategories
    {

    ILogic<CategoriesDTO> categoriesLogic = new CategoriesLogic();
        public void Start()
        {
            Console.WriteLine("Menu de Categorias");
            Console.WriteLine("Por Favor Selecciona una Opcion:");
            Console.WriteLine("1. Listar Categorías");
            Console.WriteLine("2. Agregar Categoria");
            Console.WriteLine("3. Actualizar Categoria");
            Console.WriteLine("4. Eliminar Categoria");
            Console.WriteLine("5. Volver al menu anterior");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    GetAllCategories(categoriesLogic);
                    break;
                case "2":
                    InsertCategory(categoriesLogic);
                    break;
                case "3":
                    UpdateCategory(categoriesLogic);
                    break;
                case "4":
                    DeleteCategory(categoriesLogic);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingresa una opción válida.");
                    break;
            }
            Start();
        }   

        static void GetAllCategories(ILogic<CategoriesDTO> categoriesLogic)
        {
            try
            {
                var categories = categoriesLogic.GetAll();
                foreach (var category in categories)
                {
                    Console.WriteLine($"CategoryID: {category.CategoryID}, CategoryName: {category.CategoryName}, Description: {category.Description}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las categorías: {ex.Message}");
            }
        }

        static void InsertCategory(ILogic<CategoriesDTO> categoriesLogic)
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la categoria:");
                var categoryName = Console.ReadLine();
                Console.WriteLine("Ingrese la descripcion de la categoria:");
                var description = Console.ReadLine();
                var category = new CategoriesDTO
                {
                    CategoryName = categoryName,
                    Description = description
                };
                categoriesLogic.Insert(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la categoría: {ex.Message}");
            }
        }

        static void UpdateCategory(ILogic<CategoriesDTO> categoriesLogic)
        {
            try
            {
                Console.WriteLine("Ingrese el ID de la categoria a actualizar:");
                var categoryID = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre de la categoria:");
                var categoryName = Console.ReadLine();
                Console.WriteLine("Ingrese la descripcion de la categoria:");
                var description = Console.ReadLine();
                var category = new CategoriesDTO
                {
                    CategoryID = categoryID,
                    CategoryName = categoryName,
                    Description = description
                };
                categoriesLogic.Update(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la categoría: {ex.Message}");
            }
        }

        static void DeleteCategory(ILogic<CategoriesDTO> categoriesLogic)
        {
            try
            {
                Console.WriteLine("Ingrese el ID de la categoria a eliminar:");
                var categoryID = int.Parse(Console.ReadLine());
                var category = new CategoriesDTO
                {
                    CategoryID = categoryID
                };
                categoriesLogic.Delete(category.CategoryID);
                Console.WriteLine("Categoria eliminada correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la categoría: {ex.Message}");
            }
        }
    }
}
