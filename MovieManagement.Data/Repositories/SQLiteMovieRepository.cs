using Microsoft.Data.Sqlite;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using System.Collections.Generic;

namespace MovieManagement.Data.Repositories
{
    public class SQLiteMovieRepository : IMovieRepository
    {
        private string connectionString = "Data Source=movies.db";

        public SQLiteMovieRepository()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS Movies
                (
                    Id INTEGER PRIMARY KEY,
                    Title TEXT NOT NULL,
                    Year INTEGER,
                    Language TEXT,
                    Rating REAL
                )";

                SqliteCommand command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Add(Movie movie)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO Movies
                               (Id, Title, Year, Language, Rating)
                               VALUES
                               (@Id, @Title, @Year, @Language, @Rating)";

                SqliteCommand command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", movie.Id);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@Year", movie.Year);
                command.Parameters.AddWithValue("@Language", movie.Language);
                command.Parameters.AddWithValue("@Rating", movie.Rating);

                command.ExecuteNonQuery();
            }
        }

        public List<Movie> GetAll()
        {
            List<Movie> movies = new List<Movie>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Movies";

                SqliteCommand command = new SqliteCommand(sql, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Movie movie = new Movie();

                        movie.Id = reader.GetInt32(0);
                        movie.Title = reader.GetString(1);
                        movie.Year = reader.GetInt32(2);
                        movie.Language = reader.GetString(3);
                        movie.Rating = reader.GetDouble(4);

                        movies.Add(movie);
                    }
                }
            }

            return movies;
        }

        public Movie Get(int id)
        {
            return null;
        }

        public Movie Update(Movie movie)
        {
            return movie;
        }

        public void Delete(int id)
        {
        }
    }
}