using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTest.Models
{
    public class Pics
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Title of picture")]
        public string? title { get; set; }
		[DisplayName("Discription of picture")]
		public string? description { get; set; }
		
		public  string? picPath {  get; set; }

		[DisplayName("Picture to upload")]
		[NotMapped]
        public required IFormFile picFile { get; set; }

        public required string foreign { get; set; }
    }
}
