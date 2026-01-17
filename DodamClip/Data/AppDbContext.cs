using Microsoft.EntityFrameworkCore;

namespace DodamClip.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    }

}
