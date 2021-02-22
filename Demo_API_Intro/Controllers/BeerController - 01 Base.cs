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

        public IEnumerable<Beer> GetAll()
        {
            return BeerService.Instance.GetAll();
        }

        // [AcceptVerbs("GET")]
        [HttpGet] 
        public Beer FindBeerById(int id)
        {
            return BeerService.Instance.Get(id);
        }

        //[AcceptVerbs("POST")]
        [HttpPost]
        public void Insert(Beer beer)
        {
            BeerService.Instance.Insert(beer);
        }

        //[AcceptVerbs("PUT", "PATCH")]
        [HttpPut]
        [HttpPatch]
        public void Update(int id, Beer beer)
        {
            BeerService.Instance.Update(id, beer);
        }

        //[AcceptVerbs("Delete")]
        [HttpDelete]
        public void Delete(int id)
        {
            BeerService.Instance.Delete(id);
        }
    }
    */
}
