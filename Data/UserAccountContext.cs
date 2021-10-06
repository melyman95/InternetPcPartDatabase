using Microsoft.EntityFrameworkCore;

namespace InternetPcPartDatabase.Data
{
    public class UserAccountContext : DbContext
    {
        public UserAccountContext(DbContextOptions<UserAccountContext> options)
            : base(options)
        {

        }
    }
}
