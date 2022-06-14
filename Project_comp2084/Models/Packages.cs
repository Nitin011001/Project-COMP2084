using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_comp2084.Models
{
    public class Packages
    {
   

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Please provide valid Package Name"), MinLength(5, ErrorMessage = "Please provide valid Categorie and atleast greater than 5 char")]
        public string PackageName { get; set; }
        [Required]
        [Range(200,3999)]
        public int Price { get; set; }
        public string Description
        {
            get { return $"{ PackageName} - {Price}"; }
        }
        [ForeignKey("Premium")]
        public int? PremiumId { get; set; }

        public Premium?Premium { get; set; }
    }
}
