using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Business.Services
{
    internal class MovieService
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

            repository.Add(movie);

            foreach (Movie existingMovie in repository.GetAll())
            {
                if (existingMovie.Title.ToLower() == movie.Title.ToLower())
                {
                    throw new Exception("Já existe um filme com esse título.");
                }
            }
        }

    }
}
