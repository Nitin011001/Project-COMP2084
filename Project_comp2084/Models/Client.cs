using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_comp2084.Models
{
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Please provide valid Package Name"), MinLength(5, ErrorMessage = "Please provide valid Name and atleast greater than 5 char")]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Please provide valid Package Name"), MinLength(5, ErrorMessage = "Please provide valid Location and atleast greater than 5 char")]
        public string Location { get; set; }

        [ForeignKey("Vehicle")]
        public int? VehicleId { get; set; }

        public Vehicle? Vehicle { get; set; }



    }
}
