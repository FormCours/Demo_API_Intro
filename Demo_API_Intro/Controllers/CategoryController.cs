using Demo_API_Intro.Models;
using Demo_API_Intro.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_API_Intro.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FindAll()
        {
            IEnumerable<Category> categories = CategoryService.Instance.GetAll();

            return Json(categories);
        }


        [HttpGet]
        public IHttpActionResult Find(int id)
        {
            Category category = CategoryService.Instance.Get(id);

            if(category == null)
            {
                return NotFound();
            }
            return Json(category);
        }


        [HttpPost]
        public IHttpActionResult InsertCategory(CategoryData category)
        {
            Category categoryAlreadyExists = CategoryService.Instance.GetAll()
                .FirstOrDefault(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());

            if(categoryAlreadyExists != null)
            {
                return BadRequest($"Category {category.Name} already exists!");
            }

            Category categoryInsert = new Category()
            {
                Name = category.Name
            };

            Category categorySave = CategoryService.Instance.Insert(categoryInsert);
            return Json(categorySave);
        }


        [HttpPut, HttpPatch]
        public IHttpActionResult UpdateCategory(int id, CategoryData category)
        {
            if(CategoryService.Instance.Get(id) == null)
            {
                return NotFound();
            }

            Category categoryUpdate = new Category()
            {
                Name = category.Name
            };

            CategoryService.Instance.Update(id, categoryUpdate);
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpDelete] 
        public IHttpActionResult RemoveCategory(int id)
        {
            bool isOk = CategoryService.Instance.Delete(id);

            if (isOk)
                return Ok();

            return NotFound();
        }
    }
}
