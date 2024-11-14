using System.ComponentModel.DataAnnotations;

namespace WebApplicationTest.Models
{
    public class User
    {
        
        public int id { get; set; }

        //[RegularExpression("")] her skriver man RegEx
        [Required] //Gør at man skal skrive det ind
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
