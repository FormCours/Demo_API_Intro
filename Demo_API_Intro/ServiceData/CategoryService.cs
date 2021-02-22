using Demo_API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ServiceData
{
    public class CategoryService
    {
        #region Singleton
        private static Lazy<CategoryService> _Instance = new Lazy<CategoryService>(() => new CategoryService());
        public static CategoryService Instance { get { return _Instance.Value; } }
        #endregion

        #region Fake Data
        private static List<Category> Categories = new List<Category>()
        {
            new Category() {Id = 1, Name = "Triple"},
            new Category() {Id = 2, Name = "Spécial"},
            new Category() {Id = 3, Name = "Trapiste"},
            new Category() {Id = 4, Name = "Stout"},
            new Category() {Id = 5, Name = "Pils"},
            new Category() {Id = 6, Name = "Abbaye"},
            new Category() {Id = 7, Name = "Fruité"},
            new Category() {Id = 8, Name = "Blanche"},
            new Category() {Id = 9, Name = "Pale lager"},
        };
        #endregion

        private CategoryService()
        { }

        #region Crud
        public IEnumerable<Category> GetAll()
        {
            return Categories.AsEnumerable();
        }

        public Category Get(int id)
        {
            return Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category Insert(Category category)
        {
            int newId = Categories.Max(c => c.Id) + 1;
            category.Id = newId;

            Categories.Add(category);
            return category;
        }

        public bool Update(int id, Category category)
        {
            Category target = Categories.SingleOrDefault(c => c.Id == id);

            if(target != null)
            {
                target.Name = category.Name;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            int nbRow = Categories.RemoveAll(c => c.Id == id);

            return nbRow == 1;
        }
        #endregion
    }
}