using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> categories = new List<Category>();

        public void Add(Category category)
        {
            categories.Add(category);
        }

        public List<Category> GetAll()
        {
            return categories;
        }

        public Category Get(int id)
        {
            return categories.Find(c => c.Id == id);
        }

        public void Delete(int id)
        {
            Category category = Get(id);

            if (category != null)
            {
                categories.Remove(category);
            }
        }
    }
}
