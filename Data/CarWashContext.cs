using Microsoft.EntityFrameworkCore;
using CarWashApp.Models;

namespace CarWashApp.Data
{
    public class CarWashContext : DbContext
    {
        public CarWashContext(DbContextOptions<CarWashContext> options)
            : base(options)
        {
        }

        public DbSet<CarWashService> CarWashServices { get; set; }
    }
}
