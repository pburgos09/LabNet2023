using Practica3.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica3.EF.Logic
{
    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {

        public CategoriesLogic() : base()
        {
        }

        public void Delete(Categories entity)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryID == entity.CategoryID);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Categories Insert(Categories entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(Categories entity)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryID == entity.CategoryID);
            if (category != null)
            {
                category.CategoryName = entity.CategoryName;
                category.Description = entity.Description;
                category.Picture = entity.Picture;
                _context.SaveChanges();
            }
        }
    }
}
