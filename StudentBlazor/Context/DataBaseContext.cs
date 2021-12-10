
using Microsoft.EntityFrameworkCore;
using StudentBlazor.Models;

namespace StudentBlazor.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base(options)
        {

        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Students> Student { get; set; }

    }
}
