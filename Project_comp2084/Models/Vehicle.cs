using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_comp2084.Models
{
    public class Vehicle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Please provide valid Package Name"), MinLength(5, ErrorMessage = "Please provide valid Name and atleast greater than 5 char")]
        public string type { get; set; }
        [Required]
        [Range(09,999)]
        public int Cost { get; set; }

    }
}
