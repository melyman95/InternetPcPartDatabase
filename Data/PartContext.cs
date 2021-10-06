using InternetPcPartDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace InternetPcPartDatabase.Data
{
    public class PartContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PartContext(DbContextOptions<PartContext> options)
            : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Part>? Parts {  get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<UserAccount>? UserAccounts {  get; set; }
    }
}
