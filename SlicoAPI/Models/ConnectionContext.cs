using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlicoAPI.Models
{
    public class ConnectionContext:DbContext
    {

        public ConnectionContext(DbContextOptions<ConnectionContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customers> customers { get; set; }

    }
}
