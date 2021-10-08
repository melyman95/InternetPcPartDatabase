using InternetPcPartDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetPcPartDatabase.Data
{
    public class PartContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PartContext(Microsoft.EntityFrameworkCore.DbContextOptions<PartContext> options)
            : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Part>? Parts {  get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<UserAccount>? UserAccounts {  get; set; }

        public DbSet<InternetPcPartDatabase.Models.RegisterViewModel> RegisterViewModel { get; set; }

        public DbSet<InternetPcPartDatabase.Models.LoginViewModel> LoginViewModel { get; set; }
    }
}
