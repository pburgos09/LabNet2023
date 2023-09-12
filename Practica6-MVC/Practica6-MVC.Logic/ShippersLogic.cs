using Practica6_MVC.Entities;
using Practica6_MVC.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica6_MVC.Logic
{
    public class ShippersLogic : BaseLogic, ILogic<ShippersDTO>
    {
        public ShippersLogic() : base()
        {
        }

        public bool Delete(int id)
        {
            var shipper = _context.Shippers.FirstOrDefault(x => x.ShipperID == id);
            if (shipper != null)
            {
                _context.Shippers.Remove(shipper);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ShippersDTO> GetAll()
        {
            return _context.Shippers.Select(x => new ShippersDTO
            {
                ShipperID = x.ShipperID,
                CompanyName = x.CompanyName,
                Phone = x.Phone
            }).ToList();
        }

        public ShippersDTO Insert(ShippersDTO entity)
        {
            var shipper = new Shippers
            {
                CompanyName = entity.CompanyName,
                Phone = entity.Phone
            };
            _context.Shippers.Add(shipper);
            _context.SaveChanges();
            return entity;
        }

        public void Update(ShippersDTO entity)
        {
            var shipper = _context.Shippers.FirstOrDefault(x => x.ShipperID == entity.ShipperID);
            if (shipper != null)
            {
                shipper.CompanyName = entity.CompanyName;
                shipper.Phone = entity.Phone;
                _context.SaveChanges();
            }else
            {
                throw new System.Exception("No se encontró el shipper");
            }
        }

        public ShippersDTO GetById(int id)
        {
            var shipper = _context.Shippers.FirstOrDefault(x => x.ShipperID == id);
            if (shipper != null)
            {
                return new ShippersDTO
                {
                    ShipperID = shipper.ShipperID,
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                };
            }
            else
            {
                throw new System.Exception("No se encontró el shipper");
            }
        }
    }
}
