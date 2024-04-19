using AgendaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
    }
}