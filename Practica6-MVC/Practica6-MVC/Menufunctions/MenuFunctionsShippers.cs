using Practica6_MVC.Logic;
using Practica6_MVC.Logic.DTO;
using System;

namespace Practica6_MVC.Menufunctions
{
    public class MenuFunctionsShippers
    {

        ILogic<ShippersDTO> shippersLogic = new ShippersLogic();

        public void Start()
        {
            Console.WriteLine("Menu de Shippers");
            Console.WriteLine("Por Favor Selecciona una Opcion:");
            Console.WriteLine("1. Listar Shippers");
            Console.WriteLine("2. Agregar Shipper");
            Console.WriteLine("3. Actualizar Shipper");
            Console.WriteLine("4. Eliminar Shipper");
            Console.WriteLine("5. Volver al menu anterior");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    GetAllShippers(shippersLogic);
                    break;
                case "2":
                    InsertShipper(shippersLogic);
                    break;
                case "3":
                    UpdateShipper(shippersLogic);
                    break;
                case "4":
                    DeleteShipper(shippersLogic);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingresa una opción válida.");
                    break;
            }
            Start();
        }

        static void GetAllShippers(ILogic<ShippersDTO> shippersLogic)
        {
            try
            {
                var shippers = shippersLogic.GetAll();
                foreach (var shipper in shippers)
                {
                    Console.WriteLine($"ShipperID: {shipper.ShipperID}, CompanyName: {shipper.CompanyName}, Phone: {shipper.Phone}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los shippers: {ex.Message}");
            }
        }

        static void InsertShipper(ILogic<ShippersDTO> shippersLogic)
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la compañia:");
                var companyName = Console.ReadLine();
                Console.WriteLine("Ingrese el telefono:");
                var phone = Console.ReadLine();
                var shipper = new ShippersDTO
                {
                    CompanyName = companyName,
                    Phone = phone
                };
                shippersLogic.Insert(shipper);
            }catch(Exception ex)
            {
                Console.WriteLine($"Error al insertar el shipper: {ex.Message}");
            }
        }

        static void UpdateShipper(ILogic<ShippersDTO> shippersLogic)
        {
            try
            {
                Console.WriteLine("Ingrese el ID del Shipper a actualizar:");
                var shipperID = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre de la compañia:");
                var companyName = Console.ReadLine();
                Console.WriteLine("Ingrese el telefono:");
                var phone = Console.ReadLine();
                var shipper = new ShippersDTO
                {
                    ShipperID = shipperID,
                    CompanyName = companyName,
                    Phone = phone
                };
                shippersLogic.Update(shipper);
            }catch(Exception ex)
            {
                Console.WriteLine($"Error al actualizar el shipper: {ex.Message}");
            }
        }

        static void DeleteShipper(ILogic<ShippersDTO> shippersLogic)
        {
            try
            {
                Console.WriteLine("Ingrese el ID del Shipper a eliminar:");
                var shipperID = int.Parse(Console.ReadLine());
                var shipper = new ShippersDTO
                {
                    ShipperID = shipperID
                };
                shippersLogic.Delete(shipper);
            }catch(Exception ex)
            {
                Console.WriteLine($"Error al eliminar el shipper: {ex.Message}");
            }
        }
    }
}
