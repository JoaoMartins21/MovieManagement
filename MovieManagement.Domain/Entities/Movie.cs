using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.Entities
{
    public class Movie
    {
        public int Id {  get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Language { get; set; }

        public double Rating { get; set; }


    }
}
