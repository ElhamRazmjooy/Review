using System.ComponentModel.DataAnnotations;

namespace FiltersSample.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(18, 100)]
        public int Age { get; set; }
    }
}
