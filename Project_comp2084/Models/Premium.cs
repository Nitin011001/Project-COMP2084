using System.ComponentModel.DataAnnotations;

namespace Project_comp2084.Models
{
    public class Premium
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Packages>?package { get; set; }

    }
}
