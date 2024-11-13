using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTest.Models
{
    public class Pics
    {
        [Key]
        public int Id { get; set; }

        public string? title { get; set; }

        public string? description { get; set; }

        
        public  string? picPath {  get; set; }

        
        [NotMapped]
        public required IFormFile picFile { get; set; }

        public required string foreign { get; set; }
    }
}
