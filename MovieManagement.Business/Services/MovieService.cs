using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Business.Services
{
    public class MovieService
    {
        private IMovieRepository repository;

        public MovieService(IMovieRepository repository)
        {
            this.repository = repository;
        }

        public void AddMovie(Movie movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new Exception("O título é obrigatório.");
            }

            if (movie.Rating < 0 || movie.Rating > 5)
            {
                throw new Exception("A classificação deve estar entre 0 e 5.");
            }

            foreach (Movie existingMovie in repository.GetAll())
            {
                if (existingMovie.Title.ToLower() == movie.Title.ToLower())
                {
                    throw new Exception("Já existe um filme com esse título.");
                }
            }

            repository.Add(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return repository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return repository.Get(id);
        }

        public Movie SearchMovieByTitle(string title)
        {
            foreach (Movie movie in repository.GetAll())
            {
                if (movie.Title.ToLower() == title.ToLower())
                {
                    return movie;
                }
            }

            return null;
        }

        public void DeleteMovie(int id)
        {
            repository.Delete(id);
        }
    }
}