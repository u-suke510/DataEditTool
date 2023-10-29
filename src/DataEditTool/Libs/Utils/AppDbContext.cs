using Libs.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libs
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<TTodo> Todos
        {
            get;
            set;
        }

        protected AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
