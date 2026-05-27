using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.Interfaces
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        
        List<Movie> GetAll();

        Movie Get(int id);

        Movie Update(Movie movie);

        void Delete(int id);
    }
}
