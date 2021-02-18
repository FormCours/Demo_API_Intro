using Demo_API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ServiceData
{
    public class BeerService
    {
        #region Singleton
        private static Lazy<BeerService> _Instance = new Lazy<BeerService>(() => new BeerService());
        public static BeerService Instance { get { return _Instance.Value; } }
        #endregion

        #region FakeData
        private static List<Beer> Beers = new List<Beer>()
        {
            new Beer() {Id= 1, Name = "Triple karmeliet", Brewery="Brasserie Bosteels", Degree=8.4, Color="Blonde"},
            new Beer() {Id= 2, Name = "Chimay Bleue", Brewery="Abbaye Notre-Dame de Scourmont", Degree=9, Color="Brune"},
            new Beer() {Id= 3, Name = "Big Mama", Brewery="Novabirra", Degree=8, Color="Noire"},
            new Beer() {Id= 4, Name = "Delta IPA", Brewery="BBP", Degree=6.5, Color="Ambrée"}
        };
        #endregion

        private BeerService()
        { }


        public IEnumerable<Beer> GetAll()
        {
            return Beers.AsEnumerable();
        }

        public Beer Get(int id)
        {
            return Beers.SingleOrDefault(b => b.Id == id);
        }

        public Beer Insert(Beer beer)
        {
            int newId = Beers.Max(b => b.Id) + 1;

            beer.Id = newId;
            Beers.Add(beer);

            return beer;
        }

        public bool Update(int id, Beer beer)
        {
            Beer target = Beers.Single(b => b.Id == id);

            if (target != null)
            {
                target.Name = beer.Name;
                target.Brewery = beer.Brewery;
                target.Degree = beer.Degree;
                target.Color = beer.Color;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            int nbrow = Beers.RemoveAll(b => b.Id == id);

            return nbrow == 1;
        }
    }
}