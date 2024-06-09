
using Microsoft.EntityFrameworkCore;
using static YtApis.Modal.AppDbModal;

namespace YtApis.Modal
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {

        }
        public virtual DbSet<Users> Users { get; set; }
    }
}
