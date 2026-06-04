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

            CategoryRepository categoryRepository = new CategoryRepository();
            CategoryService categoryService = new CategoryService(categoryRepository);

            DirectorRepository directorRepository = new DirectorRepository();
            DirectorService directorService = new DirectorService(directorRepository);

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
                Console.WriteLine("* 5 - Adicionar Categoria              *");
                Console.WriteLine("* 6 - Listar Categorias                *");
                Console.WriteLine("* 7 - Procurar Categoria               *");
                Console.WriteLine("* 8 - ~Remover Categoria               *");
                Console.WriteLine("* 9 - Adicionar Realizador             *");
                Console.WriteLine("* 10 - Listar Realizadores             *");
                Console.WriteLine("* 11 - Procurar Realizador             *");
                Console.WriteLine("* 12 - Remover Realizador              *");
                Console.WriteLine("* 0 - Sair                             *");
                Console.WriteLine("|======================================|");
                Console.WriteLine();

                Console.Write("Opção: ");
                option = Console.ReadLine();

                switch (option)
                {

                    // CASE 1
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


                    // CASE 2
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


                    // CASE 3
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



                    // CASE 8
                    case "4":

                        Console.Clear();
                        Console.Write("Id do filme a remover: ");

                        int id = int.Parse(Console.ReadLine());

                        service.DeleteMovie(id);

                        Console.WriteLine();
                        Console.WriteLine("✓ Filme removido com sucesso!");

                        break;


                    // CASE 5
                    case "5":

                        Console.Clear();
                        Console.WriteLine("=== Adicionar Categoria ===");
                        Console.WriteLine();

                        Category category = new Category();

                        Console.Write("Id: ");
                        category.Id = int.Parse(Console.ReadLine());

                        Console.Write("Nome: ");
                        category.Name = Console.ReadLine();

                        try
                        {
                            categoryService.AddCategory(category);

                            Console.WriteLine();
                            Console.WriteLine("✓ Categoria adicionada com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"✗ Erro: {ex.Message}");
                        }

                        break;

                    // CASE 6
                    case "6":

                        Console.Clear();
                        Console.WriteLine("=== Lista de Categorias ===");
                        Console.WriteLine();

                        List<Category> categories = categoryService.GetAllCategories();

                        if (categories.Count == 0)
                        {
                            Console.WriteLine("Não existem categorias registadas.");
                        }
                        else
                        {
                            foreach (Category c in categories)
                            {
                                Console.WriteLine($"Id: {c.Id}");
                                Console.WriteLine($"Nome: {c.Name}");
                                Console.WriteLine("----------------------------------------");
                            }
                        }

                        break;

                    // CASE 7
                    case "7":

                        Console.Clear();
                        Console.WriteLine("=== Procurar Categoria ===");
                        Console.WriteLine();

                        Console.Write("Nome da categoria: ");
                        string categoryName = Console.ReadLine();

                        Category foundCategory = categoryService.SearchCategoryByName(categoryName);

                        Console.WriteLine();

                        if (foundCategory != null)
                        {
                            Console.WriteLine($"Id: {foundCategory.Id}");
                            Console.WriteLine($"Nome: {foundCategory.Name}");
                        }
                        else
                        {
                            Console.WriteLine("Categoria não encontrada.");
                        }

                        break;


                    // CASE 8
                    case "8":

                        Console.Clear();

                        Console.Write("Id da categoria a remover: ");

                        int categoryId = int.Parse(Console.ReadLine());

                        Category categoryToDelete = categoryService.GetCategory(categoryId);

                        if (categoryToDelete != null)
                        {
                            categoryService.DeleteCategory(categoryId);

                            Console.WriteLine();
                            Console.WriteLine("✓ Categoria removida com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("✗ Categoria não encontrada.");
                        }

                        break;

                    //CASE 9
                    case "9":

                        Console.Clear();
                        Console.WriteLine("=== Adicionar Realizador ===");
                        Console.WriteLine();

                        Director director = new Director();

                        Console.Write("Id: ");
                        director.Id = int.Parse(Console.ReadLine());

                        Console.Write("Nome: ");
                        director.Name = Console.ReadLine();

                        Console.Write("País: ");
                        director.Country = Console.ReadLine();

                        try
                        {
                            directorService.AddDirector(director);

                            Console.WriteLine();
                            Console.WriteLine("✓ Realizador adicionado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"✗ Erro: {ex.Message}");
                        }

                        break;


                    // CASE 10
                    case "10":

                        Console.Clear();
                        Console.WriteLine("=== Lista de Realizadores ===");
                        Console.WriteLine();

                        List<Director> directors = directorService.GetAllDirectors();

                        if (directors.Count == 0)
                        {
                            Console.WriteLine("Não existem realizadores registados.");
                        }
                        else
                        {
                            foreach (Director d in directors)
                            {
                                Console.WriteLine($"Id: {d.Id}");
                                Console.WriteLine($"Nome: {d.Name}");
                                Console.WriteLine($"País: {d.Country}");
                                Console.WriteLine("----------------------------------------");
                            }
                        }

                        break;



                    // CASE 11
                    case "11":

                        Console.Clear();
                        Console.WriteLine("=== Procurar Realizador ===");
                        Console.WriteLine();

                        Console.Write("Nome do realizador: ");
                        string directorName = Console.ReadLine();

                        Director foundDirector = directorService.SearchDirectorByName(directorName);

                        Console.WriteLine();

                        if (foundDirector != null)
                        {
                            Console.WriteLine($"Id: {foundDirector.Id}");
                            Console.WriteLine($"Nome: {foundDirector.Name}");
                            Console.WriteLine($"País: {foundDirector.Country}");
                        }
                        else
                        {
                            Console.WriteLine("Realizador não encontrado.");
                        }

                        break;


                    // CASE 12
                    case "12":

                        Console.Clear();

                        Console.Write("Id do realizador a remover: ");

                        int directorId = int.Parse(Console.ReadLine());

                        Director directorToDelete = directorService.GetDirector(directorId);

                        if (directorToDelete != null)
                        {
                            directorService.DeleteDirector(directorId);

                            Console.WriteLine();
                            Console.WriteLine("✓ Realizador removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("✗ Realizador não encontrado.");
                        }

                        break;





                    // CASE 0
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
