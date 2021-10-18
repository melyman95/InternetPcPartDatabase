using InternetPcPartDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Fluent.Infrastructure.FluentModel;

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
