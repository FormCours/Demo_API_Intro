using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.Models
{
    public class Beer
    {
        //[JsonProperty("MyId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Degree { get; set; }
        public string Brewery { get; set; }
        //[JsonIgnore]
        public string Color { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }


    public class BeerData
    {
        public string Name { get; set; }
        public double Degree { get; set; }
        public string Brewery { get; set; }
        public string Color { get; set; }
        public IEnumerable<CategoryData> Categories { get; set; }
    }

    public class BeerUpdate
    {
        public string Name { get; set; }
        public double Degree { get; set; }
        public string Brewery { get; set; }
        public string Color { get; set; }
    }

    public class BeerUpdatePartial
    {
        public string Name { get; set; }
        public double? Degree { get; set; }
        public string Brewery { get; set; }
        public string Color { get; set; }
    }
}