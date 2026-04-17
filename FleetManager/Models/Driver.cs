using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace FleetManager.Model
{
    [Table("Drivers")]
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
       
        [RegularExpression("^\\p{Lu}\\p{Ll}+$", ErrorMessage = "Name must be in the format 'Name'.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public required string Name { get; set; }
      
        [RegularExpression("^\\p{Lu}\\p{Ll}+(?:-\\p{Lu}\\p{Ll}+)?$", ErrorMessage = "Surname must be in the format 'Surname' or 'Surname-SecondSurname'.")]
        [MaxLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public required string Surname { get; set; }
        public required DrivingLicences Licence { get; set; }

    }
    public enum  DrivingLicences
    {
        A,
        B,
        C,
        D
    }
}
