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
    /*
    public class BeerController : ApiController
    {
        // Comportement naturel du routing en fonction du Protocol, le nom de l'action doit commencer par : 
        //  - GET    => Get
        //  - POST   => Post, Insert, Add
        //  - PUT    => Put
        //  - PATCH  => Patch
        //  - Delete => Delete

        // Influencer le comportement du routing à l'aide des attributs :
        //  - AcceptVerbs(...)
        //  - HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete

        // Bonne pratique : Renvoyer des "IHttpActionResult" avec le type de retour adapté.

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            IEnumerable<Beer> beers = BeerService.Instance.GetAll();

            return Json(beers);
        }

        [HttpGet] 
        public IHttpActionResult FindBeerById(int id)
        {
            Beer beer = BeerService.Instance.Get(id);

            return Json(beer);
        }

        [HttpPost]
        public IHttpActionResult Insert(Beer beer)
        {
            Beer beerDB = BeerService.Instance.Insert(beer);

            return Json(beerDB);
        }

        [HttpPut]
        [HttpPatch]
        public IHttpActionResult Update(int id, Beer beer)
        {
            if(BeerService.Instance.Get(id) == null)
                return NotFound();

            BeerService.Instance.Update(id, beer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool isOk = BeerService.Instance.Delete(id);

            if(isOk)
                return Ok();

            return NotFound();
        }
    }
    */
}
