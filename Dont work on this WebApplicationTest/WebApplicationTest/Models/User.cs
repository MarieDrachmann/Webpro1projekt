using System.ComponentModel.DataAnnotations;

namespace WebApplicationTest.Models
{
    public class User
    {
        [RegularExpression("")] //her skriver man RegEx
        public int id { get; set; }

        [Required] //Gør at man skal skrive det ind
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
