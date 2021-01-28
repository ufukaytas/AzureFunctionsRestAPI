using CustomerRequestTracking.Functions.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerRequestTracking.Functions.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            
        }

        public DbSet<RequestForm> RequestForms { get; set; }
    }
}
