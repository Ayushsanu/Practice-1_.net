using System.ComponentModel.DataAnnotations;

namespace Practice_1.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int budget {  get; set; }
    }
}
