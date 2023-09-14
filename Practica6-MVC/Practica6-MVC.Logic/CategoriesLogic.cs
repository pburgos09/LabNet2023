using Practica6_MVC.Entities;
using Practica6_MVC.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica6_MVC.Logic
{
    public class CategoriesLogic : BaseLogic, ILogic<CategoriesDTO>
    {
        public CategoriesLogic() : base()
        {
        }
        public List<CategoriesDTO> GetAll()
        {
            try
            {
                return _context.Categories.Select(x => new CategoriesDTO
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName,
                    Description = x.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las categorías:{ex.Message}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.CategoryID == id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new System.Exception("No se encontró la categoría");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la categoría:{ex.Message}");
            }
        }

        public CategoriesDTO Insert(CategoriesDTO entity)
        {
            try
            {
                if(entity.CategoryName == "" || entity.Description == "")
                {
                    throw new ArgumentException("No se puede insertar una categoría con campos vacios");
                }
                if (entity.CategoryName.Length <= 15)
                {
                    var category = new Categories
                    {
                        CategoryName = entity.CategoryName,
                        Description = entity.Description,
                        Picture = null
                    };
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    return entity;
                }
                else
                {
                    throw new ArgumentException("El nombre de la categoría no puede tener más de 15 caracteres");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar la categoría: {ex.Message}");
            }
        }

        public void Update(CategoriesDTO entity)
        {
            try
            {
                if(entity.CategoryName == "" || entity.Description == "")
                {
                    throw new ArgumentException("No se puede actualizar una categoría con campos nulos");
                }
                var category = _context.Categories.FirstOrDefault(x => x.CategoryID == entity.CategoryID);
                if (category != null)
                {
                    if (entity.CategoryName.Length <= 15)
                    {
                        category.CategoryName = entity.CategoryName;
                        category.Description = entity.Description;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentException("El nombre de la categoría no puede tener más de 15 caracteres");
                    }
                }
                else
                {
                    throw new System.Exception("No se encontró la categoría");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la categoría: {ex.Message}");
            }
        }

        public CategoriesDTO GetById(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.CategoryID == id);
                if (category != null)
                {
                    return new CategoriesDTO
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        Description = category.Description
                    };
                }
                else
                {
                    throw new System.Exception("No se encontró la categoría");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la categoría: {ex.Message}");
            }
        }
    }
}
