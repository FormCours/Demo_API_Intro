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
    [RoutePrefix("api/Beer")]
    public class BeerController : ApiController
    {
        // Comportement naturel du routing en fonction du Protocol, le nom de l'action doit commencer par : 
        //  - GET    => Get
        //  - POST   => Post, Insert, Add
        //  - PUT    => Put
        //  - PATCH  => Patch
        //  - DELETE => Delete

        // Influencer le comportement du routing à l'aide des attributs :
        //  - AcceptVerbs(...)
        //  - HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete

        // Bonne pratique : Renvoyer des "IHttpActionResult" avec le type de retour adapté.

        [HttpGet]
        public IHttpActionResult FindAll()
        {
            IEnumerable<Beer> beers = BeerService.Instance.GetAll();

            return Json(beers);
        }

        [HttpGet]
        public IHttpActionResult FindBeerById(int id)
        {
            Beer beer = BeerService.Instance.Get(id);

            if (beer == null)
                return NotFound();

            return Json(beer);
        }


        [HttpGet]
        [Route("GetByCategories")]
        public IHttpActionResult FindBeerByCategories([FromUri] string[] categories)
        {
            IEnumerable<string> categoriesSearch = categories.Select(s => s.ToLower());

            IEnumerable<Beer> result = BeerService.Instance.GetAll()
                .Where(b => b.Categories.Any(c => categoriesSearch.Contains(c.Name.ToLower())));

            return Json(result);
        }


        [HttpPost]
        public IHttpActionResult Insert(BeerData beer)
        {
            // Gestion des categories de biere
            List<Category> categoriesInsert = new List<Category>();

            if (beer.Categories != null)
            {
                IEnumerable<Category> categories = CategoryService.Instance.GetAll();

                foreach (CategoryData categoryData in beer.Categories)
                {
                    Category category = categories.SingleOrDefault(c => c.Name.Trim().ToLower() == categoryData.Name.Trim().ToLower());
                    if (category == null)
                    {
                        category = CategoryService.Instance.Insert(new Category() { Name = categoryData.Name });
                    }
                    categoriesInsert.Add(category);
                }
            }

            // Mapping de la biere
            Beer beerInsert = new Beer()
            {
                Name = beer.Name,
                Brewery = beer.Brewery,
                Color = beer.Color,
                Degree = beer.Degree,
                Categories = categoriesInsert
            };

            // Ajout de la biere en DB
            Beer beerDB = BeerService.Instance.Insert(beerInsert);
            return Json(beerDB);
        }

        [HttpPut]
        public IHttpActionResult FullUpdate(int id, BeerUpdate beer)
        {
            if (BeerService.Instance.Get(id) == null)
                return NotFound();

            Beer beerUpdate = new Beer()
            {
                Name = beer.Name,
                Brewery = beer.Brewery,
                Color = beer.Color,
                Degree = beer.Degree
            };

            BeerService.Instance.Update(id, beerUpdate);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        public IHttpActionResult PartialUpdate(int id, BeerUpdatePartial beer)
        {
            Beer beerDB = BeerService.Instance.Get(id);

            if (beerDB == null)
                return NotFound();

            Beer beerUpdate = new Beer()
            {
                Name = beer.Name ?? beerDB.Name,
                Brewery = beer.Brewery ?? beerDB.Brewery,
                Color = beer.Color ?? beerDB.Color,
                Degree = beer.Degree ?? beerDB.Degree
            };

            BeerService.Instance.Update(id, beerUpdate);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool isOk = BeerService.Instance.Delete(id);

            if (isOk)
                return Ok();

            return NotFound();
        }



        [HttpPost]
        [Route("{id}/AddCategory/{idCategory}")]
        public IHttpActionResult AddCategory(int id, int idCategory)
        {
            Beer beer = BeerService.Instance.Get(id);

            if (beer == null)
                return BadRequest($"The beer '{id}' dont exists !");

            Category categoryAdd = CategoryService.Instance.GetAll().SingleOrDefault(c => c.Id == idCategory);

            if (categoryAdd == null)
                return BadRequest($"The category '{idCategory}' dont exists !");

            if (beer.Categories.Any(c => c.Id == categoryAdd.Id))
                return BadRequest($"The category '{idCategory}' is already add'");


            ((List<Category>)beer.Categories).Add(categoryAdd);
            return Json(beer);
        }

        [HttpPost]
        [Route("{id}/RemoveCategory/{idCategory}")]
        public IHttpActionResult RemoveCategory(int id, int idCategory)
        {
            Beer beer = BeerService.Instance.Get(id);

            if (beer == null)
                return BadRequest($"The beer '{id}' dont exists !");

            Category categoryRemove = CategoryService.Instance.GetAll().SingleOrDefault(c => c.Id == idCategory);

            if (categoryRemove == null)
                return BadRequest($"The category '{idCategory}' dont exists !");

            if (!beer.Categories.Any(c => c.Id == categoryRemove.Id))
                return BadRequest($"The category '{idCategory}' is not add'");

            ((List<Category>)beer.Categories).RemoveAll(c => c.Id == categoryRemove.Id);
            return Json(beer);
        }
    }
}
