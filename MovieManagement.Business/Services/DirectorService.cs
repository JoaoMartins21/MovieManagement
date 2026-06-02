using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Business.Services
{
    public class DirectorService
    {
        private IDirectorRepository repository;

        public DirectorService(IDirectorRepository repository)
        {
            this.repository = repository;
        }

        public void AddDirector(Director director)
        {
            if (string.IsNullOrWhiteSpace(director.Name))
            {
                throw new Exception("O nome do realizador é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(director.Country))
            {
                throw new Exception("O país do realizador é obrigatório.");
            }

            repository.Add(director);
        }

        public List<Director> GetAllDirectors()
        {
            return repository.GetAll();
        }

        public Director GetDirector(int id)
        {
            return repository.Get(id);
        }

        public void DeleteDirector(int id)
        {
            repository.Delete(id);
        }
    }
}
