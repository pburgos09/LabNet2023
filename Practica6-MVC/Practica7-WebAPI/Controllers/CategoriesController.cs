﻿using Practica6_MVC.Logic;
using Practica6_MVC.Logic.DTO;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Practica7_WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {
        CategoriesLogic CategoriesLogic = new CategoriesLogic();

        // GET: api/Categories
        public IHttpActionResult GetCategories()
        {
            try
            {
                var result = CategoriesLogic.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Categories/5

        public IHttpActionResult GetCategories([FromUri] int id)
        {
            try
            {
                var result = CategoriesLogic.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST : api/Categories

        public IHttpActionResult PostCategories([FromBody] CategoriesDTO categoriesDTO)
        {
            try
            {
                var newCategory = CategoriesLogic.Insert(categoriesDTO);
                return Ok(newCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT : api/Categories/5

        public IHttpActionResult PutCategories([FromUri] int id, [FromBody] CategoriesDTO categoriesDTO)
        {
            try
            {
                var updateCategory = new CategoriesDTO
                {
                    CategoryID = id,
                    CategoryName = categoriesDTO.CategoryName,
                    Description = categoriesDTO.Description
                };
                CategoriesLogic.Update(updateCategory);
                return Ok(updateCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE : api/Categories/5

        public IHttpActionResult DeleteCategories([FromUri] int id)
        {
            try
            {
                CategoriesLogic.Delete(id);
                return Ok("Categoria eliminada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}