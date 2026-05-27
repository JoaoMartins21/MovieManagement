using System;
using System.Collections.Generic;
using System.Text;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private List<Movie> movies = new List<Movie>();

        public void Add(Movie movie)
        {
            movies.Add(movie);
        }

        public List<Movie> GetAll()
        {
            return movies;
        }

        public Movie Get(int id)
        {
            return movies.Find(m => m.Id == id);
        }

        public Movie Update(Movie movie)
        {
            Movie existingMovie = Get(movie.Id);

            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Year = movie.Year;
                existingMovie.Language = movie.Language;
                existingMovie.Rating = movie.Rating;
            }
            return existingMovie;
        }
        public void Delete(int id)
        {
            Movie movie = Get(id);

            if (movie != null)
            {
                movies.Remove(movie);
            }
        }
    }
}
