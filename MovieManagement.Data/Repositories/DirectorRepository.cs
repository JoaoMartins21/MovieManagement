using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private List<Director> directors = new List<Director>();

        public void Add(Director director)
        {
            directors.Add(director);
        }

        public List<Director> GetAll()
        {
            return directors;
        }

        public Director Get(int id)
        {
            return directors.Find(d => d.Id == id);
        }

        public void Delete(int id)
        {
            Director director = Get(id);

            if (director != null)
            {
                directors.Remove(director);
            }
        }
    }
}
