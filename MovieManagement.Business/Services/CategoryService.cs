using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Business.Services
{
    public class CategoryService
    {
        private ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void AddCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new Exception("O nome da categoria é obrigatório.");
            }

            foreach (Category existingCategory in repository.GetAll())
            {
                if (existingCategory.Name.ToLower() == category.Name.ToLower())
                {
                    throw new Exception("Já existe uma categoria com esse nome.");
                }
            }

            repository.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return repository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return repository.Get(id);
        }

        public void DeleteCategory(int id)
        {
            repository.Delete(id);
        }

        public Category SearchCategoryByName(string name)
        {
            foreach (Category category in repository.GetAll())
            {
                if (category.Name.ToLower() == name.ToLower())
                {
                    return category;
                }
            }

            return null;
        }
    }
}
