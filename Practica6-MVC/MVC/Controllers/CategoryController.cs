using MVC.Models;
using Practica6_MVC.Logic;
using Practica6_MVC.Logic.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesLogic categories = new CategoriesLogic();

        // GET: Category
        public ActionResult Index()
        {
            var result = categories.GetAll();

            List<CategoriesView> categoriesView = result.Select(x => new CategoriesView
            {
                Id = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();

            return View(categoriesView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoriesView categoriesView)
        {
            try
            {
                var category = new CategoriesDTO
                {
                    CategoryName = categoriesView.Name,
                    Description = categoriesView.Description
                };
                categories.Insert(category);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = ex.Message
                };
                return RedirectToAction("Index","Error", errorViewModel);
            }
        }

        // POST: DeleteCategory
        public ActionResult Delete(int id)
        {
            try
            {
                categories.Delete(id);
                return Json(new { success = true });
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(CategoriesView categoriesView)
        {
            try
            {
                var category = new CategoriesDTO
                {
                    CategoryID = categoriesView.Id,
                    CategoryName = categoriesView.Name,
                    Description = categoriesView.Description
                };
                categories.Update(category);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Update(int id)
        {
            var result = categories.GetById(id);

            CategoriesView categoriesView = new CategoriesView
            {
                Id = result.CategoryID,
                Name = result.CategoryName,
                Description = result.Description
            };

            return View(categoriesView);
        }

        public ActionResult singleCagegory(int id)
        {
            var result = categories.GetById(id);

            CategoriesView categoriesView = new CategoriesView
            {
                Id = result.CategoryID,
                Name = result.CategoryName,
                Description = result.Description
            };

            return View(categoriesView);
        }
    }
}