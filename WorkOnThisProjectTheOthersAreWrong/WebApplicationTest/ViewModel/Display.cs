using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApplicationTest.Models;

namespace WebApplicationTest.ViewModel
{
    public class Display
    {
        [Key]
        public int id { get; set; }

        public List <Pics> pics {  get; set; }

        public List<IdentityUser> IUser { get; set; }
    }
}
