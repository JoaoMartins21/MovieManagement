using MovieManagement.Business.Services;
using MovieManagement.Data.Repositories;
using MovieManagement.Domain.Entities;

namespace MovieManagement.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieRepository repository = new MovieRepository();
            MovieService service = new MovieService(repository);

            string option = "";

            while (option != "0")
            {
                Console.Clear();

                Console.WriteLine("|======================================|");
                Console.WriteLine("*         MOVIE MANAGEMENT             *");
                Console.WriteLine("|======================================|");
                Console.WriteLine("* 1 - Adicionar Filme                  *");
                Console.WriteLine("* 2 - Listar Filmes                    *");
                Console.WriteLine("* 3 - Procurar Filme                   *");
                Console.WriteLine("* 4 - Remover Filme                    *");
                Console.WriteLine("* 0 - Sair                             *");
                Console.WriteLine("|======================================|");
                Console.WriteLine();

                Console.Write("Opção: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        Console.Clear();
                        Console.WriteLine("=== Adicionar Filme ===");
                        Console.WriteLine();

                        Movie movie = new Movie();

                        Console.Write("Id: ");
                        movie.Id = int.Parse(Console.ReadLine());

                        Console.Write("Título: ");
                        movie.Title = Console.ReadLine();

                        Console.Write("Ano: ");
                        movie.Year = int.Parse(Console.ReadLine());

                        Console.Write("Língua: ");
                        movie.Language = Console.ReadLine();

                        Console.Write("Classificação (0-5): ");
                        movie.Rating = double.Parse(Console.ReadLine());

                        try
                        {
                            service.AddMovie(movie);
                            Console.WriteLine();
                            Console.WriteLine("✓ Filme adicionado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"✗ Erro: {ex.Message}");
                        }

                        break;

                    case "2":

                        Console.Clear();
                        Console.WriteLine("=== Lista de Filmes ===");
                        Console.WriteLine();

                        List<Movie> movies = service.GetAllMovies();

                        if (movies.Count == 0)
                        {
                            Console.WriteLine("Não existem filmes registados.");
                        }
                        else
                        {
                            foreach (Movie m in movies)
                            {
                                Console.WriteLine($"Id: {m.Id}");
                                Console.WriteLine($"Título: {m.Title}");
                                Console.WriteLine($"Ano: {m.Year}");
                                Console.WriteLine($"Língua: {m.Language}");
                                Console.WriteLine($"Classificação: {m.Rating}");
                                Console.WriteLine("----------------------------------------");
                            }
                        }

                        break;

                    case "3":

                        Console.Clear();
                        Console.WriteLine("=== Procurar Filme ===");
                        Console.WriteLine();

                        Console.Write("Título do filme: ");
                        string title = Console.ReadLine();

                        Movie foundMovie = service.SearchMovieByTitle(title);

                        Console.WriteLine();

                        if (foundMovie != null)
                        {
                            Console.WriteLine($"Id: {foundMovie.Id}");
                            Console.WriteLine($"Título: {foundMovie.Title}");
                            Console.WriteLine($"Ano: {foundMovie.Year}");
                            Console.WriteLine($"Língua: {foundMovie.Language}");
                            Console.WriteLine($"Classificação: {foundMovie.Rating}");
                        }
                        else
                        {
                            Console.WriteLine("Filme não encontrado.");
                        }

                        break;

                    case "4":

                        Console.Clear();
                        Console.Write("Id do filme a remover: ");

                        int id = int.Parse(Console.ReadLine());

                        service.DeleteMovie(id);

                        Console.WriteLine();
                        Console.WriteLine("✓ Filme removido com sucesso!");

                        break;

                    case "0":

                        Console.WriteLine("A terminar aplicação...");
                        break;

                    default:

                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (option != "0")
                {
                    Console.WriteLine();
                    Console.WriteLine("Prima qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
