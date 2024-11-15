using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Models;

namespace WebApplicationTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplicationTest.Models.User> User { get; set; } = default!;
        public DbSet<WebApplicationTest.Models.OurPicUploads> OurPicUpload { get; set; } = default!;
        //public DbSet<WebApplicationTest.Models.Pics> Pics { get; set; } = default!;
    }
}
