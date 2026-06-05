using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);

        List<Category> GetAll();

        Category Get(int id);

        void Delete(int id);
    }
}
