using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.Interfaces
{
    public interface IDirectorRepository
    {
        void Add(Director director);

        List<Director> GetAll();

        Director Get(int id);

        void Delete(int id);
    }
}
