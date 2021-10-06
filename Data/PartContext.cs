using InternetPcPartDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetPcPartDatabase.Data
{
    public class PartContext : DbContext
    {
        public PartContext(DbContextOptions<PartContext> options)
            : base(options)
        {

        }

        public DbSet<Part> Parts {  get; set; }
    }
}
