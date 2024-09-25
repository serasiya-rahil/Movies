using System.ComponentModel.DataAnnotations;

namespace Movies.Entities
{
    public class Movie
    {


        public int MovieId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Year { get; set; }

        [Required]
        public int? Rating { get; set; }
    }
}
