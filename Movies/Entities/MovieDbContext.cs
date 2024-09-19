using Microsoft.EntityFrameworkCore;

namespace Movies.Entities
{
	public class MovieDbContext : DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
		{

		}

		public DbSet<Movie> Movies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().HasData(
				new Movie() { MovieId = 1, Name = "Movie 1", Year = 2024, Rating = 5 },
				new Movie() { MovieId = 2, Name = "Movie 2", Year = 2022, Rating = 4 },
				new Movie() { MovieId = 3, Name = "Movie 3", Year = 2023, Rating = 4 },
				new Movie() { MovieId = 4, Name = "Movie 4", Year = 2021, Rating = 3 }
				);
		}
	}
}
