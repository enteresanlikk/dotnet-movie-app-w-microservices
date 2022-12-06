using Movies.API.Models;

namespace Movies.API.Data;

public static class MoviesContextSeed
{
    public static void SeedAsync(MoviesAPIContext moviesContext)
    {
        if (!moviesContext.Movies.Any())
        {
            var movies = new List<Movie>() {
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    Genre = "Drama",
                    Rating = "9.5",
                    ReleaseDate = new DateTime(1994, 10, 14),
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg",
                    Owner = "admin"
                },
                new Movie
                {
                    Title = "The Godfather",
                    Genre = "Drama",
                    Rating = "9.0",
                    ReleaseDate = new DateTime(1972, 3, 24),
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg",
                    Owner = "user"
                },
                new Movie
                {
                    Title = "The Godfather: Part II",
                    Genre = "Drama",
                    Rating = "9.2",
                    ReleaseDate = new DateTime(1974, 12, 20),
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/02/Godfather_part_ii.jpg",
                    Owner = "admin"
                },
                new Movie
                {
                    Title = "The Dark Knight",
                    Genre = "Action",
                    Rating = "10",
                    ReleaseDate = new DateTime(2008, 7, 18),
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/Dark_Knight.jpg",
                    Owner = "admin"
                }
            };

            moviesContext.Movies.AddRange(movies);
            moviesContext.SaveChanges();
        }
    }
}
