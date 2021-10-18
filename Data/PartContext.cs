using InternetPcPartDatabase.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InternetPcPartDatabase.Data
{
    public class PartContext : IdentityDbContext
    {
        public PartContext(Microsoft.EntityFrameworkCore.DbContextOptions<PartContext> options)
            : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Part>? Parts {  get; set; }

       /* public Microsoft.EntityFrameworkCore.DbSet<RegisterViewModel> RegisterViewModel { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<LoginViewModel> LoginViewModel { get; set; }
       */

        // public DbSet
    }
}
